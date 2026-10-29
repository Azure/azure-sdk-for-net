// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AIInfraOptimization.Models
{
    public readonly partial struct WeightPrecision
    {
        // Follow .NET casing while retaining the service's INT8 literal.
        /// <summary> 8-bit integer. </summary>
        [CodeGenMember("INT8")]
        public static WeightPrecision Int8 { get; } = new WeightPrecision(INT8Value);

        // Follow .NET casing while retaining the service's INT4 literal.
        /// <summary> 4-bit integer. </summary>
        [CodeGenMember("INT4")]
        public static WeightPrecision Int4 { get; } = new WeightPrecision(INT4Value);
    }
}
