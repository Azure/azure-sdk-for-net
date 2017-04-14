// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class UserImpl 
    {
        /// <summary>
        /// Specifies if the user account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">If set to true, the user account is enabled.</param>
        /// <return>The next stage for a user definition.</return>
        User.Definition.IWithCreate User.Definition.IWithAccountEnabled.WithAccountEnabled(bool enabled)
        {
            return this.WithAccountEnabled(enabled) as User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the password for the user.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <return>The next stage for a user definition.</return>
        User.Definition.IWithMailNickname User.Definition.IWithPassword.WithPassword(string password)
        {
            return this.WithPassword(password) as User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the temporary password for the user.
        /// </summary>
        /// <param name="password">The temporary password.</param>
        /// <param name="forceChangePasswordNextLogin">If set to true, the user will have to change the password next time.</param>
        /// <return>The next stage for a user definition.</return>
        User.Definition.IWithMailNickname User.Definition.IWithPassword.WithPassword(string password, bool forceChangePasswordNextLogin)
        {
            return this.WithPassword(password, forceChangePasswordNextLogin) as User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the mail nickname for the user.
        /// </summary>
        /// <param name="mailNickname">The mail nickname.</param>
        /// <return>The next stage for a user definition.</return>
        User.Definition.IWithCreate User.Definition.IWithMailNickname.WithMailNickname(string mailNickname)
        {
            return this.WithMailNickname(mailNickname) as User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the display name of the user.
        /// </summary>
        /// <param name="displayName">The human-readable display name.</param>
        /// <return>The next stage of a user definition.</return>
        User.Definition.IWithPassword User.Definition.IWithDisplayName.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName) as User.Definition.IWithPassword;
        }

        /// <summary>
        /// Gets or sets object Id.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.ObjectId
        {
            get
            {
                return this.ObjectId();
            }
        }

        /// <summary>
        /// Gets or sets user principal name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.UserPrincipalName
        {
            get
            {
                return this.UserPrincipalName();
            }
        }

        /// <summary>
        /// Gets The mail alias for the user.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.MailNickname
        {
            get
            {
                return this.MailNickname();
            }
        }

        /// <summary>
        /// Gets or sets user display name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets or sets user mail.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.Mail
        {
            get
            {
                return this.Mail();
            }
        }

        /// <summary>
        /// Gets or sets object type.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.ObjectType
        {
            get
            {
                return this.ObjectType();
            }
        }

        /// <summary>
        /// Gets or sets user signIn name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.SignInName
        {
            get
            {
                return this.SignInName();
            }
        }
    }
}