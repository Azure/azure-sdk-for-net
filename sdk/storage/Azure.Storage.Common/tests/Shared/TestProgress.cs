// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Test
{
    public class TestProgress : IProgress<long>
    {
        public List<long> List = new List<long>();
        public void Report(long value)
        {
            List.Add(value);
        }
    }
}
