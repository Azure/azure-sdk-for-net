// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    public class BimodalRepro
    {
        [Benchmark]
        public SequenceWriter Bimodal()
        {
            return new SequenceWriter();
        }
    }
}
