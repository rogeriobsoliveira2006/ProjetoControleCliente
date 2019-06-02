using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.Repository.Impl
{
    public class Conexao
    {
        //atributos...
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        //métodos...
        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ControleDBClientes"].ConnectionString);
            con.Open();//conexão aberta...
        }

        protected void FecharConexao()
        {
            con.Close();//fechar conexão...
        }
    }
}
