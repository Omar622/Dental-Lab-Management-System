using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System
{
    partial class Form2
    {
        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Enabled)
            {
                // add existing doctor
                if (textBox8.Text == "")
                {
                    MessageBox.Show("The order shouldn't be empty");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("The price shouldn't be empty");
                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Choose doctor name!");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Number of orders shouldn't be empty");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Date: " + dateTimePicker2.Value +
                    "\nOrder: " + textBox8.Text +
                    "\nNumber of order: " + textBox9.Text +
                    "\nDoctor Name: " + comboBox1.Items[comboBox1.SelectedIndex] +
                    "\nPatient Name: " + textBox11.Text +
                    "\nPrice: " + textBox7.Text
                    , "Confirm", MessageBoxButtons.OKCancel);
                    switch (dr)
                    {
                        case DialogResult.OK:
                            {
                                // Add data
                                int _doctor_id = get_id_doctor(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                                if (_doctor_id != -1)
                                {
                                    add_new_transaction(_doctor_id, textBox11.Text, dateTimePicker2.Value, textBox8.Text, int.Parse(textBox9.Text), textBox7.Text);
                                }
                                Close();
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                break;
                            }
                    }
                }
            }
            else
            {
                // add new doctor
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Doctor Name shouldn't be empty");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("The order shouldn't be empty");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("The price shouldn't be empty");
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Number of orders shouldn't be empty");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Date: " + dateTimePicker1.Value +
                        "\nOrder: " + textBox1.Text +
                        "\nNumber of order: " + textBox10.Text +
                        "\nAddress: " + textBox6.Text +
                        "\nDoctor Name: " + textBox2.Text +
                        "\nPatient Name: " + textBox12.Text +
                        "\nClinc Name: " + textBox5.Text +
                        "\nPhone: " + textBox3.Text +
                        "\nPrice: " + textBox4.Text
                        , "Confirm", MessageBoxButtons.OKCancel);
                    switch (dr)
                    {
                        case DialogResult.OK:
                            {
                                // Add data
                                add_new_doctor(textBox2.Text, textBox5.Text, textBox6.Text, textBox3.Text);
                                int _doctor_id = get_id_doctor(textBox2.Text);
                                if (_doctor_id != -1)
                                {
                                    add_new_transaction(_doctor_id, textBox12.Text, dateTimePicker1.Value, textBox1.Text, int.Parse(textBox10.Text), textBox4.Text);
                                }
                                Close();
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
