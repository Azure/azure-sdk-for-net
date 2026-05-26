// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and SubjectAlternativeNames property declaration
    // to CustomerCertificateProperties for backward API compatibility.
    // Reason 1: The old SDK (AutoRest-generated) constructor accepted a WritableSubResource-typed secretSource
    // parameter, but after the TypeSpec migration, the generated parameterless constructor uses CdnResourceReference
    // (an internal type) instead. The old constructor (WritableSubResource) is preserved here to avoid breaking
    // user code, internally converting WritableSubResource to CdnResourceReference.
    // Reason 2: The generated code references SubjectAlternativeNames in constructors and serialization
    // (CustomerCertificateProperties.Serialization.cs) but does not declare a public property for it — the
    // TypeSpec generator treats it as an internal-only field. However, the old SDK exposed it as a public property.
    // The property declaration is added here with [EditorBrowsable(EditorBrowsableState.Never)] to maintain
    // backward API compatibility while discouraging new usage.
    public partial class CustomerCertificateProperties
    {
        // Backward compatibility: old API used ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomerCertificateProperties(WritableSubResource secretSource) : this()
        {
            if (secretSource != null)
            {
                SecretSource = new CdnResourceReference { Id = secretSource.Id };
            }
        }

        /// <summary> The list of SANs. </summary>
        [WirePath("subjectAlternativeNames")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> SubjectAlternativeNames { get; }
    }
}
