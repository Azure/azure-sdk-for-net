// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using System;
    using Models;

    /// <summary>
    /// Contains members of IApplicationPackage that are in Beta.
    /// </summary>
    public interface IApplicationPackageBeta  : IBeta
    {
        /// <summary>
        /// Activates the application package.
        /// </summary>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        void Activate(string format);

        /// <summary>
        /// Activates the application package asynchronously.
        /// </summary>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ActivateAsync(string format, CancellationToken cancellationToken = default(CancellationToken));
    }
}