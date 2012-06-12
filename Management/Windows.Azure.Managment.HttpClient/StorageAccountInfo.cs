using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Windows.Azure.Management.v1_7
{
    [DataContract(Name = "Status")]
    public enum StorageAccountStatus
    {
        [EnumMember]
        Creating,

        [EnumMember]
        ResolvingDns,

        [EnumMember]
        Created,

        [EnumMember]
        Deleting,
    }

    [CollectionDataContract(Name = "StorageServices", ItemName = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountPropertiesCollection : List<StorageAccountProperties>
    {
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [CollectionDataContract(Name = "Endpoints", ItemName = "Endpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class EndpointCollection : List<Uri>
    {
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    //MS.Samples... combines Props and Keys into the same class, 
    //but Get...Properties only gets the properties and Get...Keys only gets the keys
    //so this makes no sense. 
    //We'll have two different classes....
    [DataContract(Name = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountProperties : AzureDataContractBase
    {
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        [DataMember(Name = "ServiceName", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public String Name { get; private set; }

        public String Description { get { return this._props.Description; } }

        public String AffinityGroup { get { return this._props.AffinityGroup; } }

        public String Location { get { return this._props.Location; } }

        public String Label { get { return this._props.Label.DecodeBase64(); } }

        public StorageAccountStatus Status { get { return this._props.Status; } }

        public EndpointCollection Endpoints { get { return this._props.Endpoints; } }

        public Boolean GeoReplicationEnabled { get { return this._props.GeoReplicationEnabled; } }

        public String GeoPrimaryRegion { get { return this._props.GeoPrimaryRegion;  } }

        public String StatusOfPrimary { get { return this._props.StatusOfPrimary; } }

        public String GeoSecondaryRegion { get { return this._props.GeoSecondaryRegion; } }

        public String StatusOfSecondary { get { return this._props.StatusOfSecondary; } }

        public String LastGeoFailoverTime { get { return this._props.LastGeoFailoverTime; } }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public ExtendedPropertyCollection ExtendedProperties { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public List<String> Capabilities { get; private set; }

        [DataMember(Name = "StorageServiceProperties", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        private StorageAccountPropertiesInternal _props;


        [DataContract(Name = "StorageServiceProperties", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class StorageAccountPropertiesInternal : AzureDataContractBase
        {
            [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
            internal String Description { get; private set; }

            [DataMember(Order = 1, EmitDefaultValue = false)]
            internal String AffinityGroup { get; private set; }

            [DataMember(Order = 1, EmitDefaultValue = false)]
            internal String Location { get; private set; }

            [DataMember(Order = 2)]
            internal String Label { get; private set; }

            [DataMember(Order = 3)]
            internal StorageAccountStatus Status { get; private set; }

            [DataMember(Order = 4)]
            internal EndpointCollection Endpoints { get; private set; }

            [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
            internal Boolean GeoReplicationEnabled { get; private set; }

            [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
            internal String GeoPrimaryRegion { get; private set; }

            [DataMember(Order = 7, IsRequired = false, EmitDefaultValue = false)]
            internal String StatusOfPrimary { get; private set; }

            [DataMember(Order = 8, IsRequired = false, EmitDefaultValue = false)]
            internal String GeoSecondaryRegion { get; private set; }

            [DataMember(Order = 9, IsRequired = false, EmitDefaultValue = false)]
            internal String StatusOfSecondary { get; private set; }

            [DataMember(Order = 10, IsRequired = false, EmitDefaultValue = false)]
            internal String LastGeoFailoverTime { get; private set; }
        }


    }

    [DataContract(Name = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountKeys: AzureDataContractBase
    {
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        public byte[] Primary { get { return Convert.FromBase64String(this._keys.Primary); } }

        public byte[] Secondary { get { return Convert.FromBase64String(this._keys.Secondary); } }
        
        [DataMember(Name = "StorageServiceKeys", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        private StorageAccountKeysInternal _keys;

        [DataContract(Name = "StorageServiceKeys", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class StorageAccountKeysInternal : AzureDataContractBase
        {
            [DataMember(Order = 0)]
            internal String Primary { get; private set; }

            [DataMember(Order = 1)]
            internal String Secondary { get; private set; }
        }
    }


    [DataContract(Name = "CreateStorageServiceInput", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class CreateStorageAccountInfo : AzureDataContractBase
    {
        private CreateStorageAccountInfo() { }

        internal static CreateStorageAccountInfo Create(String storageAccountName, String description, String label,
                                                        String affinityGroup, String location, Boolean geoReplicationEnabled, IDictionary<String, String> extendedProperties)
        {
            Validation.ValidateStorageAccountName(storageAccountName);
            Validation.ValidateDescription(description);
            Validation.ValidateLabel(label);
            Validation.ValidateLocationOrAffinityGroup(location, affinityGroup);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateStorageAccountInfo
            {
                Name = storageAccountName,
                Description = description,
                Label = label.EncodeBase64(),
                AffinityGroup = affinityGroup,
                Location = location, 
                GeoReplicationEnabled = geoReplicationEnabled,
                ExtendedProperties = collection
            };
        }

        [DataMember(Name="ServiceName", Order=0, IsRequired=true)]
        internal String Name { get; private set; }

        [DataMember(Order=1, IsRequired=false, EmitDefaultValue=false)]
        internal String Description { get; private set; }

        [DataMember(Order=2, IsRequired=true)]
        internal String Label { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal String AffinityGroup { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal String Location { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal Boolean GeoReplicationEnabled { get; private set; }
        
        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; } 
    }
}
