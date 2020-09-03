// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

using OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class AzureMonitorTransmitter
    {
        private readonly ServiceRestClient serviceRestClient;
        private readonly AzureMonitorExporterOptions options;
        private readonly string instrumentationKey;

        private static readonly IReadOnlyDictionary<TelemetryType, string> Telemetry_Base_Type_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "RequestData",
            [TelemetryType.Dependency] = "RemoteDependencyData",
            [TelemetryType.Message] = "MessageData",
            [TelemetryType.Event] = "EventData",
        };

        private static readonly IReadOnlyDictionary<TelemetryType, string> PartA_Name_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "Request",
            [TelemetryType.Dependency] = "RemoteDependency",
            [TelemetryType.Message] = "Message",
            [TelemetryType.Event] = "Event",
        };

        public AzureMonitorTransmitter(AzureMonitorExporterOptions exporterOptions)
        {
            ConnectionStringParser.GetValues(exporterOptions.ConnectionString, out this.instrumentationKey, out string ingestionEndpoint);

            options = exporterOptions;
            serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), endpoint: ingestionEndpoint);
        }

        internal async ValueTask<int> AddBatchActivityAsync(Batch<Activity> batchActivity, bool async, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return 0;
            }

            List<TelemetryEnvelope> telemetryItems = new List<TelemetryEnvelope>();
            TelemetryEnvelope telemetryItem;

            foreach (var activity in batchActivity)
            {
                telemetryItem = GeneratePartAEnvelope(activity);
                telemetryItem.IKey = this.instrumentationKey;
                telemetryItem.Data = GenerateTelemetryData(activity);
                telemetryItems.Add(telemetryItem);
            }

            Azure.Response<TrackResponse> response;

            if (async)
            {
                response = await this.serviceRestClient.TrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = this.serviceRestClient.TrackAsync(telemetryItems, cancellationToken).Result;
            }

            // TODO: Handle exception, check telemetryItems has items
            return response.Value.ItemsAccepted.GetValueOrDefault();
        }

        private static TelemetryEnvelope GeneratePartAEnvelope(Activity activity)
        {
            // TODO: Get TelemetryEnvelope name changed in swagger
            TelemetryEnvelope envelope = new TelemetryEnvelope(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc);
            // TODO: Validate if Azure SDK has common function to generate role instance
            envelope.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = "testRoleInstance";

            envelope.Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();
            if (activity.Parent != null)
            {
                envelope.Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.Parent.SpanId.ToHexString();
            }

            // TODO: "ai.location.ip"
            // TODO: Handle exception
            envelope.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return envelope;
        }

        private MonitorBase GenerateTelemetryData(Activity activity)
        {
            var telemetryType = activity.GetTelemetryType();
            var tags = activity.Tags.ToAzureMonitorTags(out var activityType);
            MonitorBase telemetry = new MonitorBase
            {
                BaseType = Telemetry_Base_Type_Mapping[telemetryType]
            };

            if (telemetryType == TelemetryType.Request)
            {
                var url = activity.Kind == ActivityKind.Server ? UrlHelper.GetUrl(tags) : GetMessagingUrl(tags);
                var statusCode = GetHttpStatusCode(tags);
                var success = GetSuccessFromHttpStatusCode(statusCode);
                var request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
                {
                    Name = activity.DisplayName,
                    Url = url,
                    // TODO: Handle request.source.
                };

                // TODO: Handle activity.TagObjects, extract well-known tags
                // ExtractPropertiesFromTags(request.Properties, activity.Tags);

                telemetry.BaseData = request;
            }
            else if (telemetryType == TelemetryType.Dependency)
            {
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration)
                {
                    Id = activity.Context.SpanId.ToHexString()
                };

                // TODO: Handle activity.TagObjects
                // ExtractPropertiesFromTags(dependency.Properties, activity.Tags);

                if (activityType == PartBType.Http)
                {
                    dependency.Data = UrlHelper.GetUrl(tags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    var statusCode = GetHttpStatusCode(tags);
                    dependency.ResultCode = statusCode;
                    dependency.Success = GetSuccessFromHttpStatusCode(statusCode);
                }

                // TODO: Handle dependency.target.
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetHttpStatusCode(Dictionary<string, string> tags)
        {
            if (tags.TryGetValue(SemanticConventions.AttributeHttpStatusCode, out var status))
            {
                return status;
            }

            return "0";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool GetSuccessFromHttpStatusCode(string statusCode)
        {
            return statusCode == "200" || statusCode == "Ok";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetMessagingUrl(Dictionary<string, string> tags)
        {
            tags.TryGetValue(SemanticConventions.AttributeMessagingUrl, out var url);
            return url;
        }

        private static void ExtractPropertiesFromTags(IDictionary<string, string> destination, IEnumerable<KeyValuePair<string, string>> tags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            foreach (var tag in tags.Where(item => !item.Key.StartsWith("http.", StringComparison.InvariantCulture)))
            {
                destination.Add(tag);
            }
        }
    }
}
