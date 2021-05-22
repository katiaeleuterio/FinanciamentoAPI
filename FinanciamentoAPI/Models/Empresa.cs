using System;
using System.ComponentModel.DataAnnotations;

namespace FinanciamentoAPI.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int QtdAnos { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor da parcela deve ser maior que zero.")]
        public double ValorParcela { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor da entrada deve ser maior que zero.")]
        public double ValorEntrada { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor da taxa de juros deve ser maior que 0.1.")]
        public double TaxaJuros { get; set; }
    }
}
