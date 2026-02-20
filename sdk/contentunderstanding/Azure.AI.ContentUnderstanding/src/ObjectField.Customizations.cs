// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;

namespace Azure.AI.ContentUnderstanding
{
    public partial class ObjectField
    {
        /// <summary> Object field value. </summary>
        public new IDictionary<string, ContentField>? Value => ValueObject;
    }
}
