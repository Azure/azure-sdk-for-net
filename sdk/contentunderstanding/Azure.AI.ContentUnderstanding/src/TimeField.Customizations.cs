// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class TimeField
    {
        /// <summary> Time field value. </summary>
        public new TimeSpan? Value => ValueTime;
    }
}
