using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Services
{
    public class NullMailService : IMailService
    {

        private readonly ILogger<NullMailService> logger;
        public NullMailService(ILogger<NullMailService> logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {

            logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
            // log the message


        }
    }
}
