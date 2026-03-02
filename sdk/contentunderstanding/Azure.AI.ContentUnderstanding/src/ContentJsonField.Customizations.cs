// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentJsonField
    {
        /// <summary> JSON field value. </summary>
        internal BinaryData? ValueJson { get; }

        /// <summary> JSON field value. </summary>
        public new BinaryData? Value => ValueJson;
    }
}
