namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Runtime.Serialization;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming",
        "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Property", Justification = "Needed to preserve RDFE contract.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class Property
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Value { get; set; }
    }
}
