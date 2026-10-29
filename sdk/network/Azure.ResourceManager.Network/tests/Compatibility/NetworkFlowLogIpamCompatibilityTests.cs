// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkFlowLogIpamCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string GroupPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg";
        private const string ReferencePath = GroupPath + "/providers/Microsoft.Network/virtualNetworks/vnet";
        private const string PoolPath = GroupPath + "/providers/Microsoft.Network/networkManagers/manager/ipamPools/pool";

        [Test]
        public void FlowLogPropertiesIsTheReleasedFormatObject()
        {
            Assert.That(new FlowLogProperties(), Is.Not.Null);
            Assert.That(typeof(FlowLogProperties).GetProperties().Select(p => p.Name), Is.EquivalentTo(new[] { "FormatType", "Version" }));
            Assert.That(typeof(FlowLogData).GetProperty("Format").PropertyType, Is.EqualTo(typeof(FlowLogProperties)));
            Assert.That(typeof(FlowLogInformation).GetProperty("Format").PropertyType, Is.EqualTo(typeof(FlowLogProperties)));
            Assert.That(typeof(FlowLogInformation).GetProperty("FormatType"), Is.Null);
            Assert.That(typeof(FlowLogInformation).GetProperty("Version"), Is.Null);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeFlowLogFormatAndAnalyticsRemainLive(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var logFormat = new FlowLogProperties { FormatType = FlowLogFormatType.Json, Version = 2 };
            var analytics = new TrafficAnalyticsConfigurationProperties { Enabled = true, WorkspaceId = "before" };
            var data = new FlowLogData
            {
                TargetResourceId = new ResourceIdentifier(ReferencePath),
                StorageId = new ResourceIdentifier(ReferencePath),
                Format = logFormat,
                TrafficAnalyticsConfiguration = analytics
            };
            var information = new FlowLogInformation(new ResourceIdentifier(ReferencePath), new ResourceIdentifier(ReferencePath), true)
            {
                Format = logFormat,
                TrafficAnalyticsConfiguration = analytics
            };
            Assert.That(data.Format, Is.SameAs(logFormat));
            Assert.That(information.Format, Is.SameAs(logFormat));
            logFormat.Version = 3;
            analytics.WorkspaceId = "after";
            foreach (object model in new object[] { data, information })
            {
                using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
                JsonElement root = document.RootElement;
                Assert.That(root.GetProperty("properties").GetProperty("format").GetProperty("type").GetString(), Is.EqualTo("JSON"));
                Assert.That(root.GetProperty("properties").GetProperty("format").GetProperty("version").GetInt32(), Is.EqualTo(3));
                JsonElement analyticsOwner = model is FlowLogData ? root.GetProperty("properties") : root;
                Assert.That(analyticsOwner.GetProperty("flowAnalyticsConfiguration").GetProperty("networkWatcherFlowAnalyticsConfiguration").GetProperty("workspaceId").GetString(), Is.EqualTo("after"));
            }
            var restored = ModelReaderWriter.Read<FlowLogData>(ModelReaderWriter.Write(data, options), options);
            Assert.That(restored.Format.Version, Is.EqualTo(3));
            restored.Format.Version = 4;
            Assert.That(ModelReaderWriter.Write(restored, options).ToString(), Does.Contain("\"version\":4"));
            data.Format = null;
            information.Format = null;
            Assert.That(data.Format, Is.Null);
            Assert.That(information.Format, Is.Null);
        }

        [Test]
        public void NativeInboundNatRuleExposesOnlyTheReleasedFrontendId()
        {
            Assert.That(typeof(InboundNatRuleData).GetProperty("FrontendIPConfiguration"), Is.Null);
            var model = new InboundNatRuleData { FrontendIPConfigurationId = new ResourceIdentifier(ReferencePath) };
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("frontendIPConfiguration").GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
        }

        [Test]
        public void NativeETagsRoundTrip(
            [Values(typeof(HubIPConfigurationData), typeof(HubRouteTableData), typeof(IPAllocationData), typeof(InboundNatRuleData), typeof(InboundSecurityRuleData))] Type modelType,
            [Values("J", "W")] string format,
            [Values("\"quoted\"", "W/\"weak\"")] string etag)
        {
            var options = new ModelReaderWriterOptions(format);
            string json = JsonSerializer.Serialize(new { etag, properties = new { } });
            object model = ModelReaderWriter.Read(BinaryData.FromString(json), modelType, options, AzureResourceManagerNetworkContext.Default);
            PropertyInfo property = modelType.GetProperty("ETag");
            Assert.That(property.PropertyType, Is.EqualTo(typeof(ETag?)));
            Assert.That(property.SetMethod, Is.Null);
            Assert.That(property.GetValue(model)?.ToString(), Is.EqualTo(etag));
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.TryGetProperty("etag", out JsonElement value), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(value.GetString(), Is.EqualTo(etag));
                Assert.That(document.RootElement.EnumerateObject().Count(p => p.Name == "etag"), Is.EqualTo(1));
            }
        }

        [TestCase(typeof(FrontendIPConfigurationData), "InboundNatRules", "inboundNatRules", "J")]
        [TestCase(typeof(FrontendIPConfigurationData), "InboundNatRules", "inboundNatRules", "W")]
        [TestCase(typeof(FrontendIPConfigurationData), "InboundNatPools", "inboundNatPools", "J")]
        [TestCase(typeof(FrontendIPConfigurationData), "InboundNatPools", "inboundNatPools", "W")]
        [TestCase(typeof(FrontendIPConfigurationData), "OutboundRules", "outboundRules", "J")]
        [TestCase(typeof(FrontendIPConfigurationData), "OutboundRules", "outboundRules", "W")]
        [TestCase(typeof(FrontendIPConfigurationData), "LoadBalancingRules", "loadBalancingRules", "J")]
        [TestCase(typeof(FrontendIPConfigurationData), "LoadBalancingRules", "loadBalancingRules", "W")]
        [TestCase(typeof(IPGroupData), "Firewalls", "firewalls", "J")]
        [TestCase(typeof(IPGroupData), "Firewalls", "firewalls", "W")]
        [TestCase(typeof(IPGroupData), "FirewallPolicies", "firewallPolicies", "J")]
        [TestCase(typeof(IPGroupData), "FirewallPolicies", "firewallPolicies", "W")]
        public void NativeReadonlyReferencesUseStableStorage(Type modelType, string propertyName, string wireName, string format)
        {
            var options = new ModelReaderWriterOptions(format);
            PropertyInfo property = modelType.GetProperty(propertyName);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<WritableSubResource>)));
            Assert.That(property.SetMethod, Is.Null);
            object empty = Activator.CreateInstance(modelType);
            Assert.That(property.GetValue(empty), Is.Empty);
            Assert.That(property.GetValue(empty), Is.SameAs(property.GetValue(empty)));
            object model = ModelReaderWriter.Read(BinaryData.FromString($$$$"""{"properties":{"{{{{wireName}}}}":[{"id":"{{{{ReferencePath}}}}"}]}}"""), modelType, options, AzureResourceManagerNetworkContext.Default);
            var values = (IReadOnlyList<WritableSubResource>)property.GetValue(model);
            Assert.That(values, Is.SameAs(property.GetValue(model)));
            Assert.That(values[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(values, Has.Count.EqualTo(1));
            values[0].Id = new ResourceIdentifier(ReferencePath + "2");
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.GetProperty("properties").TryGetProperty(wireName, out JsonElement references), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(references[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath + "2"));
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeHubRoutingUsesConnectedStorage(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var routing = new RoutingConfiguration { AssociatedRouteTableId = new ResourceIdentifier(ReferencePath) };
            var model = new HubVirtualNetworkConnectionData { RoutingConfiguration = routing };
            Assert.That(model.RoutingConfiguration, Is.SameAs(routing));
            routing.AssociatedRouteTableId = new ResourceIdentifier(ReferencePath + "2");
            var restored = ModelReaderWriter.Read<HubVirtualNetworkConnectionData>(ModelReaderWriter.Write(model, options), options);
            Assert.That(restored.RoutingConfiguration.AssociatedRouteTableId.ToString(), Is.EqualTo(ReferencePath + "2"));
            model.RoutingConfiguration = null;
            Assert.That(model.RoutingConfiguration, Is.Null);
        }

        [Test]
        public void ReleasedIpamOverloadsAreHiddenForwarders()
        {
            var methods = new[] { typeof(IpamPoolCollection), typeof(IpamPoolResource) }
                .SelectMany(t => t.GetMethods())
                .Where(m => new[] { "CreateOrUpdate", "CreateOrUpdateAsync", "Delete", "DeleteAsync", "Update", "UpdateAsync" }.Contains(m.Name))
                .Where(m => m.GetParameters().Any(p => p.Name == "ifMatch" && p.ParameterType == typeof(string)) ||
                    m.GetParameters().Last().ParameterType == typeof(CancellationToken) && !m.GetParameters().Any(p => p.Name == "ifMatch"))
                .ToArray();
            Assert.That(methods, Has.Length.EqualTo(12));
            foreach (MethodInfo method in methods)
            {
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
                Assert.That(method.GetCustomAttributesData().Any(a => a.AttributeType.Name == "ForwardsClientCallsAttribute"), Is.True);
                if (method.Name.StartsWith("CreateOrUpdate", StringComparison.Ordinal))
                {
                    Assert.That(method.GetParameters()[1].Name, Is.EqualTo("poolName"));
                }
                ParameterInfo condition = method.GetParameters().FirstOrDefault(p => p.Name == "ifMatch");
                Assert.That(condition?.IsOptional ?? method.GetParameters().Last().IsOptional, Is.False);
            }
        }

        [Test]
        public void IpamCompatibilityOverloadsPropagateCancellation(
            [Values("create", "delete", "update")] string operation,
            [Values(false, true)] bool asynchronous,
            [Values(false, true)] bool withStringCondition)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                cancellation.Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                throw new InvalidOperationException("The adapter did not forward the caller's cancellation token.");
            });
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetIpamPoolResource(new ResourceIdentifier(PoolPath));
            var collection = client.GetNetworkManagerResource(new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/networkManagers/manager")).GetIpamPools();
            var data = new IpamPoolData(new AzureLocation("westus"), new IpamPoolProperties(new[] { "10.0.0.0/24" }));
            var patch = new IpamPoolPatch();
            if (asynchronous)
            {
                Func<Task> send = operation switch
                {
                    "create" => () => withStringCondition
                        ? collection.CreateOrUpdateAsync(WaitUntil.Completed, "pool", data, "*", cancellation.Token)
                        : collection.CreateOrUpdateAsync(WaitUntil.Completed, "pool", data, cancellation.Token),
                    "delete" => () => withStringCondition
                        ? resource.DeleteAsync(WaitUntil.Completed, "*", cancellation.Token)
                        : resource.DeleteAsync(WaitUntil.Completed, cancellation.Token),
                    "update" => () => withStringCondition
                        ? resource.UpdateAsync(patch, "*", cancellation.Token)
                        : resource.UpdateAsync(patch, cancellation.Token),
                    _ => throw new ArgumentException(nameof(operation))
                };
                Assert.CatchAsync<OperationCanceledException>(async () => await send());
            }
            else
            {
                Func<object> send = operation switch
                {
                    "create" => () => withStringCondition
                        ? collection.CreateOrUpdate(WaitUntil.Completed, "pool", data, "*", cancellation.Token)
                        : collection.CreateOrUpdate(WaitUntil.Completed, "pool", data, cancellation.Token),
                    "delete" => () => withStringCondition
                        ? resource.Delete(WaitUntil.Completed, "*", cancellation.Token)
                        : resource.Delete(WaitUntil.Completed, cancellation.Token),
                    "update" => () => withStringCondition
                        ? resource.Update(patch, "*", cancellation.Token)
                        : resource.Update(patch, cancellation.Token),
                    _ => throw new ArgumentException(nameof(operation))
                };
                Assert.Catch<OperationCanceledException>(() => send());
            }
        }

        [Test]
        public async Task IpamOverloadsExecuteTheNativeRequest(
            [Values("create", "delete", "update")] string operation,
            [Values(false, true)] bool asynchronous,
            [Values(0, 1, 2, 3, 4, 5)] int overload)
        {
            string condition = overload == 3 ? "*" : overload == 4 ? "W/\"weak\"" : overload == 5 ? "\"quoted\"" : null;
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                if (overload != 1)
                {
                    Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                }
                return operation == "delete" ? new MockResponse(204) : new MockResponse(200).SetContent($$$$"""{"id":"{{{{PoolPath}}}}","name":"pool","location":"westus","properties":{"addressPrefixes":["10.0.0.0/24"]}}""");
            });
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetIpamPoolResource(new ResourceIdentifier(PoolPath));
            var collection = client.GetNetworkManagerResource(new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/networkManagers/manager")).GetIpamPools();
            var data = new IpamPoolData(new AzureLocation("westus"), new IpamPoolProperties(new[] { "10.0.0.0/24" }));
            var patch = new IpamPoolPatch();
            if (operation == "create")
            {
                if (asynchronous)
                {
                    if (overload == 0)
                        await collection.CreateOrUpdateAsync(WaitUntil.Completed, poolName: "pool", data, cancellation.Token);
                    else if (overload == 1)
                        await collection.CreateOrUpdateAsync(WaitUntil.Completed, "pool", data);
                    else if (overload == 5)
                        await collection.CreateOrUpdateAsync(WaitUntil.Completed, "pool", data, new ETag(condition), cancellation.Token);
                    else
                        await collection.CreateOrUpdateAsync(WaitUntil.Completed, "pool", data, condition, cancellation.Token);
                }
                else
                {
                    if (overload == 0)
                        collection.CreateOrUpdate(WaitUntil.Completed, poolName: "pool", data, cancellation.Token);
                    else if (overload == 1)
                        collection.CreateOrUpdate(WaitUntil.Completed, "pool", data);
                    else if (overload == 5)
                        collection.CreateOrUpdate(WaitUntil.Completed, "pool", data, new ETag(condition), cancellation.Token);
                    else
                        collection.CreateOrUpdate(WaitUntil.Completed, "pool", data, condition, cancellation.Token);
                }
            }
            else if (operation == "delete")
            {
                if (asynchronous)
                {
                    if (overload == 0)
                        await resource.DeleteAsync(WaitUntil.Completed, cancellation.Token);
                    else if (overload == 1)
                        await resource.DeleteAsync(WaitUntil.Completed);
                    else if (overload == 5)
                        await resource.DeleteAsync(WaitUntil.Completed, new ETag(condition), cancellation.Token);
                    else
                        await resource.DeleteAsync(WaitUntil.Completed, condition, cancellation.Token);
                }
                else
                {
                    if (overload == 0)
                        resource.Delete(WaitUntil.Completed, cancellation.Token);
                    else if (overload == 1)
                        resource.Delete(WaitUntil.Completed);
                    else if (overload == 5)
                        resource.Delete(WaitUntil.Completed, new ETag(condition), cancellation.Token);
                    else
                        resource.Delete(WaitUntil.Completed, condition, cancellation.Token);
                }
            }
            else
            {
                if (asynchronous)
                {
                    if (overload == 0)
                        await resource.UpdateAsync(patch, cancellation.Token);
                    else if (overload == 1)
                        await resource.UpdateAsync(patch);
                    else if (overload == 5)
                        await resource.UpdateAsync(patch, new ETag(condition), cancellation.Token);
                    else
                        await resource.UpdateAsync(patch, condition, cancellation.Token);
                }
                else
                {
                    if (overload == 0)
                        resource.Update(patch, cancellation.Token);
                    else if (overload == 1)
                        resource.Update(patch);
                    else if (overload == 5)
                        resource.Update(patch, new ETag(condition), cancellation.Token);
                    else
                        resource.Update(patch, condition, cancellation.Token);
                }
            }
            Request request = transport.Requests.Single();
            Assert.That(request.Method, Is.EqualTo(operation == "create" ? RequestMethod.Put : operation == "delete" ? RequestMethod.Delete : RequestMethod.Patch));
            Assert.That(request.Headers.TryGetValue("If-Match", out string header), Is.EqualTo(condition != null));
            if (condition != null)
                Assert.That(header, Is.EqualTo(condition));
        }
    }
}
