namespace Shop_T_H.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupportOnline")]
    public partial class SupportOnline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Department { get; set; }

        [StringLength(250)]
        public string Skype { get; set; }

        [StringLength(250)]
        public string Mobie { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string FaceBook { get; set; }

        public bool? Status { get; set; }
    }
}
