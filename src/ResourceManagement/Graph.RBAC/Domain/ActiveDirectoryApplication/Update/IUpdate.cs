// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition;

    /// <summary>
    /// The template for an application update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IWithSignOnUrl,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IWithIdentifierUrl,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IWithReplyUrl,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IWithCredential,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IWithMultiTenant
    {
    }

    /// <summary>
    /// The stage of application update allowing specifying identifier URLs.
    /// </summary>
    public interface IWithIdentifierUrl 
    {
        /// <summary>
        /// Adds an identifier URL to the application.
        /// </summary>
        /// <param name="identifierUrl">Unique URI that Azure AD can use for this app.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithIdentifierUrl(string identifierUrl);

        /// <summary>
        /// Removes an identifier URL from the application.
        /// </summary>
        /// <param name="identifierUrl">Identifier URI to remove.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithoutIdentifierUrl(string identifierUrl);
    }

    /// <summary>
    /// The stage of application update allowing specifying reply URLs.
    /// </summary>
    public interface IWithReplyUrl 
    {
        /// <summary>
        /// Removes a reply URL.
        /// </summary>
        /// <param name="replyUrl">The reply URL to remove.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithoutReplyUrl(string replyUrl);

        /// <summary>
        /// Adds a reply URL to the application.
        /// </summary>
        /// <param name="replyUrl">URIs to which Azure AD will redirect in response to an OAuth 2.0 request.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithReplyUrl(string replyUrl);
    }

    /// <summary>
    /// The stage of application update allowing specifying the sign on URL.
    /// </summary>
    public interface IWithSignOnUrl 
    {
        /// <summary>
        /// Specifies the sign on URL.
        /// </summary>
        /// <param name="signOnUrl">The URL where users can sign in and use this app.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithSignOnUrl(string signOnUrl);
    }

    /// <summary>
    /// The stage of application update allowing specifying if the application can be used in multiple tenants.
    /// </summary>
    public interface IWithMultiTenant 
    {
        /// <summary>
        /// Specifies if the application can be used in multiple tenants.
        /// </summary>
        /// <param name="availableToOtherTenants">True if this application is available in other tenants.</param>
        /// <return>The next stage in application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithAvailableToOtherTenants(bool availableToOtherTenants);
    }

    /// <summary>
    /// The stage of application update allowing specifying identifier keys.
    /// </summary>
    public interface IWithCredential 
    {
        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate> DefinePasswordCredential(string name);

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.UpdateDefinition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate> DefineCertificateCredential(string name);

        /// <summary>
        /// Removes a key.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <return>The next stage of the application update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update.IUpdate WithoutCredential(string name);
    }
}