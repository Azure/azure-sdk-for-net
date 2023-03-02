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

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsGetValuesBenchmarks
    {
        private AzMonList _azMonList_No_Item;
        private AzMonList _azMonList_Items;
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

            _azMonList_Items = AzMonList.Initialize();
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("intKey", 1));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("doubleKey", 1.1));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "https"));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("stringKey", "test"));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "localhost"));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("boolKey", true));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, "8888"));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("arrayKey", new int[] { 1, 2, 3 }));
           AzMonList.Add(ref _azMonList_Items, new KeyValuePair<string, object>("somekey", "value"));

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
    }
}
