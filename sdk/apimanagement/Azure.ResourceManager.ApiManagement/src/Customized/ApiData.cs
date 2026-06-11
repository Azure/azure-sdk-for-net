// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ApiManagement
{
    // GA shipped both `string ServiceLink/TermsOfServiceLink` and a parallel
    // `Uri ServiceUri/TermsOfServiceUri` on ApiData. The TypeSpec spec only defines the
    // string fields (via the existing `serviceUrl/termsOfServiceUrl -> serviceLink/termsOfServiceLink`
    // rename), so this partial re-adds the parallel `*Uri` accessors as thin pass-throughs over
    // the `*Link` strings.
    public partial class ApiData
    {
        /// <summary>
        /// Absolute URL of the backend service implementing this API. This is a back-compat
        /// shim that wraps <see cref="ServiceLink"/> as a <see cref="Uri"/>.
        /// </summary>
        public Uri ServiceUri
        {
            get => string.IsNullOrEmpty(ServiceLink) ? null : new Uri(ServiceLink);
            set => ServiceLink = value?.AbsoluteUri;
        }

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
