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

using OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class AzureMonitorTransmitter
    {
        private const string StatusCode200 = "200";
        private const string StatusCode0 = "0";
        private const string StatusCodeOk = "Ok";
        private const string HttpScheme = "http://";
        private const string SchemePostfix = "://";
        private const char Colon = '/';
        private const string HttpPort80 = "80";
        private const string HttpPort443 = "443";

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
                var url = activity.Kind == ActivityKind.Server ? GetUrl(tags) : GetMessagingUrl(tags);
                var statusCode = GetStatus(tags, out bool success) ;
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
                var statusCode = GetStatus(tags, out bool success);
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString(),
                    Success = success
                };

                // TODO: Handle activity.TagObjects
                // ExtractPropertiesFromTags(dependency.Properties, activity.Tags);

                if (activityType == PartBType.Http)
                {
                    dependency.Data = GetUrl(tags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    dependency.ResultCode = statusCode;
                }

                // TODO: Handle dependency.target.
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetUrl(Dictionary<string, string> tags)
        {
            if (tags.TryGetValue(SemanticConventions.AttributeHttpUrl, out var url))
            {
                Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri);

                if (uri.IsAbsoluteUri)
                {
                    return url;
                }
            }

            if (tags.TryGetValue(SemanticConventions.AttributeHttpScheme, out var httpScheme))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var httpHost))
                {
                    tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var httpPort);
                    if (httpPort != null && httpPort != HttpPort80 && httpPort != HttpPort443)
                    {
                        url = $"{httpScheme}{SchemePostfix}{httpHost}{Colon}{httpPort}{httpTarget}";
                    }
                    else
                    {
                        url = $"{httpScheme}{SchemePostfix}{httpHost}{httpTarget}";
                    }

                    return url;
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerName, out var netPeerName)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out var netPeerPort))
                {
                    return $"{httpScheme}{SchemePostfix}{netPeerName}{Colon}{netPeerPort}{httpTarget}";
                }
                else if (tags.TryGetValue(SemanticConventions.AttributeNetPeerIp, out var netPeerIP)
                         && tags.TryGetValue(SemanticConventions.AttributeNetPeerPort, out netPeerPort))
                {
                    return $"{httpScheme}{SchemePostfix}{netPeerIP}{Colon}{netPeerPort}{httpTarget}";
                }
            }

            if (tags.TryGetValue(SemanticConventions.AttributeHttpHost, out var host))
            {
                tags.TryGetValue(SemanticConventions.AttributeHttpTarget, out var httpTarget);
                url = $"{HttpScheme}{host}{Colon}{(httpTarget ?? url)}";
            }

            return url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetStatus(Dictionary<string, string> tags, out bool success)
        {
            tags.TryGetValue(SemanticConventions.AttributeHttpStatusCode, out var status);
            success = status == StatusCode200 || status == StatusCodeOk;

            return status ?? StatusCode0;
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
