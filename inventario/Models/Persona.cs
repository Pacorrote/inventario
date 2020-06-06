namespace inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Cliente = new HashSet<Cliente>();
            Empleado = new HashSet<Empleado>();
        }

        [Key]
        public int IdPer { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Apellido1 { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"^[A-Z¡…Õ”⁄][A-Za-z·ÈÌÛ˙\s]+", ErrorMessage = "Formato Inv·lido")]
        [StringLength(40)]
        public string Apellido2 { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        [RegularExpression(@"M|F", ErrorMessage = "Formato Incorrecto: Respuestas M/F (Masculino/Femenino)")]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Este campo {0} es obligatorio")]
        public int IdDir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        public virtual Direccion Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
