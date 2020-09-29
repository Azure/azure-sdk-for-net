// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

using OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using OpenTelemetry.Exporter.AzureMonitor.HttpParsers;
using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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
                response = await this.serviceRestClient.TrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = this.serviceRestClient.TrackAsync(telemetryItems, cancellationToken).Result;
            }

            // TODO: Handle exception, check telemetryItems has items
            return response.Value.ItemsAccepted.GetValueOrDefault();
        }

        private static TelemetryItem GeneratePartAEnvelope(Activity activity)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc);
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
                string source = null;
                string statusCode = string.Empty;
                string url = null;
                bool success = true;

                switch (activityType)
                {
                    case PartBType.Http:
                        url = activity.Kind == ActivityKind.Server ? HttpHelper.GetUrl(partBTags) : ComponentHelper.GetMessagingUrl(partBTags);
                        statusCode = HttpHelper.GetHttpStatusCode(partBTags);
                        success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                        break;
                    case PartBType.Azure:
                        ComponentHelper.ExtractComponentProperties(partBTags, activity.Kind, out _, out source);
                        break;
                }

                RequestData request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
                {
                    Name = activity.DisplayName,
                    Url = url,
                    Source = source
                };

                AddPropertiesToTelemetry(request.Properties, PartCTags);
                telemetry.BaseData = request;
            }
            else if (telemetryType == TelemetryType.Dependency)
            {
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString()
                };

                switch (activityType)
                {
                    case PartBType.Http:
                        dependency.Data = HttpHelper.GetUrl(partBTags);
                        bool parsed = AzureBlobHttpParser.TryParse(ref dependency)
                                        || AzureTableHttpParser.TryParse(ref dependency)
                                        || AzureQueueHttpParser.TryParse(ref dependency)
                                        || DocumentDbHttpParser.TryParse(ref dependency)
                                        || AzureServiceBusHttpParser.TryParse(ref dependency)
                                        || GenericServiceHttpParser.TryParse(ref dependency)
                                        || AzureIotHubHttpParser.TryParse(ref dependency)
                                        || AzureSearchHttpParser.TryParse(ref dependency);

                        if (!parsed)
                        {
                            dependency.Type = RemoteDependencyConstants.HTTP;
                        }

                        var statusCode = HttpHelper.GetHttpStatusCode(partBTags);
                        dependency.ResultCode = statusCode;
                        dependency.Success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                        break;
                    case PartBType.Azure:
                        ComponentHelper.ExtractComponentProperties(partBTags, activity.Kind, out var type, out var target);
                        dependency.Target = target;
                        dependency.Type = type;
                        break;
                }

                AddPropertiesToTelemetry(dependency.Properties, PartCTags);
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }

        private static void AddPropertiesToTelemetry(IDictionary<string, string> destination, IEnumerable<KeyValuePair<string, string>> PartCTags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            foreach (var tag in PartCTags)
            {
                destination.Add(tag);
            }
        }
    }
}
