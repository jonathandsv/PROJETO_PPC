using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace PPC_1.Models
{
    public class PPCDB
    {

        private string ConexaoBanco()
        {
            string conexao = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //SqlConnection sqlConn = new SqlConnection(conexao);
            //return (sqlConn);
            return (conexao);
        }

        public Curso EnserirCurso(Curso inserir)
        {
            
            string inserirValores = "INSERT INTO CURSO (ID_CURSO, " +
                                                        "MODALIDADE, " +
                                                        "DENOMINACAO_CURSO, " +
                                                        "HABILITACAO, " +
                                                        "LOCAL_OFERTA, " +
                                                        "TURNO, " +
                                                        "NUMERO_DE_VAGAS, " +
                                                        "CARGA_HORARIA, " +
                                                        "REGIME_LETIVO, " +
                                                        "QUANTIDADE_DE_PERIODOS, " +
                                                        "ID_COORDENADOR)" +
                                                        "VALUES " +
                                                        "(@MODALIDADE, " +
                                                        "@DENOMINACAO_CURSO, " +
                                                        "@HABILITACAO, " +
                                                        "@LOCAL_OFERTA, " +
                                                        "@TURNO, " +
                                                        "@NUMERO_DE_VAGAS, " +
                                                        "@CARGA_HORARIA, " +
                                                        "@REGIME_LETIVO, " +
                                                        "@QUANTIDADE_DE_PERIODOS, " +
                                                        "ID_COORDENADOR)"; 
            SqlConnection sqlConn = new SqlConnection(ConexaoBanco());
            using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
            {
                comm.Parameters.Add("@MODALIDADE", SqlDbType.VarChar, 50).Value = inserir.Modalidade;
                comm.Parameters.Add("@DENOMINACAO_CURSO", SqlDbType.VarChar, 50).Value = inserir.DenominacaoCurso;
                comm.Parameters.Add("@HABILITACAO", SqlDbType.VarChar, 50).Value = inserir.Habilitacao;
                comm.Parameters.Add("@LOCAL_OFERTA", SqlDbType.VarChar, 50).Value = inserir.LocalDeOferta;
                comm.Parameters.Add("@TURNO", SqlDbType.VarChar, 50).Value = inserir.TurnosDeFuncionamento;
                comm.Parameters.Add("@NUMERO_DE_VAGAS", SqlDbType.Int).Value = inserir.NumerosDeVagasCadaTurno;
                comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = inserir.CargaHorariaDoCurso;
                comm.Parameters.Add("@REGIMELETIVO", SqlDbType.VarChar, 50).Value = inserir.RegimeLetivo;
                comm.Parameters.Add("@QUANTIDADE_DE_PERIODOS", SqlDbType.Int).Value = inserir.Periodos;
                comm.Parameters.Add("@ID_COORDENADOR", SqlDbType.Int).Value = inserir.CoordenadorCurso;

            }

            return(null);
        }
    }

        

}