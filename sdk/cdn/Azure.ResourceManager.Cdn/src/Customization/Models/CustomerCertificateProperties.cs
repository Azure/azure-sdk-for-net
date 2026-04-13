// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and SubjectAlternativeNames property to CustomerCertificateProperties
    // for backward API compatibility with the previous SDK.
    // Reason 1: The old SDK constructor accepted a WritableSubResource-typed secretSource parameter,
    // but after the TypeSpec migration it was changed to ResourceReference. The old constructor is preserved here, internally converting the type.
    // Reason 2: The SubjectAlternativeNames property was exposed as a public property in the old SDK.
    // The TypeSpec-generated code may not have preserved this property or the name changed; it is manually preserved here and marked as EditorBrowsable.Never.
    public partial class CustomerCertificateProperties
    {
        // Backward compatibility: old API used ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomerCertificateProperties(WritableSubResource secretSource) : this()
        {
            if (secretSource != null)
            {
                SecretSource = new ResourceReference { Id = secretSource.Id };
            }
        }

        /// <summary> The list of SANs. </summary>
        [WirePath("subjectAlternativeNames")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> SubjectAlternativeNames { get; }
    }
}
