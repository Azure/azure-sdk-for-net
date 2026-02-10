import "@typespec/rest";
import "@typespec/http";

namespace Azure.ResourceManager.Legacy;

using Azure.ResourceManager.Private;

/**
 * This type uses an optional location property, only used by legacy APIs.
 * Concrete tracked resource types can be created by aliasing this type using a specific property type.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template Properties A model containing the provider-specific properties for this resource
 * @template PropertiesOptional A boolean flag indicating whether the resource `Properties` field is marked as optional or required. Default true is optional and recommended.
 *
 * @example
 * ```typespec
 * model Employee is TrackedResourceWithOptionalLocation<EmployeeProperties> {
 *  ...ResourceNameParameter<Employee>
 * }
 * ```
 */
@doc("Concrete tracked resource types can be created by aliasing this type using a specific property type.")
@armResourceInternal(Properties)
@Http.Private.includeInapplicableMetadataInPayload(false)
model TrackedResourceWithOptionalLocation<
  Properties extends {},
  PropertiesOptional extends valueof boolean = true
> extends CommonTypes.Resource {
  @doc("The RP-specific properties for this resource.")
  @armResourcePropertiesOptionality(PropertiesOptional)
  properties?: Properties;

  /** Resource tags. */
  tags?: Record<string>;

  /** The geo-location where the resource lives */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  location?: string;
}

/**
 * Model used only to spread in the standard `etag` envelope property for a resource
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...ETagProperty;
 * }
 * ```
 */
alias EntityTagProperty = {
  /** "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields.") */
  @visibility(Lifecycle.Read)
  etag?: string;
};

/**
 * Legacy. Model representing a non-standard `extendedLocation` envelope property with all properties optional.
 * Spread this model into a Resource Model, if you are converting a BrownField API with extended location that has optional properties
 *
 * @example
 * ```typespec
 * model Employee is TrackedResource<EmployeeProperties> {
 * ...ResourceNameParameter<Employee>;
 * ...ExtendedLocationOptionalProperty;
 * }
 * ```
 */
model ExtendedLocationOptionalProperty {
  @visibility(Lifecycle.Read, Lifecycle.Create)
  extendedLocation?: ExtendedLocationOptional;
}

/** The complex type of the extended location. */
@friendlyName("ExtendedLocation")
model ExtendedLocationOptional {
  /** The name of the extended location. */
  name?: string;

  /** The type of the extended location. */
  type?: Azure.ResourceManager.Foundations.ExtendedLocationType;
}

/**
 * Template that allows a model to include a path parameter property without adding the property to a request body
 */
@Http.Private.includeInapplicableMetadataInPayload(false)
model ResourceWithPathParameter {}

/**
 * Model representing the  `kind` envelope property only for use with a polymorphic resource..
 * Spread this model into a resource model if the resource support ARM `kind`.
 * @template Type The type of the kind property. Default is string. However you can pass a union with string values.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...PolymorphicResourceKindProperty;
 * }
 * ```
 */
@doc("The resource kind property envelope.")
model PolymorphicResourceKindProperty<Type extends string = string> {
  @doc("Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value.")
  @pattern("^[-\\w\\._,\\(\\\\\\)]+$")
  @visibility(Lifecycle.Read, Lifecycle.Create)
  kind: Type;
}

/**
 * Discriminated tracked resource types can be created by instantiating this type, with 'kind' as the discriminator property.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template KindType The type of the discriminator property `kind`. Default is string.
 * @template Description A description of the resource
 *
 * @example
 * ```typespec
 * model Pet is DiscriminatedTrackedResource {}
 *
 * model Dog extends Pet {
 *  kind: "dog";
 *  properties: DogProperties;
 * }
 * ```
 */
@doc(Description)
@armResourceInternal({})
@discriminator("kind")
@Http.Private.includeInapplicableMetadataInPayload(false)
model DiscriminatedTrackedResource<
  KindType extends string = string,
  Description extends valueof string = "Polymorphic Tracked resource types can be created by instantiating this type, with 'kind' as the discriminator."
> extends Foundations.TrackedResource {
  ...PolymorphicResourceKindProperty<KindType>;
}

/**
 * Discriminated proxy resource types can be created by instantiating using this type, with 'kind' as the discriminator property.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template KindType The type of the discriminator property `kind`. Default is string.
 * @template Description A description of the resource
 *
 * @example
 * ```typespec
 * model Pet is DiscriminatedProxyResource {}
 *
 * model Dog extends Pet {
 *  kind: "dog";
 *  properties: DogProperties;
 * }
 * ```
 */
@doc(Description)
@armResourceInternal({})
@discriminator("kind")
@Http.Private.includeInapplicableMetadataInPayload(false)
model DiscriminatedProxyResource<
  KindType extends string = string,
  Description extends valueof string = "Polymorphic proxy resource types can be created by instantiating this type, using 'kind' as the discriminator property."
> extends Foundations.ProxyResource {
  ...PolymorphicResourceKindProperty<KindType>;
}

/**
 * Polymorphic extension resources can be instantiated using this type, using 'kind' as the discriminator property.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template KindType The type of the discriminator property `kind`. Default is string.
 * @template Description A description of the resource
 *
 * @example
 * ```typespec
 * model Pet is DiscriminatedExtensionResource {}
 *
 * model Dog extends Pet {
 *  kind: "dog";
 *  properties: DogProperties;
 * }
 * ```
 */
@extensionResource
@doc(Description)
@armResourceInternal({})
@discriminator("kind")
@Http.Private.includeInapplicableMetadataInPayload(false)
model DiscriminatedExtensionResource<
  KindType extends string = string,
  Description extends valueof string = "Polymorphic extension resource types can be created by aliasing this type using a specific property type."
> extends Foundations.ExtensionResource {
  ...PolymorphicResourceKindProperty<KindType>;
}

/**
 * Model representing a custom Azure Resource Manager Resource.
 * Use this template with 'is' to create a custom resource.
 * @template isResource Optional. A boolean flag indicating whether the resource should be marked as an Azure resource. Default true.
 */
@Http.Private.includeInapplicableMetadataInPayload(false)
@customAzureResource(#{ isAzureResource: isResource })
model CustomAzureResource<isResource extends valueof boolean = true> {}
