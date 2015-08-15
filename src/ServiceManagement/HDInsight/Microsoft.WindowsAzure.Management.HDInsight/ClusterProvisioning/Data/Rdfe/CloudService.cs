namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class CloudService : IExtensibleDataObject
    {
        // Properties
        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string GeoRegion { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Label { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Needed for serialization. [tgs]")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", 
            Justification = "Part of the contract. [tgs]")]
        [DataMember(Order = 5, EmitDefaultValue = false)]
        public ResourceList Resources { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}