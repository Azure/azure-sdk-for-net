// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A service principal update allowing credentials to be specified.
    /// </summary>
    public interface IWithCredential  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IWithCredentialBeta
    {
    }

    /// <summary>
    /// A service principal update allowing role assignments to be added.
    /// </summary>
    public interface IWithRoleAssignment  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IWithRoleAssignmentBeta
    {
    }

    /// <summary>
    /// The template for a service principal update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IWithCredential,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IWithRoleAssignment
    {
    }

    /// <summary>
    /// A service principal update allowing credentials to be specified.
    /// </summary>
    public interface IWithCredentialBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate> DefinePasswordCredential(string name);

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.UpdateDefinition.IBlank<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate> DefineCertificateCredential(string name);

        /// <summary>
        /// Removes a credential.
        /// </summary>
        /// <param name="name">The name of the credential.</param>
        /// <return>The next stage of the service principal update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate WithoutCredential(string name);
    }

    /// <summary>
    /// A service principal update allowing role assignments to be added.
    /// </summary>
    public interface IWithRoleAssignmentBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Removes a role from the service principal.
        /// </summary>
        /// <param name="roleAssignment">The role assignment to remove.</param>
        /// <return>The next stage of the service principal update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate WithoutRole(IRoleAssignment roleAssignment);

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="resourceGroup">The resource group the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup);

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="subscriptionId">The subscription the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate WithNewRoleInSubscription(BuiltInRole role, string subscriptionId);

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="scope">The scope the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update.IUpdate WithNewRole(BuiltInRole role, string scope);
    }
}