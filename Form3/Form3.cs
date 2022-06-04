using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

namespace Laboratory_Management_System
{
    public partial class Form3 : Form
    {
        private int _chosen_doctor_id;
        Image img;
        bool img_set;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(int _chosen_doctor_id)
        {
            InitializeComponent();
            this._chosen_doctor_id = _chosen_doctor_id;
            img_set = false;

            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select * from table_doctors where Id = '" + _chosen_doctor_id + "'");
                if (sdr.Read())
                {
                    textBox1.Text = (sdr["Name"].ToString() == "" ? "..." : sdr["Name"].ToString());
                    textBox3.Text = (sdr["Address"].ToString() == "" ? "..." : sdr["Address"].ToString());
                    textBox2.Text = (sdr["Phone"].ToString() == "" ? "..." : sdr["Phone"].ToString());
                    textBox4.Text = (sdr["ClincName"].ToString() == "" ? "..." : sdr["ClincName"].ToString());
                }
                dp.close();
            }
        }

        private void Form3_Load(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}

        // name
        private void textBox1_TextChanged(object sender, EventArgs e){}
        // clinc name
        private void textBox4_TextChanged(object sender, EventArgs e){}
        // address
        private void textBox3_TextChanged(object sender, EventArgs e){}
        // phone
        private void textBox2_TextChanged(object sender, EventArgs e){}
        // cancel
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        // save
        private void button2_Click(object sender, EventArgs e)
        {
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                if (img_set)
                {
                    byte [] tmparr;
                    ImageConverter converter = new ImageConverter();
                    tmparr = (byte[]) converter.ConvertTo(img, typeof(byte[]));
                    dp.add_image("update table_doctors set Name = '" + textBox1.Text + "', ClincName = '" + textBox4.Text + "', Address = '" + textBox3.Text + "', phone = '" + textBox2.Text + "', Image = @img " +
                    "where Id = '" + _chosen_doctor_id + "'", tmparr);
                }
                else
                {
                    dp.insert("update table_doctors set Name = '" + textBox1.Text + "', ClincName = '" + textBox4.Text + "', Address = '" + textBox3.Text + "', phone = '" + textBox2.Text + "'" +
                    "where Id = '" + _chosen_doctor_id + "'");
                }
                dp.close();
            }
            Close();
        }
        
        // upload image
        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(opnfd.FileName);
                img_set = true;
            }
        }
    }
}
