namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Error", Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class ResourceErrorInfo : IExtensibleDataObject
    {
        // Methods

        // Properties

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public int HttpCode { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Message { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}