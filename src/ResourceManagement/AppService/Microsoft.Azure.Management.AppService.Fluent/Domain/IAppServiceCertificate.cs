// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure app service certificate.
    /// </summary>
    public interface IAppServiceCertificate  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>,
        IWrapper<Models.CertificateInner>
    {
        /// <summary>
        /// Gets the pfx blob.
        /// </summary>
        byte[] PfxBlob { get; }

        /// <summary>
        /// Gets if the certificate valid.
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// Gets the certificate expriration date.
        /// </summary>
        System.DateTime ExpirationDate { get; }

        /// <summary>
        /// Gets the raw bytes of .cer file.
        /// </summary>
        string CertificateBlob { get; }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        string Thumbprint { get; }

        /// <summary>
        /// Gets the friendly name of the certificate.
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Gets the certificate issue Date.
        /// </summary>
        System.DateTime IssueDate { get; }

        /// <summary>
        /// Gets the host names the certificate applies to.
        /// </summary>
        System.Collections.Generic.IList<string> HostNames { get; }

        /// <summary>
        /// Gets the self link.
        /// </summary>
        string SelfLink { get; }

        /// <summary>
        /// Gets the specification for the App Service Environment to use for the certificate.
        /// </summary>
        Models.HostingEnvironmentProfile HostingEnvironmentProfile { get; }

        /// <summary>
        /// Gets the certificate password.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Gets the subject name of the certificate.
        /// </summary>
        string SubjectName { get; }

        /// <summary>
        /// Gets the certificate issuer.
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Gets the public key hash.
        /// </summary>
        string PublicKeyHash { get; }

        /// <summary>
        /// Gets the app name.
        /// </summary>
        string SiteName { get; }
    }
}