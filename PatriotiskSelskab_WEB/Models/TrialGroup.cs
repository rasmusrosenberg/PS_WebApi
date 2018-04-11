namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrialGroup")]
    public partial class TrialGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrialGroup()
        {
            Treatment = new HashSet<Treatment>();
        }

        public int TrialGroupID { get; set; }

        public int? SubBlockID { get; set; }

        public int? CropID { get; set; }

        public int? TrialGroupNr { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public virtual Crop Crop { get; set; }

        public virtual SubBlock SubBlock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}
