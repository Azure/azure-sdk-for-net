// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CdnCertificateSource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CdnCertificateSource(CdnCertificateSourceType sourceType, CdnManagedCertificateType certificateType) : this(certificateType)
        {
            SourceType = sourceType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CdnCertificateSourceType SourceType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
