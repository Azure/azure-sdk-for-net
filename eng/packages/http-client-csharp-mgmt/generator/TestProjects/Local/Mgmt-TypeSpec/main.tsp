import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "./PrivateEndpointConnection.tsp";
import "./foo.tsp";
import "./bar.tsp";
import "./baz.tsp";
import "./zoo.tsp";
import "./routes.tsp";
import "./endpoint.tsp";
import "./selfhelp.tsp";
import "./playwright.tsp";
import "./databox.tsp";
import "./hcivm.tsp";
import "./quota.tsp";
import "./networkaction.tsp";
import "./joo.tsp";
import "./workload.tsp";
import "./multiplepaths.tsp";
import "./testresourcetype.tsp";
import "./resourcedata.tsp";
import "./scheduledaction.tsp";
import "./vmgroup.tsp";
import "./chaos.tsp";
using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "MgmtTestClient",
})
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtTypeSpec {

  interface Operations extends Azure.ResourceManager.Operations {}

  /** The available API versions. */
  enum Versions {
    v2024_05_01: "2024-05-01",
  }

  @@clientLocation(Bars.get, "Bar");
  @@clientLocation(Bars.update, "Bar");

  @@clientLocation(WorkloadNetworkVmGroups.get, "WorkloadNetworks");
  @@clientLocation(WorkloadNetworkVmGroups.delete, "WorkloadNetworks");
  @@clientLocation(WorkloadNetworkSegments.get, "WorkloadNetworks");
  @@clientLocation(WorkloadNetworkSegments.delete, "WorkloadNetworks");

  @@clientName(WorkloadNetworkVmGroups.get, "GetVmGroup");
  @@clientName(WorkloadNetworkVmGroups.update, "UpdateVmGroup");
  @@clientName(WorkloadNetworkVmGroups.delete, "DeleteVmGroup");
  @@clientName(WorkloadNetworkSegments.get, "GetSegment");
  @@clientName(WorkloadNetworkSegments.update, "UpdateSegment");
  @@clientName(WorkloadNetworkSegments.delete, "DeleteSegment");

  #suppress "deprecated"
  @@Azure.ClientGenerator.Core.Legacy.flattenProperty(BarSettingsResource.flattenedNestedProperty);
  @@Azure.ClientGenerator.Core.Legacy.flattenProperty(Foo.properties);

  @@alternateType(FooProperties.something, Azure.ResourceManager.Foundations.ManagedServiceIdentity, "csharp");
  @@clientName(Employees.listByParent, "GetEmployees", "csharp");
  @@alternateType(ZooAddressListListResult.value, Azure.ResourceManager.Models.SubResource[], "csharp");
  @@alternateType(Azure.ResourceManager.CommonTypes.PrivateEndpointConnectionProperties.privateEndpoint, Azure.ResourceManager.Models.SubResource, "csharp");
  @@alternateType(FooProperties.writableSubResourceProp, Azure.ResourceManager.Models.WritableSubResource, "csharp");
}

// We define this model here to test if the generated code would be replaced by Azure.ResourceManager.Models.SubResource and WritableSubResource via alternateType
namespace Azure.ResourceManager.Models {
  model SubResource { }
  model WritableSubResource { }
}