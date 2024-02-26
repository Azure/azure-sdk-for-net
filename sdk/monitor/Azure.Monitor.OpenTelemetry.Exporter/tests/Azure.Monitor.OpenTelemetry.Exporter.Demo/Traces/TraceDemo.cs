// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces
{
    internal class TraceDemo : IDisposable
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        private readonly TracerProvider? _tracerProvider;

        public TraceDemo(string connectionString, TokenCredential? credential = null)
        {
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", "my-service" },
                { "service.namespace", "my-namespace" },
                { "service.instance.id", "my-instance" },
                { "service.version", "1.0.0-demo" },
            };

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .SetResourceBuilder(resourceBuilder)
                            .AddSource(ActivitySourceName)
                            .AddProcessor(new ActivityFilteringProcessor())
                            .AddProcessor(new ActivityEnrichingProcessor())
                            .AddAzureMonitorTraceExporter(o => { o.ConnectionString = connectionString; o.SamplingRatio = 1.0F; }, credential)
                            .Build();
        }

        /// <remarks>
        /// Activities will be ingested and stored in Application Insights
        /// as either a request or dependency, according to their ActivityKind.
        /// </remarks>
        public void GenerateTraces()
        {
            // Note: This activity will be dropped due to the ActivityFilteringProcessor filtering ActivityKind.Producer.
            using (var testActivity1 = s_activitySource.StartActivity("TestInternalActivity", ActivityKind.Producer))
            {
                testActivity1?.SetTag("CustomTag1", "Value1");
                testActivity1?.SetTag("CustomTag2", "Value2");
            }

            using (var activity = s_activitySource.StartActivity("SayHello", ActivityKind.Client))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);

                using (var nestedActivity = s_activitySource.StartActivity("SayHelloAgain", ActivityKind.Server))
                {
                    nestedActivity?.SetTag("bar", "Hello, World!");
                    nestedActivity?.SetStatus(ActivityStatusCode.Ok);
                }
            }

            using (var activity = s_activitySource.StartActivity("ExceptionExample"))
            {
                try
                {
                    throw new Exception("Test exception");
                }
                catch (Exception ex)
                {
                    activity?.SetStatus(ActivityStatusCode.Error);
                    activity?.RecordException(ex);
                }
            }
        }

        public void Dispose()
        {
            _tracerProvider?.Dispose();
        }

        private class ActivityFilteringProcessor : BaseProcessor<Activity>
        {
            public override void OnStart(Activity activity)
            {
                // prevents all exporters from exporting activities with activity.Kind == ActivityKind.Producer
                if (activity.Kind == ActivityKind.Producer)
                {
                    activity.IsAllDataRequested = false;
                }
            }
        }

        private class ActivityEnrichingProcessor : BaseProcessor<Activity>
        {
            public override void OnEnd(Activity activity)
            {
                // The updated activity will be available to all processors which are called after this processor.
                activity.DisplayName = "Enriched-" + activity.DisplayName;
                activity.SetTag("CustomDimension1", "Value1");
                activity.SetTag("CustomDimension2", "Value2");
                activity.SetTag("ActivityKind", activity.Kind);
            }
        }
    }
}
