// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CdnCertificateSource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CdnCertificateSource(CdnCertificateSourceType type, CdnManagedCertificateType certificateType) : this(certificateType)
        {
            CdnCertificateSourceType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CdnCertificateSourceType CdnCertificateSourceType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
