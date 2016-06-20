
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class Display
    {
        /// <summary>
        /// Initializes a new instance of the Display class.
        /// </summary>
        public Display() { }

        /// <summary>
        /// Initializes a new instance of the Display class.
        /// </summary>
        public Display(string provider = default(string), string resource = default(string), string operation = default(string), string description = default(string), string origin = default(string))
        {
            Provider = provider;
            Resource = resource;
            Operation = operation;
            Description = description;
            Origin = origin;
        }

        /// <summary>
        /// Gets or sets the localized friendly form of the resource provider
        /// name – it is expected to also include the publisher/company
        /// responsible. It should use Title Casing and begin with
        /// “Microsoft” for 1st party services.
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the localized friendly form of the resource type
        /// related to this action/operation – it should match the public
        /// documentation for the resource provider. It should use Title
        /// Casing – for examples, please refer to the “name” section.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the localized friendly name for the operation, as it
        /// should be shown to the user. It should be concise (to fit in drop
        /// downs) but clear (i.e. self-documenting). It should use Title
        /// Casing and include the entity/resource to which it applies.
        /// </summary>
        [JsonProperty(PropertyName = "operation")]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the localized friendly description for the operation,
        /// as it should be shown to the user. It should be thorough, yet
        /// concise – it will be used in tool tips and detailed views.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the intended executor of the operation; governs the
        /// display of the operation in the RBAC UX and the audit logs UX.
        /// Default value is 'user,system'
        /// </summary>
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

    }
}
