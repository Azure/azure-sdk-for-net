namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class StorageAccount : Resource
    {
        /// <summary>
        /// Gets the type of the storage account. Possible values for this
        /// property include: 'Standard_LRS', 'Standard_ZRS', 'Standard_GRS',
        /// 'Standard_RAGRS', 'Premium_LRS'
        /// </summary>
        [JsonProperty(PropertyName = "properties.accountType")]
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public
        /// blob, queue or table object.Note that StandardZRS and PremiumLRS
        /// accounts only return the blob endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primaryEndpoints")]
        public Endpoints PrimaryEndpoints { get; set; }

        /// <summary>
        /// Gets the location of the primary for the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primaryLocation")]
        public string PrimaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the primary location of the
        /// storage account is available or unavailable. Possible values for
        /// this property include: 'Available', 'Unavailable'
        /// </summary>
        [JsonProperty(PropertyName = "properties.statusOfPrimary")]
        public AccountStatus? StatusOfPrimary { get; set; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to
        /// the secondary location. Only the most recent timestamp is
        /// retained. This element is not returned if there has never been a
        /// failover instance. Only available if the accountType is
        /// StandardGRS or StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastGeoFailoverTime")]
        public DateTime? LastGeoFailoverTime { get; set; }

        /// <summary>
        /// Gets the location of the geo replicated secondary for the storage
        /// account. Only available if the accountType is StandardGRS or
        /// StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "properties.secondaryLocation")]
        public string SecondaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the
        /// storage account is available or unavailable. Only available if
        /// the accountType is StandardGRS or StandardRAGRS. Possible values
        /// for this property include: 'Available', 'Unavailable'
        /// </summary>
        [JsonProperty(PropertyName = "properties.statusOfSecondary")]
        public AccountStatus? StatusOfSecondary { get; set; }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        [JsonProperty(PropertyName = "properties.creationTime")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Gets the user assigned custom domain assigned to this storage
        /// account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.customDomain")]
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public
        /// blob, queue or table object from the secondary location of the
        /// storage account. Only available if the accountType is
        /// StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "properties.secondaryEndpoints")]
        public Endpoints SecondaryEndpoints { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
