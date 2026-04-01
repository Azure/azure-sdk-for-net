// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AppServiceApiDefinitionInfo
    {
        // Add this property back to avoid breaking change with the fix for issue #56828
        /// <summary>
        /// The URL of the API definition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Uri
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
