// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Batch.Models;
    using System;
    /// <summary>
    /// An immutable client-side representation of an Azure batch account application.
    /// </summary>
    public interface IApplicationPackage  :
        IExternalChildResource<Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage,Microsoft.Azure.Management.Fluent.Batch.IApplication>,
        IWrapper<Microsoft.Azure.Management.Batch.Models.ApplicationPackageInner>
    {
        /// <returns>the name of application package.</returns>
        string Name { get; }

        /// <returns>the sate of the application package</returns>
        Microsoft.Azure.Management.Batch.Models.PackageState State { get; }

        /// <returns>the format of application package</returns>
        string Format { get; }

        /// <returns>the storage Url of application package where application should be uploaded</returns>
        string StorageUrl { get; }

        /// <returns>the expiry of the storage url for application package</returns>
        System.DateTime StorageUrlExpiry { get; }

        /// <returns>the date when last time this application package was activate.</returns>
        System.DateTime LastActivationTime { get; }

        /// <summary>
        /// Activates the application package.
        /// </summary>
        /// <param name="format">format format of the uploaded package supported values zip, tar</param>
        void Activate(string format);

        /// <summary>
        /// Deletes the application package.
        /// </summary>
        void Delete();

    }
}