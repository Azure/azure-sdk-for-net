// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("HealthcareEntitiesDocumentResult")]
    internal partial class HealthcareEntitiesDocumentResultInternal
    {
        /// <summary>
        /// The FHIR bundle that was produced for this document according to the specified
        /// <see cref="FhirVersion"/>. For additional information, see
        /// <see href="https://www.hl7.org/fhir/overview.html"/>.
        /// </summary>
        [CodeGenMember("FhirBundle")]
        public JsonElement FhirBundle { get; }
    }
}
