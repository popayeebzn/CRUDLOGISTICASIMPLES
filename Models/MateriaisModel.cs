using GABRIELPROJETOV1.Models;

    public class MateriaisModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public int FornecedorId { get; set; }

    // Propriedade de navegação para o Fornecedor
    public FornecedoresModel Fornecedor { get; set; }
}
