// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.SignalR
{
    public partial class SignalRCustomDomainData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="SignalRCustomDomainData"/>. </summary>
        /// <param name="domainName"> The custom domain name. </param>
        /// <param name="customCertificate"> Reference to a resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> or <paramref name="customCertificate"/> is null. </exception>
        public SignalRCustomDomainData(string domainName, WritableSubResource customCertificate)
        {
            Argument.AssertNotNull(domainName, nameof(domainName));
            Argument.AssertNotNull(customCertificate, nameof(customCertificate));

            DomainName = domainName;
            CustomCertificateId = customCertificate.Id;
        }
    }
}
