// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides the ability for the user to define custom behavior when accessing JSON through a dynamic layer.
    /// </summary>
    public struct DynamicJsonOptions
    {
        /// <summary>
        /// Specifies whether properties in the <see cref="DynamicJson"/> can be read
        /// as with either "PascalCase" or "camelCase" property names. If set to false,
        /// property reads are case sensitive.
        /// </summary>
        public bool AccessPropertyNamesPascalOrCamelCase { get; set; }
    }
}
