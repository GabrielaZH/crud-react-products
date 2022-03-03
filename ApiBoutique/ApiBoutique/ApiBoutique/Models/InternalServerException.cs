using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Models
{
    public class InternalServerException:Exception
    {
        public string clientMessage { get; set; }
        public InternalServerException(string message, string clientMessage) : base(message)
        {
            this.clientMessage = clientMessage;
        }
    }
}
