using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Hdfs
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public HdfsConfiguration Configuration { get; set; }

        public Hdfs()
        {
            Configuration = new HdfsConfiguration();
        }

    }

    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class HdfsConfiguration : ConfigurationPropertyList
    {
    }
}
