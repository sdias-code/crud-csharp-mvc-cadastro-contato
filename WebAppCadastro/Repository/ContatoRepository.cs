using System;
using System.Collections.Generic;
using System.Linq;
using WebAppCadastro.Data;
using WebAppCadastro.Models;

namespace WebAppCadastro.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _context;
        public ContatoRepository(BancoContext context)
        {
            _context = context;
        }
        public ContatoModel BuscarPorId(int id)
        {            
            var contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            return contato;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            var contatoDb = BuscarPorId(contato.Id);
            if(contatoDb == null)
            {
                throw new Exception("Contato não encontrado");
            }

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Telefone = contato.Telefone;

            _context.Update(contatoDb);
            _context.SaveChanges();
            return contatoDb;
        }

        public bool Apagar(int id)
        {
            var contato = BuscarPorId(id);

            if (contato == null)
            {
                throw new Exception("Contato não encontrado, não foi possível apagar!");
            }
            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return true;
        }
    }
}
