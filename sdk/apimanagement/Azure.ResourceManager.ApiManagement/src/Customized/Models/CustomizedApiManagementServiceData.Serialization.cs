// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceData : IUtf8JsonSerializable
    {
        internal static ApiManagementServiceData DeserializeApiManagementServiceData(JsonElement element)
        {
            ApiManagementServiceSkuProperties sku = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<ETag> etag = default;
            Optional<IList<string>> zones = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> notificationSenderEmail = default;
            Optional<string> provisioningState = default;
            Optional<string> targetProvisioningState = default;
            Optional<DateTimeOffset> createdAtUtc = default;
            Optional<Uri> gatewayUri = default;
            Optional<Uri> gatewayRegionalUri = default;
            Optional<Uri> portalUri = default;
            Optional<Uri> managementApiUri = default;
            Optional<Uri> scmUri = default;
            Optional<Uri> developerPortalUri = default;
            Optional<IList<HostnameConfiguration>> hostnameConfigurations = default;
            Optional<IReadOnlyList<IPAddress>> publicIPAddresses = default;
            Optional<IReadOnlyList<IPAddress>> privateIPAddresses = default;
            Optional<ResourceIdentifier> publicIPAddressId = default;
            Optional<PublicNetworkAccess> publicNetworkAccess = default;
            Optional<VirtualNetworkConfiguration> virtualNetworkConfiguration = default;
            Optional<IList<AdditionalLocation>> additionalLocations = default;
            Optional<IDictionary<string, string>> customProperties = default;
            Optional<IList<CertificateConfiguration>> certificates = default;
            Optional<bool> enableClientCertificate = default;
            Optional<bool> disableGateway = default;
            Optional<VirtualNetworkType> virtualNetworkType = default;
            Optional<ApiVersionConstraint> apiVersionConstraint = default;
            Optional<bool> restore = default;
            Optional<IList<RemotePrivateEndpointConnectionWrapper>> privateEndpointConnections = default;
            Optional<PlatformVersion> platformVersion = default;
            string publisherEmail = default;
            string publisherName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"))
                {
                    sku = ApiManagementServiceSkuProperties.DeserializeApiManagementServiceSkuProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("identity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        identity = null;
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("zones"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        zones = null;
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    zones = array;
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("notificationSenderEmail"))
                        {
                            notificationSenderEmail = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("targetProvisioningState"))
                        {
                            targetProvisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("createdAtUtc"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            createdAtUtc = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("gatewayUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                gatewayUri = null;
                                continue;
                            }
                            gatewayUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("gatewayRegionalUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                gatewayRegionalUri = null;
                                continue;
                            }
                            gatewayRegionalUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("portalUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                portalUri = null;
                                continue;
                            }
                            portalUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("managementApiUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                managementApiUri = null;
                                continue;
                            }
                            managementApiUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("scmUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                scmUri = null;
                                continue;
                            }
                            scmUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("developerPortalUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                developerPortalUri = null;
                                continue;
                            }
                            developerPortalUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("hostnameConfigurations"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<HostnameConfiguration> array = new List<HostnameConfiguration>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(HostnameConfiguration.DeserializeHostnameConfiguration(item));
                            }
                            hostnameConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("publicIPAddresses"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<IPAddress> array = new List<IPAddress>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(IPAddress.Parse(item.GetString()));
                            }
                            publicIPAddresses = array;
                            continue;
                        }
                        if (property0.NameEquals("privateIPAddresses"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                privateIPAddresses = null;
                                continue;
                            }
                            List<IPAddress> array = new List<IPAddress>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(IPAddress.Parse(item.GetString()));
                            }
                            privateIPAddresses = array;
                            continue;
                        }
                        if (property0.NameEquals("publicIpAddressId"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                publicIPAddressId = null;
                                continue;
                            }
                            publicIPAddressId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicNetworkAccess = new PublicNetworkAccess(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("virtualNetworkConfiguration"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                virtualNetworkConfiguration = null;
                                continue;
                            }
                            virtualNetworkConfiguration = VirtualNetworkConfiguration.DeserializeVirtualNetworkConfiguration(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("additionalLocations"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                additionalLocations = null;
                                continue;
                            }
                            List<AdditionalLocation> array = new List<AdditionalLocation>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(AdditionalLocation.DeserializeAdditionalLocation(item));
                            }
                            additionalLocations = array;
                            continue;
                        }
                        if (property0.NameEquals("customProperties"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, property1.Value.GetString());
                            }
                            customProperties = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("certificates"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                certificates = null;
                                continue;
                            }
                            List<CertificateConfiguration> array = new List<CertificateConfiguration>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(CertificateConfiguration.DeserializeCertificateConfiguration(item));
                            }
                            certificates = array;
                            continue;
                        }
                        if (property0.NameEquals("enableClientCertificate"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enableClientCertificate = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("disableGateway"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            disableGateway = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("virtualNetworkType"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            virtualNetworkType = new VirtualNetworkType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("apiVersionConstraint"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            apiVersionConstraint = ApiVersionConstraint.DeserializeApiVersionConstraint(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("restore"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            restore = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                privateEndpointConnections = null;
                                continue;
                            }
                            List<RemotePrivateEndpointConnectionWrapper> array = new List<RemotePrivateEndpointConnectionWrapper>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(RemotePrivateEndpointConnectionWrapper.DeserializeRemotePrivateEndpointConnectionWrapper(item));
                            }
                            privateEndpointConnections = array;
                            continue;
                        }
                        if (property0.NameEquals("platformVersion"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            platformVersion = new PlatformVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("publisherEmail"))
                        {
                            publisherEmail = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publisherName"))
                        {
                            publisherName = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ApiManagementServiceData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, sku, identity, Optional.ToNullable(etag), Optional.ToList(zones), notificationSenderEmail.Value, provisioningState.Value, targetProvisioningState.Value, Optional.ToNullable(createdAtUtc), gatewayUri.Value, gatewayRegionalUri.Value, portalUri.Value, managementApiUri.Value, scmUri.Value, developerPortalUri.Value, Optional.ToList(hostnameConfigurations), Optional.ToList(publicIPAddresses), Optional.ToList(privateIPAddresses), publicIPAddressId.Value, Optional.ToNullable(publicNetworkAccess), virtualNetworkConfiguration.Value, Optional.ToList(additionalLocations), Optional.ToDictionary(customProperties), Optional.ToList(certificates), Optional.ToNullable(enableClientCertificate), Optional.ToNullable(disableGateway), Optional.ToNullable(virtualNetworkType), apiVersionConstraint.Value, Optional.ToNullable(restore), Optional.ToList(privateEndpointConnections), Optional.ToNullable(platformVersion), publisherEmail, publisherName);
        }
    }
}
