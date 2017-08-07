// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure AD user.
    /// </summary>
    public interface IActiveDirectoryUser  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.UserInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ActiveDirectoryUser.Update.IUpdate>
    {
        /// <summary>
        /// Gets user mail.
        /// </summary>
        string Mail { get; }

        /// <summary>
        /// Gets user signIn name.
        /// </summary>
        string SignInName { get; }

        /// <summary>
        /// Gets the usage location of the user.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode UsageLocation { get; }

        /// <summary>
        /// Gets user principal name.
        /// </summary>
        string UserPrincipalName { get; }

        /// <summary>
        /// Gets the mail alias for the user.
        /// </summary>
        string MailNickname { get; }
    }
}