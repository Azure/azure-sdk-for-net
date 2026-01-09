// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereCertificateData
    {
        /// <summary> Certificate. </summary>
        public string Certificate => Properties?.Certificate;

        /// <summary> Certificate status. </summary>
        public SphereCertificateStatus? Status => Properties?.Status;

        /// <summary> Certificate subject. </summary>
        public string Subject => Properties?.Subject;

        /// <summary> Certificate thumbprint. </summary>
        public string Thumbprint => Properties?.Thumbprint;

        /// <summary> Certificate expiry date and time (UTC). </summary>
        public DateTimeOffset? ExpiryUtc => Properties?.ExpiryUtc;

        /// <summary> Certificate not-before date and time (UTC). </summary>
        public DateTimeOffset? NotBeforeUtc => Properties?.NotBeforeUtc;

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;
    }
}
