// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Update;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition;
    using System.Threading;
    public partial class UserImpl 
    {
        /// <summary>
        /// Specifies if the user account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the user account is enabled</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithAccountEnabled.WithAccountEnabled(bool enabled) { 
            return this.WithAccountEnabled( enabled) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the mail nickname for the user.
        /// </summary>
        /// <param name="mailNickname">mailNickname the mail nickname</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithMailNickname.WithMailNickname(string mailNickname) { 
            return this.WithMailNickname( mailNickname) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the password for the user.
        /// </summary>
        /// <param name="password">password the password</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithMailNickname Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithPassword.WithPassword(string password) { 
            return this.WithPassword( password) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the temporary password for the user.
        /// </summary>
        /// <param name="password">password the temporary password</param>
        /// <param name="forceChangePasswordNextLogin">forceChangePasswordNextLogin if set to true, the user will have to change the password next time</param>
        /// <returns>the next stage for a user definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithMailNickname Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithPassword.WithPassword(string password, bool forceChangePasswordNextLogin) { 
            return this.WithPassword( password,  forceChangePasswordNextLogin) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithMailNickname;
        }

        /// <summary>
        /// Specifies the display name of the user.
        /// </summary>
        /// <param name="displayName">displayName the human-readable display name</param>
        /// <returns>the next stage of a user definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithPassword Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithDisplayName.WithDisplayName(string displayName) { 
            return this.WithDisplayName( displayName) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IWithPassword;
        }

        /// <returns>Gets or sets object type.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.ObjectType
        {
            get
            { 
            return this.ObjectType() as string;
            }
        }
        /// <returns>Gets or sets user signIn name.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.SignInName
        {
            get
            { 
            return this.SignInName() as string;
            }
        }
        /// <returns>Gets or sets user mail.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.Mail
        {
            get
            { 
            return this.Mail() as string;
            }
        }
        /// <returns>Gets or sets user principal name.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.UserPrincipalName
        {
            get
            { 
            return this.UserPrincipalName() as string;
            }
        }
        /// <returns>Gets or sets object Id.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.ObjectId
        {
            get
            { 
            return this.ObjectId() as string;
            }
        }
        /// <returns>Gets or sets user display name.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.DisplayName
        {
            get
            { 
            return this.DisplayName() as string;
            }
        }
        /// <returns>The mail alias for the user.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser.MailNickname
        {
            get
            { 
            return this.MailNickname() as string;
            }
        }
    }
}