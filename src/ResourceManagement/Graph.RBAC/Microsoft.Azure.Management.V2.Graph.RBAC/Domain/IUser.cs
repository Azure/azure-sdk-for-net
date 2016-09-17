/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    /// <summary>
    /// An immutable client-side representation of an Azure AD user.
    /// </summary>
    public interface IUser  :
        IWrapper<UserInner>
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