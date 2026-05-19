// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization to restore back-compat properties renamed by MPG generator.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class DataFactoryExpressionV2
    {
        /// <summary> Back-compat alias for legacy "operator" property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Operator { get; set; }

        /// <summary> Back-compat alias of <see cref="Type"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataFactoryExpressionV2Type? V2Type
        {
            get => Type;
            set => Type = value;
        }

        /// <summary> Back-compat alias for legacy "value" property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Value { get; set; }
    }
}
