using ContabilidadeProcessor.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ContabilidadeProcessor.Services;

public class LancamentoReader
{
    public List<LancamentoContabil> LerLancamentos(string arquivo)
    {
        List<LancamentoContabil> lancamentos = new List<LancamentoContabil>();

        string caminho = arquivo;
        string[] linhas = File.ReadAllLines(caminho);

        for (int i = 0; i < linhas.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(linhas[i]) || linhas[i].Trim().StartsWith("#"))
                continue;

            try
            {
                string dataStr = linhas[i++].Split(":", 2)[1].Trim();
                string contaStr = linhas[i++].Split(":", 2)[1].Trim();
                string historico = linhas[i++].Split(":", 2)[1].Trim();
                string valorStr = linhas[i++].Split(":", 2)[1].Trim();
                string tipoStr = linhas[i++].Split(":", 2)[1].Trim();


                if (string.IsNullOrWhiteSpace(dataStr) || string.IsNullOrWhiteSpace(contaStr) || string.IsNullOrWhiteSpace(valorStr) || string.IsNullOrWhiteSpace(tipoStr))
                {
                    Console.WriteLine($"Algum dos dados no bloco anterior da linha {i + 1} são inválidos! Favor Corrigir.");
                    continue;
                }

                LancamentoContabil l = new()
                {
                    Data = DateTime.Parse(dataStr),
                    Conta = contaStr,
                    Historico = historico,
                    Valor = decimal.Parse(valorStr),
                    Tipo = tipoStr,
                };

                lancamentos.Add(l);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar lançamento na linha {i + 1}: O dado não estava no formato correto");
            }
        }

        return lancamentos;
    }
}


