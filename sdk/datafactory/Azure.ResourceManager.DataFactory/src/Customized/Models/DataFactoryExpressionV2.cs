// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization to restore back-compat properties renamed by MPG generator.
    public partial class DataFactoryExpressionV2
    {
        /// <summary> Back-compat alias for legacy "operator" property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public string Operator { get; set; }

        /// <summary> Back-compat alias for legacy "value" property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Value { get; set; }
    }
}
