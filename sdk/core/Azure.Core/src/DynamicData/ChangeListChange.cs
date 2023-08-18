// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    internal readonly struct ChangeListChange
    {
        internal ChangeListChange(string path, object? value)
        {
            Path = path;
            Value = value;
        }

        // TODO: implement as Memory<char>
        public readonly string Path { get; }

        public readonly object? Value { get; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
