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

    internal partial class ApplicationPackageImpl 
    {
        /// <summary>
        /// Activates the application package.
        /// </summary>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        void Microsoft.Azure.Management.Batch.Fluent.IApplicationPackageBeta.Activate(string format)
        {
            Extensions.Synchronize(() => this.ActivateAsync(format));
        }

        /// <summary>
        /// Gets the last time this application package was activated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.LastActivationTime
        {
            get
            {
                return this.LastActivationTime();
            }
        }

        /// <summary>
        /// Gets the state of the application package.
        /// </summary>
        PackageState Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Activates the application package asynchronously.
        /// </summary>
        /// <param name="format">The format of the uploaded Batch application package, either "zip" or "tar".</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Batch.Fluent.IApplicationPackageBeta.ActivateAsync(string format, CancellationToken cancellationToken)
        {
 
            await this.ActivateAsync(format, cancellationToken);
        }

        /// <summary>
        /// Gets the format of the application package.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.Format
        {
            get
            {
                return this.Format();
            }
        }

        /// <summary>
        /// Deletes the application package.
        /// </summary>
        void Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the storage URL of the application package where teh application should be uploaded.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.StorageUrl
        {
            get
            {
                return this.StorageUrl();
            }
        }

        /// <summary>
        /// Gets the expiry of the storage URL for the application package.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage.StorageUrlExpiry
        {
            get
            {
                return this.StorageUrlExpiry();
            }
        }
    }
}