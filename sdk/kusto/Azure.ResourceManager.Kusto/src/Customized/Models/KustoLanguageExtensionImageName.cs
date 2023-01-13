// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Kusto.Models
{
    /// <summary> Language extension image name. </summary>
    public readonly partial struct KustoLanguageExtensionImageName : IEquatable<KustoLanguageExtensionImageName>
    {
#pragma warning disable CA1707
        /// <summary> Python3_6_5. </summary>
        [CodeGenMember("Python365")]
        public static KustoLanguageExtensionImageName Python3_6_5 { get; } = new KustoLanguageExtensionImageName(Python3_6_5Value);
        /// <summary> Python3_9_12. </summary>
        [CodeGenMember("Python3912")]
        public static KustoLanguageExtensionImageName Python3_9_12 { get; } = new KustoLanguageExtensionImageName(Python3_9_12Value);
        /// <summary> Python3_9_12IncludeDeepLearning. </summary>
        [CodeGenMember("Python3912IncludeDeepLearning")]
        public static KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get; } = new KustoLanguageExtensionImageName(Python3_9_12IncludeDeepLearningValue);
        /// <summary> Python3_10_8. </summary>
        [CodeGenMember("Python3108")]
        public static KustoLanguageExtensionImageName Python3_10_8 { get; } = new KustoLanguageExtensionImageName(Python3_10_8Value);
#pragma warning restore CA1707
    }
}
