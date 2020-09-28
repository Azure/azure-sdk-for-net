// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Exposes methods to create various Azure client related types.
    /// </summary>
    public abstract class AzureComponentFactory
    {
        /// <summary>
        /// Creates and instance of <see cref="TokenCredential"/> from the provided <see cref="IConfiguration"/> object or returns a current default.
        /// </summary>
        public abstract TokenCredential CreateCredential(IConfiguration configuration);
    }
}