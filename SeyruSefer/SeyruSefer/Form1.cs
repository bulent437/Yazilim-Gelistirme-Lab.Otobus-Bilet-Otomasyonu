using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeyruSefer
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }
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

            string tarih = seferTarih.Text+ ".txt";
            string fileName = @"D:\c#\2020 YazGel1\YazGel\SeyruSefer\SeyruSefer\seferler\" + tarih;
            string writeText = "Sefer Başlangıç:" + seferBas.Text + "\nSefer Varış:" + seferHedef.Text + "\nSefer Tarih:" + seferTarih.Text + "\nSaat: " + seferSaat.Text + "\nKapasite: " + seferKapasite.Text +
                "\nPlaka: " + seferPlaka.Text + "\nKaptan: " + seferKaptan.Text + "\nBilet Fiyatı :" + seferBiletFiyat.Text;
     
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write); 
            int koltuksayisi = Convert.ToInt32(seferKapasite.Text);
            fs.Close();
            File.AppendAllText(fileName, Environment.NewLine + writeText);
            {
                for (int i = 1; i <= koltuksayisi; i++)
                {               
                    File.AppendAllText(fileName, Environment.NewLine + "Koltuk" + i);
                }
                File.AppendAllText(fileName, Environment.NewLine + "-");
            }
           

        }
        #endregion

    }
}
