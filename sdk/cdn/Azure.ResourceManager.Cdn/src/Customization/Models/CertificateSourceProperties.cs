// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Cdn;

namespace Azure.ResourceManager.Cdn.Models
{
    public abstract partial class CertificateSourceProperties
    {
        /// <summary> Initializes a new instance of <see cref="CertificateSourceProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CertificateSourceProperties()
        {
        }
    }
}
