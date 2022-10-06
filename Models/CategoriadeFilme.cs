using System;
using System.ComponentModel.DataAnnotations;

namespace locadora.Models
{
    public class CategoriadeFilme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(
            100,
            ErrorMessage = "O campo de nome deve conter no máximo 100 caracteres!"
        )]
        public String Nome { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(
            100,
            ErrorMessage = "O campo de nome deve conter no máximo 100 caracteres!"
        )]
        public String Descricao { get; set; }
    }

}