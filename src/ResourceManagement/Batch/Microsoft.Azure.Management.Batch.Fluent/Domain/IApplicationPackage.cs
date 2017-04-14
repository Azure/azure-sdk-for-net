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
    /// An immutable client-side representation of an Azure Batch application package.
    /// </summary>
    public interface IApplicationPackage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage,Microsoft.Azure.Management.Batch.Fluent.IApplication>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ApplicationPackageInner>
    {
        /// <summary>
        /// Activates the application package.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        void Activate(string format);

        /// <summary>
        /// Activates the application package asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ActivateAsync(string format, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the application package.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the state of the application package.
        /// </summary>
        PackageState State { get; }

        /// <summary>
        /// Gets the format of the application package.
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Gets the last time this application package was activated.
        /// </summary>
        System.DateTime LastActivationTime { get; }

        /// <summary>
        /// Gets the expiry of the storage URL for the application package.
        /// </summary>
        System.DateTime StorageUrlExpiry { get; }

        /// <summary>
        /// Gets the storage URL of the application package where teh application should be uploaded.
        /// </summary>
        string StorageUrl { get; }
    }
}