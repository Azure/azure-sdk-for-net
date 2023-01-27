// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over MutableJsonDocument.
    /// </summary>
    public partial class DynamicJson
    {
        // TODO: Decide whether or not to support equality

        private readonly MutableJsonElement _element;

        internal DynamicJson(MutableJsonElement element)
        {
            _element = element;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _element.ToString();
        }
    }
}
