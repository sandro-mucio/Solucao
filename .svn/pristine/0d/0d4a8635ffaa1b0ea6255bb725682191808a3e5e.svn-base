using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{

    public class UsuarioBO
    {
        //properties
        private string cnn = string.Empty;
        private DCBancoDataContext bco;

        //constructors
        public UsuarioBO(string conexao)
        {
            this.cnn = conexao;
            bco = new DCBancoDataContext(cnn);
        }

        #region ações
        public int inserir(string nome, string login, string senha, string email, string observacoes, int nivel)
        {
            try
            {
                Usuario obj = new Usuario();

                obj.login = login;
                obj.senha = senha;
                obj.email = email;
                obj.nivel = nivel;
                obj.nome = nome;
                obj.observacoes = observacoes;

                obj.ativo = true;
                obj.data = DateTime.Now;

                bco.Usuarios.InsertOnSubmit(obj);
                bco.SubmitChanges();
                return obj.id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public int alterar(int id, string nome, string login, string senha, string email, string observacoes, bool ativo, int nivel)
        {
            try
            {
                Usuario obj = bco.Usuarios.FirstOrDefault(x => x.id == id);
                if (obj == null) { throw new Exception("Usuário não localizado."); }

                obj.login = login;
                if (!string.IsNullOrEmpty(senha))
                {
                    obj.senha = senha;
                }
                obj.email = email;
                obj.nivel = nivel;
                obj.nome = nome;
                obj.observacoes = observacoes;
                obj.ativo = ativo;

                obj.data = DateTime.Now;

                bco.SubmitChanges();
                return obj.id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void excluir(int id)
        {
            try
            {
                Usuario obj = bco.Usuarios.FirstOrDefault(x => x.id == id);
                if (obj == null) { throw new Exception("Usuário não localizado."); }
                bco.Usuarios.DeleteOnSubmit(obj);
                bco.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        #region consultas
        public List<Usuario> listar()
        {
            try
            {
                return bco.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Usuario PorId(int id)
        {
            try
            {
                return bco.Usuarios.FirstOrDefault((x) => x.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Usuario PorNome(string nome)
        {
            try
            {
                return bco.Usuarios.FirstOrDefault((x) => x.nome.Contains(nome));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Usuario PorLogin(string login)
        {
            try
            {
                return bco.Usuarios.FirstOrDefault((x) => x.login.Equals(login));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Usuario PorEmail(string email)
        {
            try
            {
                return bco.Usuarios.FirstOrDefault((x) => x.email.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region auxiliares
        //private

        #endregion
    }
}
