namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FieldBlock")]
    public partial class FieldBlock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FieldBlock()
        {
            SubBlock = new HashSet<SubBlock>();
        }

        public int FieldBlockID { get; set; }

        [StringLength(1)]
        public string BlockChar { get; set; }

        public int? FieldBlockYear { get; set; }

        public int? FieldBlockLength { get; set; }

        public int? FieldBlockWidth { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubBlock> SubBlock { get; set; }
    }
}
