using Kuis13Yanti.Controller;
using Kuis13Yanti.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuis13Yanti
{
    public partial class Form1 : Form
    {
        Connection konek = new Connection();
        private ControllerEmployee pegawaiControl;
        public Form1()
        {
            pegawaiControl = new ControllerEmployee();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            guna2DataGridView1.DataSource = pegawaiControl.selectEmployee(new MySqlCommand("select * from Pegawai"));
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void guna2ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                pegawaiControl.deleteEmployee(txtId.Text);
                showTable();
                guna2ButtonClear.PerformClick();
                MessageBox.Show("Employee Deleted Succesfully", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ButtonSearch_Click(object sender, EventArgs e)
        {
            if(radioButtonIslam.Checked)
            {
                guna2DataGridView1.DataSource = pegawaiControl.searchEmployee(radioButtonIslam.Text);
            }
            else if(radioButtonKristen.Checked)
            {
                guna2DataGridView1.DataSource = pegawaiControl.searchEmployee(radioButtonKristen.Text);
            }
            else if (radioButtonAll.Checked)
            {
                showTable();
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = pegawaiControl.searchEmployee(search.Text);
        }

        
    }
}
