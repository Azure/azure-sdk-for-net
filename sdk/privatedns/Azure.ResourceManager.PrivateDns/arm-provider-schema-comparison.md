# ARM provider schema comparison: Azure.ResourceManager.PrivateDns

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

8 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 2 matching normalized patterns; 8 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 8 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/A/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/AAAA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/CNAME/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/MX/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/PTR/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/SOA/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/SRV/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/TXT/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}`
  - resolveArmResources-only: `Microsoft.Network.RecordSets.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Network.RecordSets.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}/{}/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateDnsZones/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
