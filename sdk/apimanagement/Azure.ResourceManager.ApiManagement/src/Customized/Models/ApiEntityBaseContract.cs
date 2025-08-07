// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Summary of revision metadata. </summary>
    public partial class ApiEntityBaseContract
    {
        /// <summary> A URL to the Terms of Service for the API. MUST be in the format of a URL. </summary>
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
