using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1)]
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [MaxLength(90, ErrorMessage = "El nombre no debe ser mayor a 90 caracteres.")]
        [Column("name", Order = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [MaxLength(200, ErrorMessage = "La descripción no debe ser mayor a 200 caracteres.")]
        [Column("description", Order = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio es requerid0.")]
        [Column("price", Order = 4)]
        public decimal Price { get; set; }

    }
}
