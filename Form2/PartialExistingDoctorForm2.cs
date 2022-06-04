using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Laboratory_Management_System
{
    partial class Form2
    {
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            button3.Enabled = false;
            groupBox2.Show();
            button2.Enabled = true;
            load_combobox();
            textBox9.Text = "1";
        }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        // order
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        // price
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        // number of orders
        private void textBox9_TextChanged(object sender, EventArgs e) { }
        // patient name
        private void textBox11_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void load_combobox()
        {
            comboBox1.Items.Clear();
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select Name from table_doctors");
                for (int i = 0; sdr.Read(); ++i)
                {
                    comboBox1.Items.Add(sdr["Name"].ToString());
                }
                dp.close();
            }
        }
    }
}
