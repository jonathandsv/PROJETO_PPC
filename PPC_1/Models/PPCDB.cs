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
            return (WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public Curso InserirCurso(Curso inserir)
        {

            try
            {
                string inserirValores = @"INSERT INTO CURSOS (TIPO_CURSO,
                                                        MODALIDADE, 
                                                        DENOMINACAO_CURSO,
                                                        HABILITACAO,
                                                        LOCAL_OFERTA,
                                                        TURNO,
                                                        NUMERO_DE_VAGAS,
                                                        CARGA_HORARIA,
                                                        REGIME_LETIVO,
                                                        QUANTIDADE_DE_PERIODOS
                                                        ) 
                                                        VALUES
                                                        (@TIPO_CURSO,
                                                        @MODALIDADE,
                                                        @DENOMINACAO_CURSO,
                                                        @HABILITACAO,
                                                        @LOCAL_OFERTA,
                                                        @TURNO,
                                                        @NUMERO_DE_VAGAS,
                                                        @CARGA_HORARIA,
                                                        @REGIME_LETIVO,
                                                        @QUANTIDADE_DE_PERIODOS
                                                        )";
                string conexao = ConexaoBanco();

                //SqlConnection sqlConn = new SqlConnection(conexao);

                using (var sqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@TIPO_CURSO", SqlDbType.VarChar, 50).Value = inserir.TipoDeCurso;
                        comm.Parameters.Add("@MODALIDADE", SqlDbType.VarChar, 50).Value = inserir.Modalidade;
                        comm.Parameters.Add("@DENOMINACAO_CURSO", SqlDbType.VarChar, 50).Value = inserir.DenominacaoCurso;
                        comm.Parameters.Add("@HABILITACAO", SqlDbType.VarChar, 50).Value = inserir.Habilitacao;
                        comm.Parameters.Add("@LOCAL_OFERTA", SqlDbType.VarChar, 50).Value = inserir.LocalDeOferta;
                        comm.Parameters.Add("@TURNO", SqlDbType.VarChar, 50).Value = inserir.TurnosDeFuncionamento;
                        comm.Parameters.Add("@NUMERO_DE_VAGAS", SqlDbType.Int).Value = inserir.NumerosDeVagasCadaTurno;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = inserir.CargaHorariaDoCurso;
                        comm.Parameters.Add("@REGIME_LETIVO", SqlDbType.VarChar, 50).Value = inserir.RegimeLetivo;
                        comm.Parameters.Add("@QUANTIDADE_DE_PERIODOS", SqlDbType.Int).Value = inserir.Periodos;
                        

                        sqlConn.Open();
                        comm.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }

                return (null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}