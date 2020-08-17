using System;
using System.Collections.Generic;
using System.Text;

namespace Holistica.Core._3_Domain_Model
{
   public class NewsletterSubscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }

        public NewsletterSubscription(string name, string email, string code = null)
        {
            Name = name;
            Email = email;
            Code = code ?? new Guid().ToString();
        }

        public NewsletterSubscription()
        {
            
        }
    }
}
