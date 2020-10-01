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
using Azure;
using Azure.Core.Pipeline;

using OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class AzureMonitorTransmitter
    {
        private readonly ApplicationInsightsRestClient applicationInsightsRestClient;
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
            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
        }

        internal async ValueTask<int> AddBatchActivityAsync(Batch<Activity> batchActivity, bool async, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return 0;
            }

            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                telemetryItem = GeneratePartAEnvelope(activity);
                telemetryItem.InstrumentationKey = this.instrumentationKey;
                telemetryItem.Data = GenerateTelemetryData(activity);
                telemetryItems.Add(telemetryItem);
            }

            Azure.Response<TrackResponse> response;

            if (async)
            {
                // TODO: RequestFailedException is thrown when http response is not equal to 200 or 206. Implement logic to catch exception.
                response = await this.applicationInsightsRestClient.TrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = this.applicationInsightsRestClient.TrackAsync(telemetryItems, cancellationToken).Result;
            }

            // TODO: Handle exception, check telemetryItems has items
            return response.Value.ItemsAccepted.GetValueOrDefault();
        }

        private static TelemetryItem GeneratePartAEnvelope(Activity activity)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture));
            ExtractRoleInfo(activity.GetResource(), out var roleName, out var roleInstance);
            telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = roleName;
            telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = roleInstance;
            telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();
            if (activity.Parent != null)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.Parent.SpanId.ToHexString();
            }
            // TODO: Handle exception
            telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return telemetryItem;
        }

        internal static void ExtractRoleInfo(Resource resource, out string roleName, out string roleInstance)
        {
            if (resource == null)
            {
                roleName = null;
                roleInstance = null;
                return;
            }

            string serviceName = null;
            string serviceNamespace = null;
            roleInstance = null;

            foreach (var attribute in resource.Attributes)
            {
                if (attribute.Key == Resource.ServiceNameKey && attribute.Value is string)
                {
                    serviceName = attribute.Value.ToString();
                }
                else if (attribute.Key == Resource.ServiceNamespaceKey && attribute.Value is string)
                {
                    serviceNamespace = attribute.Value.ToString();
                }
                else if (attribute.Key == Resource.ServiceInstanceIdKey && attribute.Value is string)
                {
                    roleInstance = attribute.Value.ToString();
                }
            }

            if (serviceName != null && serviceNamespace != null)
            {
                roleName = string.Concat(serviceNamespace, ".", serviceName);
            }
            else
            {
                roleName = serviceName;
            }
        }

        private MonitorBase GenerateTelemetryData(Activity activity)
        {
            var telemetryType = activity.GetTelemetryType();
            var activityType = activity.TagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);
            MonitorBase telemetry = new MonitorBase
            {
                BaseType = Telemetry_Base_Type_Mapping[telemetryType]
            };

            if (telemetryType == TelemetryType.Request)
            {
                var url = activity.Kind == ActivityKind.Server ? UrlHelper.GetUrl(partBTags) : GetMessagingUrl(partBTags);
                var statusCode = GetHttpStatusCode(partBTags);
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
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString()
                };

                // TODO: Handle activity.TagObjects
                // ExtractPropertiesFromTags(dependency.Properties, activity.Tags);

                if (activityType == PartBType.Http)
                {
                    dependency.Data = UrlHelper.GetUrl(partBTags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    var statusCode = GetHttpStatusCode(partBTags);
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
