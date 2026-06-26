// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Old SDK exposed both string (TermsOfServiceLink/ServiceLink) and Uri (TermsOfServiceUri/ServiceUri).
    // The string versions are generated natively via @@clientName. These provide the Uri wrappers.
    // Not spec-fixable: @@alternateType replaces the property type entirely, removing the
    // string accessor which is also part of the published contract.
    public partial class ApiCreateOrUpdateContent
    {
        /// <summary> A URL to the Terms of Service for the API. MUST be in the format of a URL. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri TermsOfServiceUri
        {
            get
            {
                return Uri.TryCreate(TermsOfServiceLink, UriKind.Absolute, out var uri) ? uri : null;
            }
            set
            {
                TermsOfServiceLink = value.AbsoluteUri;
            }
        }

        /// <summary> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ServiceUri
        {
            get
            {
                return Uri.TryCreate(ServiceLink, UriKind.Absolute, out var uri) ? uri : null;
            }
            set
            {
                ServiceLink = value.AbsoluteUri;
            }
        }
    }
}
