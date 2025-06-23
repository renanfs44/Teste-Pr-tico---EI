namespace ContabilidadeProcessor.Models;

public class LancamentoContabil
{
    public DateTime Data { get; set; }
    public string Conta { get; set; }
    public string Historico { get; set; }
    public decimal Valor { get; set; }
    public string Tipo { get; set; } // Débito ou Crédito

}
