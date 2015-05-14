using System.ServiceModel;
using System.ServiceModel.Channels;

namespace JP.ExamSystem.ExamService
{
    public class ClientIPHelper
    {
        public static ClientIPHelper Instance()
        {
            return new ClientIPHelper();
        }

        public string ClientIp()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address;
        }

        public string ClientPort()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Port.ToString();
        }

        public string ClientIpAndPort()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address + ";" + endpoint.Port.ToString();
        }
    }
}
