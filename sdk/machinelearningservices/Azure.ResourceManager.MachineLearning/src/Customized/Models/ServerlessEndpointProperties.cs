// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class ServerlessEndpointProperties
    {
        /// <summary> Specifies the content safety status. </summary>
        [WirePath("contentSafety.contentSafetyStatus")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentSafetyStatus? ContentSafetyStatus
        {
            get => ContentSafety?.ContentSafetyStatus;
            set
            {
                if (value.HasValue)
                {
                    ContentSafety ??= new ContentSafety(value.Value);
                    ContentSafety.ContentSafetyStatus = value.Value;
                }
                else
                {
                    ContentSafety = null;
                }
            }
        }
    }
}
