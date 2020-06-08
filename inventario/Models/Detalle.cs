namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detalle")]
    public partial class Detalle
    {
        [Key]
        public int IdDet { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdCab { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdPro { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Formato Inválido")]
        [Range(1,1000, ErrorMessage = "Este campo {0} requiere un número entre {1} y {2}")]
        [Column(TypeName = "numeric")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Formato Inválido")]
        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        public virtual Cabecera Cabecera { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
