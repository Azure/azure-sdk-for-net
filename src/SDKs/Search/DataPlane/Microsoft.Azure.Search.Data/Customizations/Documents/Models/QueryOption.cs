// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Common;

    internal struct QueryOption
    {
        public QueryOption(string name, string value) : this()
        {
            Name = name;
            Value = value;
        }

        public QueryOption(string name, IEnumerable<string> values) : this(name, values.ToCommaSeparatedString())
        {
            // Do nothing.
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString() => $"{Name}={Value}";
    }
}
