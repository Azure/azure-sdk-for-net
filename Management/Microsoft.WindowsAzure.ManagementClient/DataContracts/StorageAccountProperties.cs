//-----------------------------------------------------------------------
// <copyright file="StorageAccountProperties.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the StorageAccountProperties, 
//    StorageAccountPropertiesCollection and the StorageAccountEndpointsCollection
//    classes.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of <see cref="StorageAccountProperties"/> objects.
    /// </summary>
    [CollectionDataContract(Name = "StorageServices", ItemName = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountPropertiesCollection : List<StorageAccountProperties>
    {
        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    /// <summary>
    /// Represents a set of storage account service endpoints.
    /// </summary>
    [CollectionDataContract(Name = "Endpoints", ItemName = "Endpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountEndpointCollection : List<Uri>
    {
        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    /// <summary>
    /// Represents the properties of a Windows Azure storage account.
    /// </summary>
    [DataContract(Name = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountProperties : AzureDataContractBase
    {
        /// <summary>
        /// The Service Management API request URI used to perform 
        /// requests against the storage account. 
        /// </summary>
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the name of the storage account. 
        /// This name is the DNS prefix name and can be used to access 
        /// the storage account.
        /// For example, if the service name is MyService you could 
        /// access the access blob service of the storage account by calling: 
        /// http://MyService.blob.core.windows.net
        /// </summary>
        [DataMember(Name = "ServiceName", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description for the strorage account.
        /// </summary>
        public string Description { get { return _props.Description; } }

        /// <summary>
        /// Gets the AffintyGroup with which this storage account is associated, 
        /// if any.
        /// If AffinityGroup is set, Location will be null.
        /// </summary>
        public string AffinityGroup { get { return _props.AffinityGroup; } }

        /// <summary>
        /// Gets the location of the storage account. 
        /// Valid locations are returned from 
        /// <see cref="AzureHttpClient.ListLocationsAsync"/>.
        /// If Location is set, AffinityGroup will be null.
        /// </summary>
        public string Location { get { return _props.Location; } }

        /// <summary>
        /// Gets the user supplied label for the storage account.
        /// </summary>
        public string Label { get { return _props.Label.DecodeBase64(); } }

        /// <summary>
        /// Gets the current <see cref="StorageAccountStatus"/> for the storage account.
        /// </summary>
        public StorageAccountStatus Status { get { return _props.Status; } }

        /// <summary>
        /// Gets the set of endpoints for the storage account.
        /// </summary>
        public StorageAccountEndpointCollection Endpoints { get { return _props.Endpoints; } }

        /// <summary>
        /// Indicates whether the data in the storage account is replicated across more than one 
        /// geographic location so as to enable resilience in the face of catastrophic service loss. 
        /// The value is true if geo-replication is enabled; otherwise false.
        /// </summary>
        public bool GeoReplicationEnabled { get { return _props.GeoReplicationEnabled; } }

        /// <summary>
        /// Indicates the primary geographical region in which the storage account exists at this time.
        /// </summary>
        public string GeoPrimaryRegion { get { return _props.GeoPrimaryRegion;  } }

        /// <summary>
        /// Indicates whether the primary storage region is available.
        /// </summary>
        public string StatusOfPrimary { get { return _props.StatusOfPrimary; } }

        /// <summary>
        /// Indicates the geographical region in which the storage account is being replicated.
        /// </summary>
        public string GeoSecondaryRegion { get { return _props.GeoSecondaryRegion; } }

        /// <summary>
        /// Indicates whether the secondary storage region is available.
        /// </summary>
        public string StatusOfSecondary { get { return _props.StatusOfSecondary; } }

        /// <summary>
        /// A timestamp that indicates the most recent instance of a failover to the secondary region. 
        /// </summary>
        public string LastGeoFailoverTime { get { return _props.LastGeoFailoverTime; } }

        /// <summary>
        /// Gets a collection of extended properties associated with 
        /// the storage account.
        /// </summary>
        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public ExtendedPropertyCollection ExtendedProperties { get; private set; }

        /// <summary>
        /// Indicates if the storage account is able to perform virtual machine related operations. 
        /// If so, this List contains a string containing "PersistentVMRole." Otherwise, this will be null.
        /// </summary>
        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public List<string> Capabilities { get; private set; }

        [DataMember(Name = "StorageServiceProperties", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        private StorageAccountPropertiesInternal _props;


        [DataContract(Name = "StorageServiceProperties", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class StorageAccountPropertiesInternal : AzureDataContractBase
        {
            [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
            internal string Description { get; private set; }

            [DataMember(Order = 1, EmitDefaultValue = false)]
            internal string AffinityGroup { get; private set; }

            [DataMember(Order = 1, EmitDefaultValue = false)]
            internal string Location { get; private set; }

            [DataMember(Order = 2)]
            internal string Label { get; private set; }

            [DataMember(Order = 3)]
            internal StorageAccountStatus Status { get; private set; }

            [DataMember(Order = 4)]
            internal StorageAccountEndpointCollection Endpoints { get; private set; }

            [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
            internal bool GeoReplicationEnabled { get; private set; }

            [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
            internal string GeoPrimaryRegion { get; private set; }

            [DataMember(Order = 7, IsRequired = false, EmitDefaultValue = false)]
            internal string StatusOfPrimary { get; private set; }

            [DataMember(Order = 8, IsRequired = false, EmitDefaultValue = false)]
            internal string GeoSecondaryRegion { get; private set; }

            [DataMember(Order = 9, IsRequired = false, EmitDefaultValue = false)]
            internal string StatusOfSecondary { get; private set; }

            [DataMember(Order = 10, IsRequired = false, EmitDefaultValue = false)]
            internal string LastGeoFailoverTime { get; private set; }
        }
    }


}
