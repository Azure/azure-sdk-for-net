# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataMigration
namespace: Azure.ResourceManager.DataMigration
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/2f28b5026a4b44adefd0237087acb0c48cfe31a6/specification/datamigration/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  SQL: Sql
  Sqldb: SqlDB
  Sqldw: SqlDW
  Sqlmi: SqlMI
  Db: DB|db
  Mi: MI|mi
  OCI: Oci

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDBName}

directive:
  - from: sqlmigration.json
    where: $.definitions
    transform: >
      $.DatabaseMigrationPropertiesSqlMi['x-ms-client-name'] = 'DatabaseMigrationSqlMIProperties';
      $.DatabaseMigrationPropertiesSqlVm['x-ms-client-name'] = 'DatabaseMigrationSqlVmProperties';
      $.DatabaseMigrationPropertiesSqlDb['x-ms-client-name'] = 'DatabaseMigrationSqlDBProperties';
```
