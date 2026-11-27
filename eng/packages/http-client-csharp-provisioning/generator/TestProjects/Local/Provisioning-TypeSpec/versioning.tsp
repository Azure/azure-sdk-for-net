import "@azure-tools/typespec-azure-core";
import "@typespec/rest";

using TypeSpec.Versioning;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace ProvisioningTypeSpec;

/** A resource used to test versioned properties. */
@resource("versionedResources")
model VersionedResource is TrackedResource<VersionedResourceProperties> {
  ...ResourceNameParameter<
    VersionedResource,
    SegmentName = "versionedResources"
  >;
}

/** Properties with different API-version lifetimes. */
model VersionedResourceProperties {
  /** A property available in every API version. */
  initialStableProperty?: string;

  /** A property available only in the preview API version. */
  @added(Versions.v2024_03_01_preview)
  @removed(Versions.v2024_05_01)
  previewOnlyProperty?: string;

  /** A property introduced in preview and retained in the following stable API version. */
  @added(Versions.v2024_03_01_preview)
  previewRetainedProperty?: string;

  /** A property introduced in the latest stable API version. */
  @added(Versions.v2024_05_01)
  latestStableProperty?: string;
}

@armResourceOperations
interface VersionedResources {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<VersionedResource>;
  get is ArmResourceRead<VersionedResource>;
  update is ArmResourcePatchAsync<
    VersionedResource,
    VersionedResourceProperties
  >;
  delete is ArmResourceDeleteWithoutOkAsync<VersionedResource>;
}

/** A resource available only in the preview API version. */
@added(Versions.v2024_03_01_preview)
@removed(Versions.v2024_05_01)
@resource("previewOnlyResources")
model PreviewOnlyResource is TrackedResource<PreviewOnlyResourceProperties> {
  ...ResourceNameParameter<
    PreviewOnlyResource,
    SegmentName = "previewOnlyResources"
  >;
}

/** Properties of a preview-only resource. */
@added(Versions.v2024_03_01_preview)
@removed(Versions.v2024_05_01)
model PreviewOnlyResourceProperties {
  /** A preview-only value. */
  value?: string;
}

@added(Versions.v2024_03_01_preview)
@removed(Versions.v2024_05_01)
@armResourceOperations
interface PreviewOnlyResources {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<PreviewOnlyResource>;
  get is ArmResourceRead<PreviewOnlyResource>;
  update is ArmResourcePatchAsync<
    PreviewOnlyResource,
    PreviewOnlyResourceProperties
  >;
  delete is ArmResourceDeleteWithoutOkAsync<PreviewOnlyResource>;
}

/** A resource introduced in preview and retained in the following stable API version. */
@added(Versions.v2024_03_01_preview)
@resource("previewRetainedResources")
model PreviewRetainedResource is TrackedResource<PreviewRetainedResourceProperties> {
  ...ResourceNameParameter<
    PreviewRetainedResource,
    SegmentName = "previewRetainedResources"
  >;
}

/** Properties of a resource introduced in preview and retained in stable. */
@added(Versions.v2024_03_01_preview)
model PreviewRetainedResourceProperties {
  /** A retained value. */
  value?: string;
}

@added(Versions.v2024_03_01_preview)
@armResourceOperations
interface PreviewRetainedResources {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<PreviewRetainedResource>;
  get is ArmResourceRead<PreviewRetainedResource>;
  update is ArmResourcePatchAsync<
    PreviewRetainedResource,
    PreviewRetainedResourceProperties
  >;
  delete is ArmResourceDeleteWithoutOkAsync<PreviewRetainedResource>;
}

/** A resource introduced in the latest stable API version. */
@added(Versions.v2024_05_01)
@resource("latestStableResources")
model LatestStableResource is TrackedResource<LatestStableResourceProperties> {
  ...ResourceNameParameter<
    LatestStableResource,
    SegmentName = "latestStableResources"
  >;
}

/** Properties of a resource introduced in the latest stable API version. */
@added(Versions.v2024_05_01)
model LatestStableResourceProperties {
  /** A stable value. */
  value?: string;
}

@added(Versions.v2024_05_01)
@armResourceOperations
interface LatestStableResources {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<LatestStableResource>;
  get is ArmResourceRead<LatestStableResource>;
  update is ArmResourcePatchAsync<
    LatestStableResource,
    LatestStableResourceProperties
  >;
  delete is ArmResourceDeleteWithoutOkAsync<LatestStableResource>;
}
