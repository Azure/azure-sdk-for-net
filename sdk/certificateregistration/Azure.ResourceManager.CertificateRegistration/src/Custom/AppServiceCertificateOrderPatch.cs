// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.CertificateRegistration.Models
{
    public partial class AppServiceCertificateOrderPatch
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
        }
    }
}
