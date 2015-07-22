namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "UsageMeters", Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class UsageMeterCollection : List<UsageMeter>
    {
        // Methods
        public UsageMeterCollection()
        {
        }

        public UsageMeterCollection(IEnumerable<UsageMeter> meters)
            : base(meters)
        {
        }
    }
}