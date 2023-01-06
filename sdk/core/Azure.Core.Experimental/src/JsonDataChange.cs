// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Dynamic
{
    internal struct JsonDataChange<T> : IJsonDataChange
    {
        public string Property { get; set; }

        public T? Value { get; set; }
    }

    internal interface IJsonDataChange
    {
        public string Property { get; set; }
    }
}
