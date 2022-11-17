// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClientOptions
    {
        private string _azureRegionalAuthorityName;

        public TokenCredentialOptions Options { get; set; }

        public string ClientId { get; set; }

        public ResourceIdentifier ResourceIdentifier { get; set; }

        public bool PreserveTransport { get; set; }

        public TimeSpan? InitialImdsConnectionTimeout { get; set; }

        public CredentialPipeline Pipeline { get; set; }

        /// <summary>
        ///  The name of the Azure Regional Authority used by ESTS-R
        /// </summary>
        public string AzureRegionalAuthorityName
        {
            get { return _azureRegionalAuthorityName ?? EnvironmentVariables.AzureRegionalAuthorityName; }
            set { _azureRegionalAuthorityName = value; }
        }
    }
}
