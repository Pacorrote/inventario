namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cabecera")]
    public partial class Cabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cabecera()
        {
            Detalle = new HashSet<Detalle>();
        }

        [Key]
        public int IdCab { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdMov { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdCli { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdEmp { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdDep { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Formato inválido")]
        [StringLength(10)]
        public string Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Departamento Departamento { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Movimiento Movimiento { get; set; }
    }
}
