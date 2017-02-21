// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The description of the IoT hub.
    /// </summary>
    public partial class IotHubDescription : Resource
    {
        /// <summary>
        /// Initializes a new instance of the IotHubDescription class.
        /// </summary>
        public IotHubDescription()
        {
        }

        /// <summary>
        /// Initializes a new instance of the IotHubDescription class.
        /// </summary>
        public IotHubDescription(string location, string subscriptionid, string resourcegroup, IotHubSkuInfo sku, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string etag = default(string), IotHubProperties properties = default(IotHubProperties))
            : base(location, id, name, type, tags)
        {
            Subscriptionid = subscriptionid;
            Resourcegroup = resourcegroup;
            Etag = etag;
            Properties = properties;
            Sku = sku;
        }

        /// <summary>
        /// The subscription identifier.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionid")]
        public string Subscriptionid { get; set; }

        /// <summary>
        /// The name of the resource group that contains the IoT hub. A
        /// resource group name uniquely identifies the resource group within
        /// the subscription.
        /// </summary>
        [JsonProperty(PropertyName = "resourcegroup")]
        public string Resourcegroup { get; set; }

        /// <summary>
        /// The Etag field is *not* required. If it is provided in the
        /// response body, it must also be provided as a header per the
        /// normal ETag convention.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IotHubProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public IotHubSkuInfo Sku { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (Subscriptionid == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Subscriptionid");
            }
            if (Resourcegroup == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Resourcegroup");
            }
            if (Sku == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sku");
            }
            if (this.Properties != null)
            {
                this.Properties.Validate();
            }
            if (this.Sku != null)
            {
                this.Sku.Validate();
            }
        }
    }
}
