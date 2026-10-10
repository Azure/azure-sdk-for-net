// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore the previous public secrets constructor/property for account-key
    // datastore credentials after TypeSpec normalized credential construction.
    [CodeGenSuppress("MachineLearningAccountKeyDatastoreCredentials", typeof(MachineLearningAccountKeyDatastoreSecrets))]
    public partial class MachineLearningAccountKeyDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningAccountKeyDatastoreCredentials"/>. </summary>
        public MachineLearningAccountKeyDatastoreCredentials(MachineLearningAccountKeyDatastoreSecrets secrets) : base()
        {
            Secrets = secrets;
        }

        /// <summary> Storage account secrets. </summary>
        [CodeGenMember("Secrets")]
        [WirePath("secrets")]
        public MachineLearningAccountKeyDatastoreSecrets Secrets { get; set; }
    }
}
