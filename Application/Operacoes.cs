using Application.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace Application
{
    [Table("OperacoesHistorico")]
    public class Operacoes
    {
        public Operacoes()
        {
            
        }
        public Operacoes(string nome, float result, DateTime dataHora)
        {
            NomeOperacao = nome;
            Resultado = result;
            DataHoraOperacao = dataHora;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NomeOperacao { get; set; }
        public double Resultado { get; set; }
        public DateTime DataHoraOperacao { get; set; }

        public static float Soma(float n1, float n2)
        {
            return n1 + n2;
        }

        public static float Subtracao(float n1, float n2)
        {
            return n1 - n2;
        }

        public static float Multiplicacao(float n1, float n2)
        {
            return n1 * n2;
        }

        public static float Divisao(float n1, float n2)
        {
            return n1 / n2;
        }

    }
}