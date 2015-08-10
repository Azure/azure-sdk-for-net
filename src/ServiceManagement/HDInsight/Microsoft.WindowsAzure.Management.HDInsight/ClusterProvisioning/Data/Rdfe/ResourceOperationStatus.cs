namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract(Name = "OperationStatus", Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class ResourceOperationStatus : IExtensibleDataObject
    {
        // Methods

        // Properties
        [DataMember(Order = 3, EmitDefaultValue = false)]
        public ResourceErrorInfo Error { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Result { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "Done as part of the contract. [tgs.]")]
        public string Type { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}