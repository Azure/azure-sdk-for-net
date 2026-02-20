// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class DateTimeOffsetField
    {
        /// <summary> Date field value. </summary>
        public new DateTimeOffset? Value => ValueDate;
    }
}
