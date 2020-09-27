using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_T_H.Model.Abstract
{
    public abstract class AudiTable : IAuditable,ISeoable,ISwitchable
    {
        public DateTime? CreateDate { get ; set ; }
        [MaxLength(256)]
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string UpdateBy { get; set; }
        public string MetaKeyWord { get ; set ; }
        public string MetaDescription { get ; set ; }
        public bool Status { get ; set ; }
    }
}
