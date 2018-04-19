using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication6
{ 
  
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("Server=DESKTOP-C7AP5JN; DataBase=car; Integrated Security =true ; ");
        SqlDataAdapter da;
        DataTable datatable = new DataTable();
        CurrencyManager cm;
        SqlCommandBuilder commandbuilder;
       
        public Form1()
        {
            InitializeComponent();
            da = new SqlDataAdapter("Select * From Car1",cn);
            da.Fill(datatable);
            txtid.DataBindings.Add("Text",datatable,"CID");
            txtNumber.DataBindings.Add("Text", datatable, "cNumber");
            txttype.DataBindings.Add("Text",datatable,"CType");
            cm = (CurrencyManager)this.BindingContext[datatable];
            
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void last_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;
        }

        private void front_Click(object sender, EventArgs e)
        {
            cm.Position -=1 ;
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;
        }

        private void next_Click(object sender, EventArgs e)
        {
            cm.Position += 1;
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;
        }

        private void first_Click(object sender, EventArgs e)
        {
            cm.Position = datatable.Rows.Count - 1;
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
              
             cm.AddNew();
              txtid.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm.EndCurrentEdit();
            commandbuilder = new SqlCommandBuilder(da);
            da.Update(datatable);
            MessageBox.Show("ADDED ","Addtion");
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cm.RemoveAt(cm.Position);
            cm.EndCurrentEdit();
            commandbuilder = new SqlCommandBuilder(da);
            da.Update(datatable);
            MessageBox.Show("delted ", "delte");
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.EndCurrentEdit();
            commandbuilder = new SqlCommandBuilder(da);
            da.Update(datatable);
            cm.Refresh();
            MessageBox.Show("update ", "update");
            label4.Text = (cm.Position + 1) + " / " + datatable.Rows.Count;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
