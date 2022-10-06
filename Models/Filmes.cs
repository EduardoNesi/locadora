using System;
using System.ComponentModel.DataAnnotations;

namespace locadora.Models
{
    public class Filmes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(
           100,
           ErrorMessage = "O campo de nome deve conter no máximo 100 caracteres!"
       )]
        public String Nome { get; set; }
        [Required(ErrorMessage = "O campo produtora é obrigatório.")]
        [StringLength(
           100,
           ErrorMessage = "O campo de produtora deve conter no máximo 100 caracteres!"
       )]
        public String Produtora { get; set; }
        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        [Range(
            0,
            999,
            ErrorMessage = "O valor do produto deve ser até R$999."
        )]
        public float Preco { get; set; }
        public int CategoriadeFilmeId { get; set; }
        public CategoriadeFilme CategoriadeFilme { get; set; }
    }

}