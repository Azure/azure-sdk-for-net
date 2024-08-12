// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Kusto.Models
{
    /// <summary> Language extension image name. </summary>
    public readonly partial struct KustoLanguageExtensionImageName : IEquatable<KustoLanguageExtensionImageName>
    {
        private const string Python3_9_12Value = "Python3_9_12";
        private const string Python3_9_12IncludeDeepLearningValue = "Python3_9_12IncludeDeepLearning";

#pragma warning disable CA1707
        /// <summary> Python3_6_5. </summary>
        [CodeGenMember("Python365")]
        public static KustoLanguageExtensionImageName Python3_6_5 { get; } = new KustoLanguageExtensionImageName(Python3_6_5Value);
        /// <summary> Python3_9_12. </summary>
        [CodeGenMember("Python3912")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12 { get; } = new KustoLanguageExtensionImageName(Python3_9_12Value);
        /// <summary> Python3_9_12IncludeDeepLearning. </summary>
        [CodeGenMember("Python3912IncludeDeepLearning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get; } = new KustoLanguageExtensionImageName(Python3_9_12IncludeDeepLearningValue);
        /// <summary> Python3_10_8. </summary>
        [CodeGenMember("Python3108")]
        public static KustoLanguageExtensionImageName Python3_10_8 { get; } = new KustoLanguageExtensionImageName(Python3_10_8Value);
#pragma warning restore CA1707
    }
}
