// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App.
    /// </summary>
    public interface ICertificateDetails  :
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.CertificateDetailsInner>
    {
        System.DateTime NotBefore { get; }

        string Issuer { get; }

        string Thumbprint { get; }

        string RawData { get; }

        string Subject { get; }

        string SignatureAlgorithm { get; }

        string SerialNumber { get; }

        System.DateTime NotAfter { get; }

        int Version { get; }
    }
}