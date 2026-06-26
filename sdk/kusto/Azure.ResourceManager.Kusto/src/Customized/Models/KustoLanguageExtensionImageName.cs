// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Kusto.Models
{
    // These values doesn't exist in spec and are kept from GA.
    public readonly partial struct KustoLanguageExtensionImageName
    {
        private const string Python3_9_12Value = "Python3_9_12";
        private const string Python3_9_12IncludeDeepLearningValue = "Python3_9_12IncludeDeepLearning";

#pragma warning disable CA1707
        /// <summary> Python3_9_12. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12 { get; } = new KustoLanguageExtensionImageName(Python3_9_12Value);

        /// <summary> Python3_9_12IncludeDeepLearning. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get; } = new KustoLanguageExtensionImageName(Python3_9_12IncludeDeepLearningValue);
#pragma warning restore CA1707
    }
}
