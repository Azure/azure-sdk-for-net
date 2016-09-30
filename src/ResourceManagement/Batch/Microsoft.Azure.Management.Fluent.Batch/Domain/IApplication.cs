// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Batch.Models;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure batch account application.
    /// </summary>
    public interface IApplication  :
        IExternalChildResource<Microsoft.Azure.Management.Fluent.Batch.IApplication,Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        IWrapper<Microsoft.Azure.Management.Batch.Models.ApplicationInner>
    {
        /// <returns>the display name for application</returns>
        string DisplayName { get; }

        /// <returns>the list of application packages</returns>
        IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage> ApplicationPackages ();

        /// <returns>true if automatic updates are allowed, otherwise false</returns>
        bool? UpdatesAllowed { get; }

        /// <returns>the default version for application.</returns>
        string DefaultVersion { get; }

    }
}