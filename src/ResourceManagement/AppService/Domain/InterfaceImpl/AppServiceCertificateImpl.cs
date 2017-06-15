// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    internal partial class AppServiceCertificateImpl 
    {
        /// <summary>
        /// Gets the certificate password.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Password
        {
            get
            {
                return this.Password();
            }
        }

        /// <summary>
        /// Gets the public key hash.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.PublicKeyHash
        {
            get
            {
                return this.PublicKeyHash();
            }
        }

        /// <summary>
        /// Gets the app name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SiteName
        {
            get
            {
                return this.SiteName();
            }
        }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        /// <summary>
        /// Gets the raw bytes of .cer file.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.CertificateBlob
        {
            get
            {
                return this.CertificateBlob();
            }
        }

        /// <summary>
        /// Gets the pfx blob.
        /// </summary>
        byte[] Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.PfxBlob
        {
            get
            {
                return this.PfxBlob();
            }
        }

        /// <summary>
        /// Gets the host names the certificate applies to.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.HostNames
        {
            get
            {
                return this.HostNames() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the certificate issuer.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Issuer
        {
            get
            {
                return this.Issuer();
            }
        }

        /// <summary>
        /// Gets if the certificate valid.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.Valid
        {
            get
            {
                return this.Valid();
            }
        }

        /// <summary>
        /// Gets the self link.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SelfLink
        {
            get
            {
                return this.SelfLink();
            }
        }

        /// <summary>
        /// Gets the specification for the App Service Environment to use for the certificate.
        /// </summary>
        Models.HostingEnvironmentProfile Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.HostingEnvironmentProfile
        {
            get
            {
                return this.HostingEnvironmentProfile() as Models.HostingEnvironmentProfile;
            }
        }

        /// <summary>
        /// Gets the certificate issue Date.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.IssueDate
        {
            get
            {
                return this.IssueDate();
            }
        }

        /// <summary>
        /// Gets the subject name of the certificate.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.SubjectName
        {
            get
            {
                return this.SubjectName();
            }
        }

        /// <summary>
        /// Gets the certificate expriration date.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate.ExpirationDate
        {
            get
            {
                return this.ExpirationDate();
            }
        }

        /// <summary>
        /// Gets the friendly name of the certificate.
        /// </summary>
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
        /// <return>The next stage of the definition.</return>
        AppServiceCertificate.Definition.IWithCreate AppServiceCertificate.Definition.IWithPfxFilePassword.WithPfxPassword(string password)
        {
            return this.WithPfxPassword(password) as AppServiceCertificate.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the app service certificate.
        /// </summary>
        /// <param name="certificateOrder">The app service certificate order.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificate.Definition.IWithCreate AppServiceCertificate.Definition.IWithCertificate.WithExistingCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingCertificateOrder(certificateOrder) as AppServiceCertificate.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the PFX file from a URL.
        /// </summary>
        /// <param name="url">The URL pointing to the PFX file.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxFileFromUrl(string url)
        {
            return this.WithPfxFileFromUrl(url) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }

        /// <summary>
        /// Specifies the PFX certificate file to upload.
        /// </summary>
        /// <param name="file">The PFX certificate file.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxFile(string file)
        {
            return this.WithPfxFile(file) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }

        /// <summary>
        /// Specifies the PFX byte array to upload.
        /// </summary>
        /// <param name="pfxByteArray">The PFX byte array.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificate.Definition.IWithPfxFilePassword AppServiceCertificate.Definition.IWithCertificate.WithPfxByteArray(params byte[] pfxByteArray)
        {
            return this.WithPfxByteArray(pfxByteArray) as AppServiceCertificate.Definition.IWithPfxFilePassword;
        }
    }
}