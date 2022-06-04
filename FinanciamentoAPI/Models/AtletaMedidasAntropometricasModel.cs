using System.ComponentModel.DataAnnotations;

namespace BikeFit.Models
{
    //Medidas antropométricas do atleta
    public class AtletaMedidasAntropometricasModel
    {
        [Key]
        public int Id { get; set; }

        //fk horiunda da tabela AtletaDadosPessoais
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int IdAtleta { get; set; }

        //Velor em cm
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal Cavalo { get; set; }

        //Valor em cm
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal Antebraco { get; set; }

        //Valor entre 0 e 10
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Flexibilidade { get; set; }
    }
}
