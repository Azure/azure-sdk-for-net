// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.Batch.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using Microsoft.Azure.Management.V2.Resource.Core;
    internal partial class ApplicationPackageImpl 
    {
        /// <returns>the sate of the application package</returns>
        Microsoft.Azure.Management.Batch.Models.PackageState Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.State
        {
            get
            {
                return this.State;
            }
        }
        /// <returns>the date when last time this application package was activate.</returns>
        System.DateTime Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.LastActivationTime
        {
            get
            {
                return this.LastActivationTime;
            }
        }
        /// <summary>
        /// Activates the application package.
        /// </summary>
        /// <param name="format">format format of the uploaded package supported values zip, tar</param>
        void Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.Activate (string format) { 
            this.Activate( format);
        }

        /// <returns>the expiry of the storage url for application package</returns>
        System.DateTime Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.StorageUrlExpiry
        {
            get
            {
                return this.StorageUrlExpiry;
            }
        }
        /// <returns>the format of application package</returns>
        string Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.Format
        {
            get
            {
                return this.Format as string;
            }
        }
        /// <summary>
        /// Deletes the application package.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.Delete () {
            this.Delete();
        }

        /// <returns>the storage Url of application package where application should be uploaded</returns>
        string Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage.StorageUrl
        {
            get
            {
                return this.StorageUrl as string;
            }
        }
    }
}