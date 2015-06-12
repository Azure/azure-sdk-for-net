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
        /// Gets the type of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public string AccountType { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public
        /// blob, queue or table object.Note that StandardZRS and PremiumLRS
        /// accounts only return the blob endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "primaryEndpoints")]
        public Endpoints PrimaryEndpoints { get; set; }

        /// <summary>
        /// Gets the location of the primary for the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "primaryLocation")]
        public string PrimaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the primary location of the
        /// storage account is available or unavailable.
        /// </summary>
        [JsonProperty(PropertyName = "statusOfPrimary")]
        public string StatusOfPrimary { get; set; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to
        /// the secondary location. Only the most recent timestamp is
        /// retained. This element is not returned if there has never been a
        /// failover instance. Only available if the accountType is
        /// StandardGRS or StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "lastGeoFailoverTime")]
        public DateTime? LastGeoFailoverTime { get; set; }

        /// <summary>
        /// Gets the location of the geo replicated secondary for the storage
        /// account. Only available if the accountType is StandardGRS or
        /// StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryLocation")]
        public string SecondaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the
        /// storage account is available or unavailable. Only available if
        /// the accountType is StandardGRS or StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "statusOfSecondary")]
        public string StatusOfSecondary { get; set; }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        [JsonProperty(PropertyName = "creationTime")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Gets the user assigned custom domain assigned to this storage
        /// account.
        /// </summary>
        [JsonProperty(PropertyName = "customDomain")]
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public
        /// blob, queue or table object from the secondary location of the
        /// storage account. Only available if the accountType is
        /// StandardRAGRS.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryEndpoints")]
        public Endpoints SecondaryEndpoints { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.PrimaryEndpoints != null)
            {
                this.PrimaryEndpoints.Validate();
            }
            if (this.CustomDomain != null)
            {
                this.CustomDomain.Validate();
            }
            if (this.SecondaryEndpoints != null)
            {
                this.SecondaryEndpoints.Validate();
            }
        }
    }
}
