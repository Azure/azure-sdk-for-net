// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using Constants = Microsoft.Azure.WebJobs.Extensions.SignalRService.Constants;

namespace SignalRServiceExtension.Tests
{
    public class NegotiateContextAsyncConverterTest
    {
        private const string HubName = "hub1";
        private const int Count = 3;

        private static readonly IEnumerable<ServiceEndpoint> PrimaryEndpoints = FakeEndpointUtils.GetFakeConnectionString(Count).Zip(Enumerable.Range(0, Count), (ConnStr, Id) => (ConnStr, Id))
            .Select(pair => new ServiceEndpoint(pair.ConnStr, EndpointType.Primary, $"p{pair.Id}"));

        private static readonly IEnumerable<ServiceEndpoint> SecondaryEndpoints = FakeEndpointUtils.GetFakeConnectionString(Count).Zip(Enumerable.Range(0, Count), (ConnStr, Id) => (ConnStr, Id))
            .Select(pair => new ServiceEndpoint(pair.ConnStr, EndpointType.Secondary, $"s{pair.Id}"));

        private static readonly IEnumerable<ServiceEndpoint> Endpoints = PrimaryEndpoints.Concat(SecondaryEndpoints);

        [Fact]
        public async Task EndpointsEqualFact()
        {
            var configuration = CreateTestConfiguration();
            var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance);
            var converter = new NegotiationContextAsyncConverter(serviceManagerStore);
            var attribute = new SignalRNegotiationAttribute { HubName = HubName };

            var endpointList = (await converter.ConvertAsync(attribute, default)).Endpoints.Select(e => e.Name);
            foreach (var expectedEndpoint in Endpoints)
            {
                Assert.Contains(expectedEndpoint.Name, endpointList);
            }
        }

        private static IConfiguration CreateTestConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.ServiceTransportTypeName] = ServiceTransportType.Persistent.ToString();
            foreach (var e in Endpoints)
            {
                AddEndpointsToConfiguration(configuration, e);
            }
            return configuration;
        }

        private static void AddEndpointsToConfiguration(IConfiguration configuration, ServiceEndpoint endpoint)
        {
            configuration[$"{Constants.AzureSignalREndpoints}:{endpoint.Name}:{endpoint.EndpointType}"] = endpoint.ConnectionString;
        }
    }
}