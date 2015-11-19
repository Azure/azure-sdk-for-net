using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Oozie
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public OozieConfiguration Configuration  { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public BlobContainerReference AdditionalSharedLibraries { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public BlobContainerReference AdditionalActionExecutorLibraries { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public AzureDatabaseReference Catalog { get; set; }

        public Oozie()
        {
            Configuration = new OozieConfiguration();
        }
    }

    [CollectionDataContract(Name = "Configuration", Namespace = Constants.XsdNamespace)]
    public class OozieConfiguration : ConfigurationPropertyList
    {
    }
}
