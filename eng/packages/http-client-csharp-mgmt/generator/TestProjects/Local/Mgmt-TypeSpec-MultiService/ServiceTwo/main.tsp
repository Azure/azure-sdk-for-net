import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "ServiceTwo",
})
@versioned(ServiceTwo.Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace ServiceTwo;

enum Versions {
  v2024_06_01: "2024-06-01",
}

model Bar is TrackedResource<BarProperties> {
  ...ResourceNameParameter<Bar>;
}

model BarProperties {
  description?: string;
  provisioningState?: ResourceProvisioningState;
}

@armResourceOperations
interface Bars {
  get is ArmResourceRead<Bar>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Bar>;
  delete is ArmResourceDeleteWithoutOkAsync<Bar>;
  list is ArmResourceListByParent<Bar>;
}
