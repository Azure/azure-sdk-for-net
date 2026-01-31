// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.AI.Translation.Text
{
    /// <summary> Client options for TextTranslationClient. </summary>
    public partial class TextTranslationClientOptions : ClientOptions
    {
        /// <summary> Initializes new instance of TextTranslationClientOptions. </summary>
        public TextTranslationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2025_10_01_Preview => "2025-10-01-preview",
                ServiceVersion.V3_0 or _ => throw new NotSupportedException()
            };
            Diagnostics.LoggedHeaderNames.Add("X-RequestId");
        }
    }
}
