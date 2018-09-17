using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace PPC_1.Models
{
    public class PPCDB
    {

       private SqlConnection ConexaoBanco() {
            string conexao = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConn = new SqlConnection(conexao);
            return(sqlConn);
        }

        

}