// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure AD application.
    /// </summary>
    public interface IActiveDirectoryApplication  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ActiveDirectoryApplication.Update.IUpdate>
    {
        /// <summary>
        /// Gets the application permissions.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ApplicationPermissions { get; }

        /// <summary>
        /// Gets a collection of URIs for the application.
        /// </summary>
        System.Collections.Generic.ISet<string> IdentifierUris { get; }

        /// <summary>
        /// Gets a collection of reply URLs for the application.
        /// </summary>
        System.Collections.Generic.ISet<string> ReplyUrls { get; }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        string ApplicationId { get; }

        /// <summary>
        /// Gets the mapping of certificate credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials { get; }

        /// <summary>
        /// Gets whether the application is be available to other tenants.
        /// </summary>
        bool AvailableToOtherTenants { get; }

        /// <summary>
        /// Gets the mapping of password credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials { get; }

        /// <summary>
        /// Gets the home page of the application.
        /// </summary>
        System.Uri SignOnUrl { get; }
    }
}