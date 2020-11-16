// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsBenchmarks
    {
        private AzureMonitorConverter.TagEnumerationState monitorTags_no_item;
        private IEnumerable<KeyValuePair<string, object>> tagObjects;


        [GlobalSetup]
        public void Setup()
        {
            monitorTags_no_item = new AzureMonitorConverter.TagEnumerationState
            {
                PartBTags = PooledList<KeyValuePair<string, object>>.Create(),
                PartCTags = PooledList<KeyValuePair<string, object>>.Create()
            };

            tagObjects = new Dictionary<string, object>();
        }

        [GlobalCleanup]
        public void Cleanup()
        {

        }

        [Benchmark]
        public void Enumerate_PooledList_NoItem()
        {
            HttpHelper.ActivityTagsEnumeratorFactory<AzureMonitorConverter.TagEnumerationState>.Enumerate(tagObjects, ref monitorTags_no_item);
        }

        [Benchmark]
        public void Enumerate_TagObjects_NoItem()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_PooledList_Part_B()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_PooledList_Part_C()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartC()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_PooledList_PartB_And_C()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB_And_C()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }
    }
}
