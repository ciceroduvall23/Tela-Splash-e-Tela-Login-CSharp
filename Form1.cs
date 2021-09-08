using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                if (progressBar1.Value < 100)
                {
                progressBar1.Value = progressBar1.Value + 2; //para alterar o valor tem que ser divisivel por 100 Exemplo 10,20,30...

            }
            else
            {
                timer1.Enabled = false;
                frmlogin log = new frmlogin();
                log.Show();
                this.Visible = false; //fechar a tela de splash

            }


        }
    }
}
