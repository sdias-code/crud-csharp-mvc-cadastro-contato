using System.Collections.Generic;
using WebAppCadastro.Models;

namespace WebAppCadastro.Repository
{
    public interface IContatoRepository
    {
        public ContatoModel BuscarPorId(int id);
        public List<ContatoModel> BuscarTodos();
        public ContatoModel Atualizar(ContatoModel contato);
        public ContatoModel Adicionar(ContatoModel contatoModel);
        public bool Apagar(int id);
    }
}
