// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure AD user.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IUser  :
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.Models .UserInner>
    {
        /// <returns>Gets or sets object Id.</returns>
        string ObjectId { get; }

        /// <returns>Gets or sets object type.</returns>
        string ObjectType { get; }

        /// <returns>Gets or sets user principal name.</returns>
        string UserPrincipalName { get; }

        /// <returns>Gets or sets user display name.</returns>
        string DisplayName { get; }

        /// <returns>Gets or sets user signIn name.</returns>
        string SignInName { get; }

        /// <returns>Gets or sets user mail.</returns>
        string Mail { get; }

        /// <returns>The mail alias for the user.</returns>
        string MailNickname { get; }

    }
}