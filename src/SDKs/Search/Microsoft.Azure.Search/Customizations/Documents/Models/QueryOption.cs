// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;

    internal struct QueryOption
    {
        public QueryOption(string name, string value)
            : this()
        {
            this.Name = name;
            this.Value = value;
        }

        public QueryOption(string name, IEnumerable<string> values)
            : this(name, values.ToCommaSeparatedString())
        {
            // Do nothing.
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}={1}", this.Name, this.Value);
        }
    }
}
