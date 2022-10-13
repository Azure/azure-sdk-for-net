// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("FhirVersion")]
    public readonly partial struct WellKnownFhirVersion
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        private const string V4_0_1Value = "4.0.1";

        /// <summary> 4.0.1. </summary>
        [CodeGenMember("Four01")]
        public static WellKnownFhirVersion V4_0_1 { get; } = new WellKnownFhirVersion(V4_0_1Value);
#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
