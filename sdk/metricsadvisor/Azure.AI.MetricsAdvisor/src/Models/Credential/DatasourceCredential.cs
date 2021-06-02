// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Provides different ways of authenticating to a <see cref="DataFeedSource"/> for data ingestion when the
    /// default authentication method does not suffice. The supported credentials are:
    /// <list type="bullet">
    ///   <item><see cref="ServicePrincipalDatasourceCredential"/></item>
    /// </list>
    /// </summary>
    [CodeGenModel("DataSourceCredential")]
    public partial class DatasourceCredential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceCredential"/> class.
        /// </summary>
        internal DatasourceCredential(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DatasourceCredential"/>. Set by the service.
        /// </summary>
        [CodeGenMember("DataSourceCredentialId")]
        public string Id { get; }

        /// <summary>
        /// A custom unique name for this <see cref="DatasourceCredential"/> to be displayed on the web portal.
        /// </summary>
        [CodeGenMember("DataSourceCredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// A description of this <see cref="DatasourceCredential"/>.
        /// </summary>
        [CodeGenMember("DataSourceCredentialDescription")]
        public string Description { get; set; }
    }
}
