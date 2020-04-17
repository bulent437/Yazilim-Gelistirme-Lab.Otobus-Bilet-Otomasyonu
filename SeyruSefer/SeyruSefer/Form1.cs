using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraReports.UI;

namespace SeyruSefer
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();

        }
        // string yol = @"C:\Users\C\source\repos\bulent437\YazGel\SeyruSefer\SeyruSefer\seferler\";
        string yol = @"D:\c#\2020 YazGel1\YazGel\SeyruSefer\SeyruSefer\seferler\";
        #region Sayfa Kontrolü

        private void seferEklemeButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = seferEklemePage;
        }

        private void seferSilmeButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = seferSilmePage;
        }

        private void kaptanDegistirmeButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = kaptanDegistirmePage;
        }

        private void seferGelirButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = seferGelirPage;
        }

        private void seferListelemeButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = seferListelemePage;
        }

        private void biletSatisButton_Click(object sender, EventArgs e)
        {
            pageControl.SelectedPage = biletSatisPage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pageControl.SelectedPage = biletSatisPage;

        }
        #endregion
        #region Sefer Kaydetme
        private void seferKaydetButton_Click(object sender, EventArgs e)
        {
            //https://www.kodlamamerkezi.com/c-net/c-ile-dosya-okuma-ve-yazma-islemleri/
            //https://www.yazilimkodlama.com/programlama/c-folderbrowserdialog-ile-klasor-icindeki-dosyalari-listeleme/ burdan bakarak sefer sayısını değiştiricez
            //https://www.muslu.net/2015/03/c-dosya-kontrol-var-mi-yok-mu.html
            //https://trmsma.wordpress.com/2017/08/04/c-ta-indexof-metodu/

            int seferNo = 0;
            string tarih = seferTarih.Text + ".txt";
            string dosya = @"C:\Users\C\source\repos\bulent437\YazGel\SeyruSefer\SeyruSefer\seferler\" + tarih;
            FileStream fs;
            if (File.Exists(dosya) == true) // dizindeki dosya var mı ?
            {
                fs = new FileStream(dosya, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();
                while (yazi != null)
                {
                    if (yazi.IndexOf("Sefer No:") == 0)
                    {
                        seferNo = Convert.ToInt32(yazi.Substring((yazi.IndexOf(":") + 1), (yazi.Length - 9)));
                        seferNo++;
                    }
                    yazi = sw.ReadLine();
                }
                sw.Close();
                fs.Close();
            }
            else
            {
                seferNo = 0;
            }

            string writeText = "Sefer No:" + seferNo + "\nSefer Başlangıç:" + seferBas.Text + "\nSefer Varış:" + seferHedef.Text + "\nSefer Tarih:" + seferTarih.Text + "\nSaat: " + seferSaat.Text + "\nKapasite: " + seferKapasite.Text +
                "\nPlaka: " + seferPlaka.Text + "\nKaptan: " + seferKaptan.Text + "\nBilet Fiyatı :" + seferBiletFiyat.Text;

            int koltuksayisi = Convert.ToInt32(seferKapasite.SelectedItem);

            if (koltuksayisi <= 0 || koltuksayisi == null)
            {
                MessageBox.Show("Araç kapasitesi 0 dan büyük olmalıdır");
            }
            else
            {
                FileStream fs1 = new FileStream(dosya, FileMode.OpenOrCreate, FileAccess.Write);

                fs1.Close();
                File.AppendAllText(dosya, Environment.NewLine + writeText);
                {
                    for (int i = 1; i <= koltuksayisi; i++)
                    {

                        File.AppendAllText(dosya, Environment.NewLine + "Koltuk" + i + ":B");


                    }
                    File.AppendAllText(dosya, Environment.NewLine + "-");
                }

            }
        }
        #endregion
        #region Sefer Listeleme
        ArrayList SeferKoltuk =new ArrayList();
        private void seferGetirButton_Click(object sender, EventArgs e)
        {
            SeferKoltuk.Clear();
            sefericerikListele.Properties.Items.Clear();
            ArrayList Seferler = new ArrayList();
            string dosyaAdi = SeferTarihiListele.Text + ".txt";
            string dosya = yol + dosyaAdi;
            FileStream fs;
            if (File.Exists(dosya) == true)
            {
                fs = new FileStream(dosya, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();
                while (yazi != null)
                {
                    if (yazi.IndexOf("Sefer No:") == 0)
                    {
                        Seferler.Add(yazi.Substring((yazi.IndexOf(":") + 1), (yazi.Length - 9)));
                        SeferKoltuk.Add(yazi);
                        //seferno = Convert.ToInt32(yazi.Substring((yazi.IndexOf(":") + 1), (yazi.Length - 9)));
                    }
                    else if (yazi.IndexOf("Koltuk")==0)
                    {
                        SeferKoltuk.Add(yazi);
                    }
                    yazi = sw.ReadLine();

                }
                foreach (String eleman in Seferler)
                {
                    sefericerikListele.Properties.Items.Add("Sefer No:" + eleman);
                }
                sw.Close();
                fs.Close();
            }

            else { MessageBox.Show("Bu tarihte kayıt bulunmamaktadır."); }


        }
        
        private void seferListeleButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SeferKoltuk.Count; i++) 
            { 
                if(SeferKoltuk[i].ToString()==sefericerikListele.Text)//seçilen sefer ile textden aldığımız sefer eşleşince içinde tekrar döngü oluşturucaz
                {
                    i++;
                    for (int j = i; j < 51; j++) 
                    //sıradaki sefere gelene kadarki bütün koltukları listele(göstermek için kullancaz)
                    //daha sonra bilet satışı için kullancaz aynı kodu bu sefer butonlara event ekleyicez tıklanabilcek
                    //http://www.gorselprogramlama.com/kod-ile-buton-olusturma-c-net/
                    if (SeferKoltuk[j].ToString().IndexOf("Koltuk") == 0)
                    {
                        Label a = new Label();
                        a.Top = 10 * j;
                        a.Text = SeferKoltuk[j].ToString();                       
                        panel1.Controls.Add(a);
                    }
                    else
                        break;
                }
            }
        }
        #endregion
    }
}
