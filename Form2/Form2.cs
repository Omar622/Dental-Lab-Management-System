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

namespace Laboratory_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox2.Hide();
            button2.Enabled = false;
            groupBox1.Show();
            button3.Enabled = true;
            textBox10.Text = "1";
        }

        #region Add

        
        

        
        #endregion

        #region New Doctor Components
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            button2.Enabled = false;
            groupBox1.Show();
            button3.Enabled = true;
            textBox10.Text = "1";
        }
        private void groupBox1_Enter(object sender, EventArgs e){}
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e){}
        // Address
        private void textBox6_TextChanged(object sender, EventArgs e){ }
        // order
        private void textBox1_TextChanged_1(object sender, EventArgs e){}
        // Doctor Name
        private void textBox2_TextChanged_1(object sender, EventArgs e){}
        // Clinc Name
        private void textBox5_TextChanged(object sender, EventArgs e){}
        // phone
        private void textBox3_TextChanged_1(object sender, EventArgs e){}
        // price
        private void textBox4_TextChanged_1(object sender, EventArgs e){}
        // number of orders
        private void textBox10_TextChanged(object sender, EventArgs e){}
        // patient name
        private void textBox12_TextChanged(object sender, EventArgs e){}
        #endregion
        
    }
}
