// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class ValidateProbeContent
    {
        // Backward compatibility: old API used Uri ProbeUri property and ctor(Uri)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateProbeContent(Uri probeUri) : this(probeUri?.AbsoluteUri)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ProbeUri => ProbeURL != null ? new Uri(ProbeURL) : null;
    }
}
