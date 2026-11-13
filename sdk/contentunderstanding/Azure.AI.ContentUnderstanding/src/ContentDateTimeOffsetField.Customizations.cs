// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentDateTimeOffsetField
    {
        /// <summary> Date field value, in ISO 8601 (YYYY-MM-DD) format. </summary>
        internal DateTimeOffset? ValueDate { get; }

        /// <summary> Date field value. </summary>
        public new DateTimeOffset? Value => ValueDate;
    }
}
