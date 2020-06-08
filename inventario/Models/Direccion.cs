namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Direccion")]
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            Persona = new HashSet<Persona>();
        }

        [Key]
        public int IdDir { get; set; }

        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [StringLength(40)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Ciudad { get; set; }


        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][0-9A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [StringLength(40)]
        public string Calle { get; set; }

        [RegularExpression(@"[0-9]+", ErrorMessage = "Formato Inv·lido")]
        public int NumExt { get; set; }

        [RegularExpression(@"[0-9]+", ErrorMessage = "Formato Inv·lido")]
        public int? NumInt { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"[0-9]{5}", ErrorMessage = "Formato Inv·lido")]
        public int CodePostal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
