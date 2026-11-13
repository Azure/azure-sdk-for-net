// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentStringField
    {
        /// <summary> String field value. </summary>
        internal string? ValueString { get; }

        /// <summary> String field value. </summary>
        public new string? Value => ValueString;
    }
}
