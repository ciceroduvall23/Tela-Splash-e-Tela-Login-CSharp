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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ubisoft;Data Source=DESKTOP-OOKTGKQ\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("select * from usuario where logins=@logins and senha=@senha", sql); //ele vai pegar os campos e disponibilizar para digitar o varchar e verificar se o login e a senha estarão corretas

            command.Parameters.Add("@logins", SqlDbType.VarChar).Value = txtfrmlogin.Text; //quando o usuario digitar pegar no textBox,converter em varchar,para variaveis logins e senha
            command.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtfrmsenha.Text;

            try
            {
                sql.Open(); //vai abrir o banco de dados
                SqlDataReader drms = command.ExecuteReader();
                if (drms.HasRows == false)
                { 
                    throw new Exception("Usuario ou Senha Incorreta");
                 }
             drms.Read();
            MessageBox.Show("Login com suceeso");
            frmprincipalcs frmPri = new frmprincipalcs(); //vai fazer o login e entrar na tela principal,tem que ter um Form criado 
            frmPri.Show();
            this.Visible = false; //fechar a tela de splash
        }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            finally
            {

                sql.Close();
            }



          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
