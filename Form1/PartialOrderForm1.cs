using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Laboratory_Management_System
{
    partial class Form1
    {
        // show orders page
        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Show();
            data_gird_view_load_date();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        // Add order
        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.FormClosing += new FormClosingEventHandler(Form1_Load); // reload form1 when form2 is closed
            f.Show();
        }

        private void data_gird_view_load_date()
        {
            dataGridView1.Rows.Clear();
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select * from table_transactions");
                List<int> _doctor_id = new List<int>();
                List<string> _patient_name = new List<string>();
                List<int> _number_of_orders = new List<int>();
                List<DateTime> _date = new List<DateTime>();
                List<string> _order = new List<string>();
                List<int> _price = new List<int>();

                for (int i = 0; sdr.Read(); ++i)
                {
                    _doctor_id.Add((int)sdr["Doctor_Id"]);
                    _patient_name.Add(Convert.ToString(sdr["PatientName"]));
                    _date.Add((DateTime)sdr["Date"]);
                    _order.Add((string)sdr["Order"]);
                    _number_of_orders.Add((int)sdr["NumberOfOrders"]);
                    _price.Add((int)sdr["Price"]);
                }
                for (int i = 0; i < _date.Count; ++i)
                {
                    string _name, _phone, _address;
                    sdr.Close();
                    sdr = dp.query("select Name from table_doctors where Id = " + _doctor_id[i]);
                    if (sdr.Read())
                    {
                        _name = (string)sdr["Name"];
                    }
                    else continue;
                    sdr.Close();

                    sdr = dp.query("select Phone from table_doctors where Id = " + _doctor_id[i]);
                    if (sdr.Read())
                    {
                        _phone = (string)sdr["Phone"];
                    }
                    else continue;
                    sdr.Close();

                    sdr = dp.query("select Address from table_doctors where Id = " + _doctor_id[i]);
                    if (sdr.Read())
                    {
                        _address = (string)sdr["Address"];
                    }
                    else continue;

                    dataGridView1.Rows.Add(
                        i + 1,
                        _date[i],
                        _name,
                        _patient_name[i],
                        _order[i],
                        _number_of_orders[i],
                        _price[i],
                        _number_of_orders[i] * _price[i],
                        _phone,
                        _address
                        );
                }
                dp.close();
            }
        }
    }
}
