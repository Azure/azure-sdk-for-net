// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    [InProcess]
    public class BimodalRepro
    {
        [Benchmark]
        public void Bimodal()
        {
            using var content = new SequenceWriter();
        }
    }
}
