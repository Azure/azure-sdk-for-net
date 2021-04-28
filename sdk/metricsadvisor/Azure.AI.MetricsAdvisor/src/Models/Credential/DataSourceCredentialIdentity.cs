// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("DataSourceCredential")]
    internal partial class DataSourceCredentialIdentity
    {
        [CodeGenMember("DataSourceCredentialId")]
        public string Id { get; }

        [CodeGenMember("DataSourceCredentialName")]
        public string Name { get; set; }

        [CodeGenMember("DataSourceCredentialDescription")]
        public string Description { get; set; }
    }
}
