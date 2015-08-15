using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Core
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public CoreConfiguration Configuration { get; set; }

        public Core()
        {
            Configuration = new CoreConfiguration();
        }

        [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
        public class CoreConfiguration : ConfigurationPropertyList
        {
        }
    }
}
