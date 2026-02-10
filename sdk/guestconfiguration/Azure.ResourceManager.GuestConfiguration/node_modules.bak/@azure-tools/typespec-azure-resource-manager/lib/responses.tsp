using Http;
using Rest;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;
using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager;

/**
 * The Azure Resource Manager synchronous OK response
 * @template ResponseBody The contents of the response body
 *
 * @example
 * ```typespec
 *  op get is ArmResourceRead<Employee, Response = ArmResponse<Employee>>;
 * ```
 */
@doc("Azure operation completed successfully.")
model ArmResponse<ResponseBody> {
  ...OkResponse;

  @doc("The body type of the operation request or response.")
  @bodyRoot
  body: ResponseBody;
}

/**
 * The Azure Resource Manager 201 response for a resource
 * @template ResponseBody The contents of the response body
 * @template ExtraHeaders Additional headers in the response. Default includes Retry-After header
 *
 * @example
 * ```typespec
 * @post
 * op post(...ResourceInstanceParameters<Employee>): ArmCreatedResponse<
 *   Employee,
 *   ExtraHeaders = {@header("x-ms-client-request-id") clientRequestId: string}
 * >;
 * ```
 */
@doc("Azure create operation completed successfully.")
model ArmCreatedResponse<
  ResponseBody,
  ExtraHeaders extends TypeSpec.Reflection.Model = Azure.Core.Foundations.RetryAfterHeader
> {
  ...CreatedResponse;
  ...ExtraHeaders;
  ...Body<ResponseBody>;
}

/**
 * The response for synchronous delete of a resource
 *
 * @example
 * ```typespec
 *  @delete
 *  @armResourceDelete(Employee)
 * op delete(
 *    ...ResourceInstanceParameters<Employee>,
 *  ): ArmDeletedResponse | ArmDeletedNoContentResponse | ErrorResponse;
 * ```
 */
@doc("Resource deleted successfully.")
model ArmDeletedResponse {
  ...OkResponse;
}

/**
 * @dev The response for asynchronous Azure Resource Manager delete ACCEPTED
 * @template LroHeaders Optional.  Allows overriding the Lro headers returned in the response.
 *
 * @example
 * ```typespec
 * op delete is ArmResourceDeleteWithoutOkAsync<
 *  Employee,
 *  Response = ArmDeleteAcceptedLroResponse | ArmDeletedNoContentResponse
 *>;
 * ```
 */
model ArmDeleteAcceptedLroResponse<LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
  Azure.Core.Foundations.RetryAfterHeader>
  is ArmAcceptedLroResponse<"Resource deletion accepted.", LroHeaders>;

/**
 * @dev The response for synchronous Azure Resource Manager delete ACCEPTED
 */
model ArmDeleteAcceptedResponse is ArmAcceptedResponse<"Resource deletion accepted.">;

/**
 * @dev The standard ACCEPTED response
 * @template Message The description of the response status (defaults to `Resource operation accepted`)
 * @template ExtraHeaders Additional headers in the response. Default includes Retry-After header
 *
 * @example
 * ```typespec
 * op post is ArmProviderActionSync<
 *  Request = Employee,
 *  Response = ArmAcceptedResponse<ExtraHeaders = ArmLroLocationHeader>,
 *  Scope = SubscriptionActionScope
 * >;
 * ```
 */
@doc(Message)
model ArmAcceptedResponse<
  Message extends valueof string = "Resource operation accepted.",
  ExtraHeaders extends TypeSpec.Reflection.Model = Azure.Core.Foundations.RetryAfterHeader
> {
  ...AcceptedResponse;
  ...ExtraHeaders;
}

/**
 * @dev The standard Azure Resource Manager response for asynchronous PATCH, POST, and DELETE operations
 * @template Description The description of the response status (defaults to `Resource operation accepted`)
 * @template LroHeaders Optional.  The lro headers that appear in the Accepted response
 *
 * @example
 * ```typespec
 * @post
 * op post(
 *  ...ResourceInstanceParameters<Employee>,
 * ): ArmAcceptedLroResponse<
 *    LroHeaders = ArmLroLocationHeader<FinalResult = Employee> &
 *    Azure.Core.Foundations.RetryAfterHeader
 * > | ErrorResponse;
 * ```
 */
@doc(Description)
model ArmAcceptedLroResponse<
  Description extends valueof string = "Resource operation accepted.",
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
    Azure.Core.Foundations.RetryAfterHeader
> {
  ...AcceptedResponse;
  ...LroHeaders;
}

/**
 * Standard Azure Resource Manager operation status response
 * @template Properties Optional resource-specific properties
 * @template StatusValues The set of allowed values for operation status
 */
model ArmOperationStatus<
  Properties extends {} = never,
  StatusValues extends TypeSpec.Reflection.Union = ResourceProvisioningState
> {
  /** RP-specific properties for the operationStatus resource, only appears when operation ended with Succeeded status */
  @visibility(Lifecycle.Read)
  properties?: Properties;

  /** The operation status */
  @Azure.Core.lroStatus
  status: StatusValues;

  /** The unique identifier for the operationStatus resource */
  @key
  @path
  @segment("operationStatuses")
  id: string;

  /** The name of the  operationStatus resource */
  @visibility(Lifecycle.Read)
  name?: string;

  /** Operation start time */
  @visibility(Lifecycle.Read)
  startTime?: utcDateTime;

  /** Operation complete time */
  @visibility(Lifecycle.Read)
  endTime?: utcDateTime;

  /** The progress made toward completing the operation */
  @visibility(Lifecycle.Read)
  percentComplete?: float64;

  /** Errors that occurred if the operation ended with Canceled or Failed status */
  @visibility(Lifecycle.Read)
  error?: ErrorDetail;
}

/**
 * The standard header for asynchronous operation polling
 *  @template StatusMonitor The status monitor type for lro polling
 *  @template UrlValue The value type of the Azure-AsyncOperation header
 *  @template FinalResult The logical final result of the operation
 *
 * @example
 * ```typespec
 * op changeWidget is ArmResourceActionAsync<
 *  WidgetResource,
 *  WidgetResourceRequest,
 *  WidgetResourceResponse,
 *  LroHeaders = ArmAsyncOperationHeader<FinalResult = WidgetResource>
 * >;
 * ```
 */
model ArmAsyncOperationHeader<
  StatusMonitor extends {} = ArmOperationStatus,
  UrlValue extends string = string,
  FinalResult extends TypeSpec.Reflection.Model | unknown | void = never
> {
  /** A link to the status monitor */
  @header("Azure-AsyncOperation")
  @Azure.Core.pollingLocation(Azure.Core.StatusMonitorPollingOptions<PollingModel = StatusMonitor>)
  @Azure.Core.finalLocation(FinalResult)
  azureAsyncOperation?: UrlValue;
}

/**
 * The default header for lro PUT and DELETE polling
 * @template LroPollingOptions The polling options when polling the url in the location header
 * @template FinalResult The ultimate final result of the logical operation
 * @template UrlValue The value type for the location header
 * 
 * @example
 * ```typespec
 * op update is ArmResourceActionAsync<
 *  Employee,
 *  Employee,
 *  OkResponse,
 *  LroHeaders = ArmLroLocationHeader<
 *    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
 *    Employee
 *  >
  >;
 * ```
 */
model ArmLroLocationHeader<
  LroPollingOptions extends Azure.Core.PollingOptions = Azure.Core.StatusMonitorPollingOptions<PollingModel = ArmOperationStatus>,
  FinalResult extends TypeSpec.Reflection.Model | unknown | void = void,
  UrlValue extends string = string
> {
  /** The Location header contains the URL where the status of the long running operation can be checked. */
  @header("Location")
  @Azure.Core.pollingLocation(LroPollingOptions)
  @Azure.Core.finalLocation(FinalResult)
  location?: UrlValue;
}

/**
 * Provide Both Azure-AsyncOperation and Location headers
 * @template StatusMonitor The type of the polling StatusMonitor when following the Azure-AsyncOperation url
 * @template FinalResult The type of the logical result when following the location header
 * @template PollingUrlValue The value type of the link to the status monitor
 * @template FinalUrlValue The value type fo the link to the final result
 *
 * @example
 * ```typespec
 *  op delete is ArmResourceDeleteWithoutOkAsync<
 *    Employee,
 *    LroHeaders = ArmCombinedLroHeaders<ArmOperationStatus, Employee>
 *  >;
 * ```
 */
model ArmCombinedLroHeaders<
  StatusMonitor extends {} = ArmOperationStatus,
  FinalResult extends TypeSpec.Reflection.Model | unknown | void = void,
  PollingUrlValue extends string = ResourceLocation<StatusMonitor>,
  FinalUrlValue extends string = string
> {
  /** A link to the status monitor */
  @Azure.Core.pollingLocation(Azure.Core.StatusMonitorPollingOptions<StatusMonitor>)
  @header("Azure-AsyncOperation")
  azureAsyncOperation?: PollingUrlValue;

  /** The Location header contains the URL where the status of the long running operation can be checked. */
  @header("Location")
  @Azure.Core.finalLocation(FinalResult)
  location?: FinalUrlValue;
}

/**
 * @dev Azure Resource Manager response for a properly formed delete request, with no resource found
 *
 * @example
 * ```typespec
 * op delete is ArmResourceDeleteWithoutOkAsync<
 *  Employee,
 *  Response = ArmDeleteAcceptedLroResponse | ArmDeletedNoContentResponse
 * >;
 * ```
 */
model ArmDeletedNoContentResponse is ArmNoContentResponse<"Resource does not exist.">;

/**
 * Standard Azure Resource Manager NoContent (204) response
 * @template Message The description of the response status (defaults to `Operation completed successfully`)
 *
 * @example
 * ```typespec
 * @delete
 * op delete(@path id:string): ArmNoContentResponse;
 * ```
 */
@doc(Message)
model ArmNoContentResponse<Message extends valueof string = "Operation completed successfully."> {
  ...NoContentResponse;
}

/**
 * @dev Resource update operation succeeded
 * @template Resource The resource being updated
 *
 * @example
 * ```typespec
 * @put
 * op update(
 *  ...ResourceInstanceParameters<Employee>,
 * ): ArmResourceUpdatedResponse<Employee>;
 * ```
 */
@doc("Resource '{name}' update operation succeeded", Resource)
model ArmResourceUpdatedResponse<Resource extends Azure.ResourceManager.Foundations.SimpleResource>
  is ArmResponse<Resource>;

/**
 * @dev Resource create operation succeeded
 * @template Resource The resource being updated
 * @template LroHeaders Optional. The lro headers returned with a Created response
 *
 * @example
 * ```typespec
 * op createOrUpdate is ArmResourceCreateOrReplaceAsync<
 *   Employee,
 *   Response = ArmResponse<Employee> | ArmResourceCreatedResponse<
 *     Employee,
 *     LroHeaders = ArmLroLocationHeader<FinalResult = Employee> & Azure.Core.Foundations.RetryAfterHeader
 *   >
 * >;
 * ```
 */
@doc("Resource '{name}' create operation succeeded", Resource)
model ArmResourceCreatedResponse<
  Resource extends Azure.ResourceManager.Foundations.SimpleResource,
  LroHeaders extends TypeSpec.Reflection.Model = Azure.Core.Foundations.RetryAfterHeader
> {
  ...CreatedResponse;
  ...LroHeaders;

  @Azure.Core.pollingLocation(Azure.Core.StatusMonitorPollingOptions<Resource>)
  @doc("The resource body")
  @bodyRoot
  body: Resource;
}

/**
 * @dev Resource synchronous create operation succeeded
 * @template Resource The resource being updated
 *
 * @example
 * ```typespec
 * op createOrUpdate is ArmResourceCreateOrReplaceSync<
 *  Employee,
 *  Response = ArmResponse<Employee> | ArmResourceCreatedSyncResponse<Employee>
 * >;
 * ```
 */
@doc("Resource '{name}' create operation succeeded", Resource)
model ArmResourceCreatedSyncResponse<Resource extends Azure.ResourceManager.Foundations.SimpleResource> {
  ...CreatedResponse;

  @doc("The body type of the operation request or response.")
  @bodyRoot
  body: Resource;
}

/**
 * @dev Resource exists response
 *
 * @example
 * ```typespec
 * @head
 * op head(...ResourceInstanceParameters<Employee>): ArmResourceExistsResponse;
 * ```
 */
@doc("The Azure resource exists")
model ArmResourceExistsResponse {
  ...NoContentResponse;
}

/**
 * @dev Resource is not found response
 * ```typespec
 * @head
 * op head(...ResourceInstanceParameters<Employee>): ArmResponse<Employee>  | ArmResourceNotFoundResponse;
 * ```
 */
@doc("The Azure resource is not found")
model ArmResourceNotFoundResponse {
  ...NotFoundResponse;
}
