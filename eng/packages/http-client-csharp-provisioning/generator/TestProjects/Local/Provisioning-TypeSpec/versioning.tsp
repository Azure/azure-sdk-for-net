import "@azure-tools/typespec-azure-core";
import "@typespec/rest";

using TypeSpec.Versioning;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core.Legacy;

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

  /** An enum property available in every API version. */
  initialStableEnum?: InitialStableEnum;

  /** An enum property available only in the preview API version. */
  @added(Versions.v2024_03_01_preview)
  @removed(Versions.v2024_05_01)
  previewOnlyEnum?: PreviewOnlyEnum;

  /** An enum property introduced in preview and retained in the following stable API version. */
  @added(Versions.v2024_03_01_preview)
  previewRetainedEnum?: PreviewRetainedEnum;

  /** An enum property introduced in the latest stable API version. */
  @added(Versions.v2024_05_01)
  latestStableEnum?: LatestStableEnum;

  /** A preview-introduced model flattened onto a stable resource. */
  @added(Versions.v2024_03_01_preview)
  @flattenProperty
  previewWrapper?: PreviewFlattenedWrapper;

  /** A shared stable leaf reached through a preview-only property. */
  @added(Versions.v2024_03_01_preview)
  @flattenProperty
  previewSharedWrapper?: SharedFlattenedLeaf;

  /** A preview-only path using automatic single-property flattening. */
  @added(Versions.v2024_03_01_preview)
  previewSafeWrapper?: SharedFlattenedLeaf;

  /** A nested preview-introduced model flattened onto a stable resource. */
  @added(Versions.v2024_03_01_preview)
  @flattenProperty
  nestedWrapper?: NestedFlattenedWrapper;

  /** A stable use of the same leaf, which must remain unmarked. */
  stableSharedWrapper?: SharedFlattenedLeaf;
}

/** A wrapper introduced in preview, whose scalar has no independent version history. */
@added(Versions.v2024_03_01_preview)
model PreviewFlattenedWrapper {
  /** A scalar exposed by flattening a preview model. */
  flattenedPreviewValue?: string;
}

/** A stable leaf shared by preview and stable paths. */
model SharedFlattenedLeaf {
  /** A stable scalar exposed by a preview wrapper. */
  sharedValue?: string;
}

/** An outer wrapper for nested flattening. */
model NestedFlattenedWrapper {
  /** An inner preview-only model. */
  @added(Versions.v2024_03_01_preview)
  @flattenProperty
  inner?: NestedPreviewFlattenedWrapper;
}

/** An inner model introduced in preview. */
@added(Versions.v2024_03_01_preview)
model NestedPreviewFlattenedWrapper {
  /** A scalar exposed through two flattened wrappers. */
  nestedPreviewValue?: string;
}

@@flattenProperty(VersionedResource.properties);

/** An enum available in every API version. */
enum InitialStableEnum {
  Enabled,
  Disabled,
}

/** An enum available only in the preview API version. */
@added(Versions.v2024_03_01_preview)
@removed(Versions.v2024_05_01)
enum PreviewOnlyEnum {
  Enabled,
  Disabled,
}

/** An enum introduced in preview and retained in the following stable API version. */
@added(Versions.v2024_03_01_preview)
enum PreviewRetainedEnum {
  Enabled,
  Disabled,
}

/** An enum introduced in the latest stable API version. */
@added(Versions.v2024_05_01)
enum LatestStableEnum {
  Enabled,
  Disabled,
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
