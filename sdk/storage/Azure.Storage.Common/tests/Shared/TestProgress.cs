// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Storage.Test
{
    public class TestProgress : IProgress<long>
    {
        public ConcurrentBag<long> List = new ConcurrentBag<long>();
        public void Report(long value)
        {
            List.Add(value);
        }
    }
}
