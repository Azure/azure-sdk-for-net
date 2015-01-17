namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "Files", ItemName = "Resource",
        Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Done to maintain consistency with the contract. [tgs]")]
    internal class ResourceList : List<Resource>
    {
        // Methods
        public ResourceList()
        {
        }

        public ResourceList(IEnumerable<Resource> resources) : base(resources)
        {
        }
    }
}