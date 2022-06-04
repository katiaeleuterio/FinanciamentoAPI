using System.ComponentModel.DataAnnotations;

namespace BikeFit.Models
{
    public class AtletaMedidasAntropometricasModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int IdAtleta { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal Cavalo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal Antebraco { get; set; }

        //Valor entre 0 e 10
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Flexibilidade { get; set; }
    }
}
