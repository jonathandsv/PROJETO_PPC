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

        public int excluirPPC(int id)
        {
            int retorno = 0;
            try
            {
                string conexao = ConexaoBanco();

                string stringDeletar = @"DELETE FROM PPC WHERE ID_PPC = @id";

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
        
        public Disciplina InserirDisciplina(Disciplina disciplina)
        {
            try
            {
                string inserirValores = @"INSERT INTO DISCIPLINAS (NOME_DISCIPLINA, CARGA_HORARIA, QUANTIDADE_SEMESTRES) 
                                                     VALUES (@NOME_DISCIPLINA, @CARGA_HORARIA, @QUANTIDADE_SEMESTRES)";

                string conexao = ConexaoBanco();

                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@NOME_DISCIPLINA", SqlDbType.VarChar, 50).Value = disciplina.Nome;
                        comm.Parameters.Add("@CARGA_HORARIA", SqlDbType.Int).Value = disciplina.CargaHoraria;
                        comm.Parameters.Add("@QUANTIDADE_SEMESTRES", SqlDbType.Int).Value = disciplina.Semestre;

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

        public CursoDisciplina VincularDisciplinaCurso(CursoDisciplina disciplina)
        {
            try
            {
                string inserirValores = @"INSERT INTO CURSOS_DISCIPLINAS (ID_CURSO, ID_DISCIPLINA) VALUES (@ID_CURSO, @ID_DISCIPLINA)";

                string conexao = ConexaoBanco();

                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@ID_CURSO", SqlDbType.Int).Value = disciplina.IdCurso;
                        comm.Parameters.Add("@ID_DISCIPLINA", SqlDbType.Int).Value = disciplina.IdDisciplina;

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

        public List<Disciplina> BuscarDisciplinasFiltradas()
        {
            try
            {
                string conexao = ConexaoBanco();

                //string stringBuscar = @"SELECT DISTINCT NOME_DISCIPLINA FROM DISCIPLINAS";
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
                        disciplina.Nome = dr["NOME_DISCIPLINA"].ToString();
                        disciplina.Id = Convert.ToInt32(dr["ID_DISCIPLINA"]);
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

        public int excluirDisciplina(int id)
        {
            int retorno = 0;
            try
            {
                string conexao = ConexaoBanco();

                string stringDeletar = @"DELETE FROM DISCIPLINAS WHERE ID_DISCIPLINA = @id";

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

        public List<CursoDisciplina> BuscarDisciplinasVinculadas(int idCurso, int idDisciplina)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM CURSOS_DISCIPLINAS WHERE ID_CURSO = @IdCurso AND ID_DISCIPLINA = @IdDisciplina";

                if (idDisciplina == 0)
                {
                    stringBuscar = @"SELECT * FROM CURSOS_DISCIPLINAS WHERE ID_CURSO = @IdCurso";
                }

                SqlConnection sqlConn = new SqlConnection(conexao);

                List<CursoDisciplina> cursodisciplinas = new List<CursoDisciplina>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@IdCurso", SqlDbType.Int).Value = idCurso;
                    leitor.Parameters.Add("@IdDisciplina", SqlDbType.Int).Value = idDisciplina;

                    sqlConn.Open();

                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        CursoDisciplina cursoDisciplina = new CursoDisciplina();
                        cursoDisciplina.Id = Convert.ToInt32(dr["ID"]);
                        cursoDisciplina.IdCurso = Convert.ToInt32(dr["ID_CURSO"]);
                        cursoDisciplina.IdDisciplina = Convert.ToInt32(dr["ID_DISCIPLINA"]);
                        cursodisciplinas.Add(cursoDisciplina);
                    }
                    sqlConn.Close();
                }
                return (cursodisciplinas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Disciplina> BuscarPropriedadesDasDisciplinasVinculadas(List<CursoDisciplina> cursodisciplinas)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM DISCIPLINAS WHERE ID_DISCIPLINA = @idDisciplina";

                SqlConnection sqlConn = new SqlConnection(conexao);

                List<Disciplina> disciplinas = new List<Disciplina>();


                for (int i = 0; i < cursodisciplinas.Count; i++)
                {
                    using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                    {
                        leitor.Parameters.Add("@idDisciplina", SqlDbType.Int).Value = cursodisciplinas[i].IdDisciplina;
                        sqlConn.Open();
                        SqlDataReader dr = leitor.ExecuteReader();

                        while (dr.Read())
                        {
                            Disciplina disciplina = new Disciplina();
                            disciplina.Id = Convert.ToInt32(dr["ID_DISCIPLINA"]);
                            disciplina.Nome = dr["NOME_DISCIPLINA"].ToString();
                            disciplina.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                            disciplina.Semestre = Convert.ToInt32(dr["QUANTIDADE_SEMESTRES"]);
                            disciplinas.Add(disciplina);

                        }
                        sqlConn.Close();
                    }
                }
                return (disciplinas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cronograma InserirCronograma(Cronograma cronograma)
        {
            try
            {
                string inserirValores = @"INSERT INTO CRONOGRAMAS_ATIVIDADES (N_AULA, DESCRICAO) 
                                                                    VALUES (@N_AULA, @DESCRICAO)";

                string conexao = ConexaoBanco();

                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@N_AULA", SqlDbType.Int).Value = cronograma.NAula;
                        comm.Parameters.Add("@DESCRICAO", SqlDbType.VarChar).Value = cronograma.Descricao;

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

        public List<Cronograma> BuscarCronogramas()
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM CRONOGRAMAS_ATIVIDADES";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                List<Cronograma> cronogramas = new List<Cronograma>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        Cronograma cronograma = new Cronograma();
                        cronograma.Id = Convert.ToInt32(dr["ID_CRONOGRAMA"]);
                        cronograma.NAula = Convert.ToInt32(dr["N_AULA"]);
                        cronograma.Descricao = dr["DESCRICAO"].ToString();
                        cronogramas.Add(cronograma);
                       
                    }
                }

                return (cronogramas);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cronograma BuscarCronograma(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM CRONOGRAMAS_ATIVIDADES WHERE ID_CRONOGRAMA = @id";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Cronograma cronograma = new Cronograma();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        cronograma.Id = Convert.ToInt32(dr["ID_CRONOGRAMA"]);
                        cronograma.NAula = Convert.ToInt32(dr["N_AULA"]);
                        cronograma.Descricao = dr["DESCRICAO"].ToString();

                    }
                }

                return (cronograma);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int excluirCronograma(int id)
        {
            int retorno = 0;
            try
            {
                string conexao = ConexaoBanco();

                string stringDeletar = @"DELETE FROM CRONOGRAMAS_ATIVIDADES WHERE ID_CRONOGRAMA = @id";

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

        public Cronograma atualizarCronograma(Cronograma cronograma)
        {
            try
            {
                string conexao = ConexaoBanco();

                string atualizarValores = @"UPDATE CRONOGRAMAS_ATIVIDADES SET N_AULA = @N_AULA,
                                                      DESCRICAO = @DESCRICAO
                                                      WHERE ID_CRONOGRAMA = @Id";

                using (SqlConnection SqlConn = new SqlConnection(conexao))
                {

                    using (SqlCommand comm = new SqlCommand(atualizarValores, SqlConn))
                    {
                        comm.Parameters.Add("@Id", SqlDbType.Int).Value = cronograma.Id;
                        comm.Parameters.Add("@N_AULA", SqlDbType.Int).Value = cronograma.NAula;
                        comm.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 100).Value = cronograma.Descricao;
                        
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

        public Professor InserirProfessor(Professor professor)
        {
            try
            {
                string conexao = ConexaoBanco();

                string inserirValores = @"INSERT INTO USUARIOS (NOME_USUARIO, CPF, MAIOR_TITULACAO, AREA_FORMACAO, CURRICULO, DATA_ATUALIZACAO_CURRICULO, ID_PERFIL, SENHA) 
                                                                    VALUES (@NOME_USUARIO, @CPF, @MAIOR_TITULACAO, @AREA_FORMACAO, @CURRICULO, @DATA_ATUALIZACAO_CURRICULO, @ID_PERFIL, @SENHA)";


                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@NOME_USUARIO", SqlDbType.VarChar).Value = professor.Nome;
                        comm.Parameters.Add("@CPF", SqlDbType.VarChar).Value = professor.CPF;
                        comm.Parameters.Add("@MAIOR_TITULACAO", SqlDbType.VarChar).Value = professor.MaiorTitulacao;
                        comm.Parameters.Add("@AREA_FORMACAO", SqlDbType.VarChar).Value = professor.AreaFormacao;
                        comm.Parameters.Add("@CURRICULO", SqlDbType.VarChar).Value = professor.CurriculoLattos;
                        comm.Parameters.Add("@DATA_ATUALIZACAO_CURRICULO", SqlDbType.VarChar).Value = professor.DataAtualizacao;
                        comm.Parameters.Add("@ID_PERFIL", SqlDbType.Int).Value = 2;
                        comm.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = 1234567;


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

        public Professor BuscarUsuarioNome(string Nome)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM USUARIOS WHERE NOME_USUARIO = @NOME";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Professor professor = new Professor();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@NOME", SqlDbType.VarChar).Value = Nome;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                        professor.Nome = dr["NOME_USUARIO"].ToString();
                        professor.CPF = dr["CPF"].ToString();
                    }
                }

                return (professor);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Professor InserirProfessorIesAtuacaoGeral(Professor professor)
        {

            try
            {
                string conexao = ConexaoBanco();

                string inserirValores = @"INSERT INTO ATUACAO_IES_GERAL (MATRICULA, 
                                                                        DATA_ADMISSAO, 
                                                                        HORAS_NDE,      
                                                                        ORIENTACAO_TCC, 
                                                                        ATIVIDADE_EXTRA_CLASSE_CURSO,   
                                                                        COORDENACAO_CURSO, 
                                                                        COORDENACAO_OUTROS_CURSOS, 
                                                                        QTDE_HORAS_CURSO,
                                                                        QTDE_HORAS_OUTROS_CURSOS,
                                                                        PESQUISA,
                                                                        ID_USUARIO) 
                                                                    VALUES (@MATRICULA, 
                                                                            @DATA_ADMISSAO, 
                                                                            @HORAS_NDE, 
                                                                            @ORIENTACAO_TCC, 
                                                                            @ATIVIDADE_EXTRA_CLASSE_CURSO, 
                                                                            @COORDENACAO_CURSO, 
                                                                            @COORDENACAO_OUTROS_CURSOS, 
                                                                            @QTDE_HORAS_CURSO,
                                                                            @QTDE_HORAS_OUTROS_CURSOS,
                                                                            @PESQUISA,
                                                                            @ID_USUARIO)";


                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@MATRICULA", SqlDbType.Int).Value = professor.Matricula;
                        comm.Parameters.Add("@DATA_ADMISSAO", SqlDbType.DateTime).Value = professor.DataAdmissao;
                        comm.Parameters.Add("@HORAS_NDE", SqlDbType.Int).Value = professor.HorasNde;
                        comm.Parameters.Add("@ORIENTACAO_TCC", SqlDbType.Int).Value = professor.OrientacaoTcc;
                        comm.Parameters.Add("@ATIVIDADE_EXTRA_CLASSE_CURSO", SqlDbType.Int).Value = professor.AtividadesExtraClasseNoCurso;
                        comm.Parameters.Add("@COORDENACAO_CURSO", SqlDbType.Int).Value = professor.CoordenacaoCurso;
                        comm.Parameters.Add("@COORDENACAO_OUTROS_CURSOS", SqlDbType.Int).Value = professor.CoordenacaoOutrosCursos;
                        comm.Parameters.Add("@QTDE_HORAS_CURSO", SqlDbType.Int).Value = professor.QtdeHorasCurso;
                        comm.Parameters.Add("@QTDE_HORAS_OUTROS_CURSOS", SqlDbType.Int).Value = professor.QtdeHorasOutrosCursos;
                        comm.Parameters.Add("@PESQUISA", SqlDbType.Int).Value = professor.Pesquisa;
                        comm.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = professor.Id;


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

        public Professor InserirProfessorIesAtuacaoProfissional(Professor professor)
        {
            try
            {
                string conexao = ConexaoBanco();

                string inserirValores = @"INSERT INTO ATUACAO_PROFISSIONAL (MEMBRO_NDE, 
                                                                        MEMBRO_COLEGIADO, 
                                                                        DOCENTE_FORMACAO,      
                                                                        TEMPO_VINCULO, 
                                                                        TEMPO_MAGISTERIO_SUPERIOR,
                                                                        TEMPO_EXPERIENCIA_CURSO_DISTANCIA,   
                                                                        TEMPO_EXPERIENCIA_PROFISSIONAL, 
                                                                        PARTICIPACAO_EVENTOS, 
                                                                        ID_USUARIO) 
                                                                    VALUES (@MEMBRO_NDE, 
                                                                            @MEMBRO_COLEGIADO, 
                                                                            @DOCENTE_FORMACAO, 
                                                                            @TEMPO_VINCULO,
                                                                            @TEMPO_MAGISTERIO_SUPERIOR,
                                                                            @TEMPO_EXPERIENCIA_CURSO_DISTANCIA, 
                                                                            @TEMPO_EXPERIENCIA_PROFISSIONAL, 
                                                                            @PARTICIPACAO_EVENTOS, 
                                                                            @ID_USUARIO)";


                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@MEMBRO_NDE", SqlDbType.Bit).Value = professor.MembroNde;
                        comm.Parameters.Add("@MEMBRO_COLEGIADO", SqlDbType.Bit).Value = professor.MembroColegiado;
                        comm.Parameters.Add("@DOCENTE_FORMACAO", SqlDbType.Bit).Value = professor.DocenteFormacao;
                        comm.Parameters.Add("@TEMPO_VINCULO", SqlDbType.VarChar).Value = professor.TempoDeVinculoIniterrupto;
                        comm.Parameters.Add("@TEMPO_MAGISTERIO_SUPERIOR", SqlDbType.VarChar).Value = professor.TempoMagisterioSuperior;
                        comm.Parameters.Add("@TEMPO_EXPERIENCIA_CURSO_DISTANCIA", SqlDbType.VarChar).Value = professor.ExperienciaEmCursoADistacia;
                        comm.Parameters.Add("@TEMPO_EXPERIENCIA_PROFISSIONAL", SqlDbType.VarChar).Value = professor.TempoExperienciaProfissional;
                        comm.Parameters.Add("@PARTICIPACAO_EVENTOS", SqlDbType.Int).Value = professor.QtdeParticipacoesEventos;
                        comm.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = professor.Id;


                        sqlConn.Open();
                        comm.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return (null);
        }

        public Professor InserirProfessorIesPublicacoes(Professor professor)
        {
            try
            {
                string conexao = ConexaoBanco();

                string inserirValores = @"INSERT INTO PUBLICACOES_PROF (ARTIGOS_PUB_AREA, 
                                                                        ARTIGOS_PUB_OUTRAS_AREAS, 
                                                                        LIVROS_PUB_AREA,      
                                                                        LIVROS_PUB_OUTRAS_AREAS, 
                                                                        TRABALHOS_PUB_COMPLETOS,   
                                                                        TRABALHOS_PUB_RESUMOS, 
                                                                        PROPRIEDADE_INTELECTUAL_DEPOSITADO, 
                                                                        PROPRIEDADE_INTELECTUAL_REGISTRADO,
                                                                        TRADUCOES_LIVROS,
                                                                        PROJETOS_TECNICOS_ARTISTICOS,
                                                                        PRODUCAO_DIDATICO_PEDAGOGICO,
                                                                        ID_USUARIO) 
                                                                    VALUES (@ARTIGOS_PUB_AREA, 
                                                                            @ARTIGOS_PUB_OUTRAS_AREAS, 
                                                                            @LIVROS_PUB_AREA, 
                                                                            @LIVROS_PUB_OUTRAS_AREAS, 
                                                                            @TRABALHOS_PUB_COMPLETOS, 
                                                                            @TRABALHOS_PUB_RESUMOS, 
                                                                            @PROPRIEDADE_INTELECTUAL_DEPOSITADO, 
                                                                            @PROPRIEDADE_INTELECTUAL_REGISTRADO,
                                                                            @TRADUCOES_LIVROS,
                                                                            @PROJETOS_TECNICOS_ARTISTICOS,
                                                                            @PRODUCAO_DIDATICO_PEDAGOGICO,
                                                                            @ID_USUARIO)";


                using (SqlConnection sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
                    {
                        comm.Parameters.Add("@ARTIGOS_PUB_AREA", SqlDbType.Int).Value = professor.ArtigosPublicadosPeriodosCientificosNaArea;
                        comm.Parameters.Add("@ARTIGOS_PUB_OUTRAS_AREAS", SqlDbType.Int).Value = professor.ArtigosPublicadosPeriodosCientificosOutrasAreas;
                        comm.Parameters.Add("@LIVROS_PUB_AREA", SqlDbType.Int).Value = professor.LivrosPublicadosNaArea;
                        comm.Parameters.Add("@LIVROS_PUB_OUTRAS_AREAS", SqlDbType.Int).Value = professor.LivrosPublicadosEmOutrasAreas;
                        comm.Parameters.Add("@TRABALHOS_PUB_COMPLETOS", SqlDbType.Int).Value = professor.TrabalhosCompletosPublicadosAnuaisNaArea;
                        comm.Parameters.Add("@TRABALHOS_PUB_RESUMOS", SqlDbType.Int).Value = professor.TrabalhosResumosPublicadosAnuaisNaArea;
                        comm.Parameters.Add("@PROPRIEDADE_INTELECTUAL_DEPOSITADO", SqlDbType.Int).Value = professor.PropriedadeintelectualDepositado;
                        comm.Parameters.Add("@PROPRIEDADE_INTELECTUAL_REGISTRADO", SqlDbType.Int).Value = professor.PropriedadeIntelectualRegistrado;
                        comm.Parameters.Add("@TRADUCOES_LIVROS", SqlDbType.Int).Value = professor.TraducaoDeLivrosCapitulosArtigosPublicados;
                        comm.Parameters.Add("@PROJETOS_TECNICOS_ARTISTICOS", SqlDbType.Int).Value = professor.ProjetosProducoesTecnicosArtisticosCulturais;
                        comm.Parameters.Add("@PRODUCAO_DIDATICO_PEDAGOGICO", SqlDbType.Int).Value = professor.ProducaoDidaticoPedagogicoRelevante;
                        comm.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = professor.Id;


                        sqlConn.Open();
                        comm.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return (null);
        }

        public Usuario GetUsuario(string nome)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM USUARIOS WHERE NOME_USUARIO = @NOME";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Usuario usuario = new Usuario();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@NOME", SqlDbType.VarChar).Value = nome;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        usuario.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                        usuario.Nome = dr["NOME_USUARIO"].ToString();
                        usuario.CPF = dr["CPF"].ToString();
                        usuario.IdPerfil = Convert.ToInt32(dr["ID_PERFIL"]);
                        usuario.Senha = dr["SENHA"].ToString();
                    }
                }

                return (usuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Professor> GetProfessores()
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM USUARIOS WHERE ID_PERFIL = 2";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                List<Professor> professores = new List<Professor>();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        Professor professor = new Professor();
                        professor.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                        professor.Nome = dr["NOME_USUARIO"].ToString();
                        professor.CPF = dr["CPF"].ToString();
                        professores.Add(professor);
                    }
                }

                return (professores);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Professor GetProfessor(int id)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM USUARIOS WHERE ID_USUARIO = @ID";
                string stringBuscarIesGeral = @"SELECT * FROM ATUACAO_IES_GERAL WHERE ID_USUARIO = @ID_USUARIO";
                string stringBuscarAtuacaoProfissional = @"SELECT * FROM ATUACAO_PROFISSIONAL WHERE ID_USUARIO = @ID_USUARIO";
                string stringBuscarPublicacoesProf = @"SELECT * FROM PUBLICACOES_PROF WHERE ID_USUARIO = @ID_USUARIO";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Professor professor = new Professor();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                        professor.Nome = dr["NOME_USUARIO"].ToString();
                        professor.CPF = dr["CPF"].ToString();
                        professor.MaiorTitulacao = dr["MAIOR_TITULACAO"].ToString();
                        professor.AreaFormacao = dr["AREA_FORMACAO"].ToString();
                        professor.CurriculoLattos = dr["CURRICULO"].ToString();
                        professor.DataAtualizacao = Convert.ToDateTime(dr["DATA_ATUALIZACAO_CURRICULO"]);
                    }

                }

                using (SqlCommand leitor = new SqlCommand(stringBuscarIesGeral, sqlConn))
                {
                    leitor.Parameters.Add("@ID_USUARIO", SqlDbType.VarChar).Value = professor.Id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.Matricula = Convert.ToInt32(dr["MATRICULA"]);
                        professor.DataAdmissao = Convert.ToDateTime(dr["DATA_ADMISSAO"]);
                        professor.HorasNde = Convert.ToInt32(dr["HORAS_NDE"]);
                        professor.OrientacaoTcc = Convert.ToInt32(dr["ORIENTACAO_TCC"]);
                        professor.AtividadesExtraClasseNoCurso = Convert.ToInt32(dr["ATIVIDADE_EXTRA_CLASSE_CURSO"]);
                        professor.CoordenacaoCurso = Convert.ToInt32(dr["COORDENACAO_CURSO"]);
                        professor.CoordenacaoOutrosCursos = Convert.ToInt32(dr["COORDENACAO_OUTROS_CURSOS"]);
                        professor.QtdeHorasCurso = Convert.ToInt32(dr["QTDE_HORAS_CURSO"]);
                        professor.QtdeHorasOutrosCursos = Convert.ToInt32(dr["QTDE_HORAS_OUTROS_CURSOS"]);
                        professor.Pesquisa = Convert.ToInt32(dr["PESQUISA"]);
                    }
                }

                using (SqlCommand leitor = new SqlCommand(stringBuscarAtuacaoProfissional, sqlConn))
                {
                    leitor.Parameters.Add("@ID_USUARIO", SqlDbType.VarChar).Value = professor.Id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.MembroColegiado = Convert.ToBoolean(dr["MEMBRO_COLEGIADO"]);
                        professor.DocenteFormacao = Convert.ToBoolean(dr["DOCENTE_FORMACAO"]);
                        professor.TempoDeVinculoIniterrupto = dr["TEMPO_VINCULO"].ToString();
                        professor.TempoMagisterioSuperior = dr["TEMPO_MAGISTERIO_SUPERIOR"].ToString();
                        professor.ExperienciaEmCursoADistacia = dr["TEMPO_EXPERIENCIA_CURSO_DISTANCIA"].ToString();
                        professor.TempoExperienciaProfissional = dr["TEMPO_EXPERIENCIA_PROFISSIONAL"].ToString();
                        professor.QtdeParticipacoesEventos = Convert.ToInt32(dr["PARTICIPACAO_EVENTOS"]);
                    }
                }

                using(SqlCommand leitor = new SqlCommand(stringBuscarPublicacoesProf, sqlConn))
                {
                    leitor.Parameters.Add("@ID_USUARIO", SqlDbType.VarChar).Value = professor.Id;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.ArtigosPublicadosPeriodosCientificosNaArea = Convert.ToInt32(dr["ARTIGOS_PUB_AREA"]);
                        professor.ArtigosPublicadosPeriodosCientificosOutrasAreas = Convert.ToInt32(dr["ARTIGOS_PUB_OUTRAS_AREAS"]);
                        professor.LivrosPublicadosNaArea = Convert.ToInt32(dr["LIVROS_PUB_OUTRAS_AREAS"]);
                        professor.TrabalhosCompletosPublicadosAnuaisNaArea = Convert.ToInt32(dr["TRABALHOS_PUB_COMPLETOS"]);
                        professor.TrabalhosResumosPublicadosAnuaisNaArea = Convert.ToInt32(dr["TRABALHOS_PUB_RESUMOS"]);
                        professor.PropriedadeintelectualDepositado = Convert.ToInt32(dr["PROPRIEDADE_INTELECTUAL_DEPOSITADO"]);
                        professor.PropriedadeIntelectualRegistrado = Convert.ToInt32(dr["PROPRIEDADE_INTELECTUAL_REGISTRADO"]);
                        professor.TraducaoDeLivrosCapitulosArtigosPublicados = Convert.ToInt32(dr["TRADUCOES_LIVROS"]);
                        professor.ProjetosProducoesTecnicosArtisticosCulturais = Convert.ToInt32(dr["PROJETOS_TECNICOS_ARTISTICOS"]);
                        professor.ProducaoDidaticoPedagogicoRelevante = Convert.ToInt32(dr["PRODUCAO_DIDATICO_PEDAGOGICO"]);
                    }
                }

                return (professor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteProfessor(int id)
        {
            int retorno = 0;
            try
            {
                string conexao = ConexaoBanco();

                string stringDeletar = @"DELETE FROM USUARIOS WHERE ID_USUARIO = @id";

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
    
        public Professor BuscarAtuacaoIesGeral(int ID)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM ATUACAO_IES_GERAL WHERE ID_PERFIL = @ID";

                SqlConnection sqlConn = new SqlConnection(conexao);

                sqlConn.Open();

                Professor professor = new Professor();

                using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                {
                    leitor.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                    SqlDataReader dr = leitor.ExecuteReader();

                    while (dr.Read())
                    {
                        professor.Id = Convert.ToInt32(dr["ID_USUARIO"]);
                    }
                }

                return (professor);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //fim
    }
}