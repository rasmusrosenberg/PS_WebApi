namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultID { get; set; }

        public int? TreatmentProductID { get; set; }

        [StringLength(50)]
        public string ResultValue { get; set; }

        [StringLength(10)]
        public string ResultUnit { get; set; }

        public virtual Treatment_Product Treatment_Product { get; set; }
    }
}
