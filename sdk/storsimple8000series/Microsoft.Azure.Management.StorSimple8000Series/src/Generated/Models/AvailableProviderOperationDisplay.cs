
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Contains the localized display information for this particular
    /// operation/action. These value will be used by several clients for (a)
    /// custom role definitions for RBAC, (b) complex query filters for the
    /// event service and (c) audit history/records for management operations.
    /// </summary>
    public partial class AvailableProviderOperationDisplay
    {
        /// <summary>
        /// Initializes a new instance of the AvailableProviderOperationDisplay
        /// class.
        /// </summary>
        public AvailableProviderOperationDisplay() { }

        /// <summary>
        /// Initializes a new instance of the AvailableProviderOperationDisplay
        /// class.
        /// </summary>
        /// <param name="provider">The localized friendly form of the resource
        /// provider name - it is expected to also include the
        /// publisher/company responsible. It should use Title Casing and begin
        /// with 'Microsoft' for 1st party services.</param>
        /// <param name="resource">The localized friendly form of the resource
        /// type related to this action/operation - it should match the public
        /// documentation for the resource provider. It should use Title Casing
        /// - for examples, please refer to the 'name' section.</param>
        /// <param name="operation">The localized friendly name for the
        /// operation, as it should be shown to the user. It should be concise
        /// (to fit in drop downs) but clear (i.e. self-documenting). It should
        /// use Title Casing and include the entity/resource to which it
        /// applies.</param>
        /// <param name="description">The localized friendly description for
        /// the operation, as it should be shown to the user. It should be
        /// thorough, yet concise - it will be used in tool tips and detailed
        /// views.</param>
        public AvailableProviderOperationDisplay(string provider = default(string), string resource = default(string), string operation = default(string), string description = default(string))
        {
            Provider = provider;
            Resource = resource;
            Operation = operation;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the localized friendly form of the resource provider
        /// name - it is expected to also include the publisher/company
        /// responsible. It should use Title Casing and begin with 'Microsoft'
        /// for 1st party services.
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the localized friendly form of the resource type
        /// related to this action/operation - it should match the public
        /// documentation for the resource provider. It should use Title Casing
        /// - for examples, please refer to the 'name' section.
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
        /// concise - it will be used in tool tips and detailed views.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}

