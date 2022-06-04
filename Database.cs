using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Laboratory_Management_System
{
    public class Database
    {
        // make sure second occurence of '=' is after initial catalog
        private string connectionString = "Data Source=MORGAN-PC;Initial Catalog = ;Integrated Security=True";
        private SqlConnection con;

        // paramitrized constructor
        public Database(string tableName) // db_doctors
        {
            int cnt = 0;
            for (int i = 0; i < connectionString.Length; ++i)
            {
                if (connectionString[i] == '=') ++cnt;
                if (cnt == 2)
                {
                    connectionString = connectionString.Insert(i + 1, tableName);
                    break;
                }
            }
        }

        public bool setConnection(){
            con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect to data base");
                return false;
            }
        }

        public SqlDataReader query(string cmd)
        {
            SqlDataReader sdr = null;
            SqlCommand sc = new SqlCommand(cmd, con);
            try
            {
                sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't make query on data base");
                //MessageBox.Show(e.ToString());
            }
            return sdr;
        }

        public void insert(string cmd)
        {
            SqlCommand sc = new SqlCommand(cmd, con);
            try
            {
                sc.ExecuteNonQuery();
                MessageBox.Show("Data added successfully");
            }catch(Exception e){
                MessageBox.Show("Couldn't insert into data base");
                MessageBox.Show(e.ToString());

            }
        }

        public void add_image(string cmd, byte[] bytes)
        {
            SqlCommand sc = new SqlCommand(cmd, con);
            try
            {
                sc.Parameters.Add(new SqlParameter("@img", bytes));
                sc.ExecuteNonQuery();
                MessageBox.Show("Data added successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't insert into data base");
                MessageBox.Show(e.ToString());

            }
        }

        public void close()
        {
            con.Close();
        }
    }
}
