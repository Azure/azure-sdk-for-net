// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentArrayField
    {
        /// <summary> Array field value. </summary>
        internal IList<ContentField>? ValueArray { get; }

        /// <summary> Array field value. </summary>
        public new IList<ContentField>? Value => ValueArray;
    }
}
