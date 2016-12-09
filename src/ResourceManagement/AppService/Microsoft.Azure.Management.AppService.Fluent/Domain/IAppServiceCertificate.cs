// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
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
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.CertificateInner>
    {
        byte[] PfxBlob { get; }

        bool Valid { get; }

        System.DateTime ExpirationDate { get; }

        string CertificateBlob { get; }

        string Thumbprint { get; }

        string FriendlyName { get; }

        System.DateTime IssueDate { get; }

        System.Collections.Generic.IList<string> HostNames { get; }

        string SelfLink { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get; }

        string Password { get; }

        string SubjectName { get; }

        string Issuer { get; }

        string PublicKeyHash { get; }

        string SiteName { get; }
    }
}