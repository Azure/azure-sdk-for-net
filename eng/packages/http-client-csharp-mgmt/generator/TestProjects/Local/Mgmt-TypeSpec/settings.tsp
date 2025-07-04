import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@doc("The settings tenant resource definition.")
@singleton
@tenantResource
model SettingsResource is ProxyResource<SettingsProperties> {
  @doc("The default settings, applying to entire tenant.")
  @segment("settings")
  @key
  @visibility(Lifecycle.Read)
  @path
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  name: string;
}

@armResourceOperations
interface Settings {
  get is ArmResourceRead<SettingsResource>;
  createOrUpdate is ArmResourceCreateOrReplaceSync<SettingsResource>;
  update is ArmCustomPatchSync<
    SettingsResource,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<
      SettingsResource,
      SettingsProperties
    >
  >;
  delete is ArmResourceDeleteSync<SettingsResource>;
}

@doc("The Settings properties.")
model SettingsProperties {
  @doc("Boolean indicating if role-based access control is enabled for settings in this tenant.")
  accessControlEnabled: boolean;

  @doc("The status of the last provisioning operation performed on the resource.")
  @visibility(Lifecycle.Read)
  provisioningState?: ResourceProvisioningState;
}
