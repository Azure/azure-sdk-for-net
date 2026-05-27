// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentBooleanField
    {
        /// <summary> Boolean field value. </summary>
        internal bool? ValueBoolean { get; }

        /// <summary> Boolean field value. </summary>
        public new bool? Value => ValueBoolean;
    }
}
