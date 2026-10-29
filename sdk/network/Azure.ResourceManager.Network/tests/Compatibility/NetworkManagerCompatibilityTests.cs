// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using LegacyInboundSecurityRule = Azure.ResourceManager.Network.Models.InboundSecurityRule;

#pragma warning disable CS0618 // Exercise the retained released compatibility APIs.

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkManagerCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ManagerId = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.Network/networkManagers/manager";
        private const string ApplianceId = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.Network/networkVirtualAppliances/nva";
        private const string SkuId = "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/networkVirtualApplianceSkus/sku";

        [Test]
        public void AccidentalConstructorsPropertiesAndConnectionInterfacesAreRemoved()
        {
            Assert.That(typeof(NetworkInterfaceCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                new[] { typeof(ArmClient), typeof(ResourceIdentifier), typeof(string), typeof(string) }, null), Is.Null);
            Assert.That(typeof(NetworkInterfaceData).GetProperty("VirtualMachine"), Is.Null);
            Assert.That(typeof(NetworkInterfaceData).GetProperty("VirtualMachineId"), Is.Not.Null);
            foreach (Type type in new[] { typeof(NetworkSecurityPerimeterLinkReferenceData), typeof(NetworkVirtualApplianceSkuData) })
            {
                Assert.That(type.GetConstructor(Type.EmptyTypes), Is.Not.Null);
                Assert.That(type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null), Is.Null);
            }
            foreach (Type type in new[] { typeof(NetworkManagerConnectionData), typeof(SubscriptionNetworkManagerConnectionResource) })
            {
                Assert.That(type.GetInterfaces().SelectMany(i => i.GenericTypeArguments)
                    .Any(t => t.Name == "SubscriptionNetworkManagerConnectionData"), Is.False);
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeEtagsAndReferenceListsRetainTheirStorage(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var json = BinaryData.FromString("""{"etag":"\"tag\""}""");
            Assert.That(ModelReaderWriter.Read<NetworkInterfaceTapConfigurationData>(json, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(ModelReaderWriter.Read<NetworkWatcherData>(json, options).ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(ModelReaderWriter.Read<NetworkManagerConnectionData>(json, options).ETag?.ToString(), Is.EqualTo("\"tag\""));

            const string referenceId = ApplianceId + "/inboundSecurityRules/rules";
            var data = ModelReaderWriter.Read<NetworkVirtualApplianceData>(BinaryData.FromString(
                $$$"""{"properties":{"inboundSecurityRules":[{"id":"{{{referenceId}}}"}],"virtualApplianceConnections":[{"id":"{{{referenceId}}}"}],"virtualApplianceSites":[{"id":"{{{referenceId}}}"}]}}"""), options);
            foreach (string name in new[] { "InboundSecurityRules", "VirtualApplianceConnections", "VirtualApplianceSites" })
            {
                PropertyInfo property = typeof(NetworkVirtualApplianceData).GetProperty(name);
                Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<WritableSubResource>)));
                Assert.That(property.SetMethod, Is.Null);
                var values = (IReadOnlyList<WritableSubResource>)property.GetValue(data);
                Assert.That(values.Single().Id.ToString(), Is.EqualTo(referenceId));
                Assert.That(property.GetValue(data), Is.SameAs(values));
                var empty = new NetworkVirtualApplianceData();
                Assert.That((IReadOnlyList<WritableSubResource>)property.GetValue(empty), Is.Empty);
                Assert.That(property.GetValue(empty), Is.SameAs(property.GetValue(empty)));
            }
        }

        [Test]
        public void RuleCollectionModelsRemainDistinctFromTheirChildRuleModels()
        {
            Assert.That(NetworkManagerRoutingRulesResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections"));
            Assert.That(NetworkManagerRoutingRuleResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules"));
            Assert.That(NetworkManagerSecurityUserRulesResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections"));
            Assert.That(NetworkManagerSecurityUserRuleResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules"));
            var json = BinaryData.FromString("""{"properties":{"description":"collection"}}""");
            Assert.That(ModelReaderWriter.Read<NetworkManagerRoutingRulesData>(json).Description, Is.EqualTo("collection"));
            Assert.That(ModelReaderWriter.Read<NetworkManagerSecurityUserRulesData>(json).Description, Is.EqualTo("collection"));
        }

        [Test]
        public void LinkStatusRetainsItsDocumentedNoOpSetter()
        {
            var data = ModelReaderWriter.Read<NetworkSecurityPerimeterLinkReferenceData>(
                BinaryData.FromString("""{"properties":{"status":"Approved"}}"""));
            NetworkSecurityPerimeterLinkStatus? status = data.Status;
            Assert.That(status, Is.Not.Null);
            data.Status = null;
            Assert.That(data.Status, Is.EqualTo(status));
            Assert.That(typeof(NetworkSecurityPerimeterLinkReferenceData).GetProperty("Status")
                .GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
        }

        [Test]
        public void NetworkInterfaceListingUsesReleasedNames()
        {
            Assert.That(typeof(NetworkInterfaceResource).GetMethod("GetNetworkInterfaceLoadBalancers").ReturnType, Is.EqualTo(typeof(Pageable<LoadBalancerResource>)));
            Assert.That(typeof(NetworkInterfaceResource).GetMethod("GetNetworkInterfaceLoadBalancersAsync").ReturnType, Is.EqualTo(typeof(AsyncPageable<LoadBalancerResource>)));
            Assert.That(typeof(NetworkInterfaceResource).GetMethod("GetAll"), Is.Null);
            Assert.That(typeof(NetworkInterfaceResource).GetMethod("GetAllAsync"), Is.Null);
        }

        [Test]
        public async Task ConditionalAdaptersPreserveTheHeaderAndUseTheNativeEndpoint(
            [Values("groupCreate", "groupUpdate", "workspaceCreate", "workspaceDelete", "workspaceUpdate")] string operation,
            [Values(false, true)] bool async,
            [Values(null, "\"tag\"", "W/\"tag\"")] string ifMatch)
        {
            string expectedPath = ManagerId + (operation.StartsWith("group", StringComparison.Ordinal) ? "/networkGroups/group" : "/verifierWorkspaces/workspace");
            int requests = 0;
            string actualCondition = null;
            RequestMethod actualMethod = default;
            var client = CreateClient(message =>
            {
                requests++;
                message.Request.Headers.TryGetValue("If-Match", out actualCondition);
                actualMethod = message.Request.Method;
                return operation == "workspaceDelete" ? new MockResponse(204) : new MockResponse(200).SetContent(
                    $$$"""{"id":"{{{expectedPath}}}","name":"child","location":"westus","properties":{"provisioningState":"Succeeded"}}""");
            });
            var manager = client.GetNetworkManagerResource(new ResourceIdentifier(ManagerId));
            switch (operation)
            {
                case "groupCreate":
                    if (async)
                        await manager.GetNetworkGroups().CreateOrUpdateAsync(WaitUntil.Started, "group", new NetworkGroupData(), ifMatch, default);
                    else
                        manager.GetNetworkGroups().CreateOrUpdate(WaitUntil.Started, "group", new NetworkGroupData(), ifMatch, default);
                    break;
                case "groupUpdate":
                    var group = client.GetNetworkGroupResource(new ResourceIdentifier(expectedPath));
                    if (async)
                        await group.UpdateAsync(WaitUntil.Started, new NetworkGroupData(), ifMatch, default);
                    else
                        group.Update(WaitUntil.Started, new NetworkGroupData(), ifMatch, default);
                    break;
                case "workspaceCreate":
                    if (async)
                        await manager.GetNetworkVerifierWorkspaces().CreateOrUpdateAsync(WaitUntil.Started, "workspace", new NetworkVerifierWorkspaceData(AzureLocation.WestUS), ifMatch, default);
                    else
                        manager.GetNetworkVerifierWorkspaces().CreateOrUpdate(WaitUntil.Started, "workspace", new NetworkVerifierWorkspaceData(AzureLocation.WestUS), ifMatch, default);
                    break;
                case "workspaceDelete":
                    var deleting = client.GetNetworkVerifierWorkspaceResource(new ResourceIdentifier(expectedPath));
                    if (async)
                        await deleting.DeleteAsync(WaitUntil.Started, ifMatch, default);
                    else
                        deleting.Delete(WaitUntil.Started, ifMatch, default);
                    break;
                default:
                    var updating = client.GetNetworkVerifierWorkspaceResource(new ResourceIdentifier(expectedPath));
                    if (async)
                        await updating.UpdateAsync(new NetworkVerifierWorkspacePatch(), ifMatch, default);
                    else
                        updating.Update(new NetworkVerifierWorkspacePatch(), ifMatch, default);
                    break;
            }
            Assert.That(requests, Is.EqualTo(1));
            Assert.That(actualCondition, Is.EqualTo(ifMatch));
            Assert.That(actualMethod, Is.EqualTo(operation == "workspaceDelete" ? RequestMethod.Delete : operation == "workspaceUpdate" ? RequestMethod.Patch : RequestMethod.Put));
        }

        [Test]
        public async Task NativeManagerActionsRetainTheReleasedSinglePageContract(
            [Values("connectivity", "security", "deployment")] string operation,
            [Values(false, true)] bool async)
        {
            int requests = 0;
            var response = new MockResponse(200).SetContent("""{"value":[],"skipToken":"not-a-next-link"}""");
            var manager = CreateClient(message =>
            {
                requests++;
                Assert.That(message.Request.Method, Is.EqualTo(RequestMethod.Post));
                return response;
            }).GetNetworkManagerResource(new ResourceIdentifier(ManagerId));
            if (operation == "connectivity")
                await AssertSinglePage(manager.GetActiveConnectivityConfigurations(new ActiveConfigurationContent(), 2), manager.GetActiveConnectivityConfigurationsAsync(new ActiveConfigurationContent(), 2), async, response);
            else if (operation == "security")
                await AssertSinglePage(manager.GetActiveSecurityAdminRules(new ActiveConfigurationContent(), 2), manager.GetActiveSecurityAdminRulesAsync(new ActiveConfigurationContent(), 2), async, response);
            else
                await AssertSinglePage(manager.GetNetworkManagerDeploymentStatus(new NetworkManagerDeploymentStatusContent(), 2), manager.GetNetworkManagerDeploymentStatusAsync(new NetworkManagerDeploymentStatusContent(), 2), async, response);
            Assert.That(requests, Is.EqualTo(1));
            Assert.That(typeof(NetworkManagerResource).GetMethod("PostNetworkManagerCommit").GetParameters().Select(p => p.Name),
                Is.EqualTo(new[] { "waitUntil", "networkManagerCommit", "cancellationToken" }));
        }

        [Test]
        public async Task ReleasedSkuTagMethodsUseArmTagResourcesInsteadOfThrowing(
            [Values("Add", "Remove", "Set")] string operation, [Values(false, true)] bool async)
        {
            var calls = new List<RequestMethod>();
            JsonElement writtenTags = default;
            var skuResponse = new MockResponse(200).SetContent($$$"""{"id":"{{{SkuId}}}","name":"sku","properties":{}}""");
            var sku = CreateClient(message =>
            {
                if (!message.Request.Uri.ToUri().AbsolutePath.EndsWith("/providers/Microsoft.Resources/tags/default", StringComparison.OrdinalIgnoreCase))
                    return skuResponse;
                calls.Add(message.Request.Method);
                if (message.Request.Method == RequestMethod.Delete)
                    return new MockResponse(200);
                if (message.Request.Method == RequestMethod.Put)
                {
                    using var stream = new MemoryStream();
                    message.Request.Content.WriteTo(stream, default);
                    using var document = JsonDocument.Parse(stream.ToArray());
                    writtenTags = document.RootElement.GetProperty("properties").GetProperty("tags").Clone();
                }
                return new MockResponse(200).SetContent($$$$"""{"id":"{{{{SkuId}}}}/providers/Microsoft.Resources/tags/default","properties":{"tags":{"old":"value"}}}""");
            }).GetNetworkVirtualApplianceSkuResource(new ResourceIdentifier(SkuId));
            Response<NetworkVirtualApplianceSkuResource> result;
            if (operation == "Add")
                result = async ? await sku.AddTagAsync("new", "value") : sku.AddTag("new", "value");
            else if (operation == "Remove")
                result = async ? await sku.RemoveTagAsync("old") : sku.RemoveTag("old");
            else
                result = async ? await sku.SetTagsAsync(new Dictionary<string, string> { ["new"] = "value" }) : sku.SetTags(new Dictionary<string, string> { ["new"] = "value" });
            Assert.That(result.GetRawResponse(), Is.SameAs(skuResponse));
            Assert.That(calls, Is.EqualTo(operation == "Set" ? new[] { RequestMethod.Delete, RequestMethod.Get, RequestMethod.Put } : new[] { RequestMethod.Get, RequestMethod.Put }));
            Assert.That(writtenTags.TryGetProperty("old", out _), Is.EqualTo(operation == "Add"));
            Assert.That(writtenTags.TryGetProperty("new", out _), Is.EqualTo(operation != "Remove"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task RestartConvenienceMethodsWaitAndPreserveTheNativeRawResponse(bool async)
        {
            var resource = new RecordingAppliance();
            var content = new NetworkVirtualApplianceInstanceIds();
            using var cancellation = new CancellationTokenSource();
            Response response = async ? await resource.RestartAsync(content, cancellation.Token) : resource.Restart(content, cancellation.Token);
            Assert.That(resource.WaitUntil, Is.EqualTo(WaitUntil.Completed));
            Assert.That(resource.Content, Is.SameAs(content));
            Assert.That(resource.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(response, Is.SameAs(resource.Response));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task InboundRuleAdaptersKeepNativeOperationStateAndProjectTheReleasedModel(bool async)
        {
            string id = ApplianceId + "/inboundSecurityRules/rules";
            var json = BinaryData.FromString($$$"""{"id":"{{{id}}}","name":"rules","etag":"\"tag\"","properties":{"rules":[]},"extension":"preserved"}""");
            var client = CreateClient(_ => throw new InvalidOperationException("The recording collection should handle creation."));
            var native = new InboundSecurityRuleResource(client, ModelReaderWriter.Read<InboundSecurityRuleData>(json));
            var resource = new RecordingAppliance { Rules = new RecordingRuleCollection(native) };
            var content = ModelReaderWriter.Read<LegacyInboundSecurityRule>(json);
            using var cancellation = new CancellationTokenSource();
            ArmOperation<LegacyInboundSecurityRule> operation = async
                ? await resource.CreateOrUpdateInboundSecurityRuleAsync(WaitUntil.Started, "rules", content, cancellation.Token)
                : resource.CreateOrUpdateInboundSecurityRule(WaitUntil.Started, "rules", content, cancellation.Token);
            Assert.That(resource.Rules.WaitUntil, Is.EqualTo(WaitUntil.Started));
            Assert.That(resource.Rules.Name, Is.EqualTo("rules"));
            Assert.That(resource.Rules.Data.Id, Is.EqualTo(content.Id));
            Assert.That(resource.Rules.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(operation.Id, Is.EqualTo(resource.Rules.Operation.Id));
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.Throws<InvalidOperationException>(() => _ = operation.Value);
            Response response = async ? await operation.UpdateStatusAsync(cancellation.Token) : operation.UpdateStatus(cancellation.Token);
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            Assert.That(response, Is.SameAs(resource.Rules.Operation.GetRawResponse()));
            Assert.That(operation.GetRawResponse(), Is.SameAs(resource.Rules.Operation.GetRawResponse()));
            Assert.That(resource.Rules.Operation.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(operation.Value.Id.ToString(), Is.EqualTo(id));
            Assert.That(operation.Value.ETag?.ToString(), Is.EqualTo("\"tag\""));
            Assert.That(operation.Value, Is.SameAs(operation.Value));
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(operation.Value));
            Assert.That(document.RootElement.GetProperty("extension").GetString(), Is.EqualTo("preserved"));
        }

        private static ArmClient CreateClient(Func<HttpMessage, MockResponse> callback)
            => new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = MockTransport.FromMessageCallback(callback) });

        private static async Task AssertSinglePage<T>(Pageable<T> sync, AsyncPageable<T> async, bool useAsync, Response response)
        {
            var pages = new List<Page<T>>();
            if (useAsync)
            {
                await foreach (Page<T> page in async.AsPages())
                    pages.Add(page);
            }
            else
                pages.AddRange(sync.AsPages());
            Assert.That(pages, Has.Count.EqualTo(1));
            Assert.That(pages[0].Values, Is.Empty);
            Assert.That(pages[0].ContinuationToken, Is.Null);
            Assert.That(pages[0].GetRawResponse(), Is.SameAs(response));
        }

        private sealed class RecordingAppliance : NetworkVirtualApplianceResource
        {
            public MockResponse Response { get; } = new MockResponse(200);
            public WaitUntil WaitUntil { get; private set; }
            public NetworkVirtualApplianceInstanceIds Content { get; private set; }
            public CancellationToken CancellationToken { get; private set; }
            public RecordingRuleCollection Rules { get; set; }
            public override InboundSecurityRuleCollection GetInboundSecurityRules() => Rules;
            public override ArmOperation<NetworkVirtualApplianceInstanceIds> Restart(WaitUntil waitUntil, NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = default, CancellationToken cancellationToken = default)
            {
                WaitUntil = waitUntil;
                Content = networkVirtualApplianceInstanceIds;
                CancellationToken = cancellationToken;
                return new RecordingOperation<NetworkVirtualApplianceInstanceIds>(networkVirtualApplianceInstanceIds, Response);
            }
            public override Task<ArmOperation<NetworkVirtualApplianceInstanceIds>> RestartAsync(WaitUntil waitUntil, NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = default, CancellationToken cancellationToken = default)
                => Task.FromResult(Restart(waitUntil, networkVirtualApplianceInstanceIds, cancellationToken));
        }

        private sealed class RecordingRuleCollection : InboundSecurityRuleCollection
        {
            public RecordingRuleCollection(InboundSecurityRuleResource value) => Operation = new RecordingOperation<InboundSecurityRuleResource>(value, new MockResponse(200));
            public RecordingOperation<InboundSecurityRuleResource> Operation { get; }
            public WaitUntil WaitUntil { get; private set; }
            public string Name { get; private set; }
            public InboundSecurityRuleData Data { get; private set; }
            public CancellationToken CancellationToken { get; private set; }
            public override ArmOperation<InboundSecurityRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleCollectionName, InboundSecurityRuleData data, CancellationToken cancellationToken = default)
            {
                WaitUntil = waitUntil;
                Name = ruleCollectionName;
                Data = data;
                CancellationToken = cancellationToken;
                return Operation;
            }
            public override Task<ArmOperation<InboundSecurityRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleCollectionName, InboundSecurityRuleData data, CancellationToken cancellationToken = default)
                => Task.FromResult(CreateOrUpdate(waitUntil, ruleCollectionName, data, cancellationToken));
        }

        private sealed class RecordingOperation<T> : ArmOperation<T>
        {
            private readonly T _value;
            private readonly Response _response;
            public RecordingOperation(T value, Response response) { _value = value; _response = response; }
            public CancellationToken CancellationToken { get; private set; }
            public override string Id => "native-operation";
            public override bool HasCompleted => _complete;
            public override bool HasValue => _complete;
            private bool _complete;
            public override T Value => _complete ? _value : throw new InvalidOperationException("Operation has not completed.");
            public override Response GetRawResponse() => _response;
            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                cancellationToken.ThrowIfCancellationRequested();
                CancellationToken = cancellationToken;
                _complete = true;
                return _response;
            }
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => new ValueTask<Response>(UpdateStatus(cancellationToken));
        }
    }
}

#pragma warning restore CS0618
