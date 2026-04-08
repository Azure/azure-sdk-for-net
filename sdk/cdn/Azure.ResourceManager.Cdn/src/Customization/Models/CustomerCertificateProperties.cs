// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
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
