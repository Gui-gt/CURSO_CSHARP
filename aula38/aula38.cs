using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp200
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cpfTXT_Leave(object sender, EventArgs e)
        {
            string cpf = cpfTXT.Text.Replace(".", "").Replace("-", "");  
            
            if(ValidaCpF(cpf))
            {
                MessageBox.Show("valido!");
            }
            else
            {
                MessageBox.Show("tá inválido!");
            }
        }

        private bool ValidaCpF(string cpf)
        {
            if (cpf.Length != 11)
                return false;


            if(new string(cpf[0], cpf.Length) == cpf)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11- resto;
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
           resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private void cpfTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=base_teste;User=root;Password="))
            { 
                conexao.Open();
            
                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO nome (nome, cpf) VALUES (@nome,@cpf)";
                    cmd.Parameters.AddWithValue("@nome", nomeTXT.Text);
                    cmd.Parameters.AddWithValue("@cpf", cpfTXT.Text);

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Cadastrado com sucesso");
            
        }

        private void nomeTXT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Windowsform3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopularDataGridView();
           
        }
     



        private void cpfTXT_Leave(object sender, EventArgs e)
        {
            string cpf = cpfTXT.Text.Replace(".", "").Replace("-", "");

            if (VALIDAcpf(cpf))
            {
                //TRUE
                MessageBox.Show("Válidado com sucesso");
            }
            else
            {
                //FALSE
                MessageBox.Show("CPF INVÁLIDO!");
            }
        }

        private bool VALIDAcpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=base_treino;User=root;Password="))
            {
                conexao.Open();

                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO tabelao (nome, cpf) VALUES (@nome,@cpf)";
                    cmd.Parameters.AddWithValue("@nome", nomeTXT.Text);
                    cmd.Parameters.AddWithValue("@cpf", cpfTXT.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastrado gg");
                PopularDataGridView();
            }
        }



        private void dtTABELA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtTABELA.Rows[e.RowIndex];

                cpfTXT.Text = row.Cells["cpf"].Value.ToString();
                nomeTXT.Text = row.Cells["nome"].Value.ToString();
            }
        }

        private void PopularDataGridView()
        {
        
            using (MySqlConnection conexão = new MySqlConnection("Server=localhost;Port=3306;Database=base_treino;User=root;Password="))
            {
                string query = "SELECT * FROM tabelao";
                MySqlCommand command = new MySqlCommand(query, conexão);
                conexão.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();

                adapter.Fill(dt);
                dtTABELA.DataSource = dt;
              
            }  
        }

       
    }
}
    



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Windowsform3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopularDataGridView();
           
        }
     



        private void cpfTXT_Leave(object sender, EventArgs e)
        {
            string cpf = cpfTXT.Text.Replace(".", "").Replace("-", "");

            if (VALIDAcpf(cpf))
            {
                //TRUE
                MessageBox.Show("Válidado com sucesso");
            }
            else
            {
                //FALSE
                MessageBox.Show("CPF INVÁLIDO!");
            }
        }

        private bool VALIDAcpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=base_treino;User=root;Password="))
            {
                conexao.Open();

                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO tabelao (nome, cpf) VALUES (@nome,@cpf)";
                    cmd.Parameters.AddWithValue("@nome", nomeTXT.Text);
                    cmd.Parameters.AddWithValue("@cpf", cpfTXT.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastrado gg");
                PopularDataGridView();
            }
        }



        private void dtTABELA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtTABELA.Rows[e.RowIndex];

                cpfTXT.Text = row.Cells["cpf"].Value.ToString();
                nomeTXT.Text = row.Cells["nome"].Value.ToString();
            }
        }

        private void PopularDataGridView()
        {
        
            using (MySqlConnection conexão = new MySqlConnection("Server=localhost;Port=3306;Database=base_treino;User=root;Password="))
            {
                string query = "SELECT * FROM tabelao";
                MySqlCommand command = new MySqlCommand(query, conexão);
                conexão.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();

                adapter.Fill(dt);
                dtTABELA.DataSource = dt;
              
            }  
        }

       
    }
}
    



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Windowsform3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopularDataGridView();
           
        }
     



        private void cpfTXT_Leave(object sender, EventArgs e)
        {
            string cpf = cpfTXT.Text.Replace(".", "").Replace("-", "");

            if (VALIDAcpf(cpf))
            {
                //TRUE
                MessageBox.Show("Válidado com sucesso");
            }
            else
            {
                //FALSE
                MessageBox.Show("CPF INVÁLIDO!");
            }
        }

        private bool VALIDAcpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=base_treino;User=root;Password="))
            {
                conexao.Open();

                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO tabelao (nome, cpf) VALUES (@nome,@cpf)";
                    cmd.Parameters.AddWithValue("@nome", nomeTXT.Text);
                    cmd.Parameters.AddWithValue("@cpf", cpfTXT.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastrado gg");
                PopularDataGridView();
            }
        }



        private void dtTABELA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtTABELA.Rows[e.RowIndex];

                cpfTXT.Text = row.Cells["cpf"].Value.ToString();
                nomeTXT.Text = row.Cells["nome"].Value.ToString();
            }
        }

        private void PopularDataGridView()
        {
        
            using (MySqlConnection conexão = new MySqlConnection("Server=localhost;Port=3306;Database=base_treino;User=root;Password="))
            {
                string query = "SELECT * FROM tabelao";
                MySqlCommand command = new MySqlCommand(query, conexão);
                conexão.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();

                adapter.Fill(dt);
                dtTABELA.DataSource = dt;
              
            }  
        }

       
    }
}
    



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Windowsform3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopularDataGridView();
           
        }
     



        private void cpfTXT_Leave(object sender, EventArgs e)
        {
            string cpf = cpfTXT.Text.Replace(".", "").Replace("-", "");

            if (VALIDAcpf(cpf))
            {
                //TRUE
                MessageBox.Show("Válidado com sucesso");
            }
            else
            {
                //FALSE
                MessageBox.Show("CPF INVÁLIDO!");
            }
        }

        private bool VALIDAcpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=base_treino;User=root;Password="))
            {
                conexao.Open();

                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO tabelao (nome, cpf) VALUES (@nome,@cpf)";
                    cmd.Parameters.AddWithValue("@nome", nomeTXT.Text);
                    cmd.Parameters.AddWithValue("@cpf", cpfTXT.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastrado gg");
                PopularDataGridView();
            }
        }



        private void dtTABELA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtTABELA.Rows[e.RowIndex];

                cpfTXT.Text = row.Cells["cpf"].Value.ToString();
                nomeTXT.Text = row.Cells["nome"].Value.ToString();
            }
        }

        private void PopularDataGridView()
        {
        
            using (MySqlConnection conexão = new MySqlConnection("Server=localhost;Port=3306;Database=base_treino;User=root;Password="))
            {
                string query = "SELECT * FROM tabelao";
                MySqlCommand command = new MySqlCommand(query, conexão);
                conexão.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();

                adapter.Fill(dt);
                dtTABELA.DataSource = dt;
              
            }  
        }

       
    }
}
    



