// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Nested representation of a complex expression. </summary>
    public partial class DataFactoryExpressionV2
    {
        /// <summary> Expression operator value Type: string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public string Operator { get; set; }

        /// <summary> Value for Constant/Field Type: string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Value { get => V2Value.ToString(); set => V2Value = value; }
    }
}
