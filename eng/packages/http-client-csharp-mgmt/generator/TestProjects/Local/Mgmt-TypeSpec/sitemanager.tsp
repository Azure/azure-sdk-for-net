import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

/**
 * Test resource for verifying extension resources with extra path parameters.
 * This mimics the SiteManager ServiceGroup/Site pattern where the parent scope has
 * additional path segments that need to be extracted (e.g., servicegroupName).
 * 
 * Path pattern: /providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/MgmtTypeSpec/sites/{siteName}
 */
@doc("Site at ServiceGroup scope")
model ServiceGroupSite is ProxyResource<ServiceGroupSiteProperties> {
  ...ResourceNameParameter<
    Resource = ServiceGroupSite,
    KeyName = "siteName",
    SegmentName = "sites",
    NamePattern = "^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$"
  >;
}

@doc("Site properties")
model ServiceGroupSiteProperties {
  @doc("displayName of Site resource")
  displayName?: string;

  @doc("Description of Site resource")  
  description?: string;

  @doc("Provisioning state of last operation")
  @visibility(Lifecycle.Read)
  provisioningState?: Azure.ResourceManager.ResourceProvisioningState;
}

/**
 * Define the extension operations with a custom parent path that includes
 * servicegroupName - this simulates the /providers/Microsoft.Management/serviceGroups/{servicegroupName}
 * pattern used by SiteManager ServiceGroup resources.
 */
alias ServiceGroupSiteOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;

    /** the provider namespace */
    @path
    @segment("providers")
    @key
    providerNamespace: "Microsoft.Management";

    /**
     * The name of the service group
     */
    @segment("serviceGroups")
    @pattern("^[a-zA-Z0-9\\-_().]{1,90}$")
    @key
    @path
    servicegroupName: string;
  },
  Extension.ExtensionProviderNamespace<ServiceGroupSite>,
  {
    ...Extension.ExtensionProviderNamespace<ServiceGroupSite>;
    ...KeysOf<ServiceGroupSite>;
  }
>;

@armResourceOperations(#{ omitTags: true })
interface ServiceGroupSites {
  @doc("list Site at ServiceGroup scope")
  @list
  listByServiceGroup is ServiceGroupSiteOps.List<ServiceGroupSite>;

  @doc("Get Site at ServiceGroup scope")
  get is ServiceGroupSiteOps.Read<ServiceGroupSite>;

  @doc("create or update Site at ServiceGroup scope")
  createOrUpdate is ServiceGroupSiteOps.CreateOrUpdateAsync<ServiceGroupSite>;
}
