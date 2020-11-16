// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using OpenTelemetry.Trace;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsGetValuesBenchmarks
    {
        private PooledList<KeyValuePair<string, object>> PooledList_No_Item;
        private PooledList<KeyValuePair<string, object>> PooledList_Items;
        private IEnumerable<KeyValuePair<string, object>> TagObjects_No_Item;
        private IEnumerable<KeyValuePair<string, object>> TagObjects_Items;
        private Activity IteamActivity;
        private Activity EmptyActivity;

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
            PooledList_No_Item = PooledList<KeyValuePair<string, object>>.Create();
            TagObjects_No_Item = new Dictionary<string, object>();

            PooledList_Items = PooledList<KeyValuePair<string, object>>.Create();
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("intKey", 1));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("doubleKey", 1.1));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "https"));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("stringKey", "test"));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "localhost"));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("boolKey", true));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, "8888"));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("arrayKey", new int[] { 1, 2, 3 }));
            PooledList<KeyValuePair<string, object>>.Add(ref PooledList_Items, new KeyValuePair<string, object>("somekey", "value"));

            TagObjects_Items = new Dictionary<string, object>
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
            this.IteamActivity = activitySource.StartActivity("WithTags");
            this.IteamActivity.AddTag("intKey", 1);
            this.IteamActivity.AddTag("doubleKey", 1.1);
            this.IteamActivity.AddTag(SemanticConventions.AttributeHttpScheme, "https");
            this.IteamActivity.AddTag("stringKey", "test");
            this.IteamActivity.AddTag(SemanticConventions.AttributeHttpHost, "localhost");
            this.IteamActivity.AddTag("boolKey", true);
            this.IteamActivity.AddTag(SemanticConventions.AttributeHttpHostPort, "8888");
            this.IteamActivity.AddTag("arrayKey", new int[] { 1, 2, 3 });
            this.IteamActivity.AddTag("somekey", "value");

            this.EmptyActivity = activitySource.StartActivity("NoTags");
        }

        [Benchmark]
        public void GetTagValueEmptyTagObjects()
        {
            (TagObjects_No_Item as Dictionary<string, object>).TryGetValue(SemanticConventions.AttributeHttpHost, out _);
        }

        [Benchmark]
        public void GetTagValueNonemptyTagObjects()
        {
            (TagObjects_Items as Dictionary<string, object>).TryGetValue(SemanticConventions.AttributeHttpHost, out _);
        }

        [Benchmark]
        public void GetTagValueEmptyPooledList()
        {
            object _ = PooledList_No_Item.GetTagValue(SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueNonemptyPooledList()
        {
            object _ = PooledList_Items.GetTagValue(SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueEmptyActivityTags()
        {
            object _ = this.EmptyActivity.GetTagValue(SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueNonemptyActivityTags()
        {
            object _ = this.IteamActivity.GetTagValue(SemanticConventions.AttributeHttpHost);
        }
    }
}
