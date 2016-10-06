// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{

    using Microsoft.Azure.Management.Batch.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure batch account application.
    /// </summary>
    public interface IApplication  :
        IExternalChildResource<Microsoft.Azure.Management.Batch.Fluent.IApplication,Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        IWrapper<Microsoft.Azure.Management.Batch.Fluent.Models.ApplicationInner>
    {
        /// <returns>the display name for application</returns>
        string DisplayName { get; }

        /// <returns>the list of application packages</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage> ApplicationPackages { get; }

        /// <returns>true if automatic updates are allowed, otherwise false</returns>
        bool UpdatesAllowed { get; }

        /// <returns>the default version for application.</returns>
        string DefaultVersion { get; }

    }
}