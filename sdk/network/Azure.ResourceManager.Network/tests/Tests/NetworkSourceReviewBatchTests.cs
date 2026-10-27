// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkSourceReviewBatchTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string GroupPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg";
        private const string GatewayPath = GroupPath + "/providers/Microsoft.Network/expressRouteGateways/gateway";
        private const string ReferencePath = GroupPath + "/providers/Microsoft.Network/virtualNetworks/vnet";
        private const string PortPath = GroupPath + "/providers/Microsoft.Network/expressRoutePorts/port";
        private const string PolicyPath = GroupPath + "/providers/Microsoft.Network/firewallPolicies/policy";

        [TestCase(typeof(NetworkGroupData))]
        [TestCase(typeof(NetworkGroupStaticMemberData))]
        [TestCase(typeof(NetworkManagerRoutingConfigurationData))]
        [TestCase(typeof(NetworkManagerRoutingRuleData))]
        [TestCase(typeof(NetworkManagerSecurityUserConfigurationData))]
        [TestCase(typeof(NetworkManagerSecurityUserRuleData))]
        [TestCase(typeof(NetworkSecurityPerimeterAccessRuleData))]
        [TestCase(typeof(NetworkSecurityPerimeterAssociationData))]
        [TestCase(typeof(NetworkSecurityPerimeterLinkData))]
        [TestCase(typeof(NetworkSecurityPerimeterLinkReferenceData))]
        [TestCase(typeof(NetworkSecurityPerimeterLoggingConfigurationData))]
        [TestCase(typeof(NetworkSecurityPerimeterProfileData))]
        [TestCase(typeof(ReachabilityAnalysisIntentData))]
        [TestCase(typeof(ReachabilityAnalysisRunData))]
        [TestCase(typeof(RouteMapData))]
        [TestCase(typeof(ScopeConnectionData))]
        [TestCase(typeof(SecurityAdminConfigurationData))]
        [TestCase(typeof(StaticCidrData))]
        public void NativePersistenceReplacesUnnecessaryCreateCoreOverrides(Type modelType)
        {
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                object model = ModelReaderWriter.Read(
                    BinaryData.FromString($$$$"""{"id":"{{{{ReferencePath}}}}","name":"native","properties":{},"futureField":7}"""),
                    modelType, options, AzureResourceManagerNetworkContext.Default);
                Assert.That(model.GetType(), Is.EqualTo(modelType));
                Assert.That(modelType.GetProperty("Id").GetValue(model), Is.EqualTo(new ResourceIdentifier(ReferencePath)));
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
                Assert.That(json.RootElement.TryGetProperty("futureField", out JsonElement unknown), Is.EqualTo(format == "J"));
                if (format == "J")
                    Assert.That(unknown.GetInt32(), Is.EqualTo(7));
            }
        }

        [TestCase(typeof(P2SVpnGatewayData), "p2sVpnGateways", "vpnGatewayScaleUnit", "2")]
        [TestCase(typeof(RouteFilterData), "routeFilters", "rules", "[]")]
        [TestCase(typeof(VirtualHubData), "virtualHubs", "addressPrefix", "\"10.0.0.0/24\"")]
        [TestCase(typeof(VpnGatewayData), "vpnGateways", "vpnGatewayScaleUnit", "2")]
        [TestCase(typeof(VpnSiteData), "vpnSites", "isSecuritySite", "true")]
        public void NativeIntermediateBasePreservesReleasedEnvelope(Type modelType, string resourcePath, string property, string value)
        {
            Assert.That(typeof(NetworkTrackedResourceData).IsAssignableFrom(modelType), Is.True);
            var id = new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/" + resourcePath + "/item");
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                var model = (NetworkTrackedResourceData)ModelReaderWriter.Read(
                    BinaryData.FromString($$$$"""{"id":"{{{{id}}}}","name":"item","type":"{{{{id.ResourceType}}}}","location":"westus","tags":{"owner":"sdk"},"etag":"etag-value","future":7,"properties":{"{{{{property}}}}":{{{{value}}}}}}"""),
                    modelType, options, AzureResourceManagerNetworkContext.Default);
                Assert.That(model.Id, Is.EqualTo(id));
                Assert.That(model.Name, Is.EqualTo("item"));
                Assert.That(model.ResourceType, Is.EqualTo(id.ResourceType));
                Assert.That(model.Location, Is.EqualTo(new AzureLocation("westus")));
                Assert.That(model.Tags["owner"], Is.EqualTo("sdk"));
                Assert.That(modelType.GetProperty("ETag").GetValue(model).ToString(), Is.EqualTo("etag-value"));
                model.Tags["owner"] = "updated";
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write((object)model, options, AzureResourceManagerNetworkContext.Default));
                Assert.That(json.RootElement.EnumerateObject().Select(item => item.Name), Is.Unique);
                Assert.That(json.RootElement.GetProperty("tags").GetProperty("owner").GetString(), Is.EqualTo("updated"));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty(property).GetRawText(), Is.EqualTo(value));
                Assert.That(json.RootElement.TryGetProperty("future", out _), Is.EqualTo(format == "J"));
                if (format == "J")
                    Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo(id.ResourceType.ToString()));
            }

            MethodInfo[] factories = typeof(ArmNetworkModelFactory).GetMethods()
                .Where(method => method.ReturnType == modelType && method.GetParameters().All(parameter => parameter.IsOptional)).ToArray();
            Assert.That(factories, Is.Not.Empty);
            foreach (MethodInfo factory in factories)
            {
                object[] arguments = factory.GetParameters().Select(parameter => parameter.Name switch
                {
                    "id" => (object)id,
                    "name" => "item",
                    "resourceType" => id.ResourceType,
                    "location" => new AzureLocation("westus"),
                    "tags" => new Dictionary<string, string> { ["owner"] = "sdk" },
                    _ => parameter.DefaultValue
                }).ToArray();
                var model = (NetworkTrackedResourceData)factory.Invoke(null, arguments);
                Assert.That(model.Id, Is.EqualTo(id));
                Assert.That(model.Name, Is.EqualTo("item"));
                Assert.That(model.ResourceType, Is.EqualTo(id.ResourceType));
                Assert.That(model.Tags["owner"], Is.EqualTo("sdk"));
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write((object)model, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default));
                Assert.That(json.RootElement.EnumerateObject().Select(item => item.Name), Is.Unique);
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DdosCustomPolicyCollectionsUseNativeWireStorage(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<DdosCustomPolicyData>(BinaryData.FromString($$$$"""
                {"properties":{"frontEndIpConfiguration":[{"id":"{{{{ReferencePath}}}}"}],"publicIPAddresses":[{"id":"{{{{ReferencePath}}}}"}]}}
                """), options);
            Assert.That(model.FrontEndIPConfiguration[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(model.PublicIPAddresses[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(model.PublicIPAddresses, Is.SameAs(model.PublicIPAddresses));
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").PropertyType, Is.EqualTo(typeof(IReadOnlyList<WritableSubResource>)));
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
            model.FrontEndIPConfiguration.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferencePath + "2") });
            model.PublicIPAddresses[0].Id = new ResourceIdentifier(ReferencePath + "3");
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("frontEndIpConfiguration").GetArrayLength(), Is.EqualTo(2));
            Assert.That(properties.TryGetProperty("publicIPAddresses", out JsonElement addresses), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(addresses[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath + "3"));
            }
        }

        [Test]
        public void NativeFrontendCollectionIsInitializedAndStable()
        {
            var model = new DdosCustomPolicyData();
            Assert.That(model.FrontEndIPConfiguration, Is.Empty);
            Assert.That(model.FrontEndIPConfiguration, Is.SameAs(model.FrontEndIPConfiguration));
            model.FrontEndIPConfiguration.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferencePath) });
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("frontEndIpConfiguration")[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DdosProtectionPlanPreservesInheritedResourceFields(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            string id = GroupPath + "/providers/Microsoft.Network/ddosProtectionPlans/plan";
            var model = ModelReaderWriter.Read<DdosProtectionPlanData>(BinaryData.FromString($$$$"""
                {"id":"{{{{id}}}}","name":"plan","type":"Microsoft.Network/ddosProtectionPlans","location":"westus","tags":{"owner":"sdk"},"systemData":{"createdBy":"creator"},"etag":"etag-value","future":"retained","properties":{"publicIPAddresses":[{"id":"{{{{ReferencePath}}}}"}],"virtualNetworks":[{"id":"{{{{ReferencePath}}}}"}]}}
                """), options);
            Assert.That(model.Id.ToString(), Is.EqualTo(id));
            Assert.That(model.Name, Is.EqualTo("plan"));
            Assert.That(model.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/ddosProtectionPlans"));
            Assert.That(model.Location, Is.EqualTo(new AzureLocation("westus")));
            Assert.That(model.Tags["owner"], Is.EqualTo("sdk"));
            Assert.That(model.SystemData.CreatedBy, Is.EqualTo("creator"));
            Assert.That(model.ETag.ToString(), Is.EqualTo("etag-value"));
            Assert.That(model.PublicIPAddresses[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(model.VirtualNetworks[0].Id.ToString(), Is.EqualTo(ReferencePath));
            model.Tags["owner"] = "updated";
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            Assert.That(document.RootElement.EnumerateObject().Select(property => property.Name), Is.Unique);
            Assert.That(document.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("owner").GetString(), Is.EqualTo("updated"));
            if (format == "J")
            {
                Assert.That(document.RootElement.GetProperty("id").GetString(), Is.EqualTo(id));
                Assert.That(document.RootElement.GetProperty("future").GetString(), Is.EqualTo("retained"));
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("virtualNetworks")[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
            }
        }

        [Test]
        public void DdosProtectionPlanRetainsLocationConstructor()
        {
            Assert.That(typeof(DdosProtectionPlanData).BaseType, Is.EqualTo(typeof(Azure.ResourceManager.Models.TrackedResourceData)));
            Assert.That(typeof(DdosProtectionPlanData).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly), Is.Null);
            ConstructorInfo constructor = typeof(DdosProtectionPlanData).GetConstructor(new[] { typeof(AzureLocation) });
            Assert.That(constructor, Is.Not.Null);
            var model = (DdosProtectionPlanData)constructor.Invoke(new object[] { new AzureLocation("westus") });
            Assert.That(model.Tags, Is.Empty);
            model.Tags["owner"] = "sdk";
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(model.Location, Is.EqualTo(new AzureLocation("westus")));
            Assert.That(document.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("owner").GetString(), Is.EqualTo("sdk"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DdosProtectionPlanRetainsNativeResourceGet(bool asynchronous)
        {
            string id = GroupPath + "/providers/Microsoft.Network/ddosProtectionPlans/plan";
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent($$$$"""
                {"id":"{{{{id}}}}","name":"plan","type":"Microsoft.Network/ddosProtectionPlans","location":"westus","tags":{"owner":"sdk"}}
                """));
            var resource = CreateClient(transport).GetDdosProtectionPlanResource(new ResourceIdentifier(id));
            var response = asynchronous ? await resource.GetAsync() : resource.Get();
            Assert.That(response.Value.Data.Id.ToString(), Is.EqualTo(id));
            Assert.That(response.Value.Data.Location, Is.EqualTo(new AzureLocation("westus")));
            Assert.That(response.Value.Data.Tags["owner"], Is.EqualTo("sdk"));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id));
        }

        [TestCase(typeof(ConnectionAnalyzerData), "networkWatchers/watcher/connectionAnalyzers", "J")]
        [TestCase(typeof(ConnectionAnalyzerData), "networkWatchers/watcher/connectionAnalyzers", "W")]
        [TestCase(typeof(ExpressRouteProviderPortData), "expressRouteProviderPorts", "J")]
        [TestCase(typeof(ExpressRouteProviderPortData), "expressRouteProviderPorts", "W")]
        [TestCase(typeof(IpamPoolData), "networkManagers/manager/ipamPools", "J")]
        [TestCase(typeof(IpamPoolData), "networkManagers/manager/ipamPools", "W")]
        [TestCase(typeof(NetworkSecurityPerimeterData), "networkSecurityPerimeters", "J")]
        [TestCase(typeof(NetworkSecurityPerimeterData), "networkSecurityPerimeters", "W")]
        [TestCase(typeof(NetworkVerifierWorkspaceData), "networkManagers/manager/verifierWorkspaces", "J")]
        [TestCase(typeof(NetworkVerifierWorkspaceData), "networkManagers/manager/verifierWorkspaces", "W")]
        [TestCase(typeof(ServiceGatewayData), "serviceGateways", "J")]
        [TestCase(typeof(ServiceGatewayData), "serviceGateways", "W")]
        public void NativeTrackedResourcesPreserveInheritedAndDerivedFields(Type modelType, string resourcePath, string format)
        {
            Assert.That(modelType.BaseType, Is.EqualTo(typeof(TrackedResourceData)));
            Assert.That(modelType.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly), Is.Null);
            Assert.That(modelType.GetProperty("SystemData", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly), Is.Null);
            var options = new ModelReaderWriterOptions(format);
            string scope = modelType == typeof(ExpressRouteProviderPortData) ? "/subscriptions/" + SubscriptionId : GroupPath;
            var id = new ResourceIdentifier(scope + "/providers/Microsoft.Network/" + resourcePath + "/item");
            string properties = NativeTrackedResourceProperties(modelType);
            string serviceFields = modelType == typeof(ServiceGatewayData) ? ""","sku":{"name":"Standard"},"zones":["1"]""" : string.Empty;
            var model = (TrackedResourceData)ModelReaderWriter.Read(BinaryData.FromString($$$$"""
                {"id":"{{{{id}}}}","name":"item","type":"{{{{id.ResourceType}}}}","location":"westus","tags":{"owner":"sdk"},"systemData":{"createdBy":"creator"},"future":"retained"{{{{serviceFields}}}},"properties":{{{{properties}}}}}
                """), modelType, options, AzureResourceManagerNetworkContext.Default);
            Assert.That(model.Id, Is.EqualTo(id));
            Assert.That(model.Name, Is.EqualTo("item"));
            Assert.That(model.ResourceType, Is.EqualTo(id.ResourceType));
            Assert.That(model.Location, Is.EqualTo(new AzureLocation("westus")));
            Assert.That(model.SystemData.CreatedBy, Is.EqualTo("creator"));
            Assert.That(model.Tags["owner"], Is.EqualTo("sdk"));
            model.Tags["owner"] = "updated";
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write((object)model, options, AzureResourceManagerNetworkContext.Default));
            JsonElement root = document.RootElement;
            Assert.That(root.EnumerateObject().Select(property => property.Name), Is.Unique);
            Assert.That(root.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(root.GetProperty("tags").GetProperty("owner").GetString(), Is.EqualTo("updated"));
            if (modelType == typeof(ServiceGatewayData))
            {
                Assert.That(root.GetProperty("sku").GetProperty("name").GetString(), Is.EqualTo("Standard"));
                Assert.That(root.GetProperty("zones")[0].GetString(), Is.EqualTo("1"));
            }
            using JsonDocument expectedProperties = JsonDocument.Parse(properties);
            JsonProperty expectedProperty = expectedProperties.RootElement.EnumerateObject().First();
            bool readOnlyProperty = modelType == typeof(NetworkSecurityPerimeterData) || modelType == typeof(ServiceGatewayData);
            bool includesProperty = root.GetProperty("properties").TryGetProperty(expectedProperty.Name, out JsonElement propertyValue);
            Assert.That(includesProperty, Is.EqualTo(format == "J" || !readOnlyProperty));
            if (includesProperty)
            {
                Assert.That(propertyValue.ToString(), Is.EqualTo(expectedProperty.Value.ToString()));
            }
            Assert.That(root.TryGetProperty("future", out JsonElement future), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(root.GetProperty("id").GetString(), Is.EqualTo(id.ToString()));
                Assert.That(root.GetProperty("name").GetString(), Is.EqualTo("item"));
                Assert.That(root.GetProperty("systemData").GetProperty("createdBy").GetString(), Is.EqualTo("creator"));
                Assert.That(future.GetString(), Is.EqualTo("retained"));
            }
        }

        [TestCase(typeof(ConnectionAnalyzerData))]
        [TestCase(typeof(ExpressRouteProviderPortData))]
        [TestCase(typeof(IpamPoolData))]
        [TestCase(typeof(NetworkSecurityPerimeterData))]
        [TestCase(typeof(NetworkVerifierWorkspaceData))]
        [TestCase(typeof(ServiceGatewayData))]
        public void NativeTrackedResourceConstructorsInitializeTags(Type modelType)
        {
            Type propertiesType = modelType == typeof(ConnectionAnalyzerData) ? typeof(ConnectionAnalyzerProperties)
                : modelType == typeof(IpamPoolData) ? typeof(IpamPoolProperties) : null;
            Type[] parameterTypes = propertiesType is null ? new[] { typeof(AzureLocation) } : new[] { typeof(AzureLocation), propertiesType };
            ConstructorInfo constructor = modelType.GetConstructor(parameterTypes);
            Assert.That(constructor, Is.Not.Null);
            var options = new ModelReaderWriterOptions("W");
            var location = new AzureLocation("westus");
            object properties = propertiesType is null ? null : ModelReaderWriter.Read(
                BinaryData.FromString(NativeTrackedResourceProperties(modelType)), propertiesType, options, AzureResourceManagerNetworkContext.Default);
            object[] arguments = propertiesType is null ? new object[] { location } : new[] { location, properties };
            var model = (TrackedResourceData)constructor.Invoke(arguments);
            Assert.That(model.Location, Is.EqualTo(location));
            Assert.That(model.Tags, Is.Empty);
            model.Tags["owner"] = "sdk";
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write((object)model, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("owner").GetString(), Is.EqualTo("sdk"));
        }

        [Test]
        public void EffectiveCollectionsKeepReleasedReadOnlyTypesAndReadPayloads()
        {
            var connectivity = ModelReaderWriter.Read<EffectiveConnectivityConfiguration>(BinaryData.FromString($$$$"""
                {"properties":{"connectivityTopology":"HubAndSpoke","appliesToGroups":[{"networkGroupId":"{{{{ReferencePath}}}}","groupConnectivity":"None"}],"hubs":[{"resourceId":"{{{{ReferencePath}}}}","resourceType":"Microsoft.Network/virtualHubs"}]}}
                """));
            AssertReadOnlyCollection<ConnectivityGroupItem>(typeof(EffectiveConnectivityConfiguration), "AppliesToGroups");
            AssertReadOnlyCollection<ConnectivityHub>(typeof(EffectiveConnectivityConfiguration), "Hubs");
            Assert.That(connectivity.AppliesToGroups.Single().NetworkGroupId, Is.EqualTo(ReferencePath));
            Assert.That(connectivity.Hubs.Single().ResourceId.ToString(), Is.EqualTo(ReferencePath));
            AssertReadOnlyView(connectivity.AppliesToGroups);
            AssertReadOnlyView(connectivity.Hubs);
            var restored = ModelReaderWriter.Read<EffectiveConnectivityConfiguration>(ModelReaderWriter.Write(connectivity));
            Assert.That(restored.AppliesToGroups.Single().NetworkGroupId, Is.EqualTo(ReferencePath));
            Assert.That(restored.Hubs.Single().ResourceId.ToString(), Is.EqualTo(ReferencePath));

            var rule = ModelReaderWriter.Read<EffectiveSecurityAdminRule>(BinaryData.FromString("""
                {"kind":"Custom","properties":{"protocol":"Tcp","access":"Allow","priority":100,"direction":"Inbound","sources":[{"addressPrefix":"10.0.0.0/24"}],"destinations":[{"addressPrefix":"10.1.0.0/24"}],"sourcePortRanges":["1000"],"destinationPortRanges":["443"]}}
                """));
            AssertReadOnlyCollection<AddressPrefixItem>(typeof(EffectiveSecurityAdminRule), "Sources");
            AssertReadOnlyCollection<AddressPrefixItem>(typeof(EffectiveSecurityAdminRule), "Destinations");
            AssertReadOnlyCollection<string>(typeof(EffectiveSecurityAdminRule), "SourcePortRanges");
            AssertReadOnlyCollection<string>(typeof(EffectiveSecurityAdminRule), "DestinationPortRanges");
            Assert.That(rule.Sources.Single().AddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(rule.Destinations.Single().AddressPrefix, Is.EqualTo("10.1.0.0/24"));
            Assert.That(rule.SourcePortRanges, Is.EqualTo(new[] { "1000" }));
            Assert.That(rule.DestinationPortRanges, Is.EqualTo(new[] { "443" }));
            AssertReadOnlyView(rule.Sources);
            AssertReadOnlyView(rule.Destinations);
            AssertReadOnlyView(rule.SourcePortRanges);
            AssertReadOnlyView(rule.DestinationPortRanges);
            var restoredRule = ModelReaderWriter.Read<EffectiveSecurityAdminRule>(ModelReaderWriter.Write(rule));
            Assert.That(restoredRule.Sources.Single().AddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(restoredRule.DestinationPortRanges, Is.EqualTo(new[] { "443" }));
        }

        [Test]
        public void GeneratedUriRoutingAndETagPropertiesReadAndPersistRealStorage()
        {
            const string connectionUri = "https://management.azure.com" + ReferencePath;
            var authorization = ModelReaderWriter.Read<ExpressRouteCircuitAuthorizationData>(BinaryData.FromString($$$$"""
                {"properties":{"connectionResourceUri":"{{{{connectionUri}}}}"}}
                """));
            Assert.That(authorization.ConnectionResourceUri, Is.EqualTo(new Uri(connectionUri)));
            using JsonDocument authorizationJson = JsonDocument.Parse(ModelReaderWriter.Write(authorization));
            Assert.That(authorizationJson.RootElement.GetProperty("properties").GetProperty("connectionResourceUri").GetString(), Is.EqualTo(connectionUri));

            var connection = new ExpressRouteConnectionData
            {
                RoutingConfiguration = new RoutingConfiguration { AssociatedRouteTableId = new ResourceIdentifier(ReferencePath) }
            };
            using JsonDocument connectionJson = JsonDocument.Parse(ModelReaderWriter.Write(connection, new ModelReaderWriterOptions("W")));
            Assert.That(connectionJson.RootElement.GetProperty("properties").GetProperty("routingConfiguration").GetProperty("associatedRouteTable").GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
            var restored = ModelReaderWriter.Read<ExpressRouteConnectionData>(ModelReaderWriter.Write(connection));
            Assert.That(restored.RoutingConfiguration.AssociatedRouteTableId.ToString(), Is.EqualTo(ReferencePath));

            var link = ModelReaderWriter.Read<ExpressRouteLinkData>(BinaryData.FromString("""{"etag":"link-etag"}"""));
            Assert.That(link.ETag.ToString(), Is.EqualTo("link-etag"));
            using JsonDocument linkJson = JsonDocument.Parse(ModelReaderWriter.Write(link));
            Assert.That(linkJson.RootElement.GetProperty("etag").GetString(), Is.EqualTo("link-etag"));
        }

        [Test]
        public void RemovedAliasesStayAbsentAndNativeIdsRetainReleasedShapes()
        {
            foreach ((Type owner, string name) in new[]
            {
                (typeof(ExpressRouteCircuitPeeringData), "ExpressRouteConnection"),
                (typeof(ExpressRouteCircuitPeeringData), "RouteFilter"),
                (typeof(ExpressRouteConnectionData), "ExpressRouteCircuitPeering"),
                (typeof(ExpressRouteCrossConnectionData), "ExpressRouteCircuit"),
                (typeof(ExpressRouteGatewayData), "VirtualHub")
            })
            {
                Assert.That(owner.GetProperty(name), Is.Null, owner.Name + "." + name);
            }
            Assert.That(typeof(ExpressRouteCircuitPeeringData).GetProperty("ExpressRouteConnectionId").SetMethod, Is.Null);
            var peering = ModelReaderWriter.Read<ExpressRouteCircuitPeeringData>(BinaryData.FromString($$$$"""
                {"properties":{"expressRouteConnection":{"id":"{{{{ReferencePath}}}}"}}}
                """));
            Assert.That(peering.ExpressRouteConnectionId.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(typeof(ExpressRouteGatewayData).GetProperty("ExpressRouteConnections").GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            var gateway = new ExpressRouteGatewayData();
            var connections = (IReadOnlyList<ExpressRouteConnectionData>)typeof(ExpressRouteGatewayData).GetProperty("ExpressRouteConnections").GetValue(gateway);
            gateway.ExpressRouteConnectionList.Add(new ExpressRouteConnectionData());
            Assert.That(connections, Has.Count.EqualTo(1));
            AssertReadOnlyView(connections);
        }

        public static IEnumerable<TestCaseData> PeeringOperations()
        {
            foreach ((bool crossConnection, string name, string suffix) in new[]
            {
                (false, "GetArpTableExpressRouteCircuit", "arpTables/primary"),
                (false, "GetRoutesTableExpressRouteCircuit", "routeTables/primary"),
                (false, "GetRoutesTableSummaryExpressRouteCircuit", "routeTablesSummary/primary"),
                (false, "GetPeeringStatsExpressRouteCircuit", "stats"),
                (true, "GetArpTableExpressRouteCrossConnection", "arpTables/primary"),
                (true, "GetRoutesTableExpressRouteCrossConnection", "routeTables/primary"),
                (true, "GetRoutesTableSummaryExpressRouteCrossConnection", "routeTablesSummary/primary")
            })
            {
                yield return new TestCaseData(crossConnection, name, suffix, false);
                yield return new TestCaseData(crossConnection, name, suffix, true);
            }
        }

        [TestCaseSource(nameof(PeeringOperations))]
        public async Task HistoricalPeeringNamesExecuteNativeEndpoints(bool crossConnection, string name, string suffix, bool asynchronous)
        {
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return new MockResponse(200).SetContent("""{"value":[]}""");
            });
            ArmClient client = CreateClient(transport);
            string path = GroupPath + "/providers/Microsoft.Network/" + (crossConnection ? "expressRouteCrossConnections" : "expressRouteCircuits") + "/circuit/peerings/AzurePrivatePeering";
            ArmResource resource = crossConnection
                ? client.GetExpressRouteCrossConnectionPeeringResource(new ResourceIdentifier(path))
                : client.GetExpressRouteCircuitPeeringResource(new ResourceIdentifier(path));
            MethodInfo method = resource.GetType().GetMethod(name + (asynchronous ? "Async" : ""));
            Assert.That(method, Is.Not.Null);
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(method.GetParameters().Last().Name, Is.EqualTo("cancellationToken"));
            Assert.That(method.GetParameters().Last().IsOptional, Is.True);
            using var cancellation = new CancellationTokenSource();
            object[] parameters = name.Contains("Stats")
                ? new object[] { cancellation.Token }
                : new object[] { WaitUntil.Completed, "primary", cancellation.Token };
            object result = method.Invoke(resource, parameters);
            if (asynchronous)
            {
                await (Task)result;
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(name.Contains("Stats") ? RequestMethod.Get : RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(path + "/" + suffix));
            Assert.That(observed.CanBeCanceled, Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void HistoricalPeeringOperationsPropagateCancellation(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                cancellation.Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200);
            });
            var resource = CreateClient(transport).GetExpressRouteCircuitPeeringResource(new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/expressRouteCircuits/circuit/peerings/AzurePrivatePeering"));
            if (asynchronous)
            {
                Assert.CatchAsync<OperationCanceledException>(async () => await resource.GetArpTableExpressRouteCircuitAsync(WaitUntil.Completed, "primary", cancellation.Token));
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => resource.GetArpTableExpressRouteCircuit(WaitUntil.Completed, "primary", cancellation.Token));
            }
        }

        [TestCase(0, false)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(2, true)]
        public async Task NativeExpressRoutePagingExecutesCollectionEndpoints(int family, bool asynchronous)
        {
            string itemPath = family == 0 ? GatewayPath + "/expressRouteConnections/connection" : GatewayPath;
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return new MockResponse(200).SetContent($$$$"""{"value":[{"id":"{{{{itemPath}}}}","name":"item"}]}""");
            });
            var client = CreateClient(transport);
            using var cancellation = new CancellationTokenSource();
            var items = new List<ArmResource>();
            if (family == 0)
            {
                var collection = client.GetExpressRouteGatewayResource(new ResourceIdentifier(GatewayPath)).GetExpressRouteConnections();
                if (asynchronous)
                {
                    await foreach (var item in collection.GetAllAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(collection.GetAll(cancellation.Token));
                }
            }
            else if (family == 1)
            {
                var collection = client.GetResourceGroupResource(new ResourceIdentifier(GroupPath)).GetExpressRouteGateways();
                if (asynchronous)
                {
                    await foreach (var item in collection.GetAllAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(collection.GetAll(cancellation.Token));
                }
            }
            else
            {
                var subscription = client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId));
                if (asynchronous)
                {
                    await foreach (var item in subscription.GetExpressRouteGatewaysAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(subscription.GetExpressRouteGateways(cancellation.Token));
                }
            }
            Assert.That(items.Single().Id.ToString(), Is.EqualTo(itemPath));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            string expectedPath = family == 0 ? GatewayPath + "/expressRouteConnections"
                : family == 1 ? GroupPath + "/providers/Microsoft.Network/expressRouteGateways"
                : "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/expressRouteGateways";
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(expectedPath));
            Assert.That(observed.CanBeCanceled, Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeCollectionEnumeratorsUseGetAllInsteadOfEmptyOrThrowingStubs(bool connections)
        {
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("""{"value":[]}"""));
            var client = CreateClient(transport);
            object collection = connections
                ? client.GetExpressRouteGatewayResource(new ResourceIdentifier(GatewayPath)).GetExpressRouteConnections()
                : client.GetResourceGroupResource(new ResourceIdentifier(GroupPath)).GetExpressRouteGateways();
            Assert.That(((IEnumerable)collection).Cast<ArmResource>(), Is.Empty);
            Assert.That((IEnumerable<ArmResource>)collection, Is.Empty);
            await foreach (var item in (IAsyncEnumerable<ArmResource>)collection)
            {
                Assert.Fail("Expected an empty service result, got " + item.Id);
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativePortAndFirewallReferencesRetainReadOnlyContracts(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            string references = $$$$"""[{"id":"{{{{ReferencePath}}}}"}]""";
            var port = ModelReaderWriter.Read<ExpressRoutePortData>(BinaryData.FromString($$$$"""{"properties":{"circuits":{{{{references}}}}}}"""), options);
            var policy = ModelReaderWriter.Read<FirewallPolicyData>(BinaryData.FromString($$$$"""{"properties":{"childPolicies":{{{{references}}}},"firewalls":{{{{references}}}},"ruleCollectionGroups":{{{{references}}}}}}"""), options);
            var authorization = ModelReaderWriter.Read<ExpressRoutePortAuthorizationData>(BinaryData.FromString($$$$"""{"properties":{"circuitResourceUri":"https://management.azure.com{{{{ReferencePath}}}}"}}"""), options);

            Assert.That(authorization.CircuitResourceUri, Is.EqualTo(new Uri("https://management.azure.com" + ReferencePath)));
            AssertReadOnlyCollection<WritableSubResource>(typeof(ExpressRoutePortData), nameof(ExpressRoutePortData.Circuits));
            Assert.That(port.Circuits[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(port.Circuits, Is.SameAs(port.Circuits));
            Assert.That(new ExpressRoutePortData().Circuits, Is.Empty);
            foreach (string name in new[] { "ChildPolicies", "Firewalls", "RuleCollectionGroups" })
            {
                AssertReadOnlyCollection<WritableSubResource>(typeof(FirewallPolicyData), name);
                var values = (IReadOnlyList<WritableSubResource>)typeof(FirewallPolicyData).GetProperty(name).GetValue(policy);
                Assert.That(values[0].Id.ToString(), Is.EqualTo(ReferencePath));
                Assert.That(values, Is.SameAs(typeof(FirewallPolicyData).GetProperty(name).GetValue(policy)));
                Assert.That(typeof(FirewallPolicyData).GetProperty(name).GetValue(new FirewallPolicyData()), Is.Empty);
                values[0].Id = new ResourceIdentifier(ReferencePath + "2");
            }
            port.Circuits[0].Id = new ResourceIdentifier(ReferencePath + "2");

            using JsonDocument portJson = JsonDocument.Parse(ModelReaderWriter.Write(port, options));
            using JsonDocument policyJson = JsonDocument.Parse(ModelReaderWriter.Write(policy, options));
            using JsonDocument authorizationJson = JsonDocument.Parse(ModelReaderWriter.Write(authorization, options));
            Assert.That(portJson.RootElement.GetProperty("properties").TryGetProperty("circuits", out JsonElement circuits), Is.EqualTo(format == "J"));
            Assert.That(authorizationJson.RootElement.GetProperty("properties").TryGetProperty("circuitResourceUri", out _), Is.EqualTo(format == "J"));
            foreach (string wireName in new[] { "childPolicies", "firewalls", "ruleCollectionGroups" })
            {
                Assert.That(policyJson.RootElement.GetProperty("properties").TryGetProperty(wireName, out JsonElement values), Is.EqualTo(format == "J"));
                if (format == "J")
                {
                    Assert.That(values[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath + "2"));
                }
            }
            if (format == "J")
            {
                Assert.That(circuits[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath + "2"));
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeFirewallRuleGroupETagIsDeserializedInsteadOfDefaulted(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<FirewallPolicyRuleCollectionGroupData>(BinaryData.FromString("""{"etag":"review-etag","properties":{"priority":100}}"""), options);
            Assert.That(model.ETag.ToString(), Is.EqualTo("review-etag"));
            Assert.That(model.Priority, Is.EqualTo(100));
            Assert.That(typeof(FirewallPolicyRuleCollectionGroupData).GetProperty("ETag").PropertyType, Is.EqualTo(typeof(ETag?)));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            Assert.That(json.RootElement.TryGetProperty("etag", out JsonElement etag), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(etag.GetString(), Is.EqualTo("review-etag"));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeAuthorizationCreateUsesOnlyItsOwnName(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return new MockResponse(200).SetContent($$$$"""{"id":"{{{{PortPath}}}}/authorizations/authorization","name":"authorization","properties":{"provisioningState":"Succeeded"}}""");
            });
            var parent = CreateClient(transport).GetExpressRoutePortResource(new ResourceIdentifier(PortPath));
            var collection = parent.GetExpressRoutePortAuthorizations();
            Assert.That(collection.Id.ToString(), Is.EqualTo(PortPath));
            foreach (MethodInfo method in typeof(ExpressRoutePortAuthorizationCollection).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(method => method.Name is "CreateOrUpdate" or "CreateOrUpdateAsync"))
            {
                Assert.That(method.GetParameters().Select(parameter => parameter.Name), Is.EqualTo(new[] { "waitUntil", "authorizationName", "data", "cancellationToken" }));
            }
            ArmOperation<ExpressRoutePortAuthorizationResource> operation = asynchronous
                ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "authorization", new ExpressRoutePortAuthorizationData(), cancellation.Token)
                : collection.CreateOrUpdate(WaitUntil.Completed, "authorization", new ExpressRoutePortAuthorizationData(), cancellation.Token);
            Assert.That(operation.Value.Id.ToString(), Is.EqualTo(PortPath + "/authorizations/authorization"));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(PortPath + "/authorizations/authorization"));
            Assert.That(observed.CanBeCanceled, Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeAuthorizationParentGetForwardsToTheChildEndpoint(bool asynchronous)
        {
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent($$$$"""{"id":"{{{{PortPath}}}}/authorizations/authorization","name":"authorization"}"""));
            var parent = CreateClient(transport).GetExpressRoutePortResource(new ResourceIdentifier(PortPath));
            var response = asynchronous
                ? await parent.GetExpressRoutePortAuthorizationAsync("authorization")
                : parent.GetExpressRoutePortAuthorization("authorization");
            Assert.That(response.Value.Id.ToString(), Is.EqualTo(PortPath + "/authorizations/authorization"));
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(PortPath + "/authorizations/authorization"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeAuthorizationPagingUsesCorrectTransportAndContinuation(bool asynchronous)
        {
            string next = "https://management.azure.com" + PortPath + "/authorizations?api-version=2026-01-01&skipToken=second";
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                return new MockResponse(200).SetContent(message.Request.Uri.ToUri().Query.Contains("skipToken")
                    ? $$$$"""{"value":[{"id":"{{{{PortPath}}}}/authorizations/second","name":"second"}]}"""
                    : $$$$"""{"value":[{"id":"{{{{PortPath}}}}/authorizations/first","name":"first"}],"nextLink":"{{{{next}}}}"}""");
            });
            var tracking = new ModeTrackingTransport(transport);
            var collection = CreateClient(tracking).GetExpressRoutePortResource(new ResourceIdentifier(PortPath)).GetExpressRoutePortAuthorizations();
            var ids = new List<string>();
            if (asynchronous)
            {
                await foreach (var item in collection.GetAllAsync(cancellation.Token))
                {
                    ids.Add(item.Id.Name);
                }
                await foreach (var page in collection.GetAllAsync(cancellation.Token).AsPages(next))
                {
                    Assert.That(page.Values.Single().Id.Name, Is.EqualTo("second"));
                }
            }
            else
            {
                ids.AddRange(collection.GetAll(cancellation.Token).Select(item => item.Id.Name));
                Assert.That(collection.GetAll(cancellation.Token).AsPages(next).Single().Values.Single().Id.Name, Is.EqualTo("second"));
            }
            Assert.That(ids, Is.EqualTo(new[] { "first", "second" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(asynchronous ? tracking.AsyncCalls : tracking.SyncCalls, Is.EqualTo(3));
            Assert.That(asynchronous ? tracking.SyncCalls : tracking.AsyncCalls, Is.Zero);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeProviderPortPagingPreservesTheReleasedFilter(bool asynchronous)
        {
            string id = "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/expressRouteProviderPorts/provider";
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                return new MockResponse(200).SetContent($$$$"""{"value":[{"id":"{{{{id}}}}","name":"provider","location":"westus","properties":{}}]}""");
            });
            var collection = CreateClient(transport).GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId)).GetExpressRouteProviderPorts();
            var resources = new List<ExpressRouteProviderPortResource>();
            if (asynchronous)
            {
                await foreach (var item in collection.GetAllAsync("location eq 'westus'", cancellation.Token))
                {
                    resources.Add(item);
                }
            }
            else
            {
                resources.AddRange(collection.GetAll("location eq 'westus'", cancellation.Token));
            }
            Assert.That(resources.Single().Id.ToString(), Is.EqualTo(id));
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo("/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/expressRouteProviderPorts"));
            Assert.That(Uri.UnescapeDataString(transport.Requests.Single().Uri.ToUri().Query), Does.Contain("$filter=location eq 'westus'"));
            MethodInfo method = typeof(ExpressRouteProviderPortCollection).GetMethod(asynchronous ? "GetAllAsync" : "GetAll", new[] { typeof(string), typeof(CancellationToken) });
            Assert.That(method.GetParameters()[0].Name, Is.EqualTo("filter"));
            Assert.That(method.GetParameters()[0].IsOptional, Is.True);
        }

        [Test]
        public async Task NativeProviderPortEnumeratorsExecuteRequestsInsteadOfReturningEmpty()
        {
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("""{"value":[]}"""));
            var collection = CreateClient(transport).GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId)).GetExpressRouteProviderPorts();
            Assert.That(((IEnumerable)collection).Cast<ArmResource>(), Is.Empty);
            Assert.That((IEnumerable<ArmResource>)collection, Is.Empty);
            await foreach (var item in (IAsyncEnumerable<ArmResource>)collection)
            {
                Assert.Fail("Expected the service's empty list, got " + item.Id);
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task LegacyFirewallCreateOverloadIsHiddenAndForwardsDefaultAfcFlag(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent($$$$"""{"id":"{{{{PolicyPath}}}}","name":"policy","properties":{"provisioningState":"Succeeded"}}"""));
            var collection = CreateClient(transport).GetResourceGroupResource(new ResourceIdentifier(GroupPath)).GetFirewallPolicies();
            string name = asynchronous ? "CreateOrUpdateAsync" : "CreateOrUpdate";
            MethodInfo method = typeof(FirewallPolicyCollection).GetMethod(name, new[] { typeof(WaitUntil), typeof(string), typeof(FirewallPolicyData), typeof(CancellationToken) });
            Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(method.GetParameters().Last().IsOptional, Is.False);
            var operation = asynchronous
                ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "policy", new FirewallPolicyData(), cancellation.Token)
                : collection.CreateOrUpdate(WaitUntil.Completed, "policy", new FirewallPolicyData(), cancellation.Token);
            Assert.That(operation.Value.Id.ToString(), Is.EqualTo(PolicyPath));
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(PolicyPath));
            Assert.That(transport.Requests.Single().Uri.ToUri().Query, Does.Not.Contain("afcManagedSync"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task LegacyFirewallDeployAliasUsesTheUnchangedDeployEndpoint(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200));
            var resource = CreateClient(transport).GetFirewallPolicyResource(new ResourceIdentifier(PolicyPath));
            string name = asynchronous ? "DeployFirewallPolicyDeploymentAsync" : "DeployFirewallPolicyDeployment";
            Assert.That(typeof(FirewallPolicyResource).GetMethod(name).GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            if (asynchronous)
            {
                await resource.DeployFirewallPolicyDeploymentAsync(WaitUntil.Started, cancellation.Token);
            }
            else
            {
                resource.DeployFirewallPolicyDeployment(WaitUntil.Started, cancellation.Token);
            }
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(PolicyPath + "/deploy"));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task NativeFirewallIdpsOperationsUseTheirReleasedNamesAndEndpoints(bool filters, bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                return new MockResponse(200).SetContent("{}");
            });
            var resource = CreateClient(transport).GetFirewallPolicyResource(new ResourceIdentifier(PolicyPath));
            if (filters)
            {
                var content = new SignatureOverridesFilterValuesQueryContent { FilterName = "severity" };
                var response = asynchronous
                    ? await resource.GetFirewallPolicyIdpsSignaturesFilterValueAsync(content, cancellation.Token)
                    : resource.GetFirewallPolicyIdpsSignaturesFilterValue(content, cancellation.Token);
                Assert.That(response.Value, Is.Not.Null);
            }
            else
            {
                var content = new IdpsQueryContent { Search = "review" };
                var response = asynchronous
                    ? await resource.GetFirewallPolicyIdpsSignatureAsync(content, cancellation.Token)
                    : resource.GetFirewallPolicyIdpsSignature(content, cancellation.Token);
                Assert.That(response.Value, Is.Not.Null);
            }
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(PolicyPath + (filters ? "/listIdpsFilterOptions" : "/listIdpsSignatures")));
            Assert.That(transport.Requests.Single().Content, Is.Not.Null);
        }

        [TestCase("AddTag")]
        [TestCase("AddTagAsync")]
        [TestCase("RemoveTag")]
        [TestCase("RemoveTagAsync")]
        [TestCase("SetTags")]
        [TestCase("SetTagsAsync")]
        public void LocationTagCompatibilityPreservesReleasedNamesAndHiddenObsoleteMetadata(string name)
        {
            MethodInfo method = typeof(ExpressRoutePortsLocationResource).GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This method is obsolete and will be removed in a future release"));
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            string[] parameters = name.StartsWith("Add") ? new[] { "key", "value", "cancellationToken" }
                : name.StartsWith("Remove") ? new[] { "key", "cancellationToken" }
                : new[] { "tags", "cancellationToken" };
            Assert.That(method.GetParameters().Select(parameter => parameter.Name), Is.EqualTo(parameters));
            Assert.That(method.GetParameters().Last().IsOptional, Is.True);
        }

        [Test]
        public void UnreleasedDraftUpdateHelpersArePrivateAndReleasedAliasesRemainHidden()
        {
            Assert.That(typeof(ExpressRoutePortsLocationData).GetConstructor(Type.EmptyTypes), Is.Not.Null);
            Assert.That(typeof(ExpressRoutePortsLocationData).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null), Is.Null);
            foreach (string name in new[] { "Update", "UpdateAsync" })
            {
                Type[] signature = { typeof(WaitUntil), typeof(FirewallPolicyDraftData), typeof(CancellationToken) };
                Assert.That(typeof(FirewallPolicyDraftResource).GetMethod(name, signature), Is.Null);
                Assert.That(typeof(FirewallPolicyDraftResource).GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic, null, signature, null)?.IsPrivate, Is.True);
                MethodInfo method = typeof(FirewallPolicyResource).GetMethod(name, new[] { typeof(WaitUntil), typeof(FirewallPolicyData), typeof(CancellationToken) });
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This method is obsolete and will be removed in a future release"));
                Assert.That(method.GetParameters().Last().IsOptional, Is.True);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DraftTagsUsePrivateUpdateHelpersAndNativeCreateOrUpdate(bool asynchronous)
        {
            string id = PolicyPath + "/firewallPolicyDrafts/default";
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                if (message.Request.Uri.ToUri().AbsolutePath.EndsWith("/providers/Microsoft.Resources", StringComparison.OrdinalIgnoreCase))
                    return new MockResponse(200).SetContent($$$$"""{"id":"{{{{message.Request.Uri.ToUri().AbsolutePath}}}}","namespace":"Microsoft.Resources","resourceTypes":[]}""");
                return new MockResponse(200).SetContent($$$$"""{"id":"{{{{id}}}}","name":"default","tags":{},"properties":{"provisioningState":"Succeeded"}}""");
            });
            var resource = CreateClient(transport).GetFirewallPolicyDraftResource(new ResourceIdentifier(id));
            var response = asynchronous
                ? await resource.AddTagAsync("review", "sdk", cancellation.Token)
                : resource.AddTag("review", "sdk", cancellation.Token);
            Assert.That(response.Value.Id.ToString(), Is.EqualTo(id));
            var request = transport.Requests.Single(request => request.Method == RequestMethod.Put);
            Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(id));
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, cancellation.Token);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.That(body.RootElement.GetProperty("tags").GetProperty("review").GetString(), Is.EqualTo("sdk"));
        }

        [TestCase(false, WaitUntil.Started)]
        [TestCase(true, WaitUntil.Started)]
        [TestCase(false, WaitUntil.Completed)]
        [TestCase(true, WaitUntil.Completed)]
        public async Task BastionFullDataUpdatesUseNativePut(bool asynchronous, WaitUntil waitUntil)
        {
            string id = GroupPath + "/providers/Microsoft.Network/bastionHosts/host";
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                return new MockResponse(200).SetContent($$$$"""{"id":"{{{{id}}}}","name":"host","location":"westus","properties":{"provisioningState":"Succeeded"}}""");
            });
            var resource = CreateClient(transport).GetBastionHostResource(new ResourceIdentifier(id));
            var data = new BastionHostData { Location = AzureLocation.WestUS };
            data.Tags["review"] = "sdk";
            var operation = asynchronous
                ? await resource.UpdateAsync(waitUntil, data, cancellation.Token)
                : resource.Update(waitUntil, data, cancellation.Token);
            Assert.That(operation.HasCompleted, Is.EqualTo(waitUntil == WaitUntil.Completed));
            if (waitUntil == WaitUntil.Completed)
                Assert.That(operation.Value.Id.ToString(), Is.EqualTo(id));
            var request = transport.Requests.Single();
            Assert.That(request.Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(id));
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, cancellation.Token);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.That(body.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(body.RootElement.GetProperty("tags").GetProperty("review").GetString(), Is.EqualTo("sdk"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void BastionFullDataUpdatesPropagateCancellation(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200);
            });
            var resource = CreateClient(transport).GetBastionHostResource(
                new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/bastionHosts/host"));
            var data = new BastionHostData();
            if (asynchronous)
                Assert.CatchAsync<OperationCanceledException>(async () => await resource.UpdateAsync(WaitUntil.Completed, data, cancellation.Token));
            else
                Assert.Catch<OperationCanceledException>(() => resource.Update(WaitUntil.Completed, data, cancellation.Token));
        }

        [TestCase(false, "add")]
        [TestCase(true, "add")]
        [TestCase(false, "remove")]
        [TestCase(true, "remove")]
        [TestCase(false, "replace")]
        [TestCase(true, "replace")]
        public async Task LocationTagsUseReleasedArmTagResourceBehavior(bool asynchronous, string operation)
        {
            string id = "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/ExpressRoutePortsLocations/westus";
            string tagPath = id + "/providers/Microsoft.Resources/tags/default";
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                if (message.Request.Method == RequestMethod.Delete)
                    return new MockResponse(200);
                return new MockResponse(200).SetContent(message.Request.Uri.ToUri().AbsolutePath == tagPath
                    ? $$$$"""{"id":"{{{{tagPath}}}}","name":"default","properties":{"tags":{"existing":"keep","remove":"old"}}}"""
                    : $$$$"""{"id":"{{{{id}}}}","name":"westus"}""");
            });
            var resource = CreateClient(transport).GetExpressRoutePortsLocationResource(new ResourceIdentifier(id));
            Response<ExpressRoutePortsLocationResource> response;
            if (operation == "add")
                response = asynchronous ? await resource.AddTagAsync("review", "sdk", cancellation.Token) : resource.AddTag("review", "sdk", cancellation.Token);
            else if (operation == "remove")
                response = asynchronous ? await resource.RemoveTagAsync("remove", cancellation.Token) : resource.RemoveTag("remove", cancellation.Token);
            else
            {
                var tags = new Dictionary<string, string> { ["review"] = "sdk" };
                response = asynchronous ? await resource.SetTagsAsync(tags, cancellation.Token) : resource.SetTags(tags, cancellation.Token);
            }
            Assert.That(response.Value.Id.ToString(), Is.EqualTo(id));
            Assert.That(transport.Requests.Last().Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests.Last().Uri.ToUri().AbsolutePath, Is.EqualTo(id));
            Assert.That(transport.Requests.Select(request => request.Method), Is.EqualTo(operation == "replace"
                ? new[] { RequestMethod.Delete, RequestMethod.Get, RequestMethod.Put, RequestMethod.Get }
                : new[] { RequestMethod.Get, RequestMethod.Put, RequestMethod.Get }));
            var request = transport.Requests.Single(request => request.Method == RequestMethod.Put);
            Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(tagPath));
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, cancellation.Token);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            JsonElement values = body.RootElement.GetProperty("properties").GetProperty("tags");
            Assert.That(values.TryGetProperty("existing", out _), Is.EqualTo(operation != "replace"));
            Assert.That(values.TryGetProperty("remove", out _), Is.EqualTo(operation == "add"));
            Assert.That(values.TryGetProperty("review", out JsonElement review), Is.EqualTo(operation != "remove"));
            if (operation != "remove")
                Assert.That(review.GetString(), Is.EqualTo("sdk"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ReleasedFirewallUpdateAliasForwardsInsteadOfThrowing(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                return new MockResponse(200).SetContent($$$$"""{"id":"{{{{PolicyPath}}}}","name":"policy","properties":{"provisioningState":"Succeeded"}}""");
            });
            var resource = CreateClient(transport).GetFirewallPolicyResource(new ResourceIdentifier(PolicyPath));
#pragma warning disable CS0618
            var operation = asynchronous
                ? await resource.UpdateAsync(WaitUntil.Completed, new FirewallPolicyData(), cancellation.Token)
                : resource.Update(WaitUntil.Completed, new FirewallPolicyData(), cancellation.Token);
#pragma warning restore CS0618
            Assert.That(operation.Value.Id.ToString(), Is.EqualTo(PolicyPath));
            Assert.That(transport.Requests.Single().Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(PolicyPath));
            Assert.That(transport.Requests.Single().Uri.ToUri().Query, Does.Not.Contain("afcManagedSync"));
        }

        private static string NativeTrackedResourceProperties(Type modelType) =>
            modelType == typeof(ConnectionAnalyzerData)
                ? """{"expiryInDays":7,"source":{"type":"ExternalAddress","address":"10.0.0.1"},"destination":{"type":"ExternalAddress","address":"10.0.0.2"},"diagnosticOperations":[]}"""
                : modelType == typeof(IpamPoolData) ? """{"displayName":"review","addressPrefixes":["10.0.0.0/24"]}"""
                : modelType == typeof(ExpressRouteProviderPortData) ? """{"peeringLocation":"review","portPairDescriptor":"pair"}"""
                : modelType == typeof(NetworkSecurityPerimeterData) ? """{"perimeterGuid":"00000000-0000-0000-0000-000000000002"}"""
                : modelType == typeof(ServiceGatewayData) ? """{"provisioningState":"Succeeded"}"""
                : modelType == typeof(NetworkVerifierWorkspaceData) ? """{"description":"review"}"""
                : throw new ArgumentException("Unexpected tracked-resource model.", nameof(modelType));

        private static void AssertReadOnlyView<T>(IReadOnlyList<T> values)
        {
            var collection = (IList<T>)values;
            Assert.That(collection.IsReadOnly, Is.True);
            Assert.Throws<NotSupportedException>(() => collection.Add(values[0]));
        }

        private static void AssertReadOnlyCollection<T>(Type owner, string name)
        {
            PropertyInfo property = owner.GetProperty(name);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<T>)), owner.Name + "." + name);
            Assert.That(property.SetMethod, Is.Null, owner.Name + "." + name);
        }

        private sealed class ModeTrackingTransport : HttpPipelineTransport
        {
            private readonly MockTransport _inner;

            public ModeTrackingTransport(MockTransport inner) => _inner = inner;

            public int SyncCalls { get; private set; }
            public int AsyncCalls { get; private set; }

            public override Request CreateRequest() => _inner.CreateRequest();

            public override void Process(HttpMessage message)
            {
                SyncCalls++;
                _inner.Process(message);
            }

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                AsyncCalls++;
                return _inner.ProcessAsync(message);
            }
        }

        private static ArmClient CreateClient(HttpPipelineTransport transport) =>
            new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
    }
}
