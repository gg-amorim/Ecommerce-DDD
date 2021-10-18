using Entities.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("Product")]
    public class Produto : Notifies
    {
        [Column("PROD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PROD_NOME")]
        [Display(Name = "Nome")]
        public int Nome { get; set; }

        [Column("PROD_VALOR")]
        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Column("PROD_ESTADO")]
        [Display(Name = "Estado")]
        public int Estado { get; set; }
    }
}