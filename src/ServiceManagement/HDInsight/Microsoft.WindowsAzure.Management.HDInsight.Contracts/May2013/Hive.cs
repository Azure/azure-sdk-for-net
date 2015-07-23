using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Hive
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public HiveConfiguration Configuration { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public BlobContainerReference AdditionalLibraries { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public AzureDatabaseReference Catalog { get; set; }

        public Hive()
        {
            Configuration = new HiveConfiguration();
        }

    }

    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class HiveConfiguration : ConfigurationPropertyList
    {
    }
}
