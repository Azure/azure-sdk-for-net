namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "CloudServices", ItemName = "CloudService", Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Done to maintain consistency with the contract. [tgs]")]
    internal class CloudServiceList : List<CloudService>
    {
        // Methods
        public CloudServiceList()
        {
        }

        public CloudServiceList(IEnumerable<CloudService> cloudServices) : base(cloudServices)
        {
        }

        public string SerializeToXml()
        {
            var ser = new DataContractSerializer(this.GetType());
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }
    }
}