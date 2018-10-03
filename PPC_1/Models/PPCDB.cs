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
                                                        QUANTIDADE_DE_PERIODOS,
                                                        ID_COORDENADOR
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
                                                        @QUANTIDADE_DE_PERIODOS,
                                                        @ID_COORDENADOR
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
                        comm.Parameters.Add("@ID_COORDENADOR", SqlDbType.Int).Value = curso.CoordenadorCurso;

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

        public Curso atualizarCurso(Curso curso)
        {
            try
            {
                string conexao = ConexaoBanco();

                string atualizarValores = @"UPDATE CURSOS SET TIPO_CURSO = @TIPO_CURSO,
                                                      MODALIDADE = @MODALIDADE,
                                                      DENOMINACAO_CURSO = @DENOMINACAO_CURSO,
                                                      HABILITACAO = @HABILITACAO,
                                                      LOCAL_OFERTA = @LOCAL_OFERTA,
                                                      TURNO = @TURNO,
                                                      NUMERO_DE_VAGAS = @NUMERO_DE_VAGAS,
                                                      CARGA_HORARIA = @CARGA_HORARIA,
                                                      REGIME_LETIVO = @REGIME_LETIVO,
                                                      QUANTIDADE_DE_PERIODOS = @QUANTIDADE_DE_PERIODOS,
                                                      ID_COORDENADOR = @ID_COORDENADOR
                                                      WHERE ID_CURSO = @Id";

                using (SqlConnection SqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(atualizarValores, SqlConn))
                    {
                        comm.Parameters.Add("@Id", SqlDbType.Int).Value = curso.Id;
                        comm.Parameters.Add("@TIPO_CURSO", SqlDbType.VarChar, 50).Value = curso.TipoDeCurso;
                        comm.Parameters.Add("@MODALIDADE", SqlDbType.VarChar, 50).Value = curso.Modalidade;
                        comm.Parameters.Add("@DENOMINACAO_CURSO", SqlDbType.VarChar, 50).Value = curso.DenominacaoCurso;
                        comm.Parameters.Add("@HABILITACAO", SqlDbType.VarChar, 50).Value = curso.Habilitacao;
                        comm.Parameters.Add("@LOCAL_OFERTA", SqlDbType.VarChar, 50).Value = curso.LocalDeOferta;
                        comm.Parameters.Add("@TURNO", SqlDbType.VarChar, 50).Value = curso.TurnosDeFuncionamento;
                        comm.Parameters.Add("@NUMERO_DE_VAGAS", SqlDbType.Int).Value = curso.NumerosDeVagasCadaTurno;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = curso.CargaHorariaDoCurso;
                        comm.Parameters.Add("@REGIME_LETIVO", SqlDbType.VarChar).Value = curso.RegimeLetivo;
                        comm.Parameters.Add("@QUANTIDADE_DE_PERIODOS", SqlDbType.Int).Value = curso.Periodos;
                        comm.Parameters.Add("@ID_COORDENADOR", SqlDbType.Int).Value = curso.CoordenadorCurso;

                        SqlConn.Open();
                        comm.ExecuteNonQuery();
                        SqlConn.Close();

                    }

                }


                return (null);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Curso> BuscarCursos()
        {
            string conexao = ConexaoBanco();

            string stringBuscar = @"SELECT * FROM CURSOS";

            SqlConnection sqlConn = new SqlConnection(conexao);

            sqlConn.Open();

            List<Curso> cursos = new List<Curso>();

            using(SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
            {
                SqlDataReader dr = leitor.ExecuteReader();

                while (dr.Read())
                {
                    Curso curso = new Curso();
                    curso.Id = Convert.ToInt32(dr["ID_CURSO"]);
                    curso.TipoDeCurso = dr["TIPO_CURSO"].ToString();
                    curso.DenominacaoCurso = dr["DENOMINACAO_CURSO"].ToString();
                    cursos.Add(curso);
                }
            }


            return (cursos);
        }

        public Curso BuscarCursos(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM CURSOS WHERE ID_CURSO = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Curso curso = new Curso();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {

                        curso.Id = Convert.ToInt32(dr["ID_CURSO"]);
                        curso.TipoDeCurso = dr["TIPO_CURSO"].ToString();
                        curso.Modalidade = dr["MODALIDADE"].ToString();
                        curso.DenominacaoCurso = dr["DENOMINACAO_CURSO"].ToString();
                        curso.Habilitacao = dr["HABILITACAO"].ToString();
                        curso.LocalDeOferta = dr["LOCAL_OFERTA"].ToString();
                        curso.TurnosDeFuncionamento = dr["TURNO"].ToString();
                        curso.NumerosDeVagasCadaTurno = Convert.ToInt32(dr["NUMERO_DE_VAGAS"]);
                        curso.CargaHorariaDoCurso = Convert.ToInt32(dr["CARGA_HORARIA"]);
                        curso.RegimeLetivo = dr["REGIME_LETIVO"].ToString();
                        curso.Periodos = Convert.ToInt32(dr["QUANTIDADE_DE_PERIODOS"]);
                        curso.CoordenadorCurso = Convert.ToInt32(dr["ID_COORDENADOR"]);
                    }
                }


                return (curso);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int excluirCurso(int id)
        {
            int retorno = 0;
            try
            {
                string conexao = ConexaoBanco();

                string stringDeletar = @"DELETE FROM CURSOS WHERE ID_CURSO = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();
                using (SqlCommand apagador = new SqlCommand(stringDeletar, sqlConn))
                {
                    apagador.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    retorno = apagador.ExecuteNonQuery();
                    sqlConn.Close();
                }



                return (0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Coordenador BuscarCoordenadores(int id)
        {
            string conexao = ConexaoBanco();

            string stringBuscar = @"SELECT * FROM USUARIOS WHERE ID_USUARIO = @id";

            SqlConnection sqlConn = new SqlConnection(conexao);

            sqlConn.Open();
            Coordenador coordenador = new Coordenador();
            using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn)) {

                leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    


                    while (dr.Read())
                    {
                        coordenador.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                        coordenador.Nome = dr["NOME_USUARIO"].ToString();
                        coordenador.MaiorTitulacao = dr["MAIOR_TITULACAO"].ToString();
                        coordenador.CPF = dr["CPF"].ToString();
                    }
            }

            return (coordenador);
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
                coordenador.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                coordenador.Nome = dr["NOME_USUARIO"].ToString();
                coordenador.MaiorTitulacao = dr["MAIOR_TITULACAO"].ToString();
                coordenador.CPF = dr["CPF"].ToString();
                coordenadores.Add(coordenador);
            }

            return(coordenadores);
        }        
    }
}