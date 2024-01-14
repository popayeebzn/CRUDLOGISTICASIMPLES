using GABRIELPROJETOV1.Data;
using GABRIELPROJETOV1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GABRIELPROJETOV1.Repositorio
{
    public class MateriaisRepositorio : IMateriaisRepositorio
    {
        private readonly BancoContext _bancoContext;

        public MateriaisRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public MateriaisModel Adicionar(MateriaisModel material)
        {
            // Carregue o fornecedor relacionado
            material.Fornecedor = _bancoContext.Fornecedores.Find(material.FornecedorId);

            _bancoContext.Materiais.Add(material);
            _bancoContext.SaveChanges();

            return material;
        }


        public List<MateriaisModel> BuscarTodos()
        {
            return _bancoContext.Materiais.Include(m => m.Fornecedor).ToList();
        }

        public MateriaisModel ListarPorId(int id)
        {
            return _bancoContext.Materiais.FirstOrDefault(x => x.Id == id);
        }

        public MateriaisModel Alterar(MateriaisModel material)
        {
            MateriaisModel materialDB = ListarPorId(material.Id);

            if (materialDB == null)
            {
                throw new Exception("Material não encontrado.");
            }

            materialDB.Nome = material.Nome;
            materialDB.Quantidade = material.Quantidade;
            materialDB.FornecedorId = material.FornecedorId; // Certifique-se de que esta atribuição está correta

            _bancoContext.Materiais.Update(materialDB);
            _bancoContext.SaveChanges();

            return materialDB;
        }

        public bool Apagar(int id)
        {
            MateriaisModel materialDB = ListarPorId(id);

            if (materialDB == null)
            {
                throw new Exception("Material não encontrado.");
            }

            _bancoContext.Materiais.Remove(materialDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public void Excluir(int materialId)
        {
            var material = _bancoContext.Materiais.FirstOrDefault(m => m.Id == materialId);

            if (material != null)
            {
                _bancoContext.Materiais.Remove(material);
                _bancoContext.SaveChanges();
            }
        }
    }
}
