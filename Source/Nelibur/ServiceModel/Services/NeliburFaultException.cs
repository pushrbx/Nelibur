using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Nelibur.ServiceModel.Services
{
    public class NeliburFaultException : FaultException
    {
        public NeliburFaultException()
        {
        }

        public NeliburFaultException(string message) : base(message)
        {
        }

        public NeliburFaultException(MessageFault fault) : base(fault)
        {
        }
    }
}
