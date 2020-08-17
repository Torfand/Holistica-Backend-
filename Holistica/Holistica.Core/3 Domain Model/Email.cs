using System;
using System.Collections.Generic;
using System.Text;

namespace Holistica.Core._3_Domain_Model
{
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Email(string to, string @from, string subject, string content)
        {
            To = to;
            From = @from;
            Subject = subject;
            Content = content;
        }

        public Email()
        {
            
        }
    }
}
