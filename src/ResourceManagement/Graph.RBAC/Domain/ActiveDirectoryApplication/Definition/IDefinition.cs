// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;

    /// <summary>
    /// The stage of application definition allowing specifying identifier URLs.
    /// </summary>
    public interface IWithIdentifierUrl 
    {
        /// <summary>
        /// Adds an identifier URL to the application.
        /// </summary>
        /// <param name="identifierUrl">Unique URI that Azure AD can use for this app.</param>
        /// <return>The next stage in application definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate WithIdentifierUrl(string identifierUrl);
    }

    /// <summary>
    /// The first stage of the application definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithSignOnUrl
    {
    }

    /// <summary>
    /// An application definition with sufficient inputs to create a new
    /// application in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithIdentifierUrl,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithReplyUrl,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCredential,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithMultiTenant
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of application definition allowing specifying the sign on URL.
    /// </summary>
    public interface IWithSignOnUrl 
    {
        /// <summary>
        /// Specifies the sign on URL.
        /// </summary>
        /// <param name="signOnUrl">The URL where users can sign in and use this app.</param>
        /// <return>The next stage in application definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate WithSignOnUrl(string signOnUrl);
    }

    /// <summary>
    /// The stage of application definition allowing specifying reply URLs.
    /// </summary>
    public interface IWithReplyUrl 
    {
        /// <summary>
        /// Adds a reply URL to the application.
        /// </summary>
        /// <param name="replyUrl">URIs to which Azure AD will redirect in response to an OAuth 2.0 request.</param>
        /// <return>The next stage in application definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate WithReplyUrl(string replyUrl);
    }

    /// <summary>
    /// The stage of application definition allowing specifying if the application can be used in multiple tenants.
    /// </summary>
    public interface IWithMultiTenant 
    {
        /// <summary>
        /// Specifies if the application can be used in multiple tenants.
        /// </summary>
        /// <param name="availableToOtherTenants">True if this application is available in other tenants.</param>
        /// <return>The next stage in application definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate WithAvailableToOtherTenants(bool availableToOtherTenants);
    }

    /// <summary>
    /// The stage of application definition allowing specifying identifier keys.
    /// </summary>
    public interface IWithCredential 
    {
        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate> DefinePasswordCredential(string name);

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition.IWithCreate> DefineCertificateCredential(string name);
    }
}