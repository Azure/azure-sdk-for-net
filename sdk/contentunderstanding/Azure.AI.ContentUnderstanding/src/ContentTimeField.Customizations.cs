// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentTimeField
    {
        /// <summary> Time field value, in ISO 8601 (hh:mm:ss) format. </summary>
        internal TimeSpan? ValueTime { get; }

        /// <summary> Time field value. </summary>
        public new TimeSpan? Value => ValueTime;
    }
}
