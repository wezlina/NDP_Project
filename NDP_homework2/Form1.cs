﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDP_homework2 {
    public partial class Form1 : Form {

        List<Randevu> randevular = new List<Randevu>();
        List<Müşteri> müşteriler = new List<Müşteri>();
        List<Calisan> calisanlar = new List<Calisan>();
        List<String> calisan_isimleri = new List<String>();

        public Form1() {
            InitializeComponent();

            //dataGridView1.DataSource = randevular;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.DataSource = calisan_isimleri;
        }

        abstract class Work {
            public String tarih { get; set; }
            public int ucret { get; set; }
            public string hizmet { get; set; }
        }

        class Randevu : Work {
            public String müşteri { get; set; }
            public String müşteri_ulaşım { get; set; }
            public String calisan { get; set; }
        }

        private void button1_Click(object sender, EventArgs e) {

            Randevu randevu = new Randevu();
            Müşteri müşteri = new Müşteri();

            müşteri.Ad = textBox1.Text;
            müşteri.Soyad = textBox2.Text;
            müşteri.Phone = textBox3.Text;

            randevu.müşteri = müşteri.Ad + " " + müşteri.Soyad;
            randevu.müşteri_ulaşım = müşteri.Phone;

            if (checkBox1.Checked) {
                randevu.ucret += 100;
                randevu.hizmet += " " + checkBox1.Text;
            }
            if (checkBox2.Checked) {
                randevu.ucret += 30;
                randevu.hizmet += " " + checkBox2.Text;
            }
            if (checkBox3.Checked) {
                randevu.ucret += 20;
                randevu.hizmet += " " + checkBox3.Text;
            }
            if (checkBox4.Checked) {
                randevu.ucret += 15;
                randevu.hizmet += " " + checkBox4.Text;
            }

            randevu.tarih = dateTimePicker1.Text + " " + comboBox1.Text;
            randevular.Add(randevu);
            müşteriler.Add(müşteri);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = randevular;

            /*listBox1.Items.Add(randevu.müşteri.Ad + " "
                + randevu.müşteri.Soyad + " -- "
                + randevu.hizmetler + " -- "
                + randevu.müşteri.Phone + " -- "
                + randevu.tarih + " -- Toplam ücret: \n"
                + randevu.ucret);*/
        }

        private bool kontrol() {
            if (checkBox1.Checked) {
                return true;
            }
            else {
                return false;
            }
        }

        private void çalışanEkleToolStripMenuItem_Click(object sender, EventArgs e) {
            Calisan calisan = new Calisan();
            Calisan_ekle calisan_Ekle = new Calisan_ekle(calisan);
            calisan_Ekle.ShowDialog();
            calisanlar.Add(calisan);
            calisan_isimleri.Add(calisan.Ad + " " + calisan.Soyad);
            comboBox2.DataSource = null;
            comboBox2.DataSource = calisan_isimleri;
        }

        private void calisan_isimleri_guncelle() {
            calisan_isimleri = null;
            foreach (Calisan eleman in calisanlar) {
                calisan_isimleri.Add(eleman.Ad + " " + eleman.Soyad);
            }//dictionary kullan böyle olmaz
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            // İlk checkbox'un durumuna bağlı olarak diğer checkbox'ların etkinlik durumunu ayarla
            if (checkBox1.Checked) {
                // İlk checkbox işaretli ise diğer checkbox'ları etkinleştir
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else {
                // İlk checkbox işaretli değilse diğer checkbox'ları devre dışı bırak
                checkBox3.Enabled = false;
                checkBox3.Checked = false; // İlk checkbox işaretli değilse diğerleri de işaretsiz olmalı
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) {
            // İlk iki checkbox'un durumuna bağlı olarak son iki checkbox'un etkinlik durumunu ayarla
            if (kontrol()) {
                // İlk checkbox işaretli ise diğer checkbox'ları etkinleştir
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            // İlk iki checkbox'un durumuna bağlı olarak son iki checkbox'un etkinlik durumunu ayarla
            if (kontrol()) {
                // İlk checkbox işaretli ise diğer checkbox'ları etkinleştir
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }
        private void label7_Click(object sender, EventArgs e) {

        }
        private void label8_Click(object sender, EventArgs e) {

        }
        private void textBox3_TextChanged(object sender, EventArgs e) {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
        private void button2_Click(object sender, EventArgs e) {

        }
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        private void randevuDüzenleToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void çalışanÇıkarToolStripMenuItem_Click(object sender, EventArgs e) {
            Calisankontrol kontrol = new Calisankontrol(calisanlar, true);
            kontrol.ShowDialog();
            comboBox2.DataSource = null;
            comboBox2.DataSource = calisan_isimleri;
        }

        private void çalışanlarıGüncelleToolStripMenuItem_Click(object sender, EventArgs e) {
            Calisankontrol kontrol = new Calisankontrol(calisanlar, false);
            kontrol.ShowDialog();
            comboBox2.DataSource = null;
            comboBox2.DataSource = calisan_isimleri;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            // comboBox1'deki seçili öğeyi kontrol et
            if (comboBox2.SelectedItem != null) {
                // Eğer seçili bir öğe varsa, comboBox2'yi etkinleştir
                comboBox1.Enabled = true;
            }
            else {
                // Seçili bir öğe yoksa, comboBox2'yi devre dışı bırak
                comboBox1.Enabled = false;
            }
        }
    }
}