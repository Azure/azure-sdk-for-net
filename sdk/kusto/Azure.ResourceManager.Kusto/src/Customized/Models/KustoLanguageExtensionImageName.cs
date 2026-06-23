// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Kusto.Models
{
    // The TypeSpec generator strips underscores from enum member names (member "Python3_6_5" -> Python365,
    // "Python3_10_8" -> Python3108), and @@clientName cannot preserve them. Use CodeGenMember to rename the
    // generated members back to the GA underscored names. Python3_9_12 / Python3_9_12IncludeDeepLearning were
    // dropped from the spec, so they are re-added here as custom (obsolete) members for backward compatibility.
    public readonly partial struct KustoLanguageExtensionImageName
    {
        private const string Python3_9_12Value = "Python3_9_12";
        private const string Python3_9_12IncludeDeepLearningValue = "Python3_9_12IncludeDeepLearning";

#pragma warning disable CA1707
        /// <summary> Python3_6_5. </summary>
        [CodeGenMember("Python365")]
        public static KustoLanguageExtensionImageName Python3_6_5 { get; } = new KustoLanguageExtensionImageName(Python365Value);

        /// <summary> Python3_10_8. </summary>
        [CodeGenMember("Python3108")]
        public static KustoLanguageExtensionImageName Python3_10_8 { get; } = new KustoLanguageExtensionImageName(Python3108Value);

        /// <summary> Python3_9_12. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12 { get; } = new KustoLanguageExtensionImageName(Python3_9_12Value);

        /// <summary> Python3_9_12IncludeDeepLearning. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get; } = new KustoLanguageExtensionImageName(Python3_9_12IncludeDeepLearningValue);
#pragma warning restore CA1707
    }
}
