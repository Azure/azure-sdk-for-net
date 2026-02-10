import "@typespec/versioning";

namespace Azure.Core.Traits;

using Reflection;
using Versioning;

/**
 * Enumerates the standard trait locations for Azure.Core operations.
 */
@doc("Enumerates the standard trait locations for Azure.Core operations.")
enum TraitLocation {
  @doc("Identifies operation parameters as the trait target.")
  Parameters,

  @doc("Identifies operation response as the trait target.")
  Response,

  @doc("Identifies the API version parameter as the trait target.")
  ApiVersionParameter,
}

/**
 * Enumerates the standard trait contexts for Azure.Core operations.
 */
@doc("")
enum TraitContext {
  @doc("Trait is applicable for resource 'read' operations.")
  Read,

  @doc("Trait is applicable for resource 'create' operations.")
  Create,

  @doc("Trait is applicable for resource 'update' operations.")
  Update,

  @doc("Trait is applicable for resource 'delete' operations.")
  Delete,

  @doc("Trait is applicable for resource 'list' operations.")
  List,

  @doc("Trait is applicable for resource actions.")
  Action,

  @doc("Only traits that did not specify a trait context (and therefore always apply) will be exposed.")
  Undefined,
}

/**
 * Used to override a trait.
 * @template Trait The trait to override.
 */
@Private.applyTraitOverride(Trait)
model TraitOverride<Trait extends Model> {}

/**
 * Declares a trait that is applied as a query parameter.
 * @template Parameters The name of the query parameter.
 * @template Contexts The contexts in which the trait is applicable.
 */
@trait
@Private.ensureAllQueryParams(Parameters)
model QueryParametersTrait<Parameters extends Model, Contexts = unknown> {
  @traitContext(Contexts)
  queryParams: {
    @traitLocation(TraitLocation.Parameters)
    parameters: Parameters;
  };
}

/**
 * Declares a trait that is applied as a query parameter for list operations.
 * @template Parameters Object describing the query parameters.
 */
@trait
model ListQueryParametersTrait<Parameters extends Model>
  is QueryParametersTrait<Parameters, TraitContext.List>;

/**
 * Declares a trait that is applied as a request header parameter.
 * @template Headers Object describing the request header parameters.
 * @template Contexts The contexts in which the trait is applicable.
 */
@trait
@Private.ensureAllHeaderParams(Headers)
model RequestHeadersTrait<Headers extends Model, Contexts = unknown> {
  @traitContext(Contexts)
  requestHeaders: {
    @traitLocation(TraitLocation.Parameters)
    parameters: Headers;
  };
}

/**
 * Declares a trait that is applied as a response header parameter.
 * @template Headers Object describing the response header parameters.
 * @template Contexts The contexts in which the trait is applicable.
 */
@trait
@Private.ensureAllHeaderParams(Headers)
model ResponseHeadersTrait<Headers extends Model, Contexts = unknown> {
  @traitContext(Contexts)
  responseHeaders: {
    @traitLocation(TraitLocation.Response)
    parameters: Headers;
  };
}

/**
 * Declares a version parameter trait.
 * @template VersionParameter The type of the version parameter.
 */
@trait("VersionParameter")
model VersionParameterTrait<VersionParameter> {
  versionParameter: {
    @traitLocation(TraitLocation.ApiVersionParameter)
    apiVersionParam: VersionParameter;
  };
}

/**
 * Provides clientRequestId headers for requests and responses.
 * @template VersionAdded The version when the trait was added to the specification.
 *           Leave this empty if the trait is always supported.
 */
@trait("ClientRequestId")
@traitAdded(VersionAdded)
model SupportsClientRequestId<VersionAdded extends EnumMember | null = null> {
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This inline model is never used directly in operations."
  clientRequestId: {
    @traitLocation(TraitLocation.Parameters)
    parameters: ClientRequestIdHeader;

    @traitLocation(TraitLocation.Response)
    response: ClientRequestIdHeader;
  };
}

/**
 * Indicates that the service or operation does not support clientRequestId headers.
 */
@trait("ClientRequestId")
model NoClientRequestId {
  clientRequestId: {};
}

/**
 * Provides conditional request headers for requests and ETag headers for responses.
 * @template VersionAdded The version when the trait was added to the specification.
 *           Leave this empty if the trait is always supported.
 */
@trait("ConditionalRequests")
@traitAdded(VersionAdded)
model SupportsConditionalRequests<VersionAdded extends EnumMember | null = null> {
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This inline model is never used directly in operations."
  conditionalRequests: {
    @traitContext(
      TraitContext.Read | TraitContext.Update | TraitContext.Delete | TraitContext.Create
    )
    @traitLocation(TraitLocation.Parameters)
    parameters: ConditionalRequestHeaders;

    @traitContext(TraitContext.Read | TraitContext.Create | TraitContext.Update)
    @traitLocation(TraitLocation.Response)
    response: EtagResponseEnvelope;
  };
}

/**
 * Indicates that the service or operation does not support conditional requests.
 */
@trait("ConditionalRequests")
model NoConditionalRequests {
  conditionalRequests: {};
}

/**
 * Provides repeatable request headers for requests and responses.
 * @template VersionAdded The version when the trait was added to the specification.
 *           Leave this empty if the trait is always supported.
 */
@trait("RepeatableRequests")
@traitAdded(VersionAdded)
model SupportsRepeatableRequests<VersionAdded extends EnumMember | null = null> {
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This inline model is never used directly in operations."
  @traitContext(
    TraitContext.Create | TraitContext.Update | TraitContext.Delete | TraitContext.Action
  )
  repeatableRequests: {
    @traitLocation(TraitLocation.Parameters)
    parameters: RepeatabilityRequestHeaders;

    @traitLocation(TraitLocation.Response)
    response: RepeatabilityResponseHeaders;
  };
}

/**
 * Indicates that the service or operation does not support repeatable requests.
 */
@trait("RepeatableRequests")
model NoRepeatableRequests {
  repeatableRequests: {};
}

/**
 * `@trait` marks a model type as representing a 'trait' and performs basic validation
 * checks.
 *
 * @param target The model type to mark as a trait.
 * @param traitName An optional name to uniquely identify the trait.  If unspecified,
 *        the model type name is used.
 */
extern dec `trait`(target: Model, traitName?: valueof string);

/**
 * `@traitContext` sets the applicable context for a trait on its envelope property.
 *
 * @param target The trait envelope property where the context will be applied.
 * @param contexts An enum member or union of enum members representing the trait's
 *        applicable contexts.
 */
extern dec traitContext(target: ModelProperty, contexts: EnumMember | Union | unknown);

/**
 * `@traitLocation` sets the applicable location for a trait on its envelope property.
 *
 * @param target The trait envelope property where the context will be applied.
 * @param contexts An enum member or union of enum members representing the trait's
 *        applicable contexts.
 */
extern dec traitLocation(target: ModelProperty, contexts: EnumMember);

/**
 * Sets the version for when the trait was added to the specification.  Can be applied
 * to either a trait model type or its envelope property.
 * @param addedVersion The enum member representing the service version.
 */
extern dec traitAdded(target: Model | ModelProperty, addedVersion: EnumMember | null);

namespace Private {
  @Private.addTraitProperties(Traits, Location, Contexts)
  model TraitProperties<
    Traits extends Model,
    Location extends TypeSpec.Reflection.EnumMember,
    Contexts = unknown
  > {}

  @doc("Contains the details of a specific trait expected by an interface or operation.")
  model ExpectedTrait {
    @doc("The name of the expected trait.")
    trait: string;

    @doc("The diagnostic to be raised when the trait is not present.")
    diagnostic: string;
  }

  /**
   * `@traitSource` stores the `traitName` of its original trait on the envelope property.
   *
   * @param target The trait envelope property where `traitName` will be stored.
   * @param traitName The name of the original trait to which this property belongs.
   */
  extern dec traitSource(target: ModelProperty, traitName: valueof string);

  /**
   * Copies trait properties from `traitModel` into `target` which conform to the
   * specified location and contexts.
   * @param traitModel The trait model type to be applied.
   * @param traitLocation The trait location to use for selecting trait properties.
   * @param traitContexts The trait contexts to use for selecting trait properties.
   */
  extern dec addTraitProperties(
    target: Model,
    traitModel: Model,
    traitLocation: EnumMember,
    traitContexts: EnumMember | Union | unknown
  );

  /**
   * `@applyTraitOverride` copies the `traitModel` into `target` and renames its envelope
   * property to enable the trait to override another trait sharing the same name.
   *
   * @param target The model into which the trait will be copied.
   * @param traitModel The trait model type to be overridden.
   */
  extern dec applyTraitOverride(target: Model, traitModel: Model);

  /**
   * `@ensureTraitsPresent` checks the envelope properties of `traitModel` to ensure all
   * of the `expectedTraits` are present as envelope properties.
   *
   * @param target The interface or operation where the `traitModel` should be checked.
   * @param traitModel The trait model type to check.
   * @param expectedTraits The array of `ExpectedTrait` models which describe each expected trait.
   */
  extern dec ensureTraitsPresent(
    target: Interface | TypeSpec.Reflection.Operation,
    traitModel: Model,
    expectedTraits: ExpectedTrait[]
  );

  /**
   * `@ensureAllQueryParams` checks the properties of `paramModel` to ensure they all are marked
   * with the `@query` decorator.
   *
   * @param target The model type where this check will be established.
   * @param paramModel The actual model type to check for query parameters.
   */
  extern dec ensureAllQueryParams(target: Model, paramModel: Model);

  /**
   * `@ensureAllHeaderParams` checks the properties of `paramModel` to ensure they all are marked
   * with the `@header` decorator.
   *
   * @param target The model type where this check will be established.
   * @param paramModel The actual model type to check for header properties.
   */
  extern dec ensureAllHeaderParams(target: Model, paramModel: Model);
}
