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
    public partial class StorageAccountCreateParameters : Resource
    {
        /// <summary>
        /// Gets or sets the account type. Possible values for this property
        /// include: 'StandardLRS', 'StandardZRS', 'StandardGRS',
        /// 'StandardRAGRS', 'PremiumLRS'
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
