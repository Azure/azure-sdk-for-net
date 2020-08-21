// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    internal static class TextAnalyticsServiceSerializer
    {
        #region Deserialize Common

        internal static TextAnalyticsError ReadTextAnalyticsError(JsonElement element)
        {
            string errorCode = default;
            string message = default;
            string target = default;
            TextAnalyticsError innerError = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    errorCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    innerError = ReadTextAnalyticsError(property.Value);
                    continue;
                }
            }

            // Return the innermost error, which should be only one level down.
            return innerError.ErrorCode == default ? new TextAnalyticsError(errorCode, message, target) : innerError;
        }

        #endregion Deserialize Common
    }
}
