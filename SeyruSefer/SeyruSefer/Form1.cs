using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
