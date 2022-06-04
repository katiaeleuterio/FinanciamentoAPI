using System;
using System.ComponentModel.DataAnnotations;

namespace BikeFit.Models
{
    public class AtletaDadosPessoais
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        public string CEP { get; set; }

        public string UF { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }
    }
}
