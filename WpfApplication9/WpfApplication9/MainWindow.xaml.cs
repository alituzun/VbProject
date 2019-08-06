using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string kardNo;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnDogrula_Click(object sender, RoutedEventArgs e)
        {
            if (kartNo.Text.ToString() == "")
            {
                MessageBox.Show("Kart No giriniz.");
            }
            else
            {
                kardNo = kartNo.Text.ToString();
                if (kontrolluhn(kardNo))
                {
                    if (FindType(kardNo) = "KartTipiBulunamadi")
                    MessageBox.Show("Kart geçerli. " + '\n' + FindType(kardNo));
                    

                }
                else
                {
                    MessageBox.Show("Kart Gecersiz.");
                }
            }
            kartNo.Clear();
        }
        private void btnOlustur_Click(object sender, RoutedEventArgs e)
        {
            int[] cardno=new int[15];
            RandomKart(cardno);
        }
        private void btnHesapla_Click(object sender, RoutedEventArgs e)
        {
            if (julianDate.Text.ToString().Length==4){
            string jDate;
            jDate = julianDate.Text.ToString();
            jDateHesapla(jDate);
            }
            else
            {
                MessageBox.Show("Julian Tarihi gecerli degil");
            }
            julianDate.Text = "";
        }
        private bool kontrolluhn(String cardNo)
        {
            int nKarakter = cardNo.Length;

            int ntoplam = 0;
            bool isSecond = false;
            for (int i = nKarakter - 1; i >= 0; i--)
            {
                int sayi = cardNo[i] - '0';
                if (isSecond == true)
                {
                    sayi = sayi * 2;
                }
                ntoplam += sayi / 10;
                ntoplam += sayi % 10;
                isSecond = !isSecond;
            }
            return (ntoplam % 10 == 0);
        }
        public enum CardType
        {
            MasterCard, Visa, AmericanExpress, Discover, JCB , KartTipiBulunamadi
        };
        public static CardType FindType(string cardNumber)
        {
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return CardType.Visa;
            }

            else if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return CardType.MasterCard;
            }

            else if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$").Success)
            {
                return CardType.AmericanExpress;
            }

            else if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
            {
                return CardType.Discover;
            }

            else if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
            {
                return CardType.JCB;
            }

            else
            {
                return CardType.KartTipiBulunamadi;
            }

            //throw new Exception("Unknown card.");
        }
        bool IsNumeric(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        private void jDateHesapla(string jDate)
        {
            string year;
            bool kontrol = IsNumeric(jDate);
            if (kontrol)
            {
                int tyear = 0;
                year = jDate.Substring(0, 1);
                tyear = Convert.ToInt32(year) + 2010;
                string kalan = jDate.Substring(1, 3);
                int tarih = Int32.Parse(kalan);
                if ((tarih == 000))
                {
                    MessageBox.Show("Julian Tarihi gecerli degil.");
                }
                else
                {
                    if (tarih < 32)
                    {
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(tarih + "/" + "01" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("01" + "/" + tarih + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "01" + "/" + tarih);
                        }
                    }
                    else if (tarih < 60)
                    {
                        int ara = tarih - 31;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "02" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("02" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "02" + "/" + ara);
                        }
                    }
                    else if (tarih < 91)
                    {
                        int ara = tarih - 59;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "03" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("03" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "03" + "/" + ara);
                        }
                    }
                    else if (tarih < 121)
                    {
                        int ara = tarih - 90;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "04" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("04" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "04" + "/" + ara);
                        }
                    }
                    else if (tarih < 152)
                    {
                        int ara = tarih - 120;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "05" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("05" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "05" + "/" + ara);
                        }
                    }
                    else if (tarih < 182)
                    {
                        int ara = tarih - 151;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "06" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("06" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "06" + "/" + ara);
                        }
                    }
                    else if (tarih < 213)
                    {
                        int ara = tarih - 181;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "07" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("07" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "07" + "/" + ara);
                        }
                    }
                    else if (tarih < 244)
                    {
                        int ara = tarih - 212;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "08" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("08" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "08" + "/" + ara);
                        }
                    }
                    else if (tarih < 274)
                    {
                        int ara = tarih - 243;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "09" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("09" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "09" + "/" + ara);
                        }
                    }
                    else if (tarih < 305)
                    {
                        int ara = tarih - 273;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "10" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("10" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "10" + "/" + ara);
                        }
                    }
                    else if (tarih < 335)
                    {
                        int ara = tarih - 304;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "11" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("11" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "11" + "/" + ara);
                        }
                    }
                    else if (tarih < 366)
                    {
                        int ara = tarih - 334;
                        if (chkNormal.IsChecked == true)
                        {
                            MessageBox.Show(ara + "/" + "12" + "/" + tyear);
                        }
                        if (chkAy.IsChecked == true)
                        {
                            MessageBox.Show("12" + "/" + ara + "/" + tyear);
                        }
                        if (chkYil.IsChecked == true)
                        {
                            MessageBox.Show(tyear + "/" + "12" + "/" + ara);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Julian Tarihi gecerli degil.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Julian Tarihi gecerli degil.");
            }
        }
        private void RandomKart(int[] cardno)
        {
            int cifttoplam=0,aratoplam=0,tektoplam=0,sontoplam=0;
            int ara = 0;
            string cardNum = string.Empty;
            Random rnd = new Random();
            cardno[0] = rnd.Next(1, 10);
            for (int i = 1; i < 15; i++)
            {
                cardno[i] = rnd.Next(0, 10);
            }
            for (int k = 0; k < 15;)
            {
                ara = cardno[k] * 2;
                if (ara > 9)
                {
                    aratoplam = ara % 10;
                    cifttoplam += aratoplam + 1;
                }
                else
                {
                    cifttoplam += ara;
                }
                k = k + 2;
            }
            for (int l = 1; l < 15; )
            {
                tektoplam += cardno[l];
                l = l + 2;
            }

            sontoplam = tektoplam + cifttoplam;
            int sonsayi,sonsayimodu;
            sonsayimodu = sontoplam % 10;
            sonsayi = 10 - sonsayimodu;
            for (int j = 0; j < 15; j++)
            {
                cardNum += cardno[j].ToString();
            }
            cardNum += sonsayi.ToString();
                MessageBox.Show(cardNum);

        }
    }
}
