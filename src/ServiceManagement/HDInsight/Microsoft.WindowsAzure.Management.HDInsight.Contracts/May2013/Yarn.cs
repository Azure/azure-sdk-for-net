using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Yarn
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public YarnConfiguration Configuration { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public CapacitySchedulerConfiguration CapacitySchedulerConfiguration { get; set; }

        public Yarn()
        {
            Configuration = new YarnConfiguration();
            CapacitySchedulerConfiguration = new CapacitySchedulerConfiguration();
        }
    }

    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class YarnConfiguration : ConfigurationPropertyList
    {
    }
}