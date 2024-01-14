using GABRIELPROJETOV1.Models;
using GABRIELPROJETOV1.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GABRIELPROJETOV1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFornecedoresRepositorio _fornecedoresRepositorio;
        private readonly IMateriaisRepositorio _materiaisRepositorio;

        public HomeController(IFornecedoresRepositorio fornecedoresRepositorio, IMateriaisRepositorio materiaisRepositorio)
        {
            _fornecedoresRepositorio = fornecedoresRepositorio;
            _materiaisRepositorio = materiaisRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CFornecedores()
        {
            return View();
        }
        
        public IActionResult MEstoques()
        {

            List<MateriaisModel> materiais = _materiaisRepositorio.BuscarTodos(); // Substitua isso pelo método real do seu repositório
            return View(materiais);
        }
        public IActionResult GRelatorios()
        {
            return View();
        }

        public IActionResult ListaFornecedores()
        {
            List<FornecedoresModel> fornecedores = _fornecedoresRepositorio.BuscarTodos();

            return View(fornecedores);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {

            FornecedoresModel fornecedores = _fornecedoresRepositorio.ListarPorId(Id);
            return View(fornecedores);
        }

        public IActionResult Editar(int Id)
        {
            FornecedoresModel fornecedores = _fornecedoresRepositorio.ListarPorId(Id);
            return View(fornecedores);
        }

        public IActionResult Informacoes(int Id)
        {
            FornecedoresModel fornecedores = _fornecedoresRepositorio.ListarPorId(Id);
            return View(fornecedores);
        }

        public IActionResult VerInfo()
        {
            return View();
        }

        public IActionResult Apagar(int id)
        {
            _fornecedoresRepositorio.Apagar(id);
            
            return RedirectToAction("ListaFornecedores");

        }

        //aqui criar cadastro


        [HttpPost]
        public IActionResult CFornecedores(FornecedoresModel Fornecedor)
        {
            _fornecedoresRepositorio.Adicionar(Fornecedor);

            return RedirectToAction("ListaFornecedores");
        }


        [HttpPost]
        public IActionResult CFornecedoresAlterar(FornecedoresModel Fornecedor)
        {
            _fornecedoresRepositorio.Alterar(Fornecedor);

            return RedirectToAction("ListaFornecedores");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        // materiais



        public IActionResult CMateriais()
        {

            var fornecedores = _fornecedoresRepositorio.BuscarTodos();

            ViewBag.Fornecedores = fornecedores;

            return View();
        }

        [HttpPost]
        public IActionResult CMateriais(MateriaisModel material)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionar o material usando o repositório de materiais
                    var materialCadastrado = _materiaisRepositorio.Adicionar(material);

                    // Redirecionar para a página de informações do material recém-cadastrado
                    return RedirectToAction("MEstoques", new { id = materialCadastrado.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao cadastrar o material: {ex.Message}");
                }
            }

            // Recarregar a lista de fornecedores para preencher o dropdown
            ViewBag.Fornecedores = _fornecedoresRepositorio.BuscarTodos();

            return View(material);
        }



        // TESTE LISTA MATERIAIS



        [HttpPost]
        public IActionResult AumentarQuantidade(int materialId)
        {
            // Encontrar o material no repositório
            var material = _materiaisRepositorio.ListarPorId(materialId);

            // Aumentar a quantidade em 1
            material.Quantidade++;

            // Atualizar o material no banco de dados
            _materiaisRepositorio.Alterar(material);

            // Redirecionar de volta para a página
            return RedirectToAction("MEstoques");
        }

        [HttpPost]
        public IActionResult DiminuirQuantidade(int materialId)
        {
            // Encontrar o material no repositório
            var material = _materiaisRepositorio.ListarPorId(materialId);

            // Diminuir a quantidade em 1, garantindo que não seja negativa
            material.Quantidade = Math.Max(0, material.Quantidade - 1);

            // Atualizar o material no banco de dados
            _materiaisRepositorio.Alterar(material);

            // Redirecionar de volta para a página
            return RedirectToAction("MEstoques");
        }


        [HttpPost]
        public IActionResult ExcluirMaterial(int materialId)
        {
            // Encontrar o material no repositório
            var material = _materiaisRepositorio.ListarPorId(materialId);

            if (material != null)
            {
                // Excluir o material do banco de dados
                _materiaisRepositorio.Excluir(materialId);
            }
            else
            {
                // Adicione uma mensagem de depuração
                Console.WriteLine($"Material com ID {materialId} não encontrado.");
            }

            // Redirecionar de volta para a página
            return RedirectToAction("MEstoques");
        }
    }
}
