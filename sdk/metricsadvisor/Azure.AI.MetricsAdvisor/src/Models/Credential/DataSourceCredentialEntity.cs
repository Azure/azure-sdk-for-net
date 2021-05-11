// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The credential used to authenticate a <see cref="DataFeedSource"/> for data ingestion.
    /// </summary>
    [CodeGenModel("DataSourceCredential")]
    public partial class DataSourceCredentialEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceCredentialEntity"/> class.
        /// </summary>
        internal DataSourceCredentialEntity(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataSourceCredentialEntity"/>. Set by the service.
        /// </summary>
        [CodeGenMember("DataSourceCredentialId")]
        public string Id { get; }

        /// <summary>
        /// A custom unique name for this <see cref="DataSourceCredentialEntity"/> to be displayed on the web portal.
        /// </summary>
        [CodeGenMember("DataSourceCredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// A description of this <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        [CodeGenMember("DataSourceCredentialDescription")]
        public string Description { get; set; }
    }
}
