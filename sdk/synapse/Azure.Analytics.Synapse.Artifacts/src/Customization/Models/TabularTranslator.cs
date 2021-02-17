// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> A copy activity tabular translator. </summary>
    public partial class TabularTranslator : CopyTranslator
    {
        /// <summary> Initializes a new instance of TabularTranslator. </summary>
        public TabularTranslator()
        {
            Type = "TabularTranslator";
        }
    }
}
