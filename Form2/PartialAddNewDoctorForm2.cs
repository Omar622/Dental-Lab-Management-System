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
        private int get_id_doctor(string _name)
        {
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                SqlDataReader sdr = dp.query("select Doctor_Id from table_doctors where Name = '" + _name + "'");
                if (sdr.Read()) return (int)sdr["Doctor_Id"];
                dp.close();
            }

            return -1;
        }

        private void add_new_doctor(string _name, string _clinc_name, string _address, string _phone)
        {
            Database dp = new Database("db_doctors");
            if (dp.setConnection())
            {
                dp.insert("insert into table_doctors (Name, ClincName, Address, Phone) values ('"
                    + _name + "', '" + _clinc_name + "', '" + _address + "', '" + _phone + "')");
                dp.close();
            }
        }
    }
}
