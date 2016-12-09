// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQ2VydGlmaWNhdGVEZXRhaWxzSW1wbA==
    internal partial class CertificateDetailsImpl  :
        IndexableWrapper<CertificateDetailsInner>,
        ICertificateDetails
    {
        ///GENMHASH:1B172487E6EF67B78787A37894F473FD:8E4007E7DA9D157B87035BF90C065ED0
        public DateTime NotBefore()
        {
            //$ return Inner.NotBefore();

            return DateTime.Now;
        }

        ///GENMHASH:1FEB53873B02953EA0CD266740DA9FCB:E017957F7666F01443438263FECCC29A
        public string Issuer()
        {
            //$ return Inner.Issuer();

            return null;
        }

        ///GENMHASH:8F04665E49050E6C5BD8AE7B8E51D285:415AB6515F3750504B0F67632D677FD0
        public string Thumbprint()
        {
            //$ return Inner.Thumbprint();

            return null;
        }

        ///GENMHASH:D1778B07864E401E5F1184DF8521AEBB:D4EE6418838182037B7603D541B62602
        public string RawData()
        {
            //$ return Inner.RawData();

            return null;
        }

        ///GENMHASH:78D011E7577A95593D3D2FA7F5C212C6:02249AC21BAFD9F00C2CB7F32B873C70
        public string Subject()
        {
            //$ return Inner.Subject();

            return null;
        }

        ///GENMHASH:5B95626191E8EB284C560210C7CC33E1:5E880CDF9D37F50032D84FC4F1D631F6
        public string SignatureAlgorithm()
        {
            //$ return Inner.SignatureAlgorithm();

            return null;
        }

        ///GENMHASH:C70ACBF55B279BA26BBE5F77DDE46E40:5464228A4B2A39EBA61B99F7033FBFCB
        public string SerialNumber()
        {
            //$ return Inner.SerialNumber();

            return null;
        }

        ///GENMHASH:958DD60972B83D2124E848FF7E414116:1C9C3B6E48A2AD8727BB321A2A6846AE
        public DateTime NotAfter()
        {
            //$ return Inner.NotAfter();

            return DateTime.Now;
        }

        ///GENMHASH:7272D744FF80A0EC280B6D4DB5A4682F:C0C35E00AF4E17F141675A2C05C7067B
        internal  CertificateDetailsImpl(CertificateDetailsInner innerObject)
            : base (innerObject)
        {
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:6D6F931BE0FE2C8F8921B2EDAE792515
        public int Version()
        {
            return (int) Inner.Version;
        }
    }
}