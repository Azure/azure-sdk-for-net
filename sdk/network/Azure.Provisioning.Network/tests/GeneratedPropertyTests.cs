// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Reflection;
using Azure.Core;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class GeneratedPropertyTests
{
    [Test]
    public void VpnServerConfigurationSuppressesNestedMetadataProjections()
    {
        Assert.That(typeof(VpnServerConfiguration).GetProperty("NamePropertiesName"), Is.Null);
        Assert.That(typeof(VpnServerConfiguration).GetProperty("PropertiesETag"), Is.Null);

        VpnServerConfiguration configuration = new("vpn") { Name = "vpn-config" };
        Assert.That(configuration.Name, Is.SameAs(configuration.ProvisionableProperties["Name"]));
        Assert.That(configuration.ETag, Is.SameAs(configuration.ProvisionableProperties["ETag"]));
        Assert.That(((IBicepValue)configuration.ETag).Self!.BicepPath, Is.EqualTo(new[] { "etag" }));
        Assert.That(((IBicepValue)configuration).Compile().ToString(), Does.Contain("name: 'vpn-config'"));
    }

    [Test]
    public void VirtualHubRoutesUsesRegisteredRouteTable()
    {
        VirtualHub hub = new("hub");
        hub.Routes = new BicepList<VirtualHubRoute>
        {
            new VirtualHubRoute { AddressPrefixes = { "10.0.0.0/24" }, NextHopIPAddress = "10.0.0.1" }
        };
        hub.Routes.Add(new VirtualHubRoute { NextHopIPAddress = "10.0.0.2" });

        string bicep = ((IBicepValue)hub).Compile().ToString();
        Assert.That(bicep, Does.Contain("routeTable: {"));
        Assert.That(bicep, Does.Contain("routes: ["));
        Assert.That(bicep, Does.Contain("'10.0.0.0/24'"));
        Assert.That(bicep, Does.Contain("nextHopIpAddress: '10.0.0.1'"));
        Assert.That(bicep, Does.Contain("nextHopIpAddress: '10.0.0.2'"));
        Assert.That(typeof(VirtualHub).GetProperty("RouteRoutes"), Is.Null);
        Assert.That(typeof(VirtualHub).GetProperty("Routes")!.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void VirtualNetworkGatewayActiveForwardsToIsActive(bool value)
    {
        VirtualNetworkGateway gateway = new("gateway");
        PropertyInfo legacy = typeof(VirtualNetworkGateway).GetProperty("Active")!;
        legacy.SetValue(gateway, new BicepValue<bool>(value));

        Assert.That(legacy.GetValue(gateway), Is.SameAs(gateway.IsActive));
        Assert.That(((IBicepValue)gateway).Compile().ToString(), Does.Contain($"activeActive: {value.ToString().ToLowerInvariant()}"));
        Assert.That(legacy.GetCustomAttribute<EditorBrowsableAttribute>()!.State, Is.EqualTo(EditorBrowsableState.Never));
        Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>()!.Message, Does.Contain("IsActive"));

        gateway.IsActive = !value;
        Assert.That(legacy.GetValue(gateway), Is.SameAs(gateway.IsActive));
        Assert.That(((IBicepValue)gateway).Compile().ToString(), Does.Contain($"activeActive: {(!value).ToString().ToLowerInvariant()}"));
    }

    [TestCase(typeof(ApplicationGatewayAuthenticationCertificate))]
    [TestCase(typeof(ApplicationGatewayBackendAddressPool))]
    [TestCase(typeof(ApplicationGatewayBackendHttpSettings))]
    [TestCase(typeof(ApplicationGatewayBackendSettings))]
    [TestCase(typeof(ApplicationGatewayFrontendIPConfiguration))]
    [TestCase(typeof(ApplicationGatewayFrontendPort))]
    [TestCase(typeof(ApplicationGatewayHttpListener))]
    [TestCase(typeof(ApplicationGatewayIPConfiguration))]
    [TestCase(typeof(ApplicationGatewayListener))]
    [TestCase(typeof(ApplicationGatewayLoadDistributionPolicy))]
    [TestCase(typeof(ApplicationGatewayLoadDistributionTarget))]
    [TestCase(typeof(ApplicationGatewayPathRule))]
    [TestCase(typeof(ApplicationGatewayPrivateLinkConfiguration))]
    [TestCase(typeof(ApplicationGatewayPrivateLinkIPConfiguration))]
    [TestCase(typeof(ApplicationGatewayProbe))]
    [TestCase(typeof(ApplicationGatewayRedirectConfiguration))]
    [TestCase(typeof(ApplicationGatewayRequestRoutingRule))]
    [TestCase(typeof(ApplicationGatewayRoutingRule))]
    [TestCase(typeof(ApplicationGatewaySslCertificate))]
    [TestCase(typeof(ApplicationGatewaySslProfile))]
    [TestCase(typeof(ApplicationGatewayTrustedClientCertificate))]
    [TestCase(typeof(ApplicationGatewayTrustedRootCertificate))]
    [TestCase(typeof(ApplicationGatewayUrlPathMap))]
    [TestCase(typeof(AzureFirewallIPConfiguration))]
    [TestCase(typeof(BastionHostIPConfiguration))]
    [TestCase(typeof(ContainerNetworkInterface))]
    [TestCase(typeof(ContainerNetworkInterfaceConfiguration))]
    [TestCase(typeof(DdosDetectionRule))]
    [TestCase(typeof(LoadBalancerInboundNatPool))]
    [TestCase(typeof(NetworkIPConfigurationProfile))]
    [TestCase(typeof(NetworkPrivateLinkServiceConnection))]
    [TestCase(typeof(PrivateLinkServiceIPConfiguration))]
    [TestCase(typeof(ResourceNavigationLink))]
    [TestCase(typeof(ServiceAssociationLink))]
    [TestCase(typeof(VirtualNetworkApplianceIPConfiguration))]
    public void ResourceTypeUsesRegisteredGeneratedValue(Type modelType)
    {
        ProvisionableConstruct model = (ProvisionableConstruct)Activator.CreateInstance(modelType)!;
        PropertyInfo property = modelType.GetProperty("ResourceType")!;
        object value = property.GetValue(model)!;

        Assert.That(property.PropertyType, Is.EqualTo(typeof(BicepValue<ResourceType>)));
        Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        Assert.That(value, Is.SameAs(model.ProvisionableProperties["ResourceType"]));
        Assert.That(((IBicepValue)value).IsOutput, Is.True);
        Assert.That(((IBicepValue)value).Self!.BicepPath, Is.EqualTo(new[] { "type" }));
    }

    [TestCase(typeof(ApplicationGateway), "AvailabilityZones")]
    [TestCase(typeof(ApplicationGatewayPrivateEndpointConnection), "ConnectionState")]
    [TestCase(typeof(ExpressRouteGateway), "ExpressRouteConnectionList")]
    [TestCase(typeof(FlowLog), "TrafficAnalyticsConfiguration")]
    [TestCase(typeof(NetworkPrivateLinkServiceConnection), "ConnectionState")]
    [TestCase(typeof(NetworkVirtualApplianceConnection), "ConnectionRoutingConfiguration")]
    [TestCase(typeof(TunnelConnectionHealth), "LastConnectionEstablishedOn")]
    public void RestoredGeneratedPropertyIsNotAnObsoleteAlias(Type modelType, string propertyName)
    {
        PropertyInfo property = modelType.GetProperty(propertyName)!;

        Assert.That(property, Is.Not.Null);
        Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
    }
}
