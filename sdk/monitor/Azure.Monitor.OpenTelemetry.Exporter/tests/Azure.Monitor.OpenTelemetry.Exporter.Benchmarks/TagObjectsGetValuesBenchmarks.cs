// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

using System.Collections.Generic;
using System.Diagnostics;

/*
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


|                        Method |      Mean |     Error |    StdDev |    Median | Allocated |
|------------------------------ |----------:|----------:|----------:|----------:|----------:|
|    GetTagValueEmptyTagObjects |  5.762 ns | 0.1512 ns | 0.4412 ns |  5.650 ns |         - |
| GetTagValueNonemptyTagObjects | 14.824 ns | 0.3339 ns | 0.8796 ns | 14.521 ns |         - |
|     GetTagValueEmptyAzMonList |  1.909 ns | 0.0737 ns | 0.1618 ns |  1.901 ns |         - |
|  GetTagValueNonemptyAzMonList |  9.269 ns | 0.2202 ns | 0.4833 ns |  9.220 ns |         - |
*/

/*
Re-measured on .NET 8 before the AzMonList rework. Two things changed since the .NET 6
run above:

1. The ordering that justified AzMonList's linear scan has REVERSED. On .NET 6 the scan
   (9.269 ns) beat Dictionary.TryGetValue (14.824 ns); on .NET 8 the scan (13.784 ns) is
   SLOWER than Dictionary.TryGetValue (9.619 ns). Runtime string hashing improved.
2. GetTagValues allocates on every call - the params array plus the result array.

GetTagValueAzMonList_x26 shows the compounding a single-lookup benchmark hides: the
old-semconv HTTP client conversion performs 26 lookups.

NOTE: ShortRun (3 iterations) - Error is wide.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.400
  [Host]   : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4
  ShortRun : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4

Job=ShortRun  IterationCount=3  LaunchCount=1  WarmupCount=3

| Method                        | Mean       | Error      | StdDev    | Gen0   | Allocated |
|------------------------------ |-----------:|-----------:|----------:|-------:|----------:|
| GetTagValueEmptyTagObjects    |   2.518 ns |  0.3196 ns | 0.0175 ns |      - |         - |
| GetTagValueNonemptyTagObjects |   9.619 ns |  1.1204 ns | 0.0614 ns |      - |         - |
| GetTagValueEmptyAzMonList     |   1.304 ns |  0.7231 ns | 0.0396 ns |      - |         - |
| GetTagValueNonemptyAzMonList  |  13.784 ns |  2.2086 ns | 0.1211 ns |      - |         - |
| GetTagValuesTwoKeysAzMonList  |  75.288 ns |  7.4244 ns | 0.4070 ns | 0.0031 |      80 B |
| GetTagValuesFiveKeysAzMonList | 188.756 ns | 12.0554 ns | 0.6608 ns | 0.0050 |     128 B |
| GetTagValueAzMonList_x26      | 254.895 ns | 47.5259 ns | 2.6051 ns |      - |         - |
*/

/*
After adding the slot index. Reading a recognized attribute by slot removes the scan and the
string comparisons entirely. GetTagValues is gone, so its two allocations per call are gone
with it.

The x26 pair is the honest comparison - a single slot read is small enough that the JIT can
fold it away. 270.0 ns -> 13.5 ns is a 20x reduction on the number of lookups an
old-semconv HTTP client conversion actually performs.

The scan list holds unrecognized tags only and the slot list recognized attributes only,
matching how the two are built in production.

| Method                         | Mean        | Error      | StdDev    | Allocated |
|------------------------------- |------------:|-----------:|----------:|----------:|
| GetTagValueEmptyTagObjects     |   2.1544 ns |  0.0584 ns | 0.0032 ns |         - |
| GetTagValueNonemptyTagObjects  |   9.2364 ns |  1.5102 ns | 0.0828 ns |         - |
| GetTagValueEmptyAzMonList      |   1.1930 ns |  0.2083 ns | 0.0114 ns |         - |
| GetTagValueNonemptyAzMonList   |  16.3385 ns |  0.8378 ns | 0.0459 ns |         - |
| GetTagValueBySlotAzMonList     |   0.0087 ns |  0.1578 ns | 0.0086 ns |         - |
| GetTagValueAzMonList_x26       | 269.9516 ns | 41.3607 ns | 2.2671 ns |         - |
| GetTagValueBySlotAzMonList_x26 |  13.5489 ns |  0.4264 ns | 0.0234 ns |         - |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsGetValuesBenchmarks
    {
        private AzMonList _azMonList_No_Item;
        private AzMonList _azMonList_Items;
        private AzMonList _azMonList_Mapped;
        private IEnumerable<KeyValuePair<string, object>> _tagObjects_No_Item;
        private IEnumerable<KeyValuePair<string, object>> _tagObjects_Items;
        private Activity _itemActivity;

        static TagObjectsGetValuesBenchmarks()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [GlobalSetup]
        public void Setup()
        {
            _azMonList_No_Item = AzMonList.Initialize();
            _tagObjects_No_Item = new Dictionary<string, object>();

            // Unrecognized tags only, matching the UnMappedTags list in production. Nine entries
            // keeps the scan depth equal to the recorded baseline.
            _azMonList_Items = AzMonList.Initialize();
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("intKey", 1));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("doubleKey", 1.1));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("schemeKey", "https"));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("stringKey", "test"));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("hostKey", "localhost"));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("boolKey", true));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("portKey", "8888"));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("arrayKey", new int[] { 1, 2, 3 }));
            AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("somekey", "value"));

            // Recognized attributes only, matching the MappedTags list in production.
            _azMonList_Mapped = AzMonList.InitializeForMappedTags();
            AzMonList.Add(ref _azMonList_Mapped, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "https"));
            AzMonList.Add(ref _azMonList_Mapped, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "localhost"));
            AzMonList.Add(ref _azMonList_Mapped, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, "8888"));

            _tagObjects_Items = new Dictionary<string, object>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                [SemanticConventions.AttributeHttpScheme] = "https",
                ["stringKey"] = "test",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                ["boolKey"] = true,
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["arrayKey"] = new int[] { 1, 2, 3 },
                ["somekey"] = "value"
            };

            using var activitySource = new ActivitySource("test");
            _itemActivity = activitySource.StartActivity("WithTags");
            _itemActivity.AddTag("intKey", 1);
            _itemActivity.AddTag("doubleKey", 1.1);
            _itemActivity.AddTag(SemanticConventions.AttributeHttpScheme, "https");
            _itemActivity.AddTag("stringKey", "test");
            _itemActivity.AddTag(SemanticConventions.AttributeHttpHost, "localhost");
            _itemActivity.AddTag("boolKey", true);
            _itemActivity.AddTag(SemanticConventions.AttributeHttpHostPort, "8888");
            _itemActivity.AddTag("arrayKey", new int[] { 1, 2, 3 });
            _itemActivity.AddTag("somekey", "value");
        }

        [Benchmark]
        public void GetTagValueEmptyTagObjects()
        {
            (_tagObjects_No_Item as Dictionary<string, object>).TryGetValue(SemanticConventions.AttributeHttpHost, out _);
        }

        [Benchmark]
        public void GetTagValueNonemptyTagObjects()
        {
            (_tagObjects_Items as Dictionary<string, object>).TryGetValue("somekey", out _);
        }

        [Benchmark]
        public void GetTagValueEmptyAzMonList()
        {
            AzMonList.GetTagValue(ref _azMonList_No_Item, SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueNonemptyAzMonList()
        {
            AzMonList.GetTagValue(ref _azMonList_Items, "somekey");
        }

        // Constant-time read of a recognized attribute, replacing the linear scan above.
        [Benchmark]
        public void GetTagValueBySlotAzMonList()
        {
            _ = _azMonList_Mapped[SemanticSlot.HttpHost];
        }

        // The real conversion path performs 13-26 lookups; a single lookup understates it.
        [Benchmark]
        public void GetTagValueAzMonList_x26()
        {
            for (int i = 0; i < 26; i++)
            {
                AzMonList.GetTagValue(ref _azMonList_Items, "somekey");
            }
        }

        [Benchmark]
        public void GetTagValueBySlotAzMonList_x26()
        {
            for (int i = 0; i < 26; i++)
            {
                _ = _azMonList_Mapped[SemanticSlot.HttpHost];
            }
        }
    }
}
