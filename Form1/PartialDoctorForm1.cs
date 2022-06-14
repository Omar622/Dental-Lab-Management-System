using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Laboratory_Management_System
{
    partial class Form1
    {
        // show doctors page
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            doctors_list_data_load();
            groupBox2.Show();
            groupBox4.Show();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        // Edit
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(_chosen_doctor_id); // There is must be a chosen doctor
            f.FormClosing += new FormClosingEventHandler(Form1_Load);
            f.Show();
        }

        private void doctors_list_data_load()
        {
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select Name, ClincName, Image from table_doctors");

                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; sdr.Read(); ++i)
                {
                    list_tile tmp = new list_tile();
                    tmp.Title = sdr["Name"].ToString();
                    tmp.SubTitle = sdr["ClincName"].ToString() == "" ? "Sub Title" : sdr["ClincName"].ToString();
                    try
                    {
                        var bytes = (byte[])sdr["Image"];
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            tmp.Icon = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        tmp.Icon = Properties.Resources.unknown_user;
                    }
                    tmp.Click += new System.EventHandler(doctors_related_date_load); // Add click event
                    flowLayoutPanel1.Controls.Add(tmp);
                }
                dp.close();
            }

        }
        private void doctors_related_date_load(object sender, EventArgs e)
        {
            list_tile tmp = (list_tile)sender;

            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select * from table_doctors where Name = '" + tmp.Title + "'");
                if (sdr.Read())
                {
                    label5.Text = (sdr["Name"].ToString() == "" ? "..." : sdr["Name"].ToString());
                    label6.Text = (sdr["Address"].ToString() == "" ? "..." : sdr["Address"].ToString());
                    label7.Text = (sdr["Phone"].ToString() == "" ? "..." : sdr["Phone"].ToString());
                    label8.Text = (sdr["ClincName"].ToString() == "" ? "..." : sdr["ClincName"].ToString());
                    try
                    {
                        byte[] bytes = (byte[])sdr["Image"];
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        pictureBox1.Image = Properties.Resources.unknown_user;
                    }
                    _chosen_doctor_id = int.Parse(sdr["Doctor_Id"].ToString());
                    doctors_transaction_load(_chosen_doctor_id);
                }
                dp.close();
            }
            groupBox4.Hide();
        }
        private void doctors_transaction_load(int _doctor_id) // load data grid view
        {
            dataGridView2.Rows.Clear();
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select * from table_transactions where Doctor_Id = '" + _doctor_id + "'");

                while (sdr.Read())
                {
                    dataGridView2.Rows.Add(
                        int.Parse(sdr["Doctor_Id"].ToString()),
                        (DateTime)sdr["Date"],
                        sdr["PatientName"].ToString(),
                        sdr["Order"].ToString(),
                        int.Parse(sdr["NumberOfOrders"].ToString()),
                        int.Parse(sdr["Price"].ToString()),
                        int.Parse(sdr["Price"].ToString()) * int.Parse(sdr["NumberOfOrders"].ToString())
                        );
                }
                dp.close();
            }
        }
    }
}
