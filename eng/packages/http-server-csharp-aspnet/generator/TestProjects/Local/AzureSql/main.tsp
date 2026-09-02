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

// ---------------------------------------------------------------------------
// Service definition with API versioning
// ---------------------------------------------------------------------------

@armProviderNamespace
@service(#{ title: "Azure SQL Database Resource Provider" })
@versioned(Versions)
namespace Microsoft.Sql;

/** Supported API versions. */
enum Versions {
  /** Initial stable version (2025-11-01). Create, Get, Delete only. */
  @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
  v2025_11_01: "2025-11-01",

  /** Second stable version (2025-12-01). Adds List and Update operations. */
  @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
  v2025_12_01: "2025-12-01",

  /** Latest stable version (2026-02-01). Adds ElasticPoolId property. */
  @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
  v2026_02_01: "2026-02-01",
}

// ---------------------------------------------------------------------------
// Database resource
// ---------------------------------------------------------------------------

/** Database resource properties. */
model DatabaseProperties {
  /** The collation of the database. */
  collation?: string;

  /** The max size of the database in bytes. */
  maxSizeBytes?: int64;

  /** The status of the database. */
  @visibility(Lifecycle.Read)
  status?: string;

  /** The creation date of the database. */
  @visibility(Lifecycle.Read)
  creationDate?: utcDateTime;

  /** The provisioning state. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /** The resource ID of the elastic pool containing this database. */
  @added(Versions.v2026_02_01)
  elasticPoolId?: string;
}

/** A SQL Database resource. */
model Database is TrackedResource<DatabaseProperties> {
  /** The name of the database. */
  @key("databaseName")
  @segment("databases")
  @path
  name: string;
}

// ---------------------------------------------------------------------------
// Provisioning state
// ---------------------------------------------------------------------------

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  ResourceProvisioningState,

  /** The resource is being provisioned. */
  Provisioning: "Provisioning",

  /** The resource is being updated. */
  Updating: "Updating",

  /** The resource is being deleted. */
  Deleting: "Deleting",

  /** Provisioning was accepted. */
  Accepted: "Accepted",

  string,
}

// ---------------------------------------------------------------------------
// Operations
// ---------------------------------------------------------------------------

/** Database resource operations. */
@armResourceOperations
interface Databases {
  /** Gets a database. */
  get is ArmResourceRead<Database>;

  /** Creates or updates a database (long-running operation). */
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Database>;

  /** Deletes a database (long-running operation). */
  delete is ArmResourceDeleteWithoutOkAsync<Database>;

  /** Updates a database. Added in 2025-12-01. */
  @added(Versions.v2025_12_01)
  update is ArmCustomPatchSync<
    Database,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<
      Database,
      DatabaseProperties
    >
  >;

  /** Lists databases under a server. Added in 2025-12-01. */
  @added(Versions.v2025_12_01)
  listByResourceGroup is ArmResourceListByParent<Database>;
}

/** ARM operations endpoint. */
interface Operations extends Azure.ResourceManager.Operations {}
