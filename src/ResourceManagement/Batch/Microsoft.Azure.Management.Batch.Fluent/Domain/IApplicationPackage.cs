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
        IApplicationPackageBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage,Microsoft.Azure.Management.Batch.Fluent.IApplication>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ApplicationPackageInner>
    {
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