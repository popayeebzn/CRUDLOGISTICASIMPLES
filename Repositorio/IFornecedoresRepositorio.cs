using GABRIELPROJETOV1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GABRIELPROJETOV1.Repositorio
{
    public interface IFornecedoresRepositorio
    {

        FornecedoresModel ListarPorId(int Id);
         

        List<FornecedoresModel> BuscarTodos();

        FornecedoresModel Adicionar(FornecedoresModel Fornecedor);

        FornecedoresModel Alterar(FornecedoresModel Fornecedor);

        bool Apagar(int Id);

    }
}
