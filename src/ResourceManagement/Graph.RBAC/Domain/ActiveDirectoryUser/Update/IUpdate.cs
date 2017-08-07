// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A user update allowing password to be specified.
    /// </summary>
    public interface IWithPassword  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithPasswordBeta
    {
    }

    /// <summary>
    /// A user update allowing setting whether the user should change password on the next login.
    /// </summary>
    public interface IWithPromptToChangePasswordOnLogin  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithPromptToChangePasswordOnLoginBeta
    {
    }

    /// <summary>
    /// A user update allowing usage location to be specified.
    /// </summary>
    public interface IWithUsageLocation  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithUsageLocationBeta
    {
    }

    /// <summary>
    /// A user update allowing specifying whether the account is enabled.
    /// </summary>
    public interface IWithAccontEnabled  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithAccontEnabledBeta
    {
    }

    /// <summary>
    /// The template for a user update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithAccontEnabled,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithPassword,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithPromptToChangePasswordOnLogin,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IWithUsageLocation
    {
    }

    /// <summary>
    /// A user update allowing password to be specified.
    /// </summary>
    public interface IWithPasswordBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the password of the user.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <return>The next stage of user update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IUpdate WithPassword(string password);
    }

    /// <summary>
    /// A user update allowing setting whether the user should change password on the next login.
    /// </summary>
    public interface IWithPromptToChangePasswordOnLoginBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies whether the user should change password on the next login.
        /// </summary>
        /// <param name="promptToChangePasswordOnLogin">True if the user should change password on next login.</param>
        /// <return>The next stage of user update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IUpdate WithPromptToChangePasswordOnLogin(bool promptToChangePasswordOnLogin);
    }

    /// <summary>
    /// A user update allowing usage location to be specified.
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
        /// <return>The next stage of user update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IUpdate WithUsageLocation(CountryISOCode usageLocation);
    }

    /// <summary>
    /// A user update allowing specifying whether the account is enabled.
    /// </summary>
    public interface IWithAccontEnabledBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies whether the user account is enabled.
        /// </summary>
        /// <param name="accountEnabled">True if account is enabled, false otherwise.</param>
        /// <return>The next stage of user update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Update.IUpdate WithAccountEnabled(bool accountEnabled);
    }
}