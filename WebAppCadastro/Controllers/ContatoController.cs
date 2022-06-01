using Microsoft.AspNetCore.Mvc;
using System;
using WebAppCadastro.Models;
using WebAppCadastro.Repository;

namespace WebAppCadastro.Controllers
{
    public class ContatoController: Controller
    {
        private readonly IContatoRepository _context;
        public ContatoController(IContatoRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaDeContatos = _context.BuscarTodos();
            return View(listaDeContatos);
        }
        public IActionResult Criar()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";

                return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar contato! - Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");                
            }
            
        }
        public IActionResult Editar(int id)
        {
            var contato = _context.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Atualizar(contato);

                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";

                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao alterar contato! - Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _context.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";                    
                }
                else
                {
                    TempData["MensagemErro"] = $"Erro ao tentar apagar o contato!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao tentar apagar o contato! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _context.BuscarPorId(id);
            return View(contato);
        }
    }
}
