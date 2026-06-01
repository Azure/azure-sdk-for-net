// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // GA shipped both `string TermsOfServiceLink` and a parallel `Uri TermsOfServiceUri`
    // on the Api* surface. The TypeSpec spec only defines the string field (via the existing
    // `serviceUrl/termsOfServiceUrl -> serviceLink/termsOfServiceLink` rename), which yields
    // the `*Link` property. This partial adds the parallel `*Uri` accessor as a thin
    // pass-through over the `*Link` string, preserving the public API contract without
    // altering the wire shape.
    public partial class ApiEntityBaseContract
    {
        /// <summary>
        /// A URL to the Terms of Service for the API. MUST be in the format of a URL. This
        /// is a back-compat shim that wraps <see cref="TermsOfServiceLink"/> as a <see cref="Uri"/>.
        /// </summary>
        public Uri TermsOfServiceUri => string.IsNullOrEmpty(TermsOfServiceLink) ? null : new Uri(TermsOfServiceLink);
    }
}
