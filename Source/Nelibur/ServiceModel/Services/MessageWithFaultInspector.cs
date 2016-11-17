using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Nelibur.ServiceModel.Services
{
    internal class MessageWithFaultInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (reply == null)
                return;

            if (!reply.IsFault)
                return;

            var fault = RetrieveSoapServiceFaultFromMessage(reply);
            throw fault;
        }

        private NeliburFaultException RetrieveSoapServiceFaultFromMessage(Message reply)
        {
            // todo: make the max message buffer size configurable?
            var messageFault = MessageFault.CreateFault(reply, 24000);
            return new NeliburFaultException(messageFault);
        }
    }
}
