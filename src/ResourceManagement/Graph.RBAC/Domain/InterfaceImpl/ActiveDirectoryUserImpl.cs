// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class ActiveDirectoryUserImpl 
    {
        /// <summary>
        /// Specifies whether the user account is enabled.
        /// </summary>
        /// <param name="accountEnabled">True if account is enabled, false otherwise.</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithCreate ActiveDirectoryUser.Definition.IWithAccontEnabledBeta.WithAccountEnabled(bool accountEnabled)
        {
            return this.WithAccountEnabled(accountEnabled) as ActiveDirectoryUser.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies whether the user account is enabled.
        /// </summary>
        /// <param name="accountEnabled">True if account is enabled, false otherwise.</param>
        /// <return>The next stage of user update.</return>
        ActiveDirectoryUser.Update.IUpdate ActiveDirectoryUser.Update.IWithAccontEnabledBeta.WithAccountEnabled(bool accountEnabled)
        {
            return this.WithAccountEnabled(accountEnabled) as ActiveDirectoryUser.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the email alias of the new user.
        /// </summary>
        /// <param name="emailAlias">The email alias of the new user.</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithPassword ActiveDirectoryUser.Definition.IWithUserPrincipalNameBeta.WithEmailAlias(string emailAlias)
        {
            return this.WithEmailAlias(emailAlias) as ActiveDirectoryUser.Definition.IWithPassword;
        }

        /// <summary>
        /// Specifies the user principal name of the user. It must contain one of
        /// the verified domains for the tenant.
        /// </summary>
        /// <param name="userPrincipalName">The user principal name.</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithPassword ActiveDirectoryUser.Definition.IWithUserPrincipalNameBeta.WithUserPrincipalName(string userPrincipalName)
        {
            return this.WithUserPrincipalName(userPrincipalName) as ActiveDirectoryUser.Definition.IWithPassword;
        }

        /// <summary>
        /// Specifies the password of the user.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithCreate ActiveDirectoryUser.Definition.IWithPasswordBeta.WithPassword(string password)
        {
            return this.WithPassword(password) as ActiveDirectoryUser.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the password of the user.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <return>The next stage of user update.</return>
        ActiveDirectoryUser.Update.IUpdate ActiveDirectoryUser.Update.IWithPasswordBeta.WithPassword(string password)
        {
            return this.WithPassword(password) as ActiveDirectoryUser.Update.IUpdate;
        }

        /// <summary>
        /// Gets user principal name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.UserPrincipalName
        {
            get
            {
                return this.UserPrincipalName();
            }
        }

        /// <summary>
        /// Gets the mail alias for the user.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.MailNickname
        {
            get
            {
                return this.MailNickname();
            }
        }

        /// <summary>
        /// Gets user mail.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.Mail
        {
            get
            {
                return this.Mail();
            }
        }

        /// <summary>
        /// Gets the usage location of the user.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.UsageLocation
        {
            get
            {
                return this.UsageLocation() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode;
            }
        }

        /// <summary>
        /// Gets user signIn name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.SignInName
        {
            get
            {
                return this.SignInName();
            }
        }

        /// <summary>
        /// Specifies whether the user should change password on the next login.
        /// </summary>
        /// <param name="promptToChangePasswordOnLogin">True if the user should change password on next login.</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithCreate ActiveDirectoryUser.Definition.IWithPromptToChangePasswordOnLoginBeta.WithPromptToChangePasswordOnLogin(bool promptToChangePasswordOnLogin)
        {
            return this.WithPromptToChangePasswordOnLogin(promptToChangePasswordOnLogin) as ActiveDirectoryUser.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies whether the user should change password on the next login.
        /// </summary>
        /// <param name="promptToChangePasswordOnLogin">True if the user should change password on next login.</param>
        /// <return>The next stage of user update.</return>
        ActiveDirectoryUser.Update.IUpdate ActiveDirectoryUser.Update.IWithPromptToChangePasswordOnLoginBeta.WithPromptToChangePasswordOnLogin(bool promptToChangePasswordOnLogin)
        {
            return this.WithPromptToChangePasswordOnLogin(promptToChangePasswordOnLogin) as ActiveDirectoryUser.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the usage location for the user. Required for users that
        /// will be assigned licenses due to legal requirement to check for
        /// availability of services in countries.
        /// </summary>
        /// <param name="usageLocation">A two letter country code (ISO standard 3166).</param>
        /// <return>The next stage of user definition.</return>
        ActiveDirectoryUser.Definition.IWithCreate ActiveDirectoryUser.Definition.IWithUsageLocationBeta.WithUsageLocation(CountryISOCode usageLocation)
        {
            return this.WithUsageLocation(usageLocation) as ActiveDirectoryUser.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the usage location for the user. Required for users that
        /// will be assigned licenses due to legal requirement to check for
        /// availability of services in countries.
        /// </summary>
        /// <param name="usageLocation">A two letter country code (ISO standard 3166).</param>
        /// <return>The next stage of user update.</return>
        ActiveDirectoryUser.Update.IUpdate ActiveDirectoryUser.Update.IWithUsageLocationBeta.WithUsageLocation(CountryISOCode usageLocation)
        {
            return this.WithUsageLocation(usageLocation) as ActiveDirectoryUser.Update.IUpdate;
        }
    }
}