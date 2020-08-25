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
using OpenTelemetry.Exporter.AzureMonitor.Extensions;
using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class AzureMonitorTransmitter
    {
        private const string StatusCode_200 = "200";
        private const string StatusCode_0 = "0";
        private const string StatusCode_Ok = "Ok";
        private const string HttpUrlPrefix = "http://";

        private readonly ServiceRestClient serviceRestClient;
        private readonly AzureMonitorExporterOptions options;

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
            options = exporterOptions;
            serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options));
        }

        internal async ValueTask<int> AddBatchActivityAsync(IEnumerable<Activity> batchActivity, CancellationToken cancellationToken)
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
                telemetryItem.Data = GenerateTelemetryData(activity);
                telemetryItems.Add(telemetryItem);
            }

            // TODO: Handle exception, check telemetryItems has items
            var response = await this.serviceRestClient.TrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
            return response.Value.ItemsAccepted.GetValueOrDefault();
        }

        private static TelemetryEnvelope GeneratePartAEnvelope(Activity activity)
        {
            // TODO: Get TelemetryEnvelope name changed in swagger
            TelemetryEnvelope envelope = new TelemetryEnvelope(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc);
            // TODO: Extract IKey from connectionstring
            envelope.IKey = "IKey";
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
            MonitorBase telemetry = new MonitorBase();

            var tags = activity.Tags.ToAzureMonitorTags(out var activityType);
            var telemetryType = activity.GetTelemetryType();
            telemetry.BaseType = Telemetry_Base_Type_Mapping[telemetryType];

            if (telemetryType == TelemetryType.Request)
            {
                var url = activity.Kind == ActivityKind.Server ? GetHttpUrl(tags) : GetMessagingUrl(tags);
                var statusCode = GetStatus(tags, out bool success) ?? StatusCode_0 ;
                var request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
                {
                    Name = activity.DisplayName,
                    Url = url,
                    // TODO: Handle request.source.
                };

                // TODO: Handle activity.TagObjects
                ExtractPropertiesFromTags(request.Properties, activity.Tags);

                telemetry.BaseData = request;
            }
            else if (telemetryType == TelemetryType.Dependency)
            {
                var statusCode = GetStatus(tags, out bool success) ?? StatusCode_0;
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString(),
                    Success = success
                };

                // TODO: Handle activity.TagObjects
                // ExtractPropertiesFromTags(dependency.Properties, activity.Tags);

                if (activityType != PartBType.Http)
                {
                    dependency.Data = GetHttpUrl(tags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    dependency.ResultCode = statusCode;
                }

                // TODO: Handle dependency.target.
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetHttpUrl(Dictionary<string, string> tags)
        {
            if (tags.TryGetValue(SemanticConventions.AttributeHttpUrl, out var url))
            {
                Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri);

                if (uri.IsAbsoluteUri)
                {
                    return url;
                }
            }

            // TODO: Consider StringBuilder
            if (tags.TryGetValue(SemanticConventions.AttributeHttpScheme, out var httpScheme))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var httpHost))
                {
                    url = httpScheme + httpHost + httpTarget;
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerName, out var netPeerName)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out var netPeerPort))
                {
                    url = httpScheme + netPeerName + netPeerPort + httpTarget;
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerIp, out var netPeerIP)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out netPeerPort))
                {
                    url = httpScheme + netPeerIP + netPeerPort + httpTarget;
                }
            }

            if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var host))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                url = HttpUrlPrefix + host + (httpTarget ?? url);
            }

            return url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetStatus(Dictionary<string, string> tags, out bool success)
        {
            tags.TryGetValue(SemanticConventions.AttributeHttpStatusCode, out var status);
            success = (status == StatusCode_200 || status == StatusCode_Ok) ? true : false;

            return status;
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
