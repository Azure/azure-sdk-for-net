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
    public partial struct DynamicJsonElement : IEquatable<DynamicJsonElement>
    {
        private readonly MutableJsonElement _element;

        internal DynamicJsonElement(MutableJsonElement element)
        {
            _element = element;
        }

        /// <inheritdoc />
        public bool Equals(DynamicJsonElement other)
        {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
            throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
            throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

            //return Equals(obj as DynamicJsonElement);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
            throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
        }
    }
}
