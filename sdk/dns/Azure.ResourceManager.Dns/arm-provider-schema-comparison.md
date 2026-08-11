# ARM provider schema comparison: Azure.ResourceManager.Dns

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

13 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 2 matching normalized patterns; 13 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 13 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 1 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/A/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/AAAA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/CAA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/CNAME/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/DS/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/MX/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/NAPTR/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/NS/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/PTR/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/SOA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/SRV/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/TLSA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/TXT/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}`
  - resolveArmResources-only: `Microsoft.Network.RecordSets.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.Zones.list (List) /subscriptions/{}/providers/Microsoft.Network/dnszones [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`; `Microsoft.Network.Zones.listAllByDnsZone (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}/all [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dnsZones/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

- `Microsoft.Network.Zones.list (/subscriptions/{}/providers/Microsoft.Network/dnszones) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`


### resolveArmResources-only non-resource methods

None.
