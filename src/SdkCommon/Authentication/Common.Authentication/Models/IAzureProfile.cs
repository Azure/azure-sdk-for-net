// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Common.Authentication.Models
{
    /// <summary>
    /// Interface for Azure supported profiles.
    /// </summary>
    public interface IAzureProfile
    {
        /// <summary>
        /// Gets the default azure context object.
        /// </summary>
        AzureContext Context { get; }
    }
}
