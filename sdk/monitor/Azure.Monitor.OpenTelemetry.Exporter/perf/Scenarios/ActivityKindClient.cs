// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Test.Perf;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Perf
{
    public class ActivityKindClient : PerfTest<PerfOptions>
    {
        // please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/TemplateClientTest.cs to write perf test.
        /* How to run
         * Build
            dotnet build -c Release -f <TargetFramework>
         * Run
         * dotnet run -c Release -f net7.0 --no-build --project <Path to this Project> ActivityKindClient --sync true
        */
        private const string ActivitySourceName = nameof(ActivityKindClient);
        private readonly Batch<Activity> _activityBatch;
        private readonly AzureMonitorTraceExporter _traceExporter;

        public ActivityKindClient(PerfOptions options) : base(options)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            var exporterOptions = new AzureMonitorExporterOptions();
            exporterOptions.EnableStatsbeat = false;
            exporterOptions.DisableOfflineStorage = true;
            exporterOptions.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            _traceExporter = new AzureMonitorTraceExporter(exporterOptions);

            ActivitySource activitySource = new(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                "ActivityKindClient",
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            activity?.SetStatus(ActivityStatusCode.Ok);
            activity?.SetTag(SemanticConventions.AttributeHttpScheme, "https");
            activity?.SetTag(SemanticConventions.AttributeHttpMethod, "POST");
            activity?.SetTag(SemanticConventions.AttributeHttpTarget, "api/123");
            activity?.SetTag(SemanticConventions.AttributeHttpFlavor, "1.1");
            activity?.SetTag(SemanticConventions.AttributeNetPeerName, "localhost");
            activity?.SetTag(SemanticConventions.AttributeNetPeerPort, "8080");
            activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
            activity?.Stop();

            _activityBatch = new Batch<Activity>(new Activity[] { activity ?? new Activity("Placeholder") }, 1);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var exportResult = _traceExporter.Export(_activityBatch);
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            // We do not have async export
            throw new NotImplementedException();
        }
    }
}
