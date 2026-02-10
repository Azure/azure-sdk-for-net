// This file contains operation template that are deprecated and shouldn't be used.
import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "./models.tsp";
import "./traits.tsp";
import "./operations.tsp";

namespace Azure.Core;

using Http;
using Rest;
using Versioning;
using Azure.Core.Traits;
using Azure.Core.Traits.Private;

alias StandardResourceOperations = ResourceOperations<NoConditionalRequests &
  NoRepeatableRequests &
  NoClientRequestId>;

/**
 * DEPRECATED: Use `ResourceCreateOrReplace` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to create or replace a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `ResourceCreateOrReplace` from a `ResourceOperations` interface instance."
op ResourceCreateOrReplace<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceCreateOrReplace<Resource, Traits>;

/**
 * DEPRECATED: Use `LongRunningResourceCreateOrReplace` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature to create or replace a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `LongRunningResourceCreateOrReplace` from a `ResourceOperations` interface instance."
op LongRunningResourceCreateOrReplace<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceCreateOrReplace<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceCreateOrUpdate` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to create or update a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `LongRunningResourceCreateOrReplace` from a `ResourceOperations` interface instance."
op ResourceCreateOrUpdate<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceCreateOrUpdate<Resource, Traits>;

/**
 * DEPRECATED: Use `LongRunningResourceCreateOrUpdate` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature to create or update a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `LongRunningResourceCreateOrUpdate` from a `ResourceOperations` interface instance."
op LongRunningResourceCreateOrUpdate<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceCreateOrUpdate<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceUpdate` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 * Operation signature to update a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `ResourceUpdate` from a `ResourceOperations` interface instance."
op ResourceUpdate<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceUpdate<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceCreateWithServiceProvidedName` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to synchronously create a resource with a service-provided name.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `ResourceCreateWithServiceProvidedName` from a `ResourceOperations` interface instance."
op ResourceCreateWithServiceProvidedName<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceCreateWithServiceProvidedName<Resource, Traits>;

/**
 * DEPRECATED: Use `LongRunningResourceCreateWithServiceProvidedName` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature to create a resource with a service-provided name.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
#deprecated "Use `LongRunningResourceCreateWithServiceProvidedName` from a `ResourceOperations` interface instance."
op LongRunningResourceCreateWithServiceProvidedName<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceCreateWithServiceProvidedName<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceRead` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to retrieve a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
op ResourceRead<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceRead<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceDelete` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to delete a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
op ResourceDelete<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceDelete<Resource, Traits>;

/**
 * DEPRECATED: Use `LongRunningResourceDelete` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature to delete a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
op LongRunningResourceDelete<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceDelete<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceList` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature to list resources in a paginated way.
 * @template Resource The type of the resource.
 * @template Traits Traits to apply to the operation.
 */
op ResourceList<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceList<Resource, Traits>;

/**
 * DEPRECATED: Use `ResourceAction` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature for a resource action.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters.
 * @template Response Object describing the response parameters.
 * @template Traits Traits to apply to the operation.
 */
op ResourceAction<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceAction<Resource, Parameters, Response, Traits>;

/**
 * DEPRECATED: Use `ResourceCollectionAction` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Operation signature for an action that applies to a collection of resources.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters.
 * @template Response Object describing the response parameters.
 * @template Traits Traits to apply to the operation.
 */
op ResourceCollectionAction<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.ResourceCollectionAction<Resource, Parameters, Response, Traits>;

/**
 * DEPRECATED: Use `LongRunningResourceAction` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature for a resource action.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters.
 * @template StatusResult Object describing the result of the status operation.
 * @template StatusError Object describing the error of the status operation. If not provided, the default error type is used.
 * @template Traits Traits to apply to the operation.
 */
op LongRunningResourceAction<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  StatusResult extends TypeSpec.Reflection.Model,
  StatusError = Foundations.Error,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceAction<
  Resource,
  Parameters,
  StatusResult,
  StatusError,
  Traits
>;

/**
 * DEPRECATED: Use `LongRunningResourceCollectionAction` from a `ResourceOperations` interface instance.
 * This can be done by instantiating your own version with the traits you want `alias Operations = Azure.Core.ResourceOperations<ServiceTraits>;`.
 * See https://azure.github.io/typespec-azure/docs/getstarted/azure-core/step05#defining-the-operation-interface for details on how to use.
 *
 * Long-running operation signature for an action that applies to a collection of resources.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters.
 * @template StatusResult Object describing the result of the status operation.
 * @template StatusError Object describing the error of the status operation. If not provided, the default error type is used.
 * @template Traits Traits to apply to the operation.
 */
op LongRunningResourceCollectionAction<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  StatusResult extends TypeSpec.Reflection.Model,
  StatusError = Foundations.Error,
  Traits extends TypeSpec.Reflection.Model = {}
> is StandardResourceOperations.LongRunningResourceCollectionAction<
  Resource,
  Parameters,
  StatusResult,
  StatusError,
  Traits
>;
