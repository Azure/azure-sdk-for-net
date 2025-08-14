// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public class AdditionalPropertiesBenchmarks
    {
        private AdditionalProperties _apMatch;
        private AdditionalProperties _apMiss;
#if NET8_0_OR_GREATER
        private string _property = "child";
#endif

        [Params(1, 5, 20, 100)]
        public int ItemsInDictionary;

        public AdditionalPropertiesBenchmarks()
        {
            _apMatch = new AdditionalProperties();
            _apMatch.Set("$.tags.child"u8, 0);
            _apMiss = new AdditionalProperties();
            _apMiss.Set("$.tags.diffChild"u8, 0);
        }

        [Benchmark]
        public void ContainsChild_Stack_Optimized_Match()
        {
#if NET8_0_OR_GREATER
            Span<byte> buffer = stackalloc byte[256];
            for (int i=0; i< ItemsInDictionary; i++)
            {
                int length = Encoding.UTF8.GetBytes(_property.AsSpan(), buffer);
                _apMatch.ContainsChildOf("$.tags"u8, buffer.Slice(0, length));
            }
#endif
        }

        [Benchmark]
        public void ContainsChild_Stack_FullPath_Match()
        {
#if NET8_0_OR_GREATER
            Span<byte> buffer = stackalloc byte[256];
            ReadOnlySpan<byte> span = "$.tags."u8;
            span.CopyTo(buffer);
            for (int i = 0; i < ItemsInDictionary; i++)
            {
                int length = span.Length;
                length += Encoding.UTF8.GetBytes(_property.AsSpan(), buffer.Slice(length));
                _apMatch.Contains(buffer.Slice(0, length));
            }
#endif
        }
    }
}
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
