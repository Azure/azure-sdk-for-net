// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used PascalCase (Get, Head, etc.) instead of UPPERCASE (GET, HEAD, etc.)
    public readonly partial struct RequestMethodMatchConditionMatchValue
    {
        [CodeGenMember("GET")]
        public static RequestMethodMatchConditionMatchValue Get { get; } = new RequestMethodMatchConditionMatchValue(GETValue);

        [CodeGenMember("HEAD")]
        public static RequestMethodMatchConditionMatchValue Head { get; } = new RequestMethodMatchConditionMatchValue(HEADValue);

        [CodeGenMember("POST")]
        public static RequestMethodMatchConditionMatchValue Post { get; } = new RequestMethodMatchConditionMatchValue(POSTValue);

        [CodeGenMember("PUT")]
        public static RequestMethodMatchConditionMatchValue Put { get; } = new RequestMethodMatchConditionMatchValue(PUTValue);

        [CodeGenMember("DELETE")]
        public static RequestMethodMatchConditionMatchValue Delete { get; } = new RequestMethodMatchConditionMatchValue(DELETEValue);

        [CodeGenMember("OPTIONS")]
        public static RequestMethodMatchConditionMatchValue Options { get; } = new RequestMethodMatchConditionMatchValue(OPTIONSValue);

        [CodeGenMember("TRACE")]
        public static RequestMethodMatchConditionMatchValue Trace { get; } = new RequestMethodMatchConditionMatchValue(TRACEValue);
    }
}
