// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Batch account application.
    /// </summary>
    public interface IApplication  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Batch.Fluent.IApplication,Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ApplicationInner>
    {
        /// <summary>
        /// Gets the default version for the application.
        /// </summary>
        string DefaultVersion { get; }

        /// <summary>
        /// Gets application packages.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage> ApplicationPackages { get; }

        /// <summary>
        /// Gets true if automatic updates are allowed, otherwise false.
        /// </summary>
        bool UpdatesAllowed { get; }

        /// <summary>
        /// Gets the display name of the application.
        /// </summary>
        string DisplayName { get; }
    }
}