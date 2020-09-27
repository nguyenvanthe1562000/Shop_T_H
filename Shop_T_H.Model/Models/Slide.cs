namespace Shop_T_H.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(550)]
        public string Image { get; set; }

        public bool? Status { get; set; }
    }
}
