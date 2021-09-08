using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste
{
    public partial class frmprincipalcs : Form
    {
        public frmprincipalcs()
        {
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusuario usu = new frmusuario(); //assim que clicar no botao usuario,vai abir a tela frmusuario 
            usu.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
