using GABRIELPROJETOV1.Data;
using GABRIELPROJETOV1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GABRIELPROJETOV1.Repositorio
{
    public class FornecedoresRepositorio : IFornecedoresRepositorio
    {

        private readonly BancoContext _bancoContext;

        public FornecedoresRepositorio(BancoContext bancoContext)
        {

            _bancoContext = bancoContext;

        }    

        public FornecedoresModel Adicionar(FornecedoresModel Fornecedor)
        {
            //aqui grava no banco de dados

            _bancoContext.Fornecedores.Add(Fornecedor);
            _bancoContext.SaveChanges();

            return (Fornecedor);
        }

        public List<FornecedoresModel> BuscarTodos()
        {
            
            return _bancoContext.Fornecedores.ToList();

        }

        public FornecedoresModel Alterar(FornecedoresModel fornecedor)
        {
            FornecedoresModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um ERRO na alteração do Fornecedor");

            fornecedorDB.Nome = fornecedor.Nome;
            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.SITE = fornecedor.SITE;
            fornecedorDB.ENDEREÇO = fornecedor.ENDEREÇO;
            fornecedorDB.CEP = fornecedor.CEP;
            fornecedorDB.Representante = fornecedor.Representante;
            fornecedorDB.Email = fornecedor.Email;
            fornecedorDB.Contato = fornecedor.Contato;

            _bancoContext.Fornecedores.Update(fornecedorDB);
            _bancoContext.SaveChanges();
            return fornecedorDB;
        }

        public FornecedoresModel ListarPorId(int Id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == Id);
        }

        public bool Apagar(int Id)
        {
            FornecedoresModel fornecedorDB = ListarPorId(Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um ERRO na Exclusão do Fornecedor");

            _bancoContext.Fornecedores.Remove(fornecedorDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
