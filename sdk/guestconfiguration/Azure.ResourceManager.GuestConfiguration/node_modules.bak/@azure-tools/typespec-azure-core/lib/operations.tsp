import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "./models.tsp";
import "./traits.tsp";

namespace Azure.Core;

using Http;
using Rest;
using Versioning;
using Azure.Core.Traits;
using Azure.Core.Traits.Private;

// RPC Operations

/**
 * A remote procedure call (RPC) operation.
 * @template Parameters Object describing the parameters of the operation.
 * @template Response Object describing the response of the operation.
 * @template Traits Object describing the traits of the operation.
 * @template ErrorResponse Error response of the operation. If not specified, the default error response is used.
 * @template TraitContexts Trait contexts applicable to the operation. Defaults to `TraitContext.Undefined` which means that only traits that always apply will appear. Can specify multiple using the | operator.
 */
@Foundations.Private.needsRoute
op RpcOperation<
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse,
  TraitContexts extends TraitContext = TraitContext.Undefined
> is Foundations.Operation<
  Parameters & TraitProperties<Traits, TraitLocation.Parameters>,
  Response & TraitProperties<Traits, TraitLocation.Response, TraitContexts>,
  Traits,
  ErrorResponse
>;

/**
 * A long-running remote procedure call (RPC) operation.
 * @template Parameters Object describing the parameters of the operation.
 * @template Response Object describing the response of the operation.
 * @template StatusResult Object describing the status result of the operation.
 * @template StatusError Error response of the status operation. If not specified, the default error response is used.
 * @template Traits Object describing the traits of the operation.
 * @template ErrorResponse Error response of the operation. If not specified, the default error response is used.
 * @template TraitContexts Trait contexts applicable to the operation. Defaults to `TraitContext.Undefined` which means that only traits that always apply will appear. Can specify multiple using the | operator.
 */
@Foundations.Private.needsRoute
@post
op LongRunningRpcOperation<
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  StatusResult extends TypeSpec.Reflection.Model,
  StatusError = Foundations.Error,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse,
  TraitContexts extends TraitContext = TraitContext.Undefined
> is Foundations.Operation<
  Parameters & TraitProperties<Traits, TraitLocation.Parameters>,
  AcceptedResponse &
    ResourceOperationStatus<Response, StatusResult, StatusError> &
    Foundations.LongRunningStatusLocation<StatusResult> &
    TraitProperties<Traits, TraitLocation.Response, TraitContexts>,
  Traits,
  ErrorResponse
>;

// Standard Resource Lifecycle Operations

alias ExpectedResourceOperationTraits = [
  {
    trait: "ConditionalRequests";
    diagnostic: "conditional-requests-trait-missing";
  },
  {
    trait: "RepeatableRequests";
    diagnostic: "repeatable-requests-trait-missing";
  },
  {
    trait: "ClientRequestId";
    diagnostic: "client-request-id-trait-missing";
  }
];

/**
 * Interface containing common resource operations.
 * @template InterfaceTraits Traits applicable to the operations.
 * @template ErrorResponse Error response of the operations. If not specified, the default error response is used.
 */
@ensureTraitsPresent(InterfaceTraits, ExpectedResourceOperationTraits)
interface ResourceOperations<
  InterfaceTraits extends TypeSpec.Reflection.Model,
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> {
  /**
   * Create or replace operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceCreateOrReplace", "PUT")
  @createsOrReplacesResource(Resource)
  ResourceCreateOrReplace<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    Foundations.ResourceBody<Resource> &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Parameters,
        TraitContext.Create | TraitContext.Update
      >,
    Foundations.ResourceCreatedOrOkResponse<Resource &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Response,
        TraitContext.Create | TraitContext.Update
      >>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource create or replace operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("LongRunningResourceCreateOrReplace", "PUT")
  @createsOrReplacesResource(Resource)
  LongRunningResourceCreateOrReplace<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    Foundations.ResourceBody<Resource> &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Parameters,
        TraitContext.Create | TraitContext.Update
      >,
    Foundations.ResourceCreatedOrOkResponse<Resource &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Response,
        TraitContext.Create | TraitContext.Update
      > &
      Foundations.LongRunningStatusLocation>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Create or update operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceCreateOrUpdate", "PATCH")
  @createsOrUpdatesResource(Resource)
  @parameterVisibility(Lifecycle.Create, Lifecycle.Update)
  @patch(#{ implicitOptionality: true }) // For legacy reasons
  ResourceCreateOrUpdate<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    {
      @doc("This request has a JSON Merge Patch body.")
      @TypeSpec.Http.header("Content-Type")
      contentType: "application/merge-patch+json";

      ...Foundations.ResourceBody<Resource>;
      ...TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Parameters,
        TraitContext.Create | TraitContext.Update
      >;
    },
    Foundations.ResourceCreatedOrOkResponse<Resource &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Response,
        TraitContext.Create | TraitContext.Update
      >>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource create or update operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("LongRunningResourceCreateOrUpdate", "PATCH")
  @createsOrUpdatesResource(Resource)
  @parameterVisibility(Lifecycle.Create, Lifecycle.Update)
  @patch(#{ implicitOptionality: true }) // For legacy reasons
  LongRunningResourceCreateOrUpdate<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    {
      @doc("This request has a JSON Merge Patch body.")
      @TypeSpec.Http.header("Content-Type")
      contentType: "application/merge-patch+json";

      ...Foundations.ResourceBody<Resource>;
      ...TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Parameters,
        TraitContext.Create | TraitContext.Update
      >;
    },
    Foundations.ResourceCreatedOrOkResponse<Resource &
      TraitProperties<
        Traits & InterfaceTraits,
        TraitLocation.Response,
        TraitContext.Create | TraitContext.Update
      > &
      Foundations.LongRunningStatusLocation<Resource>>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource update operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceUpdate", "PATCH")
  @updatesResource(Resource)
  @patch(#{ implicitOptionality: true }) // For legacy reasons
  ResourceUpdate<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    {
      @doc("This request has a JSON Merge Patch body.")
      @TypeSpec.Http.header("Content-Type")
      contentType: "application/merge-patch+json";

      ...Foundations.ResourceBody<Resource>;
      ...TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Update>;
    },
    Foundations.ResourceOkResponse<Resource &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Update>>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource create with service-provided name operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
  @Foundations.Private.ensureVerb("ResourceCreateWithServiceProvidedName", "POST")
  @createsResource(Resource)
  ResourceCreateWithServiceProvidedName<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceCollectionOperation<
    Resource,
    Foundations.ResourceBody<Resource> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Create>,
    Foundations.LocationOfCreatedResourceResponse<Resource> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Create>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource create with service-provided name operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
  @Foundations.Private.ensureVerb("LongRunningResourceCreateWithServiceProvidedName", "POST")
  @createsResource(Resource)
  LongRunningResourceCreateWithServiceProvidedName<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceCollectionOperation<
    Resource,
    Foundations.ResourceBody<Resource> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Create>,
    Foundations.LocationOfCreatedResourceWithServiceProvidedNameResponse<Resource> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Create>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource read operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceRead", "GET")
  @readsResource(Resource)
  ResourceRead<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Read>,
    Resource &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Read>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource delete operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
  @Foundations.Private.ensureVerb("ResourceDelete", "DELETE")
  @deletesResource(Resource)
  ResourceDelete<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Delete>,
    TypeSpec.Http.NoContentResponse &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Delete>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource delete operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/no-response-body" "We do support bodies in data plane service APIs..."
  @Foundations.Private.ensureVerb("LongRunningResourceDelete", "DELETE")
  @deletesResource(Resource)
  LongRunningResourceDelete<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Delete>,
    Foundations.AcceptedResponse<Foundations.OperationStatus &
      Foundations.LongRunningStatusLocation &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Delete>>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource list operation template.
   * @template Resource Resource type.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceList", "GET")
  ResourceList<
    Resource extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceList<
    Resource,
    TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.List>,
    Foundations.CustomPage<Resource, Traits & InterfaceTraits>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource action operation template.
   * @template Resource Resource type.
   * @template Parameters Object describing the parameters of the operation.
   * @template Response Object describing the response of the operation.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceAction", "POST")
  @action
  @actionSeparator(":")
  ResourceAction<
    Resource extends TypeSpec.Reflection.Model,
    Parameters extends TypeSpec.Reflection.Model,
    Response extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    Parameters &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Action>,
    Response &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Action>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource collection action operation template.
   * @template Resource Resource type.
   * @template Parameters Object describing the parameters of the operation.
   * @template Response Object describing the response of the operation.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("ResourceCollectionAction", "POST")
  @collectionAction(Resource)
  @actionSeparator(":")
  ResourceCollectionAction<
    Resource extends TypeSpec.Reflection.Model,
    Parameters extends TypeSpec.Reflection.Model,
    Response extends TypeSpec.Reflection.Model,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceCollectionOperation<
    Resource,
    Parameters &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Action>,
    Response &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Action>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource action operation template.
   * @template Resource Resource type.
   * @template Parameters Object describing the parameters of the operation.
   * @template StatusResult Object describing the status result of the operation.
   * @template StatusError Object describing the status error of the operation.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
  #suppress "@azure-tools/typespec-azure-resource-manager/no-response-body" "This operation must return a status monitor in its response."
  @Foundations.Private.ensureVerb("LongRunningResourceAction", "POST")
  @action
  @actionSeparator(":")
  LongRunningResourceAction<
    Resource extends TypeSpec.Reflection.Model,
    Parameters extends TypeSpec.Reflection.Model,
    StatusResult extends TypeSpec.Reflection.Model,
    StatusError = Foundations.Error,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    Resource,
    Parameters &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Action>,
    AcceptedResponse &
      ResourceOperationStatus<Resource, StatusResult, StatusError> &
      Foundations.LongRunningStatusLocation<StatusResult> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Action>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Long-running resource collection action operation template.
   * @template Resource Resource type.
   * @template Parameters Object describing the parameters of the operation.
   * @template StatusResult Object describing the status result of the operation.
   * @template StatusError Object describing the status error of the operation.
   * @template Traits Object describing the traits of the operation.
   */
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
  #suppress "@azure-tools/typespec-azure-resource-manager/no-response-body" "This operation must return a status monitor in its response."
  @Foundations.Private.ensureVerb("LongRunningResourceCollectionAction", "POST")
  @autoRoute
  @collectionAction(Resource)
  @actionSeparator(":")
  LongRunningResourceCollectionAction<
    Resource extends TypeSpec.Reflection.Model,
    Parameters extends TypeSpec.Reflection.Model,
    StatusResult extends TypeSpec.Reflection.Model,
    StatusError = Foundations.Error,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceCollectionOperation<
    Resource,
    Parameters &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Parameters, TraitContext.Action>,
    AcceptedResponse &
      ResourceOperationStatus<Resource, StatusResult, StatusError> &
      Foundations.LongRunningStatusLocation<StatusResult> &
      TraitProperties<Traits & InterfaceTraits, TraitLocation.Response, TraitContext.Action>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;

  /**
   * Resource operation status operation template.
   * @template Resource Resource type.
   * @template StatusResult Object describing the status result of the operation.
   * @template StatusError Object describing the status error of the operation.
   * @template Traits Object describing the traits of the operation.
   */
  @Foundations.Private.ensureVerb("GetResourceOperationStatus", "GET")
  @readsResource(ResourceOperationStatus<Resource>)
  @Foundations.Private.ensureResourceType(Resource)
  GetResourceOperationStatus<
    Resource extends TypeSpec.Reflection.Model,
    StatusResult = Resource,
    StatusError = Foundations.Error,
    Traits extends TypeSpec.Reflection.Model = {}
  > is Foundations.ResourceOperation<
    ResourceOperationStatus<Resource, StatusResult, StatusError>,
    {},
    ResourceOperationStatusResponse<Resource, StatusResult, StatusError>,
    Traits & InterfaceTraits,
    ErrorResponse
  >;
}

// Resource Status Monitoring

/**
 * Operation signature to retrieve a resource operation status.
 * @template Resource The type of the resource.
 * @template StatusResult Object describing the result of the status operation.
 * @template StatusError Object describing the error of the status operation. If not provided, the default error type is used.
 * @template Traits Traits to apply to the operation.
 */
@readsResource(ResourceOperationStatus<Resource>)
@Foundations.Private.ensureResourceType(Resource)
op GetResourceOperationStatus<
  Resource extends TypeSpec.Reflection.Model,
  StatusResult = Resource,
  StatusError = Foundations.Error,
  Traits extends TypeSpec.Reflection.Model = {}
> is Foundations.ResourceOperation<
  ResourceOperationStatus<Resource, StatusResult, StatusError>,
  {},
  ResourceOperationStatusResponse<Resource, StatusResult, StatusError>,
  Traits
>;
