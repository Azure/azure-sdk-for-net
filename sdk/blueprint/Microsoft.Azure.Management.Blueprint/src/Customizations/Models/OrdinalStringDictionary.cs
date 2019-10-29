// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Blueprint.Models
{
    using System;
    using System.Collections.Generic;

    public class OrdinalStringDictionary<T> : Dictionary<string, T>
    {
        public OrdinalStringDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
