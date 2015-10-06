namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class UsageMeter : IExtensibleDataObject
    {
        // Properties

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Included { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Unit { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Used { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}