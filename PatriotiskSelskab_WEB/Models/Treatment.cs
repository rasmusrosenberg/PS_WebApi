namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treatment()
        {
            Treatment_Product = new HashSet<Treatment_Product>();
        }

        public int TreatmentID { get; set; }

        public int? TrialGroupID { get; set; }

        public int? TreatmentTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TreatmentDate { get; set; }

        [StringLength(50)]
        public string TreatmentStage { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public virtual TreatmentType TreatmentType { get; set; }

        public virtual TrialGroup TrialGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment_Product> Treatment_Product { get; set; }
    }
}
