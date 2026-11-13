// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public class InsertItemsBenchmarks
    {
        [Params(1, 5, 20)]
        public int Inserts;

        private readonly Dictionary<byte[], byte[]> _jsonPaths = new()
        {
            { "$.items"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.items.foo"u8.ToArray(), "value"u8.ToArray() },
            { "$.bars[0].x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bars[0].x.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.bars[1].x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bars[1].x.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.bar.foo.x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bar.foo.x.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.properties.virtualMachine"u8.ToArray(), "value"u8.ToArray() },
            { "$.sku.name"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.sku.name.something"u8.ToArray(), "value"u8.ToArray() },
            { "$.foo.bar.baz"u8.ToArray(), "value"u8.ToArray() },
            { "$.foo.baz.bar"u8.ToArray(), "value"u8.ToArray() },
            { "$.item.something.x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z"u8.ToArray(), "[{\"a\":\"value\"}]"u8.ToArray() },
            { "$.item.something.x.y.z[0]"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z[0].foo.bar.baz.qux"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z[0].foo.bar.baz.qux.quux"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z[0].foo.bar.baz.qux.quux.corge"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray()},
        };

        private readonly Dictionary<byte[], byte[]> _jsonPathsNoNesting = new()
        {
            { "$.items"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.items1.foo"u8.ToArray(), "value"u8.ToArray() },
            { "$.bars[0].x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bars[0].x1.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.bars[1].x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bars[1].x2.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.bar.foo.x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.bar.foo.x1.y"u8.ToArray(), "value"u8.ToArray() },
            { "$.properties.virtualMachine"u8.ToArray(), "value"u8.ToArray() },
            { "$.sku.name"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.sku.name1.something"u8.ToArray(), "value"u8.ToArray() },
            { "$.foo.bar.baz"u8.ToArray(), "value"u8.ToArray() },
            { "$.foo1.baz.bar"u8.ToArray(), "value"u8.ToArray() },
            { "$.item.something.x"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x1.y"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y1.z"u8.ToArray(), "[{\"a\":\"value\"}]"u8.ToArray() },
            { "$.item.something.x.y.z1[0]"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z2[0].foo.bar.baz.qux"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z3[0].foo.bar.baz.qux.quux"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray() },
            { "$.item.something.x.y.z4[0].foo.bar.baz.qux.quux.corge"u8.ToArray(), "{\"a\":\"value\"}"u8.ToArray()},
        };

        [Benchmark]
        public void InsertItems()
        {
            JsonPatch jp = new();
            int count = 0;
            foreach (var kvp in _jsonPaths)
            {
                jp.Set(kvp.Key.AsSpan(), kvp.Value);
                count++;
                if (count >= Inserts)
                {
                    break;
                }
            }
        }

        [Benchmark]
        public void InsertItemsNoNesting()
        {
            JsonPatch jp = new();
            int count = 0;
            foreach (var kvp in _jsonPathsNoNesting)
            {
                jp.Set(kvp.Key.AsSpan(), kvp.Value);
                count++;
                if (count >= Inserts)
                {
                    break;
                }
            }
        }
    }
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
