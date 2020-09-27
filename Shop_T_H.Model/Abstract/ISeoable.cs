using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_T_H.Model.Abstract
{
    public  interface ISeoable
    {
        string MetaKeyWord { set; get; }
        string MetaDescription { set; get; }

    }
}
