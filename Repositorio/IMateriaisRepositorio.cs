using GABRIELPROJETOV1.Models;
using System.Collections.Generic;

namespace GABRIELPROJETOV1.Repositorio
{
    public interface IMateriaisRepositorio
    {
        MateriaisModel Adicionar(MateriaisModel material);
        List<MateriaisModel> BuscarTodos();
        MateriaisModel ListarPorId(int id);
        MateriaisModel Alterar(MateriaisModel material);
        bool Apagar(int id);

        void Excluir(int materialId);
    }
}