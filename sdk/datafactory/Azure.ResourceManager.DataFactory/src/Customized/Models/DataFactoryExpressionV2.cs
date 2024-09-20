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
        public string Operator { get; set; }
    }
}
