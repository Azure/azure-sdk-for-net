// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    public partial class ServicePrincipalImpl 
    {
        /// <summary>
        /// Gets the mapping from scopes to role assignments.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.RoleAssignments
        {
            get
            {
                return this.RoleAssignments() as System.Collections.Generic.ISet<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>;
            }
        }

        /// <summary>
        /// Gets app id.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ApplicationId
        {
            get
            {
                return this.ApplicationId();
            }
        }

        /// <summary>
        /// Gets the mapping of certificate credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.CertificateCredentials
        {
            get
            {
                return this.CertificateCredentials() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential>;
            }
        }

        /// <summary>
        /// Gets the list of names.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ServicePrincipalNames
        {
            get
            {
                return this.ServicePrincipalNames() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the mapping of password credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.PasswordCredentials
        {
            get
            {
                return this.PasswordCredentials() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential>;
            }
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IWithCreate>.WithCertificateCredential(CertificateCredentialImpl<IWithCreate> credential)
        {
            return this.WithCertificateCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IUpdate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IUpdate>.WithCertificateCredential(CertificateCredentialImpl<IUpdate> credential)
        {
            return this.WithCertificateCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IWithCreate>.WithPasswordCredential(PasswordCredentialImpl<IWithCreate> credential)
        {
            return this.WithPasswordCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IUpdate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IUpdate>.WithPasswordCredential(PasswordCredentialImpl<IUpdate> credential)
        {
            return this.WithPasswordCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl;
        }

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        CertificateCredential.UpdateDefinition.IBlank<ServicePrincipal.Update.IUpdate> ServicePrincipal.Update.IWithCredentialBeta.DefineCertificateCredential(string name)
        {
            return this.DefineCertificateCredential<IUpdate>(name) as CertificateCredential.UpdateDefinition.IBlank<ServicePrincipal.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a key.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <return>The next stage of the application update.</return>
        ServicePrincipal.Update.IUpdate ServicePrincipal.Update.IWithCredentialBeta.WithoutCredential(string name)
        {
            return this.WithoutCredential(name) as ServicePrincipal.Update.IUpdate;
        }

        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        PasswordCredential.UpdateDefinition.IBlank<ServicePrincipal.Update.IUpdate> ServicePrincipal.Update.IWithCredentialBeta.DefinePasswordCredential(string name)
        {
            return this.DefinePasswordCredential<IUpdate>(name) as PasswordCredential.UpdateDefinition.IBlank<ServicePrincipal.Update.IUpdate>;
        }

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        CertificateCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate> ServicePrincipal.Definition.IWithCredentialBeta.DefineCertificateCredential(string name)
        {
            return this.DefineCertificateCredential<IWithCreate>(name) as CertificateCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate>;
        }

        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        PasswordCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate> ServicePrincipal.Definition.IWithCredentialBeta.DefinePasswordCredential(string name)
        {
            return this.DefinePasswordCredential<IWithCreate>(name) as PasswordCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="resourceGroup">The resource group the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        ServicePrincipal.Update.IUpdate ServicePrincipal.Update.IWithRoleAssignmentBeta.WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup)
        {
            return this.WithNewRoleInResourceGroup(role, resourceGroup) as ServicePrincipal.Update.IUpdate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="subscriptionId">The subscription the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        ServicePrincipal.Update.IUpdate ServicePrincipal.Update.IWithRoleAssignmentBeta.WithNewRoleInSubscription(BuiltInRole role, string subscriptionId)
        {
            return this.WithNewRoleInSubscription(role, subscriptionId) as ServicePrincipal.Update.IUpdate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="scope">The scope the service principal can access.</param>
        /// <return>The next stage of the service principal update.</return>
        ServicePrincipal.Update.IUpdate ServicePrincipal.Update.IWithRoleAssignmentBeta.WithNewRole(BuiltInRole role, string scope)
        {
            return this.WithNewRole(role, scope) as ServicePrincipal.Update.IUpdate;
        }

        /// <summary>
        /// Removes a role from the service principal.
        /// </summary>
        /// <param name="roleAssignment">The role assignment to remove.</param>
        /// <return>The next stage of the service principal update.</return>
        ServicePrincipal.Update.IUpdate ServicePrincipal.Update.IWithRoleAssignmentBeta.WithoutRole(IRoleAssignment roleAssignment)
        {
            return this.WithoutRole(roleAssignment) as ServicePrincipal.Update.IUpdate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="resourceGroup">The resource group the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignmentBeta.WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup)
        {
            return this.WithNewRoleInResourceGroup(role, resourceGroup) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="subscriptionId">The subscription the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignmentBeta.WithNewRoleInSubscription(BuiltInRole role, string subscriptionId)
        {
            return this.WithNewRoleInSubscription(role, subscriptionId) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="scope">The scope the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignmentBeta.WithNewRole(BuiltInRole role, string scope)
        {
            return this.WithNewRole(role, scope) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing application by its app ID.
        /// </summary>
        /// <param name="id">The app ID of the application.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplicationBeta.WithExistingApplication(string id)
        {
            return this.WithExistingApplication(id) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing application to use by the service principal.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplicationBeta.WithExistingApplication(IActiveDirectoryApplication application)
        {
            return this.WithExistingApplication(application) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <param name="applicationCreatable">The new application's creatable.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplicationBeta.WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable)
        {
            return this.WithNewApplication(applicationCreatable) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <param name="signOnUrl">The new application's sign on URL.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplicationBeta.WithNewApplication(string signOnUrl)
        {
            return this.WithNewApplication(signOnUrl) as ServicePrincipal.Definition.IWithCreate;
        }
    }
}