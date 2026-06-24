# Azure.Provisioning.Cdn Bicep schema validation

Validation date: 2026-06-24

This report compares the TypeSpec-generated `Azure.Provisioning.Cdn` resource
surface against the official Microsoft Learn Bicep reference for
`Microsoft.Cdn` API version `2025-06-01`.

## Methodology

- Parsed generated resource classes under `src/Generated/*.cs`.
- Checked each generated ARM resource type and version from the resource
  constructor.
- Compared root deployable properties (`name`, `parent`, `location`, `tags`,
  `sku`, `identity`, `etag`, and `properties`) against the official Bicep
  reference pages.
- Spot-checked nested writable `properties` models against the Bicep resource
  format snippets and property tables.
- Ignored generated output-only properties such as `Id`, `SystemData`,
  `ProvisioningState`, `DeploymentStatus`, and service-computed host/profile
  names.

## Summary

No blocking schema mismatches were found for the 15 generated deployable
resources. All generated resources target `2025-06-01`, expose writable `Name`,
and have the expected parent relationship for child resources.

## Resource validation

| Generated type | ARM resource type | Bicep reference | Result | Notes |
|---|---|---|---|---|
| `CdnProfile` | `Microsoft.Cdn/profiles` | [profiles](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles?pivots=deployment-language-bicep) | Pass | Root fields match: `identity`, `location`, `name`, `properties`, `sku`, `tags`. `GetResourceNameRequirements()` is present. |
| `CdnEndpoint` | `Microsoft.Cdn/profiles/endpoints` | [profiles/endpoints](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/endpoints?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `location`, `name`, `properties`, `tags`. Nested endpoint properties match the Bicep format, including origins, origin groups, compression, delivery policy, geo filters, WAF link, and URL signing keys. |
| `CdnOrigin` | `Microsoft.Cdn/profiles/endpoints/origins` | [profiles/endpoints/origins](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/endpoints/origins?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested origin properties match documented writable fields. |
| `CdnOriginGroup` | `Microsoft.Cdn/profiles/endpoints/originGroups` | [profiles/endpoints/originGroups](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/endpoints/origingroups?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested health probe, origins, response-based error detection, and traffic restoration settings match the Bicep reference. |
| `CdnCustomDomain` | `Microsoft.Cdn/profiles/endpoints/customDomains` | [profiles/endpoints/customDomains](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/endpoints/customdomains?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Writable `HostName` maps to `properties.hostName`. |
| `CdnWebApplicationFirewallPolicy` | `Microsoft.Cdn/cdnWebApplicationFirewallPolicies` | [cdnWebApplicationFirewallPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/cdnwebapplicationfirewallpolicies?pivots=deployment-language-bicep) | Pass | Root fields match: `etag`, `location`, `name`, `properties`, `sku`, `tags`. `GetResourceNameRequirements()` is present. |
| `FrontDoorCustomDomain` | `Microsoft.Cdn/profiles/customDomains` | [profiles/customDomains](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/customdomains?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. TLS settings, DNS zone, host name, prevalidated domain reference, and extended properties match the Bicep reference. |
| `FrontDoorEndpoint` | `Microsoft.Cdn/profiles/afdEndpoints` | [profiles/afdEndpoints](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/afdendpoints?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `location`, `name`, `properties`, `tags`. `GetResourceNameRequirements()` is present. |
| `FrontDoorOriginGroup` | `Microsoft.Cdn/profiles/originGroups` | [profiles/originGroups](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/origingroups?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested authentication, health probe, load balancing, session affinity, and traffic restoration settings match the Bicep reference. |
| `FrontDoorOrigin` | `Microsoft.Cdn/profiles/originGroups/origins` | [profiles/originGroups/origins](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/origingroups/origins?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested origin, certificate check, ports, priority, private link, and weight settings match the Bicep reference. |
| `FrontDoorRoute` | `Microsoft.Cdn/profiles/afdEndpoints/routes` | [profiles/afdEndpoints/routes](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/afdendpoints/routes?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested route cache configuration, custom domains, origin group, patterns, rule sets, protocols, forwarding, redirect, and default domain settings match the Bicep reference. |
| `FrontDoorRuleSet` | `Microsoft.Cdn/profiles/ruleSets` | [profiles/ruleSets](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/rulesets?pivots=deployment-language-bicep) | Pass | Bicep reference only exposes `parent` and `name` as deployable root fields. Generated additional properties are output-only and not writable. |
| `FrontDoorRule` | `Microsoft.Cdn/profiles/ruleSets/rules` | [profiles/ruleSets/rules](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/rulesets/rules?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Nested actions, conditions, match processing behavior, and order match the Bicep reference. Discriminator fields (`name`, `typeName`) are emitted as defaults by concrete action/condition models. |
| `FrontDoorSecret` | `Microsoft.Cdn/profiles/secrets` | [profiles/secrets](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/secrets?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Concrete secret property types emit required `type` discriminator values for managed certificate, customer certificate, first-party managed certificate, and URL signing key scenarios. |
| `FrontDoorSecurityPolicy` | `Microsoft.Cdn/profiles/securityPolicies` | [profiles/securityPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.cdn/2025-06-01/profiles/securitypolicies?pivots=deployment-language-bicep) | Pass | Root fields match: `parent`, `name`, `properties`. Concrete WAF policy parameters emit `type: WebApplicationFirewall` and include associations plus WAF policy reference. |

## Additional observations

- Exact enum member names are now preserved by the provisioning generator for
  CDN TLS/cipher-suite enums, while wire values remain correct through
  `DataMember` attributes.
- The generated concrete polymorphic models emit discriminator defaults required
  by Bicep reference schemas, such as rule action `name`, rule action parameter
  `typeName`, secret parameter `type`, and security policy parameter `type`.
- The latest regenerated surface intentionally no longer exposes several helper
  construct types that are not deployable Bicep resources.

## Conclusion

The generated `Azure.Provisioning.Cdn` resource schema aligns with the official
Microsoft.Cdn `2025-06-01` Bicep reference for all generated deployable
resources. No schema-blocking issue was found.
