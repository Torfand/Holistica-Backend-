using System;
using System.Collections.Generic;
using System.Text;

namespace Holistica.Core._3_Domain_Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; }


        public BaseEntity(Guid id)
        {
            Id = Guid.NewGuid();
;

        }
    }
}
