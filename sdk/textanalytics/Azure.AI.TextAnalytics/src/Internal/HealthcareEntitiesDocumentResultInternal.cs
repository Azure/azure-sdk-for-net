// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("HealthcareEntitiesDocumentResult")]
    internal partial class HealthcareEntitiesDocumentResultInternal
    {
        [CodeGenMember("FhirBundle")]
        public JsonElement FhirBundle { get; }
    }
}
