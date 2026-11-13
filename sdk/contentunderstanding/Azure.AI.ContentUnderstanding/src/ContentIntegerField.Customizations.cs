// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentIntegerField
    {
        /// <summary> Integer field value. </summary>
        internal long? ValueInteger { get; }

        /// <summary> Integer field value. </summary>
        public new long? Value => ValueInteger;
    }
}
