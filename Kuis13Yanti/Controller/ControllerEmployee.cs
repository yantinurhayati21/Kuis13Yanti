using Guna.UI2.WinForms;
using Kuis13Yanti.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuis13Yanti.Controller
{
    internal class ControllerEmployee : Model.Connection
    {
        Connection koneksi = new Connection();
        DataTable table = new DataTable();
        private object guna2DataGridView1;

        public DataTable selectEmployee(MySqlCommand command)
        {
            DataTable dateEmployee = new DataTable();
            try
            {
                string selectEmployee = "SELECT * FROM Pegawai";
                da = new MySqlConnector.MySqlDataAdapter(selectEmployee, GetConn());
                da.Fill(dateEmployee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dateEmployee;
        }

        public void deleteEmployee(string id)
        {
            string delete = "delete from Pegawai where Id=" + id;

            try
            {
                cmd = new MySqlConnector.MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@Id", MySqlConnector.MySqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal delete" + ex.Message);
            }

        }

        public DataTable searchEmployee(string search)
        {
            DataTable table = new DataTable();
            try
            {
                MySqlCommand command = new MySqlCommand
                    ("select * from Pegawai where concat(Id, Nama, Alamat, Agama, Umur)like '%" + search + "%'", koneksi.GetConn());
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return table;
        }

    }
}
