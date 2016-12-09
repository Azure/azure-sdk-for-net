// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificate.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    internal partial class AppServiceCertificateImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate;
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Password
        {
            get
            {
                return this.Password();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.PublicKeyHash
        {
            get
            {
                return this.PublicKeyHash();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SiteName
        {
            get
            {
                return this.SiteName();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.CertificateBlob
        {
            get
            {
                return this.CertificateBlob();
            }
        }

        byte[] Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.PfxBlob
        {
            get
            {
                return this.PfxBlob();
            }
        }

        System.Collections.Generic.IList<string> Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.HostNames
        {
            get
            {
                return this.HostNames() as System.Collections.Generic.IList<string>;
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Issuer
        {
            get
            {
                return this.Issuer();
            }
        }

        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Valid
        {
            get
            {
                return this.Valid();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SelfLink
        {
            get
            {
                return this.SelfLink();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.HostingEnvironmentProfile Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.HostingEnvironmentProfile
        {
            get
            {
                return this.HostingEnvironmentProfile() as Microsoft.Azure.Management.AppService.Fluent.Models.HostingEnvironmentProfile;
            }
        }

        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.IssueDate
        {
            get
            {
                return this.IssueDate();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SubjectName
        {
            get
            {
                return this.SubjectName();
            }
        }

        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.ExpirationDate
        {
            get
            {
                return this.ExpirationDate();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.FriendlyName
        {
            get
            {
                return this.FriendlyName();
            }
        }

        /// <summary>
        /// Specifies the password to the PFX certificate.
        /// </summary>
        /// <param name="password">The PFX certificate password.</param>
        AppServiceCertificate.Definition.IWithCreate AppServiceCertificate.Definition.IWithPfxFilePassword.WithPfxPassword(string password)
        {
            return this.WithPfxPassword(password) as AppServiceCertificate.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the app service certificate.
        /// </summary>
        /// <param name="certificateOrder">The app service certificate order.</param>
        AppServiceCertificate.Definition.IWithCreate AppServiceCertificate.Definition.IWithCertificate.WithExistingCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingCertificateOrder(certificateOrder) as AppServiceCertificate.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the PFX file from a URL.
        /// </summary>
        /// <param name="url">The URL pointing to the PFX file.</param>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxFileFromUrl(string url)
        {
            return this.WithPfxFileFromUrl(url) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }

        /// <summary>
        /// Specifies the PFX certificate file to upload.
        /// </summary>
        /// <param name="file">The PFX certificate file.</param>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxFile(string filePath)
        {
            return this.WithPfxFile(filePath) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }

        /// <summary>
        /// Specifies the PFX byte array to upload.
        /// </summary>
        /// <param name="pfxByteArray">The PFX byte array.</param>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxByteArray(params byte[] pfxByteArray)
        {
            return this.WithPfxByteArray(pfxByteArray) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }
    }
}