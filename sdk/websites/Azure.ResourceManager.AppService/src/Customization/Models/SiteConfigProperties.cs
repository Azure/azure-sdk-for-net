// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class SiteConfigProperties
    {
        /// <summary>
        /// The URL of the API definition.
        /// </summary>
        [WirePath("apiDefinition.url")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ApiDefinitionUri
        {
            get
            {
                if (ApiDefinitionUrl is null)
                    return null;
                return Uri.TryCreate(ApiDefinitionUrl, UriKind.Absolute, out var uri) ? uri : null;
            }
            set => ApiDefinitionUrl = value?.AbsoluteUri;
        }
    }
}
