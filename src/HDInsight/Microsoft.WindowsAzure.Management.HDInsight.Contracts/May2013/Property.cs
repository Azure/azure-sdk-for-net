using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Property
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Value { get; set; }
    }
}
