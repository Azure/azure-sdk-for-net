using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Storage.Models
{
    /// <summary>
    /// </summary>
    public partial class StorageAccountPropertiesUpdateParametersJson
    {
        /// <summary>
        /// Gets or sets the account type. Note that StandardZRS and
        /// PremiumLRS accounts cannot be changed to other account types, and
        /// other account types cannot be changed to StandardZRS or
        /// PremiumLRS.
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public string AccountType { get; set; }

        /// <summary>
        /// User domain assigned to the storage account. Name is the CNAME
        /// source. Only one custom domain is supported per storage account
        /// at this time. To clear the existing custom domain, use an empty
        /// string for the custom domain name property.
        /// </summary>
        [JsonProperty(PropertyName = "customDomain")]
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CustomDomain != null)
            {
                this.CustomDomain.Validate();
            }
        }
    }
}
