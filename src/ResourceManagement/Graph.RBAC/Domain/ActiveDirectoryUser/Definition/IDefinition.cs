// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A user definition allowing setting whether the user should change password on the next login.
    /// </summary>
    public interface IWithPromptToChangePasswordOnLogin  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPromptToChangePasswordOnLoginBeta
    {
    }

    /// <summary>
    /// A user definition allowing user principal name to be specified.
    /// </summary>
    public interface IWithUserPrincipalName  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithUserPrincipalNameBeta
    {
    }

    /// <summary>
    /// An AD user definition with sufficient inputs to create a new
    /// user in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithAccontEnabled,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPromptToChangePasswordOnLogin,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithUsageLocation
    {
    }

    /// <summary>
    /// A user definition allowing usage location to be specified.
    /// </summary>
    public interface IWithUsageLocation  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithUsageLocationBeta
    {
    }

    /// <summary>
    /// The first stage of the user definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithUserPrincipalName
    {
    }

    /// <summary>
    /// A user definition allowing specifying whether the account is enabled.
    /// </summary>
    public interface IWithAccontEnabled  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithAccontEnabledBeta
    {
    }

    /// <summary>
    /// A user definition allowing password to be specified.
    /// </summary>
    public interface IWithPassword  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPasswordBeta
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithUserPrincipalName,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPassword,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A user definition allowing setting whether the user should change password on the next login.
    /// </summary>
    public interface IWithPromptToChangePasswordOnLoginBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies whether the user should change password on the next login.
        /// </summary>
        /// <param name="promptToChangePasswordOnLogin">True if the user should change password on next login.</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithCreate WithPromptToChangePasswordOnLogin(bool promptToChangePasswordOnLogin);
    }

    /// <summary>
    /// A user definition allowing user principal name to be specified.
    /// </summary>
    public interface IWithUserPrincipalNameBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the user principal name of the user. It must contain one of
        /// the verified domains for the tenant.
        /// </summary>
        /// <param name="userPrincipalName">The user principal name.</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPassword WithUserPrincipalName(string userPrincipalName);

        /// <summary>
        /// Specifies the email alias of the new user.
        /// </summary>
        /// <param name="emailAlias">The email alias of the new user.</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithPassword WithEmailAlias(string emailAlias);
    }

    /// <summary>
    /// A user definition allowing usage location to be specified.
    /// </summary>
    public interface IWithUsageLocationBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the usage location for the user. Required for users that
        /// will be assigned licenses due to legal requirement to check for
        /// availability of services in countries.
        /// </summary>
        /// <param name="usageLocation">A two letter country code (ISO standard 3166).</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithCreate WithUsageLocation(CountryISOCode usageLocation);
    }

    /// <summary>
    /// A user definition allowing specifying whether the account is enabled.
    /// </summary>
    public interface IWithAccontEnabledBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies whether the user account is enabled.
        /// </summary>
        /// <param name="accountEnabled">True if account is enabled, false otherwise.</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithCreate WithAccountEnabled(bool accountEnabled);
    }

    /// <summary>
    /// A user definition allowing password to be specified.
    /// </summary>
    public interface IWithPasswordBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the password of the user.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <return>The next stage of user definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition.IWithCreate WithPassword(string password);
    }
}