// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public partial class ActiveDirectoryApplicationImpl 
    {
        /// <summary>
        /// Removes a reply URL.
        /// </summary>
        /// <param name="replyUrl">The reply URL to remove.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithReplyUrl.WithoutReplyUrl(string replyUrl)
        {
            return this.WithoutReplyUrl(replyUrl) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Adds a reply URL to the application.
        /// </summary>
        /// <param name="replyUrl">URIs to which Azure AD will redirect in response to an OAuth 2.0 request.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithReplyUrl.WithReplyUrl(string replyUrl)
        {
            return this.WithReplyUrl(replyUrl) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Adds a reply URL to the application.
        /// </summary>
        /// <param name="replyUrl">URIs to which Azure AD will redirect in response to an OAuth 2.0 request.</param>
        /// <return>The next stage in application definition.</return>
        ActiveDirectoryApplication.Definition.IWithCreate ActiveDirectoryApplication.Definition.IWithReplyUrl.WithReplyUrl(string replyUrl)
        {
            return this.WithReplyUrl(replyUrl) as ActiveDirectoryApplication.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the application can be used in multiple tenants.
        /// </summary>
        /// <param name="availableToOtherTenants">True if this application is available in other tenants.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithMultiTenant.WithAvailableToOtherTenants(bool availableToOtherTenants)
        {
            return this.WithAvailableToOtherTenants(availableToOtherTenants) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Specifies if the application can be used in multiple tenants.
        /// </summary>
        /// <param name="availableToOtherTenants">True if this application is available in other tenants.</param>
        /// <return>The next stage in application definition.</return>
        ActiveDirectoryApplication.Definition.IWithCreate ActiveDirectoryApplication.Definition.IWithMultiTenant.WithAvailableToOtherTenants(bool availableToOtherTenants)
        {
            return this.WithAvailableToOtherTenants(availableToOtherTenants) as ActiveDirectoryApplication.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the sign on URL.
        /// </summary>
        /// <param name="signOnUrl">The URL where users can sign in and use this app.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithSignOnUrl.WithSignOnUrl(string signOnUrl)
        {
            return this.WithSignOnUrl(signOnUrl) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the sign on URL.
        /// </summary>
        /// <param name="signOnUrl">The URL where users can sign in and use this app.</param>
        /// <return>The next stage in application definition.</return>
        ActiveDirectoryApplication.Definition.IWithCreate ActiveDirectoryApplication.Definition.IWithSignOnUrl.WithSignOnUrl(string signOnUrl)
        {
            return this.WithSignOnUrl(signOnUrl) as ActiveDirectoryApplication.Definition.IWithCreate;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IWithCreate>.WithCertificateCredential(CertificateCredentialImpl<IWithCreate> credential)
        {
            return this.WithCertificateCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IUpdate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IUpdate>.WithCertificateCredential(CertificateCredentialImpl<IUpdate> credential)
        {
            return this.WithCertificateCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IWithCreate>.WithPasswordCredential(PasswordCredentialImpl<IWithCreate> credential)
        {
            return this.WithPasswordCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl;
        }

        /// <summary>
        /// Attach a credential to this model.
        /// </summary>
        /// <param name="credential">The credential to attach to.</param>
        /// <return>The interface itself.</return>
        IUpdate Microsoft.Azure.Management.Graph.RBAC.Fluent.IHasCredential<IUpdate>.WithPasswordCredential(PasswordCredentialImpl<IUpdate> credential)
        {
            return this.WithPasswordCredential(credential) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl;
        }

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        CertificateCredential.UpdateDefinition.IBlank<ActiveDirectoryApplication.Update.IUpdate> ActiveDirectoryApplication.Update.IWithCredential.DefineCertificateCredential(string name)
        {
            return this.DefineCertificateCredential<IUpdate>(name) as CertificateCredential.UpdateDefinition.IBlank<ActiveDirectoryApplication.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a key.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <return>The next stage of the application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithCredential.WithoutCredential(string name)
        {
            return this.WithoutCredential(name) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        PasswordCredential.UpdateDefinition.IBlank<ActiveDirectoryApplication.Update.IUpdate> ActiveDirectoryApplication.Update.IWithCredential.DefinePasswordCredential(string name)
        {
            return this.DefinePasswordCredential<IUpdate>(name) as PasswordCredential.UpdateDefinition.IBlank<ActiveDirectoryApplication.Update.IUpdate>;
        }

        /// <summary>
        /// Starts the definition of a certificate credential.
        /// </summary>
        /// <param name="name">The descriptive name of the certificate credential.</param>
        /// <return>The first stage in certificate credential definition.</return>
        CertificateCredential.Definition.IBlank<ActiveDirectoryApplication.Definition.IWithCreate> ActiveDirectoryApplication.Definition.IWithCredential.DefineCertificateCredential(string name)
        {
            return this.DefineCertificateCredential<IWithCreate>(name) as CertificateCredential.Definition.IBlank<ActiveDirectoryApplication.Definition.IWithCreate>;
        }

        /// <summary>
        /// Starts the definition of a password credential.
        /// </summary>
        /// <param name="name">The descriptive name of the password credential.</param>
        /// <return>The first stage in password credential definition.</return>
        PasswordCredential.Definition.IBlank<ActiveDirectoryApplication.Definition.IWithCreate> ActiveDirectoryApplication.Definition.IWithCredential.DefinePasswordCredential(string name)
        {
            return this.DefinePasswordCredential<IWithCreate>(name) as PasswordCredential.Definition.IBlank<ActiveDirectoryApplication.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds an identifier URL to the application.
        /// </summary>
        /// <param name="identifierUrl">Unique URI that Azure AD can use for this app.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithIdentifierUrl.WithIdentifierUrl(string identifierUrl)
        {
            return this.WithIdentifierUrl(identifierUrl) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Removes an identifier URL from the application.
        /// </summary>
        /// <param name="identifierUrl">Identifier URI to remove.</param>
        /// <return>The next stage in application update.</return>
        ActiveDirectoryApplication.Update.IUpdate ActiveDirectoryApplication.Update.IWithIdentifierUrl.WithoutIdentifierUrl(string identifierUrl)
        {
            return this.WithoutIdentifierUrl(identifierUrl) as ActiveDirectoryApplication.Update.IUpdate;
        }

        /// <summary>
        /// Adds an identifier URL to the application.
        /// </summary>
        /// <param name="identifierUrl">Unique URI that Azure AD can use for this app.</param>
        /// <return>The next stage in application definition.</return>
        ActiveDirectoryApplication.Definition.IWithCreate ActiveDirectoryApplication.Definition.IWithIdentifierUrl.WithIdentifierUrl(string identifierUrl)
        {
            return this.WithIdentifierUrl(identifierUrl) as ActiveDirectoryApplication.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the application permissions.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.ApplicationPermissions
        {
            get
            {
                return this.ApplicationPermissions() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets a collection of URIs for the application.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.IdentifierUris
        {
            get
            {
                return this.IdentifierUris() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.ApplicationId
        {
            get
            {
                return this.ApplicationId();
            }
        }

        /// <summary>
        /// Gets the mapping of certificate credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.CertificateCredentials
        {
            get
            {
                return this.CertificateCredentials() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential>;
            }
        }

        /// <summary>
        /// Gets a collection of reply URLs for the application.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.ReplyUrls
        {
            get
            {
                return this.ReplyUrls() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets whether the application is be available to other tenants.
        /// </summary>
        bool Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.AvailableToOtherTenants
        {
            get
            {
                return this.AvailableToOtherTenants();
            }
        }

        /// <summary>
        /// Gets the home page of the application.
        /// </summary>
        System.Uri Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.SignOnUrl
        {
            get
            {
                return this.SignOnUrl() as System.Uri;
            }
        }

        /// <summary>
        /// Gets the mapping of password credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication.PasswordCredentials
        {
            get
            {
                return this.PasswordCredentials() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential>;
            }
        }
    }
}