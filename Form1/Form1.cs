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
using System.IO;

namespace Laboratory_Management_System{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // show orders page
            groupBox2.Hide();
            groupBox1.Show();
            data_gird_view_load_date();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        #region Doctors
        private int _chosen_doctor_id = -1;
        // secondary page
        private void groupBox2_Enter(object sender, EventArgs e){}
        // name
        private void label1_Click(object sender, EventArgs e){}
        // clinc name
        private void label2_Click(object sender, EventArgs e){}
        // phone
        private void label4_Click(object sender, EventArgs e){}
        // address
        private void label3_Click(object sender, EventArgs e){}
        // given name
        private void label5_Click(object sender, EventArgs e){}
        // given clinc name
        private void label8_Click(object sender, EventArgs e){}
        // given phone
        private void label7_Click(object sender, EventArgs e){}
        // given address
        private void label6_Click(object sender, EventArgs e){}
        private void pictureBox1_Click(object sender, EventArgs e){}
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        // loaded doctor details
        private void groupBox3_Enter(object sender, EventArgs e) { }
        // waiting
        private void groupBox4_Enter(object sender, EventArgs e){}
        // choose doctor
        private void label9_Click(object sender, EventArgs e) { }
        // From
        private void label10_Click(object sender, EventArgs e) { }
        // From
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        // TO
        private void label11_Click(object sender, EventArgs e) { }
        // TO
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        #endregion

        #region Orders
        // main page
        private void groupBox1_Enter(object sender, EventArgs e){ }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        #endregion
    }
}

