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
        private AzMonList AzMonList_No_Item;
        private AzMonList AzMonList_Items;
        private IEnumerable<KeyValuePair<string, object>> TagObjects_No_Item;
        private IEnumerable<KeyValuePair<string, object>> TagObjects_Items;
        private Activity ItemActivity;
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
            AzMonList_No_Item = AzMonList.Initialize();
            TagObjects_No_Item = new Dictionary<string, object>();

            AzMonList_Items = AzMonList.Initialize();
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("intKey", 1));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("doubleKey", 1.1));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "https"));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("stringKey", "test"));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "localhost"));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("boolKey", true));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, "8888"));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("arrayKey", new int[] { 1, 2, 3 }));
           AzMonList.Add(ref AzMonList_Items, new KeyValuePair<string, object>("somekey", "value"));

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
            this.ItemActivity = activitySource.StartActivity("WithTags");
            this.ItemActivity.AddTag("intKey", 1);
            this.ItemActivity.AddTag("doubleKey", 1.1);
            this.ItemActivity.AddTag(SemanticConventions.AttributeHttpScheme, "https");
            this.ItemActivity.AddTag("stringKey", "test");
            this.ItemActivity.AddTag(SemanticConventions.AttributeHttpHost, "localhost");
            this.ItemActivity.AddTag("boolKey", true);
            this.ItemActivity.AddTag(SemanticConventions.AttributeHttpHostPort, "8888");
            this.ItemActivity.AddTag("arrayKey", new int[] { 1, 2, 3 });
            this.ItemActivity.AddTag("somekey", "value");

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
        public void GetTagValueEmptyAzMonList()
        {
            object _ = AzMonList.GetTagValue(ref AzMonList_No_Item, SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueNonemptyAzMonList()
        {
            object _ = AzMonList.GetTagValue(ref AzMonList_Items, SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueEmptyActivityTags()
        {
            object _ = this.EmptyActivity.GetTagValue(SemanticConventions.AttributeHttpHost);
        }

        [Benchmark]
        public void GetTagValueNonemptyActivityTags()
        {
            object _ = this.ItemActivity.GetTagValue(SemanticConventions.AttributeHttpHost);
        }
    }
}
