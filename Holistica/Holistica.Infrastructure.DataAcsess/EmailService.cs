using Holistica.Core._2_Domain_Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Infrastructure.DataAcsess
{
    public class EmailService : IEmailService
    {
        public async Task<bool> Send(Email email)
        {
            var fname = email.To.Remove(0, 4);
            string path = @$"C:\Skole\Yoga - Oppgave\Holistica\FileCreateTest\{fname}.txt";
            string[] mail = { email.To, email.From, email.Subject, email.Content };
            File.WriteAllLines(path, mail);
            return await Task.FromResult(true); // needs mail service implementation (Sendgrid ???)

        }
    }
}
