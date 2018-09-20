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

        public Curso InserirCurso(Curso curso)
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
                        comm.Parameters.Add("@TIPO_CURSO", SqlDbType.VarChar, 50).Value = curso.TipoDeCurso;
                        comm.Parameters.Add("@MODALIDADE", SqlDbType.VarChar, 50).Value = curso.Modalidade;
                        comm.Parameters.Add("@DENOMINACAO_CURSO", SqlDbType.VarChar, 50).Value = curso.DenominacaoCurso;
                        comm.Parameters.Add("@HABILITACAO", SqlDbType.VarChar, 50).Value = curso.Habilitacao;
                        comm.Parameters.Add("@LOCAL_OFERTA", SqlDbType.VarChar, 50).Value = curso.LocalDeOferta;
                        comm.Parameters.Add("@TURNO", SqlDbType.VarChar, 50).Value = curso.TurnosDeFuncionamento;
                        comm.Parameters.Add("@NUMERO_DE_VAGAS", SqlDbType.Int).Value = curso.NumerosDeVagasCadaTurno;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = curso.CargaHorariaDoCurso;
                        comm.Parameters.Add("@REGIME_LETIVO", SqlDbType.VarChar, 50).Value = curso.RegimeLetivo;
                        comm.Parameters.Add("@QUANTIDADE_DE_PERIODOS", SqlDbType.Int).Value = curso.Periodos;
                        

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

        public  List<Coordenador> BuscarCoordenadores()
        {
            string conexao = ConexaoBanco();

            string stringBuscar = @"SELECT * FROM USUARIOS WHERE ID_PERFIL = 1";

            SqlConnection sqlConn = new SqlConnection(conexao);

            sqlConn.Open();

            SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn);

            SqlDataReader dr = leitor.ExecuteReader();

            List<Coordenador> coordenadores = new List<Coordenador>();


            while (dr.Read())
            {
                Coordenador coordenador = new Coordenador();
                coordenador.Nome = dr["NOME_USUARIO"].ToString();
                coordenador.MaiorTitulacao = dr["MAIOR_TITULACAO"].ToString();
                coordenador.CPF = dr["CPF"].ToString();
                coordenadores.Add(coordenador);
            }

            return(coordenadores);
        }
    }
}