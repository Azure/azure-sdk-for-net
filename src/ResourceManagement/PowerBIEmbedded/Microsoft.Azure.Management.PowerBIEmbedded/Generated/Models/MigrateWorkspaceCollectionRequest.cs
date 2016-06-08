
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class MigrateWorkspaceCollectionRequest
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MigrateWorkspaceCollectionRequest class.
        /// </summary>
        public MigrateWorkspaceCollectionRequest() { }

        /// <summary>
        /// Initializes a new instance of the
        /// MigrateWorkspaceCollectionRequest class.
        /// </summary>
        public MigrateWorkspaceCollectionRequest(string targetResourceGroup = default(string), IList<string> resources = default(IList<string>))
        {
            TargetResourceGroup = targetResourceGroup;
            Resources = resources;
        }

        /// <summary>
        /// Gets or sets name of the resource group that the Power BI
        /// Workspace Collections will be migrated to.
        /// </summary>
        [JsonProperty(PropertyName = "targetResourceGroup")]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "resources")]
        public IList<string> Resources { get; set; }

    }
}
