namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treatment_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treatment_Product()
        {
            Result = new HashSet<Result>();
        }

        [Key]
        public int TreatmentProductID { get; set; }

        public int? TreatmentID { get; set; }

        public int? ProductID { get; set; }

        public decimal? ProductDose { get; set; }

        [StringLength(10)]
        public string ProductUnit { get; set; }

        public bool? DoseLog { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        public virtual Treatment Treatment { get; set; }

        public virtual UnitType UnitType { get; set; }
    }
}
