// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial struct KustoLanguageExtensionImageName
    {
        /// <summary> Python3_6_5. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_6_5 { get; } = new KustoLanguageExtensionImageName("Python3_6_5");

        /// <summary> Python3_10_8. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_10_8 { get; } = new KustoLanguageExtensionImageName("Python3_10_8");

        /// <summary> Python3_9_12. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12 { get; } = new KustoLanguageExtensionImageName("Python3_9_12");

        /// <summary> Python3_9_12IncludeDeepLearning. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get; } = new KustoLanguageExtensionImageName("Python3_9_12IncludeDeepLearning");
    }
}
