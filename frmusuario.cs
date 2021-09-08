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
    public partial class frmusuario : Form
    {
        public frmusuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ubisoft;Data Source=DESKTOP-OOKTGKQ\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("insert into usuario(iduser, Usuario, logins ,senha,Fone,Perfil)values (@iduser,@Usuario,@logins ,@senha,@Fone,@Perfil)",sql);
            command.Parameters.Add("@iduser", SqlDbType.Int).Value = txtiduser.Text;
            command.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@logins", SqlDbType.VarChar).Value = txtLogin.Text;
            command.Parameters.Add("@Senha", SqlDbType.VarChar).Value = txtSenha.Text;
            command.Parameters.Add("@Fone", SqlDbType.VarChar).Value = txtTelefone.Text;
            command.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = comboPerfil.Text;

            if (txtiduser.Text != "" & txtNome.Text != "" & txtLogin.Text != "" & txtSenha.Text != "" & txtTelefone.Text != "" & comboPerfil.Text != "") 
             {
               try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com sucesso", "frmusuario",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                    txtiduser.Text = ""; //vai zerar os campos assim que cadastrar
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtTelefone.Text = "";
                    comboPerfil.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("por favor digita todas as informações nos campos Obrigatórios");
                }
                finally
                {
                    sql.Close(); //vai fechar o banco de dados
                }
            }

            else
            {
                MessageBox.Show("por favor digita todas as informações nos campos Obrigatórios");

            }
        }

        private void frmusuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ubisoft;Data Source=DESKTOP-OOKTGKQ\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("select * from usuario where iduser=@iduser", sql); //ele vai pegar os campos e disponibilizar para digitar o varchar e verificar se o login e a senha estarão corretas

            command.Parameters.Add("@iduser", SqlDbType.VarChar).Value = txtiduser.Text; //quando o usuario digitar pegar no textBox,converter em varchar,para variaveis logins e senha

            try
            {
                sql.Open(); //vai abrir o banco de dados
                SqlDataReader drms = command.ExecuteReader();
                if (drms.HasRows == false)
                {
                    throw new Exception("Usuario não encontrado");
                }
                drms.Read();
                txtiduser.Text = Convert.ToString(drms["iduser"]); //daqui que vai tirar as informações
                txtNome.Text = Convert.ToString(drms["Usuario"]);
                txtLogin.Text = Convert.ToString(drms["logins"]);
                txtSenha.Text = Convert.ToString(drms["Senha"]);
                txtTelefone.Text = Convert.ToString(drms["Fone"]);
                comboPerfil.Text = Convert.ToString(drms["Perfil"]);
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

        private void button5_Click(object sender, EventArgs e)
        {
            txtiduser.Text = "";  //ao clicar todos os campos serão limpados 
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtTelefone.Text = "";
            comboPerfil.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ubisoft;Data Source=DESKTOP-OOKTGKQ\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("update usuario set usuario=@Usuario, logins=@logins ,senha=@Senha ,fone=@Fone ,Perfil=@Perfil where iduser=@iduser", sql);
            command.Parameters.Add("@iduser", SqlDbType.Int).Value = txtiduser.Text;
            command.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@logins", SqlDbType.VarChar).Value = txtLogin.Text;
            command.Parameters.Add("@Senha", SqlDbType.VarChar).Value = txtSenha.Text;
            command.Parameters.Add("@Fone", SqlDbType.VarChar).Value = txtTelefone.Text;
            command.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = comboPerfil.Text;

            if (txtiduser.Text != "" & txtNome.Text != "" & txtLogin.Text != "" & txtSenha.Text != "" & txtTelefone.Text != "" & comboPerfil.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso", "frmusuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtiduser.Text = ""; //vai zerar os campos assim que cadastrar
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtTelefone.Text = "";
                    comboPerfil.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("por favor digita todas as informações nos campos Obrigatórios");
                }
                finally
                {
                    sql.Close(); //vai fechar o banco de dados
                }
            }

            else
            {
                MessageBox.Show("por favor digita todas as informações nos campos Obrigatórios");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ubisoft;Data Source=DESKTOP-OOKTGKQ\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("delete from usuario where iduser=@iduser", sql); //ele vai pegar os campos e disponibilizar para digitar o varchar e verificar se o login e a senha estarão corretas

            command.Parameters.Add("@iduser", SqlDbType.VarChar).Value = txtiduser.Text; 

            try
            {
                sql.Open(); //vai abrir o banco de dados
                command.ExecuteNonQuery();
                MessageBox.Show("Dados Excluídos com Sucesso");
                txtiduser.Text = ""; 
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtTelefone.Text = "";
                comboPerfil.Text = "";
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

