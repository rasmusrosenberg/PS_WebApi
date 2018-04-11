namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubBlock")]
    public partial class SubBlock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubBlock()
        {
            TrialGroup = new HashSet<TrialGroup>();
        }

        public int SubBlockID { get; set; }

        public int? FieldBlockID { get; set; }

        [StringLength(1)]
        public string SubBlockChar { get; set; }

        public int? AmountOfTrialGroups { get; set; }

        public int? LastNrOfTrialGroup { get; set; }

        public int? SubBlockLength { get; set; }

        public int? SubBlockWidth { get; set; }

        public int? PosL { get; set; }

        public int? PosW { get; set; }

        public int? TrialTypeID { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public virtual FieldBlock FieldBlock { get; set; }

        public virtual TrialType TrialType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrialGroup> TrialGroup { get; set; }
    }
}
