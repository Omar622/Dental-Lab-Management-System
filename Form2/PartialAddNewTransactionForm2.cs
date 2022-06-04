using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System
{
    partial class Form2
    {
        private void add_new_transaction(int _doctor_id, string _patient_name, DateTime _dt, string _order, int _number_of_orders, string _price)
        {
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                dp.insert("insert into table_transactions (Doctor_Id, PatientName, Date, [Order], NumberOfOrders, Price) values ('"
                    + _doctor_id + "', '" + _patient_name + "', '" + _dt + "', '" + _order + "', '" + _number_of_orders + "', '" + _price + "')");
                dp.close();
            }
        }
    }
}
