// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Iot.Hub.Service.Authentication;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// The IoT Hub Service Client.
    /// </summary>
    public class IotHubServiceClient
    {
        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly DevicesRestClient _devicesRestClient;
        private readonly ModulesRestClient _modulesRestClient;
        private readonly QueryRestClient _queryRestClient;
        private readonly StatisticsRestClient _statisticsRestClient;

        /// <summary>
        /// place holder for Devices.
        /// </summary>
        public virtual DevicesClient Devices { get; private set; }

        /// <summary>
        /// place holder for Modules.
        /// </summary>
        public virtual ModulesClient Modules { get; private set; }

        /// <summary>
        /// place holder for Statistics.
        /// </summary>
        public virtual StatisticsClient Statistics { get; private set; }

        /// <summary>
        /// place holder for Messages.
        /// </summary>
        public virtual CloudToDeviceMessagesClient Messages { get; private set; }

        /// <summary>
        /// place holder for Files.
        /// </summary>
        public virtual FilesClient Files { get; private set; }

        /// <summary>
        /// place holder for Jobs
        /// </summary>
        public virtual JobsClient Jobs { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
        /// </summary>
        protected IotHubServiceClient()
        {
            // This constructor only exists for mocking purposes in unit tests. It should not be used otherwise.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <seealso cref="IotHubServiceClient(Uri, IotHubSasCredential, IotHubServiceClientOptions)">
        /// This other constructor provides an opportunity to override default behavior, including setting the sas token time to live, specifying the service API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </seealso>
        public IotHubServiceClient(string connectionString)
            : this(connectionString, new IotHubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <param name="options">
        /// Options that allow configuration of requests sent to the IoT Hub service.
        /// </param>
        /// <seealso cref="IotHubServiceClient(Uri, IotHubSasCredential, IotHubServiceClientOptions)">
        /// This other constructor provides an opportunity to override default behavior, including setting the sas token time to live, specifying the service API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </seealso>
        public IotHubServiceClient(string connectionString, IotHubServiceClientOptions options)
            : this(new IotHubSasCredential(connectionString), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
        /// </summary>
        /// <param name="endpoint">
        /// The IoT Hub service instance endpoint to connect to.
        /// </param>
        /// <param name="credential">
        /// The IoT Hub credentials, to be used for authenticating against an IoT Hub instance via SAS tokens.
        /// </param>
        /// <param name="options">
        /// (optional) Options that allow configuration of requests sent to the IoT Hub service.
        /// </param>
        public IotHubServiceClient(Uri endpoint, IotHubSasCredential credential, IotHubServiceClientOptions options = default)
            : this(SetEndpointToIotHubSasCredential(endpoint, credential), options)
        {
        }

        private IotHubServiceClient(IotHubSasCredential credential, IotHubServiceClientOptions options)
        {
            options ??= new IotHubServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new SasTokenAuthenticationPolicy(credential), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            _devicesRestClient = new DevicesRestClient(_clientDiagnostics, _httpPipeline, credential.Endpoint, options.GetVersionString());
            _modulesRestClient = new ModulesRestClient(_clientDiagnostics, _httpPipeline, credential.Endpoint, options.GetVersionString());
            _queryRestClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, credential.Endpoint, options.GetVersionString());
            _statisticsRestClient = new StatisticsRestClient(_clientDiagnostics, _httpPipeline, credential.Endpoint, options.GetVersionString());

            Devices = new DevicesClient(_devicesRestClient, _queryRestClient);
            Modules = new ModulesClient(_devicesRestClient, _modulesRestClient, _queryRestClient);
            Statistics = new StatisticsClient(_statisticsRestClient);

            Messages = new CloudToDeviceMessagesClient();
            Files = new FilesClient();
            Jobs = new JobsClient();
        }

        private static IotHubSasCredential SetEndpointToIotHubSasCredential(Uri endpoint, IotHubSasCredential credential)
        {
            credential.Endpoint = endpoint;
            return credential;
        }
    }
}
