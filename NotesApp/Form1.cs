using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class NoteTaking : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaking()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = noteBox.Text;

            } else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;

        }

        private void bttLoad_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {

            try
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex].Delete();

            }
            catch(Exception ex) { Console.WriteLine("Not valid note"); }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            dataGridView1.DataSource = notes;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
