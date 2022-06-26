using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class Dane : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string  //bufory
            bufor = "0",
            bOperator = "",
            bOperator2 = "",
            pierwsza = "",
            druga = "",
            bDzialania = "",
            bWynik = "",
            wynik = "";

        public bool  //flagi
            fOperator = false,
            fBufor = false,
            fWynik = false,
            fCyfr = false,
            fPrzec = false,
            fZnak = false,
            fDzialania = false;

        public void Skasuj()
        {
            fOperator = false;
            fBufor = false;
            fWynik = false;
            fCyfr = false;
            fPrzec = false;
            fZnak = false;
            fDzialania = false;
            Bufor = "0";
            BOperator = "";
            bOperator2 = "";
            BPierwsza = "";
            BDruga = "";
            bDzialania = "";
            BuforWyniku = "";
            Out = "";

        }

        

        public string Bufor
        {
            get { return bufor; }
            set
            {
                bufor = value;
                OnPropetyChanged();
            }
        }

        public string BOperator
        {
            get { return bOperator; }
            set
            {
                bOperator = value;
                OnPropetyChanged();
            }
        }
        public string BuforPoprzedniegoOperatora
        {
            get { return bOperator2; }
            set
            {
                bOperator2 = value;
                OnPropetyChanged();
            }
        }

        public string BPierwsza
        {
            get { return pierwsza; }
            set
            {
                pierwsza = value;
                OnPropetyChanged();
                OnPropetyChanged("Test");
            }
        }

        public string BDruga
        {
            get { return druga; }
            set
            {
                druga = value;
                OnPropetyChanged();
                OnPropetyChanged("Test");
            }
        }

        public string BuforDziałania
        {
            get { return bDzialania; }
            set
            {
                bDzialania = value;
                OnPropetyChanged();
                OnPropetyChanged("Test");
            }
        }

        public string BuforWyniku
        {
            get { return bWynik; }
            set
            {
                bWynik = value;
                OnPropetyChanged();
                OnPropetyChanged("Test");
            }
        }

        public string Out
        {
            get { return wynik; }
            set
            {
                wynik = value;
                OnPropetyChanged();
                OnPropetyChanged("Test");
            }
        }

        public void PobierzLiczba(string cyfra)
        {
            if (fWynik == false)
            {
                if (fCyfr == false)
                {
                    if (Bufor == "0")
                        Bufor = "";
                    Bufor += cyfra;

                }
                else
                {
                    Bufor = "";
                    Bufor += cyfra;
                    fCyfr = false;
                }
            }
            else
            {
                Skasuj();
                if (Bufor == "0")
                    Bufor = "";
                Bufor += cyfra;
            }


        }

        public void PobierzOperator(string pobierzOerator)
        {
            BOperator = pobierzOerator;
            fCyfr = true;
            fPrzec = false;
            if (fOperator == false)
            {
                BPierwsza = Bufor;
                fOperator = true;
            }
            else
            {
                if (fWynik == false)
                {
                    double bufor;
                    if (BuforPoprzedniegoOperatora == "+")
                    {
                        BDruga = Bufor;
                        bufor = Convert.ToDouble(BPierwsza) + Convert.ToDouble(BDruga);
                        Bufor = Convert.ToString(bufor);
                        BPierwsza = Bufor;
                        BDruga = "";
                    }
                    if (BuforPoprzedniegoOperatora == "-")
                    {
                        BDruga = Bufor;
                        bufor = Convert.ToDouble(BPierwsza) - Convert.ToDouble(BDruga);
                        Bufor = Convert.ToString(bufor);
                        BPierwsza = Bufor;
                        BDruga = "";
                    }
                    if (BuforPoprzedniegoOperatora == "×")
                    {
                        BDruga = Bufor;
                        bufor = Convert.ToDouble(BPierwsza) * Convert.ToDouble(BDruga);
                        Bufor = Convert.ToString(bufor);
                        BPierwsza = Bufor;
                        BDruga = "";
                    }
                    if (BuforPoprzedniegoOperatora == "÷")
                    {
                        BDruga = Bufor;
                        bufor = Convert.ToDouble(BPierwsza) / Convert.ToDouble(BDruga);
                        Bufor = Convert.ToString(bufor);
                        BPierwsza = Bufor;
                        BDruga = "";
                    }
                }
                else
                {
                    fWynik = false;
                    BPierwsza = Bufor;
                    BDruga = "";
                    Out = "";
                }

            }
            BuforPoprzedniegoOperatora = BOperator;
        }

        public void PobierzPrzecinek(string przecinek)
        {
            if (fWynik == false)
            {
                if (fPrzec == false)
                {
                    Bufor += przecinek;
                    fPrzec = true;
                }

            }
            else
            {
                Skasuj();
                Bufor += przecinek;
                fPrzec = true;
            }
        }

        public void DwaArgumenty()
        {
            double bufor;
            if (BOperator == "-")
            {
                BDruga = Bufor;
                bufor = Convert.ToDouble(BPierwsza) - Convert.ToDouble(BDruga);
                Bufor = Convert.ToString(bufor);
                fWynik = true;
                Out = "=";
            }
            if (BOperator == "+")
            {
                BDruga = Bufor;
                bufor = Convert.ToDouble(BPierwsza) + Convert.ToDouble(BDruga);
                Bufor = Convert.ToString(bufor);
                fWynik = true;

                Out = "=";
            }
            if (BOperator == "÷")
            {
                BDruga = Bufor;
                bufor = Convert.ToDouble(BPierwsza) / Convert.ToDouble(BDruga);
                Bufor = Convert.ToString(bufor);
                fWynik = true;
                Out = "=";
            }
            if (BOperator == "×")
            {
                BDruga = Bufor;
                bufor = Convert.ToDouble(BPierwsza) * Convert.ToDouble(BDruga);
                Bufor = Convert.ToString(bufor);
                fWynik = true;
                Out = "=";
            }
            
        }

        public void PrzelaczZnak()
        {
            if (Bufor != "0")
                if (fZnak == false)
                {
                    Bufor = "-" + Bufor;
                    fZnak = true;
                }
                else
                {
                    Bufor = Bufor.Substring(1);
                    fZnak = false;
                }
        }

        public string Test
        {
            get
            {
                return $"{BPierwsza} {BOperator} {BDruga} {wynik}";
            }
        }

        public void Procenty()
        {
            if (BPierwsza == "" || BPierwsza == "0")
            {
                BPierwsza = "0";
            }
            else
            {
                BDruga = Bufor;
                double bufor;
                double liczbaDruga;
                liczbaDruga = (Convert.ToDouble(BDruga) * Convert.ToDouble(BPierwsza)) / 100;
                if (bOperator2 == "+")
                {
                    bufor = Convert.ToDouble(BPierwsza) + liczbaDruga;
                    BDruga = Convert.ToString(liczbaDruga);
                    Bufor = Convert.ToString(bufor);
                    fWynik = true;
                }

            }
        }

        

        public void PobierzJednoargumentowe(string pobierzDziałanie)
        {
            BDruga = "";
            BuforPoprzedniegoOperatora = "";
            Out = "";
            BOperator = "";
            BuforDziałania = pobierzDziałanie;
            fDzialania = true;
            BPierwsza = bufor;
            JedenArgument();
        }

        public void JedenArgument()
        {
            double bufor;
            if (BuforDziałania == "√x")
            {
                bufor = Math.Sqrt(Convert.ToDouble(BPierwsza));
                Bufor = Convert.ToString(bufor);
                BPierwsza = "√(" + BPierwsza + ")";
            }
            
            if (BuforDziałania == "x²")
            {
                bufor = Convert.ToDouble(BPierwsza) * Convert.ToDouble(BPierwsza);
                Bufor = Convert.ToString(bufor);
                BPierwsza = "sqrt(" + BPierwsza + ")";
            }

            if (BuforDziałania == "1/x")
            {
                bufor = 1 / Convert.ToDouble(BPierwsza);
                Bufor = Convert.ToString(bufor);
                BPierwsza = "1/(" + BPierwsza + ")";

            }
        }

        public void PrzelaczOperator(string operatorPrzełącz)
        {
            if (fCyfr == true)
            {
                BOperator = operatorPrzełącz;
                fOperator = false;
            }

        }

        public void WsteczZnak()
        {
            Bufor = Bufor.Substring(0, Bufor.Length - 1);
            if (Bufor == "")
            {
                Bufor = "0";
            }
        }

    }
}