// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Developer tools which can be used to obtain credentials to authenticate requests.
    /// </summary>
    [Flags]
    public enum DeveloperSignOnSources
    {
        /// <summary>
        /// The Azure Cli. See https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest for installation instructions and documentation.
        /// </summary>
        AzureCli = 1
    }
}
