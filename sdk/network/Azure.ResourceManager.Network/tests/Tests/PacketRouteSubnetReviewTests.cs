// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PacketRouteSubnetReviewTests
    {
        private const string ReferenceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/publicIPAddresses/ip";

        [Test]
        public async Task PacketCaptureOperationsUseTheReleasedRequestEnvelopeAndResponseModel(
            [Values(false, true)] bool update, [Values(false, true)] bool async,
            [Values(WaitUntil.Started, WaitUntil.Completed)] WaitUntil waitUntil)
        {
            const string subscription = "00000000-0000-0000-0000-000000000001";
            const string watcherId = "/subscriptions/" + subscription + "/resourceGroups/rg/providers/Microsoft.Network/networkWatchers/watcher";
            const string captureId = watcherId + "/packetCaptures/capture";
            var content = new PacketCaptureCreateOrUpdateContent("target", new PacketCaptureStorageLocation { FilePath = "capture.cap" })
            {
                TargetType = PacketCaptureTargetType.AzureVmss,
                TimeLimitInSeconds = 120,
                IsContinuousCapture = true,
                CaptureSettings = new PacketCaptureSettings { FileCount = 2 }
            };
            content.Filters.Add(new PacketCaptureFilter { Protocol = PcProtocol.Tcp });
            var response = new MockResponse(201).SetContent(
                $$"""{"id":"{{captureId}}","name":"capture","type":"Microsoft.Network/networkWatchers/packetCaptures","etag":"tag","properties":{"target":"target","storageLocation":{"filePath":"capture.cap"},"filters":[{"protocol":"TCP"}],"provisioningState":"Succeeded"}}""");
            int requests = 0;
            var client = new ArmClient(new MockCredential(), subscription, new ArmClientOptions
            {
                Transport = MockTransport.FromMessageCallback(message =>
                {
                    requests++;
                    Assert.That(message.Request.Method, Is.EqualTo(RequestMethod.Put));
                    Assert.That(message.Request.Uri.ToUri().AbsolutePath, Is.EqualTo(captureId));
                    using var stream = new MemoryStream();
                    message.Request.Content.WriteTo(stream, CancellationToken.None);
                    using var document = JsonDocument.Parse(stream.ToArray());
                    JsonElement properties = document.RootElement.GetProperty("properties");
                    Assert.That(document.RootElement.TryGetProperty("target", out _), Is.False);
                    Assert.That(properties.TryGetProperty("properties", out _), Is.False);
                    Assert.That(properties.GetProperty("target").GetString(), Is.EqualTo("target"));
                    Assert.That(properties.GetProperty("storageLocation").GetProperty("filePath").GetString(), Is.EqualTo("capture.cap"));
                    Assert.That(properties.GetProperty("filters")[0].GetProperty("protocol").GetString(), Is.EqualTo("TCP"));
                    Assert.That(properties.GetProperty("targetType").GetString(), Is.EqualTo("AzureVMSS"));
                    Assert.That(properties.GetProperty("timeLimitInSeconds").GetInt32(), Is.EqualTo(120));
                    Assert.That(properties.GetProperty("continuousCapture").GetBoolean(), Is.True);
                    Assert.That(properties.GetProperty("captureSettings").GetProperty("fileCount").GetInt32(), Is.EqualTo(2));
                    return response;
                })
            });
            using var cancellation = new CancellationTokenSource();
            var resource = client.GetPacketCaptureResource(new ResourceIdentifier(captureId));
            var collection = client.GetNetworkWatcherResource(new ResourceIdentifier(watcherId)).GetPacketCaptures();
            ArmOperation<PacketCaptureResource> operation;
            if (update)
                operation = async
                    ? await resource.UpdateAsync(waitUntil, content, cancellation.Token)
                    : resource.Update(waitUntil, content, cancellation.Token);
            else
                operation = async
                    ? await collection.CreateOrUpdateAsync(waitUntil, "capture", content, cancellation.Token)
                    : collection.CreateOrUpdate(waitUntil, "capture", content, cancellation.Token);
            Assert.That(requests, Is.EqualTo(1));
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Id.ToString(), Is.EqualTo(captureId));
            Assert.That(operation.Value.Data.Target, Is.EqualTo("target"));
            Assert.That(operation.Value.Data.StorageLocation.FilePath, Is.EqualTo("capture.cap"));
            Assert.That(operation.Value.Data.Filters.Single().Protocol, Is.EqualTo(PcProtocol.Tcp));
            Assert.That(operation.Value.Data.ProvisioningState, Is.EqualTo(NetworkProvisioningState.Succeeded));
            Assert.That(operation.GetRawResponse(), Is.SameAs(response));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void PacketCaptureRequestPreservesItsWireShapeAndSchemaPropertyMutability(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var content = ModelReaderWriter.Read<PacketCaptureCreateOrUpdateContent>(BinaryData.FromString(
                """{"properties":{"target":"target","storageLocation":{},"futureProperty":true},"futureEnvelope":17}"""), options);
            content.Scope = new PacketCaptureMachineScope();
            content.Scope.Include.Add("0");
            content.TargetType = PacketCaptureTargetType.AzureVmss;
            content.BytesToCapturePerPacket = 64;
            content.TotalBytesPerSession = 1024;
            content.TimeLimitInSeconds = 60;
            content.IsContinuousCapture = true;
            content.CaptureSettings = new PacketCaptureSettings { FileCount = 2 };
            content.Filters.Add(new PacketCaptureFilter { Protocol = PcProtocol.Tcp });
            content.Target = "updated-target";
            content.StorageLocation = new PacketCaptureStorageLocation { FilePath = "updated.cap" };
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(content, options));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(document.RootElement.TryGetProperty("target", out _), Is.False);
            Assert.That(properties.TryGetProperty("properties", out _), Is.False);
            Assert.That(properties.GetProperty("target").GetString(), Is.EqualTo("updated-target"));
            Assert.That(properties.GetProperty("storageLocation").GetProperty("filePath").GetString(), Is.EqualTo("updated.cap"));
            Assert.That(properties.GetProperty("scope").GetProperty("include")[0].GetString(), Is.EqualTo("0"));
            Assert.That(properties.GetProperty("targetType").GetString(), Is.EqualTo("AzureVMSS"));
            Assert.That(properties.GetProperty("bytesToCapturePerPacket").GetInt64(), Is.EqualTo(64));
            Assert.That(properties.GetProperty("totalBytesPerSession").GetInt64(), Is.EqualTo(1024));
            Assert.That(properties.GetProperty("timeLimitInSeconds").GetInt32(), Is.EqualTo(60));
            Assert.That(properties.GetProperty("continuousCapture").GetBoolean(), Is.True);
            Assert.That(properties.GetProperty("captureSettings").GetProperty("fileCount").GetInt32(), Is.EqualTo(2));
            Assert.That(properties.GetProperty("filters")[0].GetProperty("protocol").GetString(), Is.EqualTo("TCP"));
            if (format == "J")
            {
                Assert.That(properties.GetProperty("futureProperty").GetBoolean(), Is.True);
                Assert.That(document.RootElement.GetProperty("futureEnvelope").GetInt32(), Is.EqualTo(17));
            }
            var roundTrip = ModelReaderWriter.Read<PacketCaptureCreateOrUpdateContent>(ModelReaderWriter.Write(content, options), options);
            Assert.That(roundTrip.Target, Is.EqualTo("updated-target"));
            Assert.That(roundTrip.TimeLimitInSeconds, Is.EqualTo(60));
            Assert.That(typeof(PacketCaptureCreateOrUpdateContent).GetProperty("Target").SetMethod, Is.Not.Null);
            Assert.That(typeof(PacketCaptureCreateOrUpdateContent).GetProperty("StorageLocation").SetMethod, Is.Not.Null);
            Assert.That(typeof(PacketCaptureCreateOrUpdateContent).GetProperty("Properties"), Is.Null);
            Assert.That(typeof(PacketCaptureCreateOrUpdateContent).Assembly.GetType("Azure.ResourceManager.Network.Models.PacketCaptureContent"), Is.Null);
            Assert.That(typeof(PacketCaptureCreateOrUpdateContent).Assembly.GetType("Azure.ResourceManager.Network.Models.PacketCaptureParameters").IsNotPublic, Is.True);
        }

        [Test]
        public async Task PolicyUpdateProjectsTheCompletedNativeOperation([Values(false, true)] bool async)
        {
            var resource = new RecordingPolicyResource();
            var data = new PolicySignaturesOverridesForIdpsData();
            using var cancellation = new CancellationTokenSource();
            Response<PolicySignaturesOverridesForIdpsResource> response = async
                ? await resource.UpdateAsync(data, cancellation.Token)
                : resource.Update(data, cancellation.Token);
            Assert.That(resource.WaitUntil, Is.EqualTo(WaitUntil.Completed));
            Assert.That(resource.Data, Is.SameAs(data));
            Assert.That(resource.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(response.Value, Is.SameAs(resource));
            Assert.That(response.GetRawResponse(), Is.SameAs(resource.Response));
        }

        [Test]
        public async Task GatewayCompatibilityActionsReturnCompletedNativeOperations(
            [Values(false, true)] bool services, [Values(false, true)] bool async,
            [Values(WaitUntil.Started, WaitUntil.Completed)] WaitUntil waitUntil)
        {
            var recording = new RecordingGatewayResource();
            ServiceGatewayResource resource = recording;
            using var cancellation = new CancellationTokenSource();
            ArmOperation operation;
            if (services)
            {
                var content = new ServiceGatewayUpdateServicesContent();
                operation = async
                    ? await resource.UpdateServicesAsync(waitUntil, content, cancellation.Token)
                    : resource.UpdateServices(waitUntil, content, cancellation.Token);
                Assert.That(recording.Content, Is.SameAs(content));
            }
            else
            {
                var content = new ServiceGatewayUpdateAddressLocationsContent();
                operation = async
                    ? await resource.UpdateAddressLocationsAsync(waitUntil, content, cancellation.Token)
                    : resource.UpdateAddressLocations(waitUntil, content, cancellation.Token);
                Assert.That(recording.Content, Is.SameAs(content));
            }
            Assert.That(recording.Calls, Is.EqualTo(1));
            Assert.That(recording.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse(), Is.SameAs(recording.Response));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeEtagsAndReadonlyFiltersUseDeserializedStorage(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var etag = BinaryData.FromString("""{"etag":"\"tag\""}""");
            Assert.That(ModelReaderWriter.Read<PrivateDnsZoneGroupData>(etag, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(ModelReaderWriter.Read<RoutingIntentData>(etag, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(ModelReaderWriter.Read<SecurityPartnerProviderData>(etag, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(ModelReaderWriter.Read<VirtualApplianceSiteData>(etag, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            var capture = ModelReaderWriter.Read<PacketCaptureData>(BinaryData.FromString(
                """{"properties":{"filters":[{"protocol":"TCP"}]}}"""), options);
            Assert.That(capture.Filters.Count, Is.EqualTo(1));
            Assert.That(typeof(PacketCaptureData).GetProperty("Filters").PropertyType, Is.EqualTo(typeof(IReadOnlyList<PacketCaptureFilter>)));
            var empty = ModelReaderWriter.Read<PacketCaptureData>(BinaryData.FromString("{}"), options);
            Assert.That(empty.Filters, Is.Null);
        }

        [Test]
        public void NativeReferenceListsKeepTheirReleasedTypesAndWireStorage()
        {
            var json = BinaryData.FromString($$"""{"properties":{"publicIPAddresses":[{"id":"{{ReferenceId}}"}]}}""");
            var prefix = ModelReaderWriter.Read<PublicIPPrefixData>(json);
            Assert.That(typeof(PublicIPPrefixData).GetProperty("PublicIPAddresses").PropertyType, Is.EqualTo(typeof(IReadOnlyList<SubResource>)));
            Assert.That(prefix.PublicIPAddresses.Single().Id.ToString(), Is.EqualTo(ReferenceId));
            Assert.That(prefix.PublicIPAddresses, Is.SameAs(prefix.PublicIPAddresses));
            var subnet = ModelReaderWriter.Read<SubnetData>(BinaryData.FromString(
                $$"""{"properties":{"ipAllocations":[{"id":"{{ReferenceId}}"}],"ipConfigurationProfiles":[],"ipConfigurations":[]}}"""));
            Assert.That(typeof(SubnetData).GetProperty("IPAllocations").PropertyType, Is.EqualTo(typeof(IList<WritableSubResource>)));
            Assert.That(subnet.IPAllocations.Single().Id.ToString(), Is.EqualTo(ReferenceId));
            Assert.That(subnet.IPAllocations, Is.SameAs(subnet.IPAllocations));
            Assert.That(subnet.IPConfigurationProfiles, Is.Empty);
            Assert.That(subnet.IPConfigurations, Is.Empty);
            subnet.IPAllocations.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferenceId + "2") });
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(subnet));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("ipAllocations").GetArrayLength(), Is.EqualTo(2));
            var definition = ModelReaderWriter.Read<ServiceEndpointPolicyDefinitionData>(BinaryData.FromString(
                $$"""{"properties":{"serviceResources":["{{ReferenceId}}"]}}"""));
            Assert.That(definition.ServiceResources.Single().ToString(), Is.EqualTo(ReferenceId));
            definition.ServiceResources.Add(new ResourceIdentifier(ReferenceId + "2"));
            using var definitionDocument = JsonDocument.Parse(ModelReaderWriter.Write(definition));
            Assert.That(definitionDocument.RootElement.GetProperty("properties").GetProperty("serviceResources").GetArrayLength(), Is.EqualTo(2));
        }

        [Test]
        public void NativeNamesConstructorsAndPageableContractsReplaceAccidentalShims()
        {
            Assert.That(typeof(EffectiveBaseSecurityAdminRule).GetProperty("ResourceId"), Is.Not.Null);
            Assert.That(typeof(EffectiveBaseSecurityAdminRule).GetProperty("Id"), Is.Null);
            Assert.That(typeof(RouteData).GetProperty("NextHopIPAddresses"), Is.Not.Null);
            Assert.That(typeof(RouteData).GetProperty("NextHopIpAddresses"), Is.Null);
            Assert.That(typeof(RouteFilterRuleData).GetProperty("Location").SetMethod, Is.Not.Null);
            Assert.That(typeof(PeerExpressRouteCircuitConnectionData).GetConstructor(Type.EmptyTypes), Is.Not.Null);
            Assert.That(typeof(NetworkManagerConnectionData).Assembly.GetType("Azure.ResourceManager.Network.SubscriptionNetworkManagerConnectionData"), Is.Null);
            Assert.That(typeof(SubnetResource).GetMethod("GetResourceNavigationLinks").ReturnType, Is.EqualTo(typeof(Pageable<ResourceNavigationLink>)));
            Assert.That(typeof(SubnetResource).GetMethod("GetResourceNavigationLinksAsync").ReturnType, Is.EqualTo(typeof(AsyncPageable<ResourceNavigationLink>)));
            Assert.That(typeof(SubnetResource).GetMethod("GetServiceAssociationLinks").ReturnType, Is.EqualTo(typeof(Pageable<ServiceAssociationLink>)));
            Assert.That(typeof(SubnetResource).GetMethod("GetServiceAssociationLinksAsync").ReturnType, Is.EqualTo(typeof(AsyncPageable<ServiceAssociationLink>)));
            var route = ModelReaderWriter.Read<RouteData>(BinaryData.FromString("""{"properties":{"hasBgpOverride":true}}"""));
            route.HasBgpOverride = false;
            Assert.That(route.HasBgpOverride, Is.True);
            var rule = new RouteFilterRuleData { Location = AzureLocation.WestUS };
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(rule));
            Assert.That(document.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
        }

        [Test]
        public void PrefixCompatibilitySetterKeepsTheNativeReadonlyValue()
        {
            var prefix = ModelReaderWriter.Read<PublicIPPrefixData>(BinaryData.FromString(
                $$"""{"properties":{"loadBalancerFrontendIpConfiguration":{"id":"{{ReferenceId}}"}}}"""));
            prefix.LoadBalancerFrontendIPConfigurationId = new ResourceIdentifier(ReferenceId + "2");
            Assert.That(prefix.LoadBalancerFrontendIPConfigurationId.ToString(), Is.EqualTo(ReferenceId));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void QueryNatMappingGeneratesTheReleasedWritableIdentifierAndObjectWireShape(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var content = new QueryInboundNatRulePortMappingContent { IPConfigurationId = new ResourceIdentifier(ReferenceId) };
            content.IPConfigurationId = new ResourceIdentifier(ReferenceId + "2");
            BinaryData json = ModelReaderWriter.Write(content, options);
            using var document = JsonDocument.Parse(json);
            Assert.That(document.RootElement.GetProperty("ipConfiguration").GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
            var roundTrip = ModelReaderWriter.Read<QueryInboundNatRulePortMappingContent>(json, options);
            Assert.That(roundTrip.IPConfigurationId.ToString(), Is.EqualTo(ReferenceId + "2"));
            Assert.That(typeof(QueryInboundNatRulePortMappingContent).GetProperty("IPConfiguration"), Is.Null);
            Assert.That(typeof(QueryInboundNatRulePortMappingContent).GetProperty("IPConfigurationId").SetMethod, Is.Not.Null);
        }

        [Test]
        public async Task NativeSubnetLinkActionsFollowTheServiceNextLink(
            [Values(false, true)] bool associations, [Values(false, true)] bool async)
        {
            const string subscription = "00000000-0000-0000-0000-000000000001";
            const string subnetId = "/subscriptions/" + subscription + "/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet";
            string action = associations ? "serviceAssociationLinks" : "resourceNavigationLinks";
            string nextLink = "https://management.azure.com" + subnetId + "/" + action + "?continuation=next";
            var first = new MockResponse(200).SetContent(
                $$"""{"value":[{"id":"{{subnetId}}/{{action}}/first","name":"first","properties":{}}],"nextLink":"{{nextLink}}"}""");
            var second = new MockResponse(200).SetContent(
                $$"""{"value":[{"id":"{{subnetId}}/{{action}}/second","name":"second","properties":{}}]}""");
            int requests = 0;
            var client = new ArmClient(new MockCredential(), subscription, new ArmClientOptions
            {
                Transport = MockTransport.FromMessageCallback(message =>
                {
                    requests++;
                    Assert.That(requests, Is.LessThanOrEqualTo(2));
                    Assert.That(message.Request.Method, Is.EqualTo(RequestMethod.Get));
                    Assert.That(message.Request.Uri.ToUri().AbsolutePath, Is.EqualTo(subnetId + "/" + action));
                    if (requests == 2) Assert.That(message.Request.Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
                    return requests == 1 ? first : second;
                })
            });
            var subnet = client.GetSubnetResource(new ResourceIdentifier(subnetId));
            if (associations)
                await AssertTwoPages(subnet.GetServiceAssociationLinks(), subnet.GetServiceAssociationLinksAsync(), async, first, second);
            else
                await AssertTwoPages(subnet.GetResourceNavigationLinks(), subnet.GetResourceNavigationLinksAsync(), async, first, second);
            Assert.That(requests, Is.EqualTo(2));
        }

        private static async Task AssertTwoPages<T>(Pageable<T> sync, AsyncPageable<T> async, bool useAsync, Response first, Response second)
        {
            var pages = new List<Page<T>>();
            if (useAsync)
            {
                await foreach (Page<T> page in async.AsPages()) pages.Add(page);
            }
            else pages.AddRange(sync.AsPages());
            Assert.That(pages, Has.Count.EqualTo(2));
            Assert.That(pages.Select(p => p.Values.Count), Is.EqualTo(new[] { 1, 1 }));
            Assert.That(pages[0].ContinuationToken, Does.Contain("continuation=next"));
            Assert.That(pages[1].ContinuationToken, Is.Null);
            Assert.That(pages[0].GetRawResponse(), Is.SameAs(first));
            Assert.That(pages[1].GetRawResponse(), Is.SameAs(second));
        }

        private sealed class RecordingPolicyResource : PolicySignaturesOverridesForIdpsResource
        {
            public MockResponse Response { get; } = new MockResponse(200);
            public PolicySignaturesOverridesForIdpsData Data { get; private set; }
            public WaitUntil WaitUntil { get; private set; }
            public CancellationToken CancellationToken { get; private set; }
            public override ArmOperation<PolicySignaturesOverridesForIdpsResource> CreateOrUpdate(WaitUntil waitUntil, PolicySignaturesOverridesForIdpsData data, CancellationToken cancellationToken = default)
            {
                WaitUntil = waitUntil;
                Data = data;
                CancellationToken = cancellationToken;
                return new CompletedOperation<PolicySignaturesOverridesForIdpsResource>(this, Response);
            }
            public override Task<ArmOperation<PolicySignaturesOverridesForIdpsResource>> CreateOrUpdateAsync(WaitUntil waitUntil, PolicySignaturesOverridesForIdpsData data, CancellationToken cancellationToken = default)
                => Task.FromResult(CreateOrUpdate(waitUntil, data, cancellationToken));
        }

        private sealed class RecordingGatewayResource : ServiceGatewayResource
        {
            public MockResponse Response { get; } = new MockResponse(200);
            public object Content { get; private set; }
            public CancellationToken CancellationToken { get; private set; }
            public int Calls { get; private set; }
            private Response<ServiceGatewayActionResult> Record(object content, CancellationToken cancellationToken)
            {
                Calls++;
                Content = content;
                CancellationToken = cancellationToken;
                return Azure.Response.FromValue<ServiceGatewayActionResult>(null, Response);
            }
            public override Response<ServiceGatewayActionResult> UpdateServices(ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default) => Record(content, cancellationToken);
            public override Task<Response<ServiceGatewayActionResult>> UpdateServicesAsync(ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default) => Task.FromResult(Record(content, cancellationToken));
            public override Response<ServiceGatewayActionResult> UpdateAddressLocations(ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default) => Record(content, cancellationToken);
            public override Task<Response<ServiceGatewayActionResult>> UpdateAddressLocationsAsync(ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default) => Task.FromResult(Record(content, cancellationToken));
        }

        private sealed class CompletedOperation<T> : ArmOperation<T>
        {
            private readonly Response _response;
            public CompletedOperation(T value, Response response) { Value = value; _response = response; }
            public override string Id => "completed-operation";
            public override bool HasCompleted => true;
            public override bool HasValue => true;
            public override T Value { get; }
            public override Response GetRawResponse() => _response;
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _response;
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => new ValueTask<Response>(_response);
        }
    }
}
