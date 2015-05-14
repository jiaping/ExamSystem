using System;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;

namespace JP.ExamSystem.ExamServer
{
    public class ServiceHostCollection : Collection<ServiceHost>, IDisposable
    {
        public ServiceHostCollection(params Type[] serviceTypes)
        {
            BatchingHostingSettings settings = BatchingHostingSettings.GetSection();
            foreach (ServiceTypeElement element in settings.ServiceTypes)
            {
                this.Add(element.ServiceType);
            }

            if (null != serviceTypes)
            {
                Array.ForEach<Type>(serviceTypes, serviceType => this.Add(new ServiceHost(serviceType)));
            }
        }
        public void Add(params Type[] serviceTypes)
        {
            if (null != serviceTypes)
            {
                Array.ForEach<Type>(serviceTypes, serviceType => this.Add(new ServiceHost(serviceType)));
            }
        }
        public void Open()
        {
            foreach (ServiceHost host in this)
            {
                host.Opened +=
                    (sender, arg) => Console.WriteLine("服务{0}开始监听！", (sender as ServiceHost).Description.ServiceType);
                host.Open();
            }
        }

      
        public void Dispose()
        {
            foreach (IDisposable host in this)
            {
                host.Dispose();
            }
        }
    }
}
