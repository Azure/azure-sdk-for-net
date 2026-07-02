# ARM provider schema comparison: Azure.ResourceManager.Dns

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

13 CRUD operation differences; 14 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 15 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 13 differences. |
| List/action operations for matching patterns | 14 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 15 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 13 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |

### 4.2 List and action operations

**Differences:** 14 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}` | Present. | Missing. |
| `Microsoft.Network.Zones.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones` | Missing. | Present. |
| `Microsoft.Network.Zones.listAllByDnsZone` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/all` | Missing. | Present. |
| `Microsoft.Network.Zones.listByDnsZone` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/A` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CAA` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/DS` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/MX` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NAPTR` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/PTR` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SRV` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TLSA` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.listByType` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/TXT` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 14 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}` | `DnsZone` | `Zone` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/a/{}` | `DnsARecord` | `ARecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/aaaa/{}` | `DnsAaaaRecord` | `AAAARecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/caa/{}` | `DnsCaaRecord` | `CAARecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/cname/{}` | `DnsCnameRecord` | `CNAMERecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/ds/{}` | `DnsDSRecord` | `DRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/mx/{}` | `DnsMXRecord` | `MXRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/naptr/{}` | `DnsNaptrRecord` | `NAPTRRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/ns/{}` | `DnsNSRecord` | `NRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/ptr/{}` | `DnsPtrRecord` | `PTRRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/soa/{}` | `DnsSoaRecord` | `SOARecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/srv/{}` | `DnsSrvRecord` | `SRVRecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/tlsa/{}` | `DnsTlsaRecord` | `TLSARecordSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/dnszones/{}/txt/{}` | `DnsTxtRecord` | `TXTRecordSet` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Network.Zones.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones` | Present. | Missing. |

