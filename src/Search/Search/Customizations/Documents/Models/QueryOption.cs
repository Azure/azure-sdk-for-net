// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Search.Models
{
    internal struct QueryOption
    {
        public QueryOption(string name, string value)
            : this()
        {
            Name = name;
            Value = value;
        }

        public QueryOption(string name, IEnumerable<string> values)
            : this(name, String.Join(",", values))
        {
            // Do nothing.
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}={1}", Name, Value);
        }
    }
}
