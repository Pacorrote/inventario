namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Detalle = new HashSet<Detalle>();
        }

        [Key]
        public int IdPro { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdProv { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [Column(TypeName = "numeric")]
        public decimal CostoUnitario { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [StringLength(40)]
        public string Unidad { get; set; }

        [Range(1, 1000, ErrorMessage = "El campo {0} debe ser entre {1} y {2}")]
        public int Cantidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
