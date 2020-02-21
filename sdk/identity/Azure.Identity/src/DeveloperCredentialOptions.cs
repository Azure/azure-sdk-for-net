// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="DeveloperCredential"/>.
    /// </summary>
    public class DeveloperCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies if the <see cref="AzureCliCredential"/> should be excluded from the <see cref="DeveloperCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeCliCredential
        {
            get
            {
                return (ExcludedSources & DeveloperSignOnSources.AzureCli) == DeveloperSignOnSources.AzureCli;
            }
            set
            {
                ExcludedSources |= DeveloperSignOnSources.AzureCli;
            }
        }

        internal DeveloperSignOnSources ExcludedSources { get; private set; }
    }
}
