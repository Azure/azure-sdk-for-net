// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService
{
    public partial class SiteConfigData
    {
        // Add this property back to avoid breaking change with the fix for issue #56828
        /// <summary>
        /// The URL of the API definition.
        /// </summary>
        [WirePath("properties.apiDefinition.url")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ApiDefinitionUri
        {
            get
            {
                if (ApiDefinitionUriStringValue is null)
                    return null;
                return Uri.TryCreate(ApiDefinitionUriStringValue, UriKind.Absolute, out var uri) ? uri : null;
            }
            set => ApiDefinitionUriStringValue = value?.AbsoluteUri;
        }
    }
}
