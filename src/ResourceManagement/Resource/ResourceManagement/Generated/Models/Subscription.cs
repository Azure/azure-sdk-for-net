using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Subscriptions.Models
{
    /// <summary>
    /// </summary>
    public partial class Subscription
    {
        /// <summary>
        /// Gets or sets the ID of the resource
        /// (/subscriptions/SubscriptionId).
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the subscription Id.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the subscription display name
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the subscription state
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
