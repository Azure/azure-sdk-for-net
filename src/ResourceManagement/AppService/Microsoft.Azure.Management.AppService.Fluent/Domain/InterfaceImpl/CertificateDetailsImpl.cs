// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;

    internal partial class CertificateDetailsImpl 
    {
        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.RawData
        {
            get
            {
                return this.RawData();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.SignatureAlgorithm
        {
            get
            {
                return this.SignatureAlgorithm();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.SerialNumber
        {
            get
            {
                return this.SerialNumber();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.NotBefore
        {
            get
            {
                return this.NotBefore();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.Issuer
        {
            get
            {
                return this.Issuer();
            }
        }

        int Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.Version
        {
            get
            {
                return this.Version();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.Subject
        {
            get
            {
                return this.Subject();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.NotAfter
        {
            get
            {
                return this.NotAfter();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }
    }
}