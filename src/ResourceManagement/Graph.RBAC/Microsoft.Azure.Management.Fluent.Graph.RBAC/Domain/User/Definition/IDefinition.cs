/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition
{

    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    /// <summary>
    /// The stage of a user definition allowing specifying if the account is enabled.
    /// </summary>
    public interface IWithAccountEnabled 
    {
        /// <summary>
        /// Specifies if the user account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the user account is enabled</param>
        /// <returns>the next stage for a user definition</returns>
        IWithCreate WithAccountEnabled (bool enabled);

    }
    /// <summary>
    /// An AD user definition with sufficient inputs to create a new
    /// user in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IUser>,
        IWithAccountEnabled
    {
    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithDisplayName,
        IWithPassword,
        IWithMailNickname,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of a user definition allowing display name to be set.
    /// </summary>
    public interface IWithDisplayName 
    {
        /// <summary>
        /// Specifies the display name of the user.
        /// </summary>
        /// <param name="displayName">displayName the human-readable display name</param>
        /// <returns>the next stage of a user definition</returns>
        IWithPassword WithDisplayName (string displayName);

    }
    /// <summary>
    /// The stage of a user definition allowing mail nickname to be specified.
    /// </summary>
    public interface IWithMailNickname 
    {
        /// <summary>
        /// Specifies the mail nickname for the user.
        /// </summary>
        /// <param name="mailNickname">mailNickname the mail nickname</param>
        /// <returns>the next stage for a user definition</returns>
        IWithCreate WithMailNickname (string mailNickname);

    }
    /// <summary>
    /// The first stage of the user definition.
    /// </summary>
    public interface IBlank  :
        IWithDisplayName
    {
    }
    /// <summary>
    /// The stage of a user definition allowing password to be set.
    /// </summary>
    public interface IWithPassword 
    {
        /// <summary>
        /// Specifies the password for the user.
        /// </summary>
        /// <param name="password">password the password</param>
        /// <returns>the next stage for a user definition</returns>
        IWithMailNickname WithPassword (string password);

        /// <summary>
        /// Specifies the temporary password for the user.
        /// </summary>
        /// <param name="password">password the temporary password</param>
        /// <param name="forceChangePasswordNextLogin">forceChangePasswordNextLogin if set to true, the user will have to change the password next time</param>
        /// <returns>the next stage for a user definition</returns>
        IWithMailNickname WithPassword (string password, bool forceChangePasswordNextLogin);

    }
}