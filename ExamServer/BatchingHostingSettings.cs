using System;
using System.ComponentModel;
using System.Configuration;

namespace JP.ExamSystem.ExamServer
{
    public class BatchingHostingSettings:ConfigurationSection
    {
        [ConfigurationProperty("",IsDefaultCollection=true)]
        public ServiceTypeElementCollection ServiceTypes
        {
            get
            {
                var aa = this[""];
                var bb = (ServiceTypeElementCollection) aa;
                return bb ;
            }
        }

        public static BatchingHostingSettings GetSection()
        {
            var cc=ConfigurationManager.GetSection("examSystem.batchingHosting");
            var bb=cc as BatchingHostingSettings;
            return bb;
        }
    }

    
        public class  ServiceTypeElementCollection:ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new ServiceTypeElement();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                ServiceTypeElement serviceTypeElement = (ServiceTypeElement) element;
                return serviceTypeElement.ServiceType.MetadataToken;
            }
        }

    public class ServiceTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("type",IsRequired = true )]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type ServiceType
        {
            get { return (Type) this["type"]; }
            set { this["type"] = value; }
        }
    }
}
