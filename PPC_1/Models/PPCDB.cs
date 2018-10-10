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

        public Ppc InserirPpc(Ppc ppc)
        {
            try
            {
                string inserirValores = @"INSERT INTO PPC (PERFIL_DO_CURSO,
                                                        PERFIL_DO_EGRESSO, 
                                                        FORMA_DE_ACESSO,
                                                        REPRES_GRAF_PERFIL_FOR,
                                                        SIST_AVAL_PROC_ENS_APREN,
                                                        SIST_AVAL_PROC_CURSO,
                                                        TCC,
                                                        ESTAGIO_CURRICULAR,
                                                        PRATICA_ATENDIMENTO_PCD,
                                                        ID_CURSO
                                                        ) 
                                                        VALUES
                                                        (@PERFIL_DO_CURSO,
                                                        @PERFIL_DO_EGRESSO,
                                                        @FORMA_DE_ACESSO,
                                                        @REPRES_GRAF_PERFIL_FOR,
                                                        @SIST_AVAL_PROC_ENS_APREN,
                                                        @SIST_AVAL_PROC_CURSO,
                                                        @TCC,
                                                        @ESTAGIO_CURRICULAR,
                                                        @PRATICA_ATENDIMENTO_PCD,
                                                        @ID_CURSO
                                                        )";
                string conexao = ConexaoBanco();

                //SqlConnection sqlConn = new SqlConnection(conexao);

                using (var sqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@PERFIL_DO_CURSO", SqlDbType.VarChar, 50).Value = ppc.PerfilDoCurso;
                        comm.Parameters.Add("@PERFIL_DO_EGRESSO", SqlDbType.VarChar, 50).Value = ppc.PerfilDoEgresso;
                        comm.Parameters.Add("@FORMA_DE_ACESSO", SqlDbType.VarChar, 50).Value = ppc.FormaDeAcesso;
                        comm.Parameters.Add("@REPRES_GRAF_PERFIL_FOR", SqlDbType.VarChar, 50).Value = ppc.RepresentacaoGrafica;
                        comm.Parameters.Add("@SIST_AVAL_PROC_ENS_APREN", SqlDbType.VarChar, 100).Value = ppc.SistemaAvaliacaoEnsinoAprendizagem;
                        comm.Parameters.Add("@SIST_AVAL_PROC_CURSO", SqlDbType.VarChar, 50).Value = ppc.SistemaAvaliacaoCurso;
                        comm.Parameters.Add("@TCC", SqlDbType.VarChar, 100).Value = ppc.TCC;
                        comm.Parameters.Add("@ESTAGIO_CURRICULAR", SqlDbType.VarChar, 50).Value = ppc.EstagioCurricular;
                        comm.Parameters.Add("@PRATICA_ATENDIMENTO_PCD", SqlDbType.VarChar, 50).Value = ppc.PraticaAtenPCD;
                        comm.Parameters.Add("@ID_CURSO", SqlDbType.Int).Value = ppc.IdCurso;

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

        public Ppc BuscarPpcs(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM PPC WHERE ID_PPC = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Ppc ppc = new Ppc();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {

                        ppc.Id = Convert.ToInt32(dr["ID_PPC"]);
                        ppc.PerfilDoCurso = dr["PERFIL_DO_CURSO"].ToString();
                        ppc.PerfilDoEgresso = dr["PERFIL_DO_EGRESSO"].ToString();
                        ppc.FormaDeAcesso = dr["FORMA_DE_ACESSO"].ToString();
                        ppc.RepresentacaoGrafica = dr["REPRES_GRAF_PERFIL_FOR"].ToString();
                        ppc.SistemaAvaliacaoEnsinoAprendizagem = dr["SIST_AVAL_PROC_ENS_APREN"].ToString();
                        ppc.SistemaAvaliacaoCurso = dr["SIST_AVAL_PROC_CURSO"].ToString();
                        ppc.TCC = dr["TCC"].ToString();
                        ppc.EstagioCurricular = dr["ESTAGIO_CURRICULAR"].ToString();
                        ppc.PraticaAtenPCD = dr["PRATICA_ATENDIMENTO_PCD"].ToString();
                        ppc.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);

                        

                    }
                }


                return (ppc);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Ppc> BuscarPpcs()
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM PPC";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                List<Ppc> ppcs = new List<Ppc>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        Ppc ppc = new Ppc();
                        ppc.Id = Convert.ToInt32(dr["ID_PPC"]);
                        ppc.PerfilDoCurso = dr["PERFIL_DO_CURSO"].ToString();
                        ppc.PerfilDoEgresso = dr["PERFIL_DO_EGRESSO"].ToString();
                        ppc.FormaDeAcesso = dr["FORMA_DE_ACESSO"].ToString();
                        ppc.RepresentacaoGrafica = dr["REPRES_GRAF_PERFIL_FOR"].ToString();
                        ppc.SistemaAvaliacaoEnsinoAprendizagem = dr["SIST_AVAL_PROC_ENS_APREN"].ToString();
                        ppc.SistemaAvaliacaoCurso = dr["SIST_AVAL_PROC_CURSO"].ToString();
                        ppc.TCC = dr["TCC"].ToString();
                        ppc.EstagioCurricular = dr["ESTAGIO_CURRICULAR"].ToString();
                        ppc.PraticaAtenPCD = dr["PRATICA_ATENDIMENTO_PCD"].ToString();
                        ppc.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);
                        ppcs.Add(ppc);
                    }
                }


                return (ppcs);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Ppc atualizarPpc(Ppc ppc)
        {
            try
            {
                string conexao = ConexaoBanco();

                string atualizarValores = @"UPDATE PPC SET PERFIL_DO_CURSO = @PERFIL_DO_CURSO,
                                                      PERFIL_DO_EGRESSO = @PERFIL_DO_EGRESSO,
                                                      FORMA_DE_ACESSO = @FORMA_DE_ACESSO,
                                                      REPRES_GRAF_PERFIL_FOR = @REPRES_GRAF_PERFIL_FOR,
                                                      SIST_AVAL_PROC_ENS_APREN = @SIST_AVAL_PROC_ENS_APREN,
                                                      SIST_AVAL_PROC_CURSO = @SIST_AVAL_PROC_CURSO,  
                                                      TCC = @TCC,
                                                      ESTAGIO_CURRICULAR = @ESTAGIO_CURRICULAR,
                                                      PRATICA_ATENDIMENTO_PCD = @PRATICA_ATENDIMENTO_PCD,
                                                      ID_CURSO = @ID_CURSO
                                                      WHERE ID_PPC = @Id";

                using (SqlConnection SqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(atualizarValores, SqlConn))
                    {
                        comm.Parameters.Add("@Id", SqlDbType.Int).Value = ppc.Id;
                        comm.Parameters.Add("@PERFIL_DO_CURSO", SqlDbType.VarChar, 50).Value = ppc.PerfilDoCurso;
                        comm.Parameters.Add("@PERFIL_DO_EGRESSO", SqlDbType.VarChar, 50).Value = ppc.PerfilDoEgresso;
                        comm.Parameters.Add("@FORMA_DE_ACESSO", SqlDbType.VarChar, 50).Value = ppc.FormaDeAcesso;
                        comm.Parameters.Add("@REPRES_GRAF_PERFIL_FOR", SqlDbType.VarChar, 50).Value = ppc.RepresentacaoGrafica;
                        comm.Parameters.Add("@SIST_AVAL_PROC_ENS_APREN", SqlDbType.VarChar, 100).Value = ppc.SistemaAvaliacaoEnsinoAprendizagem;
                        comm.Parameters.Add("@SIST_AVAL_PROC_CURSO", SqlDbType.VarChar, 50).Value = ppc.SistemaAvaliacaoCurso;
                        comm.Parameters.Add("@TCC", SqlDbType.VarChar, 50).Value = ppc.TCC;
                        comm.Parameters.Add("@ESTAGIO_CURRICULAR", SqlDbType.VarChar, 50).Value = ppc.EstagioCurricular;
                        comm.Parameters.Add("@PRATICA_ATENDIMENTO_PCD", SqlDbType.VarChar, 50).Value = ppc.PraticaAtenPCD;
                        comm.Parameters.Add("@ID_CURSO", SqlDbType.Int).Value = ppc.IdCurso;

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
        
        public Disciplina InserirDisciplina(Disciplina disciplina)
        {
            try
            {
                string inserirValores = @"INSERT INTO DISCIPLINAS (NOME_DISCIPLINA, CARGA_HORARIA, QUANTIDADE_SEMESTRES, ID_CURSO) 
                                                     VALUES (@NOME_DISCIPLINA, @CARGA_HORARIA, @QUANTIDADE_SEMESTRES, @ID_CURSO)";

                string conexao = ConexaoBanco();

                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@NOME_DISCIPLINA", SqlDbType.VarChar, 50).Value = disciplina.Nome;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = disciplina.CargaHoraria;
                        comm.Parameters.Add("@QUANTIDADE_SEMESTRES", SqlDbType.Int).Value = disciplina.Semestre;
                        comm.Parameters.Add("@ID_CURSO", SqlDbType.Int).Value = disciplina.IdCurso;

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

        public List<Disciplina> BuscarDisciplinas()
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM DISCIPLINAS";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                List<Disciplina> disciplinas = new List<Disciplina>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        Disciplina disciplina = new Disciplina();
                        disciplina.Id = Convert.ToInt32(dr["ID_DISCIPLINA"]);
                        disciplina.Nome = dr["NOME_DISCIPLINA"].ToString();
                        disciplina.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                        disciplina.Semestre = Convert.ToInt32(dr["QUANTIDADE_SEMESTRES"]);
                        disciplina.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);
                        disciplinas.Add(disciplina);
                    }
                }


                return (disciplinas);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Disciplina BuscarDisciplinas(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM DISCIPLINAS WHERE ID_DISCIPLINA = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Disciplina disciplina = new Disciplina();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        disciplina.Id = Convert.ToInt32(dr["ID_DISCIPLINA"]);
                        disciplina.Nome = dr["NOME_DISCIPLINA"].ToString();
                        disciplina.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                        disciplina.Semestre = Convert.ToInt32(dr["QUANTIDADE_SEMESTRES"]);
                        disciplina.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);
                    }
                }


                return (disciplina);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Disciplina atualizarDisciplina(Disciplina disciplina)
        {
            try
            {
                string conexao = ConexaoBanco();

                string atualizarValores = @"UPDATE DISCIPLINA SET NOME_DISCIPLINA= @NOME_DISCIPLINA,
                                                      CARGA_HORARIA = @CARGA_HORARIA,
                                                      QUANTIDADE_SEMESTRE = @QUANTIDADE_SEMESTRE,
                                                      ID_CURSO = @ID_CURSO
                                                      WHERE ID_DISCIPLINA = @Id";

                using (SqlConnection SqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(atualizarValores, SqlConn))
                    {
                        comm.Parameters.Add("@Id", SqlDbType.Int).Value = disciplina.Id;
                        comm.Parameters.Add("@NOME_DISCIPLINA", SqlDbType.VarChar, 50).Value = disciplina.Nome;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = disciplina.CargaHoraria;
                        comm.Parameters.Add("@QUANTIDADE_SEMESTRE", SqlDbType.Int).Value = disciplina.Semestre;
                        comm.Parameters.Add("@ID_CURSO", SqlDbType.Int).Value = disciplina.IdCurso;

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

        public List<Disciplina> BuscarDisciplinasVinculadas(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM DISCIPLINAS WHERE ID_CURSO = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                List<Disciplina> disciplinas = new List<Disciplina>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        Disciplina disciplina = new Disciplina();
                        disciplina.Id = Convert.ToInt32(dr["ID_DISCIPLINA"]);
                        disciplina.Nome = dr["NOME_DISCIPLINA"].ToString();
                        disciplina.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                        disciplina.Semestre = Convert.ToInt32(dr["QUANTIDADE_SEMESTRES"]);
                        disciplina.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);
                        disciplinas.Add(disciplina);
                    }
                }

                return (disciplinas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}