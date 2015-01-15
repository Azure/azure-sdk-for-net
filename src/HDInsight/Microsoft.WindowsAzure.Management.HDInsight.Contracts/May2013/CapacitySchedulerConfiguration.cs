using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class CapacitySchedulerConfiguration : ConfigurationPropertyList
    {
    }
}
