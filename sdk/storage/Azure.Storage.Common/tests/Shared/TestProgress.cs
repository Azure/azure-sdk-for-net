// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Test
{
    public class TestProgress : IProgress<long>
    {
        private readonly object _lock = new object();
        public List<long> List = new List<long>();
        public void Report(long value)
        {
            lock (_lock)
            {
                List.Add(value);
            }
        }
    }
}
