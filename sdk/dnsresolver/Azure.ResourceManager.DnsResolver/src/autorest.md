# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ccdf0b74eedb671fe038ed1a30a9be9f911ebc4f/specification/dnsresolver/resource-manager/readme.md

library-name: dnsresolver

namespace: Azure.ResourceManager.DnsResolver

clear-output-folder: true

skip-csproj: true

output-folder: Generated/

mgmt-debug:
    show-request-path: true
 
directive:
  - from: swagger-document
    where: $.definitions.InboundEndpointProperties.properties.ipConfigurations
    transform: $['x-ms-client-name'] = 'iPConfigurations'
  - from: swagger-document
    where: $.definitions.IpConfiguration
    transform: $['x-ms-client-name'] = 'IPConfiguration'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAddress
    transform: $['x-ms-client-name'] = 'privateIPAddress'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAllocationMethod
    transform: $['x-ms-client-name'] = 'privateIPAllocationMethod'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAllocationMethod
    transform: >
      $['x-ms-enum'] = {
          "name": "IPAllocationMethod",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.definitions.TargetDnsServer.properties.ipAddress
    transform: $['x-ms-client-name'] = 'iPAddress'
```
