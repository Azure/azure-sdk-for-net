// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    public partial class NumberField
    {
        /// <summary> Number field value. </summary>
        internal double? ValueNumber { get; }

        /// <summary> Number field value. </summary>
        public new double? Value => ValueNumber;
    }
}
