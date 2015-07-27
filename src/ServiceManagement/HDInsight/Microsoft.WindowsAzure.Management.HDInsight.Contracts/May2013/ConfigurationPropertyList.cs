using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [CollectionDataContract(Namespace = Constants.XsdNamespace)]
    public class ConfigurationPropertyList : List<Property>
    {
    }
}
