// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Old SDK exposed Uri TermsOfServiceUri; generated code has string TermsOfServiceLink.
    // This read-only wrapper provides the Uri version for backward compat.
    // Not spec-fixable: @@alternateType replaces the property type entirely.
    public partial class ApiEntityBaseContract
    {
        /// <summary> A URL to the Terms of Service for the API. MUST be in the format of a URL. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri TermsOfServiceUri
        {
            get
            {
                return Uri.TryCreate(TermsOfServiceLink, UriKind.Absolute, out var uri) ? uri : null;
            }
        }
    }
}
