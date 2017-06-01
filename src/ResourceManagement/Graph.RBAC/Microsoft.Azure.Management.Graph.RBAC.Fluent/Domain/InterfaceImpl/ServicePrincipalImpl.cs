// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    public partial class ServicePrincipalImpl 
    {
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

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
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

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
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
        IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IWithCreate>.WithPasswordCredential(PasswordCredentialImpl<IWithCreate> credential)
        {
            return this.WithPasswordCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl;
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
        /// Starts the definition of a password credential.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        PasswordCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate> ServicePrincipal.Definition.IWithCredential.DefinePasswordCredential(string name)
        {
            return this.DefinePasswordCredential(name) as PasswordCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate>;
        }

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        CertificateCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate> ServicePrincipal.Definition.IWithCredential.DefineCertificateCredential(string name)
        {
            return this.DefineCertificateCredential(name) as CertificateCredential.Definition.IBlank<ServicePrincipal.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="resourceGroup">The resource group the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignment.WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup)
        {
            return this.WithNewRoleInResourceGroup(role, resourceGroup) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="subscriptionId">The subscription the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignment.WithNewRoleInSubscription(BuiltInRole role, string subscriptionId)
        {
            return this.WithNewRoleInSubscription(role, subscriptionId) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns a new role to the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="role">The role to assign to the service principal.</param>
        /// <param name="scope">The scope the service principal can access.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithRoleAssignment.WithNewRole(BuiltInRole role, string scope)
        {
            return this.WithNewRole(role, scope) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Specifies an existing application by its app ID.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="id">The app ID of the application.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplication.WithExistingApplication(string id)
        {
            return this.WithExistingApplication(id) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing application to use by the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="application">The application.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplication.WithExistingApplication(IActiveDirectoryApplication application)
        {
            return this.WithExistingApplication(application) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="applicationCreatable">The new application's creatable.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplication.WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable)
        {
            return this.WithNewApplication(applicationCreatable) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new application to create and use by the service principal.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="signOnUrl">The new application's sign on URL.</param>
        /// <return>The next stage of the service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithApplication.WithNewApplication(string signOnUrl)
        {
            return this.WithNewApplication(signOnUrl) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager;
            }
        }
    }
}