// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.CertificateRegistration.Models;

namespace Azure.ResourceManager.CertificateRegistration
{
    public partial class AppServiceCertificateOrderData
    {
        /// <summary>
        /// Certificate product type.
        /// </summary>
        // Backward-compatibility shim. Use CertificateProductType instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use CertificateProductType instead.")]
        public CertificateProductType ProductType
        {
            get => CertificateProductType.GetValueOrDefault();
            set => CertificateProductType = value;
        }
    }
}
