// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf.Serializations
{
    public class BimodalRepro
    {
        [Benchmark]
        public void Bimodal() => ConstructWriter();

        private SequenceWriter ConstructWriter()
        {
            return new SequenceWriter();
        }
    }
}
