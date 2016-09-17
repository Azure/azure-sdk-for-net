/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Update;
    using System.Threading;
    public partial class UserImpl 
    {
        /// <summary>
        /// Specifies if the user account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the user account is enabled</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithAccountEnabled.WithAccountEnabled (bool enabled) {
            return this.WithAccountEnabled( enabled) as Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the mail nickname for the user.
        /// </summary>
        /// <param name="mailNickname">mailNickname the mail nickname</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithMailNickname.WithMailNickname (string mailNickname) {
            return this.WithMailNickname( mailNickname) as Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the password for the user.
        /// </summary>
        /// <param name="password">password the password</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithMailNickname Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithPassword.WithPassword (string password) {
            return this.WithPassword( password) as Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the temporary password for the user.
        /// </summary>
        /// <param name="password">password the temporary password</param>
        /// <param name="forceChangePasswordNextLogin">forceChangePasswordNextLogin if set to true, the user will have to change the password next time</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithMailNickname Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithPassword.WithPassword (string password, bool forceChangePasswordNextLogin) {
            return this.WithPassword( password,  forceChangePasswordNextLogin) as Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the display name of the user.
        /// </summary>
        /// <param name="displayName">displayName the human-readable display name</param>
        /// <returns>the next stage of a user definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithPassword Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithDisplayName.WithDisplayName (string displayName) {
            return this.WithDisplayName( displayName) as Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition.IWithPassword;
        }

        /// <returns>Gets or sets object type.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.ObjectType
        {
            get
            {
                return this.ObjectType as string;
            }
        }
        /// <returns>Gets or sets user signIn name.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.SignInName
        {
            get
            {
                return this.SignInName as string;
            }
        }
        /// <returns>Gets or sets user mail.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.Mail
        {
            get
            {
                return this.Mail as string;
            }
        }
        /// <returns>Gets or sets user principal name.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.UserPrincipalName
        {
            get
            {
                return this.UserPrincipalName as string;
            }
        }
        /// <returns>Gets or sets object Id.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.ObjectId
        {
            get
            {
                return this.ObjectId as string;
            }
        }
        /// <returns>Gets or sets user display name.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.DisplayName
        {
            get
            {
                return this.DisplayName as string;
            }
        }
        /// <returns>The mail alias for the user.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IUser.MailNickname
        {
            get
            {
                return this.MailNickname as string;
            }
        }
    }
}