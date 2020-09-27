namespace Shop_T_H.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerMobie { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [StringLength(250)]
        public string CustomerMessage { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string Createby { get; set; }

        [StringLength(250)]
        public string PaymentMethod { get; set; }

        public bool? PaymentStatus { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
