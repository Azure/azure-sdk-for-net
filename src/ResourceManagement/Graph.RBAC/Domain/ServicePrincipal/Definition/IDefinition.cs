// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A service principal definition allowing role assignments to be added.
    /// </summary>
    public interface IWithRoleAssignment  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithRoleAssignmentBeta
    {
    }

    /// <summary>
    /// A service principal definition allowing credentials to be specified.
    /// </summary>
    public interface IWithCredential  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCredentialBeta
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A service principal definition allowing application to be specified.
    /// </summary>
    public interface IWithApplication  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithApplicationBeta
    {
    }

    /// <summary>
    /// A service principal definition with sufficient inputs to create a new
    /// service principal in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCredential,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithRoleAssignment
    {
    }

    /// <summary>
    /// The first stage of the service principal definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithApplication
    {
    }

    /// <summary>
    /// A service principal definition allowing role assignments to be added.
    /// </summary>
    public interface IWithRoleAssignmentBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="resourceGroup">The resource group the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup);

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="subscriptionId">The subscription the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithNewRoleInSubscription(BuiltInRole role, string subscriptionId);

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="scope">The scope the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithNewRole(BuiltInRole role, string scope);
    }

    /// <summary>
    /// A service principal definition allowing credentials to be specified.
    /// </summary>
    public interface IWithCredentialBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate> DefinePasswordCredential(string name);

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate> DefineCertificateCredential(string name);
    }

    /// <summary>
    /// A service principal definition allowing application to be specified.
    /// </summary>
    public interface IWithApplicationBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies an existing application by its app ID.
        /// </summary>
        /// <param name="id">The app ID of the application.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithExistingApplication(string id);

        /// <summary>
        /// Specifies an existing application to use by the service principal.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithExistingApplication(IActiveDirectoryApplication application);

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <param name="applicationCreatable">The new application's creatable.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable);

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <param name="signOnUrl">The new application's sign on URL.</param>
        /// <return>The next stage of the service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithNewApplication(string signOnUrl);
    }
}