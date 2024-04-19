// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal partial class LiveMetricsRestAPIsForClientSDKsRestClient
    {
        private readonly string _host;

        public LiveMetricsRestAPIsForClientSDKsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, ConnectionVars connectionVars)
            : this(clientDiagnostics, pipeline)
        {
            _host = connectionVars.LiveEndpoint;
        }

        /// <summary> SDK ping. </summary>
        /// <param name="ikey"> The ikey of the target Application Insights component that displays server info sent by /QuickPulseService.svc/ping. </param>
        /// <param name="apikey"> Deprecated. An alternative way to pass api key. Use AAD auth instead. </param>
        /// <param name="xMsQpsTransmissionTime"> Timestamp when SDK transmits the metrics and documents to QuickPulse. A 8-byte long type of ticks. </param>
        /// <param name="xMsQpsMachineName"> Computer name where AI SDK lives. QuickPulse uses machine name with instance name as a backup. </param>
        /// <param name="xMsQpsInstanceName"> Service instance name where AI SDK lives. QuickPulse uses machine name with instance name as a backup. </param>
        /// <param name="xMsQpsStreamId"> Identifies an AI SDK as trusted agent to report metrics and documents. </param>
        /// <param name="xMsQpsRoleName"> Cloud role name for which SDK reports metrics and documents. </param>
        /// <param name="xMsQpsInvariantVersion"> Version/generation of the data contract (MonitoringDataPoint) between SDK and QuickPulse. </param>
        /// <param name="xMsQpsConfigurationEtag"> An encoded string that indicates whether the collection configuration is changed. </param>
        /// <param name="monitoringDataPoint"> Data contract between SDK and QuickPulse. /QuickPulseService.svc/ping uses this as a backup source of machine name, instance name and invariant version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ikey"/> is null. </exception>
        public QuickPulseResponse CustomPing(string ikey, string apikey = null, int? xMsQpsTransmissionTime = null, string xMsQpsMachineName = null, string xMsQpsInstanceName = null, string xMsQpsStreamId = null, string xMsQpsRoleName = null, string xMsQpsInvariantVersion = null, string xMsQpsConfigurationEtag = null, MonitoringDataPoint monitoringDataPoint = null, CancellationToken cancellationToken = default)
        {
            if (ikey == null)
            {
                throw new ArgumentNullException(nameof(ikey));
            }

            using var message = CreateIsSubscribedRequest(
                endpoint: _host,
                ikey: ikey,
                transmissionTime: xMsQpsTransmissionTime,
                machineName: xMsQpsMachineName,
                instanceName: xMsQpsInstanceName,
                streamId: xMsQpsStreamId,
                roleName: xMsQpsRoleName,
                invariantVersion: xMsQpsInvariantVersion,
                configurationEtag: xMsQpsConfigurationEtag,
                monitoringDataPoint: monitoringDataPoint);

            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CollectionConfigurationInfo value = default;
                        if (message.Response.Headers.ContentLength != 0)
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = CollectionConfigurationInfo.DeserializeCollectionConfigurationInfo(document.RootElement);
                        }
                        return new QuickPulseResponse(success: true, message.Response.Headers, value);
                    }
                case 400:
                case 401:
                case 403:
                case 404:
                case 500:
                case 503:
                    {
                        ServiceError value = default;
                        if (message.Response.Headers.ContentLength != 0)
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = ServiceError.DeserializeServiceError(document.RootElement);
                            AzureMonitorAspNetCoreEventSource.Log.PingFailedWithServiceError(message.Response.Status, value);
                        }

                        Debug.WriteLine($"{DateTime.Now}: Ping FAILED: {message.Response.Status} {message.Response.ReasonPhrase}.");
                        AzureMonitorAspNetCoreEventSource.Log.PingFailed(message.Response);
                        return new QuickPulseResponse(success: false);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> SDK post. </summary>
        /// <param name="ikey"> The ikey of the target Application Insights component that displays metrics and documents sent by /QuickPulseService.svc/post. </param>
        /// <param name="apikey"> An alternative way to pass api key. Deprecated. Use AAD authentication instead. </param>
        /// <param name="xMsQpsConfigurationEtag"> An encoded string that indicates whether the collection configuration is changed. </param>
        /// <param name="xMsQpsTransmissionTime"> Timestamp when SDK transmits the metrics and documents to QuickPulse. A 8-byte long type of ticks. </param>
        /// <param name="monitoringDataPoints"> Data contract between SDK and QuickPulse. /QuickPulseService.svc/post uses this to publish metrics and documents to the backend QuickPulse server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ikey"/> is null. </exception>
        public QuickPulseResponse CustomPost(string ikey, string apikey = null, string xMsQpsConfigurationEtag = null, int? xMsQpsTransmissionTime = null, IEnumerable<MonitoringDataPoint> monitoringDataPoints = null, CancellationToken cancellationToken = default)
        {
            if (ikey == null)
            {
                throw new ArgumentNullException(nameof(ikey));
            }

            using var message = CreatePublishRequest(
                endpoint: _host,
                ikey: ikey,
                transmissionTime: xMsQpsTransmissionTime,
                configurationEtag: xMsQpsConfigurationEtag,
                monitoringDataPoints: monitoringDataPoints);

            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CollectionConfigurationInfo value = default;
                        if (message.Response.Headers.ContentLength != 0)
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = CollectionConfigurationInfo.DeserializeCollectionConfigurationInfo(document.RootElement);
                        }
                        return new QuickPulseResponse(success: true, message.Response.Headers, value);
                    }
                case 400:
                case 401:
                case 403:
                case 404:
                case 500:
                case 503:
                    {
                        ServiceError value = default;
                        if (message.Response.Headers.ContentLength != 0)
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = ServiceError.DeserializeServiceError(document.RootElement);
                            AzureMonitorAspNetCoreEventSource.Log.PostFailedWithServiceError(message.Response.Status, value);
                        }

                        Debug.WriteLine($"{DateTime.Now}: Post FAILED: {message.Response.Status} {message.Response.ReasonPhrase}.");
                        AzureMonitorAspNetCoreEventSource.Log.PostFailed(message.Response);
                        return new QuickPulseResponse(success: false);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
