// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and SourceType property to CdnCertificateSource for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the CdnCertificateSourceType struct as the discriminator (sourceType),
    // with the constructor signature (sourceType, certificateType).
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old API is preserved here and bridges to TypeName.
    public partial class CdnCertificateSource
    {
        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CdnCertificateSource(CdnCertificateSourceType sourceType, CdnManagedCertificateType certificateType) : this(certificateType)
        {
            SourceType = sourceType;
        }

        /// <summary> Backward-compatibility shim retained when the model was regenerated from TypeSpec; hidden from IntelliSense. See the file-level comment for details. </summary>
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
