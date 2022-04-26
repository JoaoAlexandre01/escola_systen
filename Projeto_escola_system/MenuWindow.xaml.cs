using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Projeto_escola_system
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string tipo = "Privado";
            string data_criacao = dt_data_criacao.SelectedDate?.ToString("yyyy-mm-dd");

            if ((bool)rd_publica.IsChecked)
                tipo = "Pública";

            var conexao = new MySqlConnection("server=localhost;database=bd_escola;port=3360;user=root;password=root");



            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Escola (nome_esc, razao_social_esc, cnpj_esc, insc_estatual_esc," +
                    " tipo_esc, data_criacao_esc, responsavel_esc, telefone_responsavel_esc, email_esc, telefone_esc, rua_esc," +
                    " numero_esc, bairro_esc, cep_esc, cidade_esc, estado_esc) " +
                    "VALUES (@nome, @razao, @cnpj, @inscrisao, @tipo," +
                    " @criacao, @responsavel, @telefoneResponsavel, @email, @telEscola, @rua, @numero, @bairro, @cep, @cidade, @estado)";
                comando.Parameters.AddWithValue("@nome", txt_nome.Text);
                comando.Parameters.AddWithValue("@razao", txt_razao_social.Text);
                comando.Parameters.AddWithValue("@cnpj", txt_cnpj.Text); 
                comando.Parameters.AddWithValue("@inscrisao", txt_inscrisao_publica.Text);
                comando.Parameters.AddWithValue("@tipo", tipo); 
                comando.Parameters.AddWithValue("@criacao", data_criacao);
                comando.Parameters.AddWithValue("@responsavel", txt_nome_responsavel.Text); 
                comando.Parameters.AddWithValue("@ntelefoneResponsavelome", txt_telefone_responsavel.Text);
                comando.Parameters.AddWithValue("@email", txt_email_escola.Text);
                comando.Parameters.AddWithValue("@telEscola", txt_telefone_escola.Text);
                comando.Parameters.AddWithValue("@rua", txt_rua.Text);
                comando.Parameters.AddWithValue("@numero", txt_numero.Text);
                comando.Parameters.AddWithValue("@bairro", txt_bairro.Text);
                comando.Parameters.AddWithValue("@cep", txt_cep.Text);
                comando.Parameters.AddWithValue("@cidade", txt_cidade.Text);
                comando.Parameters.AddWithValue("@estado", txt_estado.Text);

                var resultado = comando.ExecuteNonQuery();

                if(resultado > 0)
                {
                    MessageBox.Show("Registro Salvo com Sucesso");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
