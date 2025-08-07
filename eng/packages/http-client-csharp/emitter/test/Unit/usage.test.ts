import { TestHost } from "@typespec/compiler/testing";
import { UsageFlags } from "@azure-tools/typespec-client-generator-core";
import { ok, strictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("Test Usage", () => {
  let runner: TestHost;

  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });
  it("Test the usage of body parameter of azure core operation.", async () => {
    const program = await typeSpecCompile(
      `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Query)
                id: string;
                @doc("name of Foo")
                name: string;
            }

            @doc("The item information.")
            model FooInfo {
                @doc("name of Foo")
                name: string;
            }

            @doc("this is a response model.")
            model BatchCreateFooListItemsRequest {
                @doc("The items to create")
                fooInfos: FooInfo[];
            }

            @doc("this is a response model.")
            model BatchCreateTextListItemsResponse {
                @doc("The item list.")
                fooList: Foo[];
            }
            interface TextLists{
                @doc("create items")
                addItems is ResourceAction<Foo, { @bodyRoot body: BatchCreateFooListItemsRequest }, BatchCreateTextListItemsResponse>;
            }
      `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const fooInfo = root.models.find((model) => model.name === "FooInfo");
    const batchCreateFooListItemsRequest = root.models.find(
      (model) => model.name === "BatchCreateFooListItemsRequest"
    );
    const batchCreateTextListItemsResponse = root.models.find(
      (model) => model.name === "BatchCreateTextListItemsResponse"
    );
    ok(fooInfo);
    strictEqual(fooInfo.usage, UsageFlags.Input | UsageFlags.Json);
    ok(batchCreateFooListItemsRequest);
    strictEqual(
      batchCreateFooListItemsRequest.usage,
      UsageFlags.Input | UsageFlags.Json
    );
    ok(batchCreateTextListItemsResponse);
    strictEqual(
      batchCreateTextListItemsResponse.usage,
      UsageFlags.Output | UsageFlags.Json
    );
  });
  it("Test the usage of body parameter and return type of azure core resource operation.", async () => {
    const program = await typeSpecCompile(
      `
            alias ResourceOperations = global.Azure.Core.ResourceOperations<NoConditionalRequests &
                NoRepeatableRequests &
                NoClientRequestId>;

            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Query)
                id: string;
                @doc("name of Foo")
                name: string;
            }

            interface FooClient{
                @doc("create Foo")
                createFoo is ResourceOperations.ResourceCreateOrUpdate<Foo>;
            }
      `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const fooModel = root.models.find((model) => model.name === "Foo");
    ok(fooModel);
    strictEqual(
      fooModel.usage,
      UsageFlags.Input |
        UsageFlags.Output |
        UsageFlags.JsonMergePatch |
        UsageFlags.Json
    );
  });
  it("Test the usage of body polymorphism type in azure core resource operation.", async () => {
    const program = await typeSpecCompile(
      `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Query)
                id: string;
                @doc("name of Foo")
                name: string;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @discriminator("discriminatorProperty")
            @doc("Base model with discriminator property.")
            model BaseModelWithDiscriminator {
                @doc("Optional property on base")
                optionalPropertyOnBase?: string;

                @doc("Required property on base")
                requiredPropertyOnBase: int32;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @doc("Deriver model with discriminator property.")
            model DerivedModelWithDiscriminatorA extends BaseModelWithDiscriminator {
                discriminatorProperty: "A";

                @doc("Required string.")
                requiredString: string;
            }

            interface FooClient{
                @doc("create Foo")
                op testFoo is Azure.Core.StandardResourceOperations.ResourceCollectionAction<
                Foo,
                { @bodyRoot body: BaseModelWithDiscriminator },
                {}
                >;
            }
      `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const baseModel = root.models.find(
      (model) => model.name === "BaseModelWithDiscriminator"
    );
    const derivedModel = root.models.find(
      (model) => model.name === "DerivedModelWithDiscriminatorA"
    );
    ok(baseModel);
    strictEqual(baseModel.usage, UsageFlags.Input | UsageFlags.Json);
    ok(derivedModel);
    strictEqual(derivedModel.usage, UsageFlags.Input | UsageFlags.Json);
  });
  it("Test the usage of response polymorphism type in azure core resource operation.", async () => {
    const program = await typeSpecCompile(
      `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Query)
                id: string;
                @doc("name of Foo")
                name: string;
            }

            @doc("This is nested model.")
            model NestedModel {
                @doc("id of NestedModel")
                id: string;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @discriminator("discriminatorProperty")
            @doc("Base model with discriminator property.")
            model BaseModelWithDiscriminator {
                @doc("Optional property on base")
                optionalPropertyOnBase?: string;

                @doc("Required property on base")
                requiredPropertyOnBase: int32;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @doc("Deriver model with discriminator property.")
            model DerivedModelWithDiscriminatorA extends BaseModelWithDiscriminator {
                discriminatorProperty: "A";

                @doc("Required string.")
                requiredString: string;

                @doc("property with complex model type.")
                nestedModel: NestedModel;
            }

            interface FooClient{
                @doc("create Foo")
                op testFoo is Azure.Core.StandardResourceOperations.ResourceCollectionAction<
                Foo,
                {},
                BaseModelWithDiscriminator
                >;
            }
      `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const baseModel = root.models.find(
      (model) => model.name === "BaseModelWithDiscriminator"
    );
    const derivedModel = root.models.find(
      (model) => model.name === "DerivedModelWithDiscriminatorA"
    );
    const nestedModel = root.models.find(
      (model) => model.name === "NestedModel"
    );
    ok(baseModel);
    strictEqual(baseModel.usage, UsageFlags.Output | UsageFlags.Json);
    ok(derivedModel);
    strictEqual(derivedModel.usage, UsageFlags.Output | UsageFlags.Json);
    ok(nestedModel);
    strictEqual(nestedModel.usage, UsageFlags.Output | UsageFlags.Json);
  });
  it("Test the usage of return type of a customized LRO operation.", async () => {
    const program = await typeSpecCompile(
      `
#suppress "@azure-tools/typespec-azure-core/documentation-required" "MUST fix in next version"
@doc("The status of the processing job.")
@lroStatus
enum JobStatus {
  NotStarted: "notStarted",
  Running: "running",
  Succeeded: "succeeded",
  Failed: "failed",
  Canceled: "canceled",
}

@doc("Provides status details for long running operations.")
model HealthInsightsOperationStatus<
  TStatusResult = never,
  TStatusError = Foundations.Error
> {
  @key("operationId")
  @doc("The unique ID of the operation.")
  @visibility(Lifecycle.Read)
  id: Azure.Core.uuid;

  @doc("The status of the operation")
  @visibility(Lifecycle.Read)
  @lroStatus
  status: JobStatus;

  @doc("The date and time when the processing job was created.")
  @visibility(Lifecycle.Read)
  createdDateTime?: utcDateTime;

  @doc("The date and time when the processing job is set to expire.")
  @visibility(Lifecycle.Read)
  expirationDateTime?: utcDateTime;

  @doc("The date and time when the processing job was last updated.")
  @visibility(Lifecycle.Read)
  lastUpdateDateTime?: utcDateTime;

  @doc("Error object that describes the error when status is Failed.")
  error?: TStatusError;

  @doc("The result of the operation.")
  @lroResult
  result?: TStatusResult;
}

@doc("The location of an instance of {name}", TResource)
scalar HealthInsightsResourceLocation<TResource extends {}> extends url;

@doc("Metadata for long running operation status monitor locations")
model HealthInsightsLongRunningStatusLocation<TStatusResult = never> {
  @pollingLocation
  @doc("The location for monitoring the operation state.")
  @TypeSpec.Http.header("Operation-Location")
  operationLocation: HealthInsightsResourceLocation<HealthInsightsOperationStatus<TStatusResult>>;
}
#suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "This is a template"
@doc("Long running RPC operation template")
op HealthInsightsLongRunningRpcOperation<
  TParams extends TypeSpec.Reflection.Model,
  TResponse extends TypeSpec.Reflection.Model,
  Traits extends Record<unknown> = {}
> is Azure.Core.RpcOperation<
  TParams & RepeatabilityRequestHeaders,
  Foundations.AcceptedResponse<HealthInsightsLongRunningStatusLocation<TResponse> &
    Foundations.RetryAfterHeader> &
    RepeatabilityResponseHeaders &
    HealthInsightsOperationStatus,
  Traits
>;
@trait("HealthInsightsRetryAfterTrait")
@doc("Health Insights retry after trait")
model HealthInsightsRetryAfterTrait {
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This inline model is never used directly in operations."
  @doc("The retry-after header.")
  retryAfter: {
    @traitLocation(TraitLocation.Response)
    response: Foundations.RetryAfterHeader;
  };
}

@doc("The inference results for the Radiology Insights request.")
model RadiologyInsightsInferenceResult {
    id: string;
}
alias Request = {
    @doc("The list of patients, including their clinical information and data.")
    patients: string[];
  };
@resource("radiology-insights/jobs")
@doc("The response for the Radiology Insights request.")
model RadiologyInsightsResult
  is HealthInsightsOperationStatus<RadiologyInsightsInferenceResult>;

  @doc("The body of the Radiology Insights request.")
  model RadiologyInsightsData {
    ...Request;

    @doc("Configuration affecting the Radiology Insights model's inference.")
    configuration?: string;
  }

#suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "This is a template"
@doc("Long running Pool operation template")
op HealthInsightsLongRunningPollOperation<TResult extends TypeSpec.Reflection.Model> is Azure.Core.RpcOperation<
  {
    @doc("A processing job identifier.")
    @path("id")
    id: Azure.Core.uuid;
  },
  TResult,
  HealthInsightsRetryAfterTrait
>;

interface LegacyLro {
    #suppress "@azure-tools/typespec-azure-core/no-rpc-path-params" "Service uses a jobId in the path"
    @summary("Get Radiology Insights job details")
    @tag("RadiologyInsights")
    @doc("Gets the status and details of the Radiology Insights job.")
    @get
    @route("/radiology-insights/jobs/{id}")
    @convenientAPI(false)
    getJob is HealthInsightsLongRunningPollOperation<RadiologyInsightsResult>;

    #suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "Polling through operation-location"
    #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "There is no long-running RPC template in Azure.Core"
    @summary("Create Radiology Insights job")
    @tag("RadiologyInsights")
    @doc("Creates a Radiology Insights job with the given request body.")
    @pollingOperation(LegacyLro.getJob)
    @route("/radiology-insights/jobs")
    @convenientAPI(true)
    createJob is HealthInsightsLongRunningRpcOperation<
      RadiologyInsightsData,
      RadiologyInsightsResult
    >;
  }
      `,
      runner,
      {
        IsNamespaceNeeded: true,
        IsTCGCNeeded: true
      }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const radiologyInsightsInferenceResult = root.models.find(
      (model) => model.name === "RadiologyInsightsInferenceResult"
    );
    ok(radiologyInsightsInferenceResult);
    // TODO -- TCGC now has a bug that the LRO final result does not have Json usage when the polling operation does not have convenientAPI but the LRO has convenientAPI. https://github.com/Azure/typespec-azure/issues/1964
    //strictEqual(radiologyInsightsInferenceResult.usage, UsageFlags.Output | UsageFlags.Json);
  });
});
