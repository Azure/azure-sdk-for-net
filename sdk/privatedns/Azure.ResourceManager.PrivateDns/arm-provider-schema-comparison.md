# ARM provider schema comparison: Azure.ResourceManager.PrivateDns

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

8 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 10 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 8 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 10 | Matching normalized resource ID patterns are compared in the following sections. |
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

**Differences:** 8 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/A/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/AAAA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/MX/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/PTR/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SOA/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/SRV/{relativeRecordSetName}` | Different. | Different. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT/{relativeRecordSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.RecordSets.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.get` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Read` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT` | Missing. | Present. |
| `Microsoft.Network.RecordSets.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/TXT/{relativeRecordSetName}` | Different. | Different. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Network.PrivateZones.recordSetsList` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/aLL` | Different. | Different. |
| `Microsoft.Network.RecordSets.listByType` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 9 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}` | `PrivateDnsZone` | `PrivateZone` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/a/{}` | `PrivateDnsARecord` | `APrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/aaaa/{}` | `PrivateDnsAaaaRecord` | `AAAAPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/cname/{}` | `PrivateDnsCnameRecord` | `CNAMEPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/mx/{}` | `PrivateDnsMXRecord` | `MXPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/ptr/{}` | `PrivateDnsPtrRecord` | `PTRPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/soa/{}` | `PrivateDnsSoaRecord` | `SOAPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/srv/{}` | `PrivateDnsSrvRecord` | `SRVPrivateDnsZones` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.network/privatednszones/{}/txt/{}` | `PrivateDnsTxtRecord` | `TXTPrivateDnsZones` |

