namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departamento")]
    public partial class Departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamento()
        {
            Cabecera = new HashSet<Cabecera>();
        }

        [Key]
        public int IdDep { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [StringLength(40)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cabecera> Cabecera { get; set; }
    }
}
