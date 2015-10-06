namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "ResourceProviderProperties", ItemName = "ResourceProviderProperty",
        Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class ResourceProviderPropertyList : List<ResourceProviderProperty>
    {
        // Methods
        public ResourceProviderPropertyList()
        {
        }

        public ResourceProviderPropertyList(IEnumerable<ResourceProviderProperty> outputs)
            : base(outputs)
        {
        }
    }
}