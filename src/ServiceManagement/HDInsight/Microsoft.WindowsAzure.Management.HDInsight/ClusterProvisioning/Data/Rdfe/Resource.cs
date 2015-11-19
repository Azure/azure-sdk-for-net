namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class Resource : IExtensibleDataObject
    {
        // Methods

        // Properties
        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string ETag { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Part of the contract. [tgs]")]
        public XmlNode[] IntrinsicSettings { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public ResourceOperationStatus OperationStatus { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists",
            Justification = "Part of the contract. [tgs]")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Needed for serialization. [tgs]")]
        [DataMember(Order = 12, EmitDefaultValue = false)]
        public OutputItemList OutputItems { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Plan { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string PromotionCode { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string ResourceProviderNamespace { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string SchemaVersion { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string SubState { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "Done for consistency with the contract.  [tgs]")]
        public string Type { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists",
            Justification = "Part of the contract. [tgs]")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Needed for serialization. [tgs]")]
        [DataMember(Order = 10, EmitDefaultValue = false)]
        public UsageMeterCollection UsageMeters { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
        
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