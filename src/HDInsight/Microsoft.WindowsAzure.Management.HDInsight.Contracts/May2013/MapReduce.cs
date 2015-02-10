using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class MapReduce
    {

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public MapReduceConfiguration Configuration { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public CapacitySchedulerConfiguration CapacitySchedulerConfiguration { get; set; }

        public MapReduce()
        {
            Configuration = new MapReduceConfiguration();
            CapacitySchedulerConfiguration = new CapacitySchedulerConfiguration();
        }

    }

    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class MapReduceConfiguration : ConfigurationPropertyList
    {
    }
}
