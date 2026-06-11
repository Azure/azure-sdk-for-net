// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // GA shipped a parallel `Uri TermsOfServiceUri` alongside `string TermsOfServiceLink`
    // on ApiPatch. This partial re-adds the `Uri` accessor as a thin pass-through.
    public partial class ApiPatch
    {
        /// <summary>
        /// A URL to the Terms of Service for the API. MUST be in the format of a URL. This
        /// is a back-compat shim that wraps <see cref="TermsOfServiceLink"/> as a <see cref="Uri"/>.
        /// </summary>
        public Uri TermsOfServiceUri
        {
            get => string.IsNullOrEmpty(TermsOfServiceLink) ? null : new Uri(TermsOfServiceLink);
            set => TermsOfServiceLink = value?.AbsoluteUri;
        }
    }
}
