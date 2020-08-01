// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    internal partial class DocumentLanguage
    {
        internal static DocumentLanguage DeserializeDocumentLanguage(JsonElement element)
        {
            string id = default;
            DetectedLanguage tempDetectedLanguage = default;
            IReadOnlyList<TextAnalyticsWarning> warnings = default;
            Optional<TextDocumentStatistics> statistics = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("warnings"))
                {
                    List<TextAnalyticsWarning> array = new List<TextAnalyticsWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextAnalyticsWarning.DeserializeTextAnalyticsWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("detectedLanguage"))
                {
                    tempDetectedLanguage = DetectedLanguage.DeserializeDetectedLanguage(property.Value);
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    statistics = TextDocumentStatistics.DeserializeTextDocumentStatistics(property.Value);
                    continue;
                }
            }
            var detectedLanguage = new DetectedLanguage(tempDetectedLanguage.Name, tempDetectedLanguage.Iso6391Name, tempDetectedLanguage.ConfidenceScore, warnings.ToList());
            return new DocumentLanguage(id, detectedLanguage, warnings, statistics.Value);
        }
    }
}
