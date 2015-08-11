namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class OutputItem : IExtensibleDataObject
    {
        // Properties

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Key { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Value { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}