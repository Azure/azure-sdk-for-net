// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Members of CDNProfiles that are in Beta.
    /// </summary>
    public interface ICdnProfilesBeta  : IBeta
    {
        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint asynchronously.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The Observable to CheckNameAvailabilityResult object if successful.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}