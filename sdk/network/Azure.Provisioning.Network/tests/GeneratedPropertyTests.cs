// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class GeneratedPropertyTests
{
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
