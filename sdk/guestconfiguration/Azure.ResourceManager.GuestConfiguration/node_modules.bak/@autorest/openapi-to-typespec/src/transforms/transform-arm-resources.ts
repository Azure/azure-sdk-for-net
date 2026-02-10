import { getAllProperties, Operation, Parameter, Property, SchemaType } from "@autorest/codemodel";
import { capitalize } from "@azure-tools/codegen";
import _ from "lodash";
import { singular } from "pluralize";
import { getSession, isCommonTypeModel } from "../autorest-session";
import { getDataTypes } from "../data-types";
import {
  ArmResourceKind,
  TypespecDecorator,
  TypespecObjectProperty,
  TypespecParameter,
  TspArmResource,
  TspArmResourceOperation,
  isFirstLevelResource,
  TypespecTemplateModel,
  TspArmOperationType,
  TspArmResourceActionOperation,
  TspArmResourceOperationBase,
  TypespecVoidType,
  TspArmResourceLifeCycleOperation,
  TspArmResourceListOperation,
  isArmResourceActionOperation,
  TspArmResourceLegacyOperationGroup,
  TspArmResourceOperationGroup,
  TypespecSpreadStatement,
  TspExternalResource,
} from "../interfaces";
import { transformDataType } from "../model";
import { getOptions, updateOptions } from "../options";
import { createClientNameDecorator, createCSharpNameDecorator } from "../pretransforms/rename-pretransform";
import { getOperationClientDecorators, getPropertyDecorators } from "../utils/decorators";
import { generateDocsContent } from "../utils/docs";
import { getEnvelopeProperty, getEnvelopeAugmentedDecorator } from "../utils/envelope-property";
import { getLogger } from "../utils/logger";
import {
  getSwaggerOperationGroupName,
  getSwaggerOperationName,
  getTSPOperationGroupName,
} from "../utils/operation-group";
import {
  ArmResource,
  ArmResourceSchema,
  _ArmResourceOperation,
  getResourceOperations,
  isExtensionScopeType,
  isResourceSchema,
} from "../utils/resource-discovery";
import { get200ResponseName } from "../utils/response";
import { isStringSchema } from "../utils/schemas";
import { escapeRegex } from "../utils/strings";
import {
  checkArmDeleteOperationResponseCodes,
  checkArmPutOperationResponseCodes,
  checkNoResponseBody,
  getSuppressionWithCode,
  SuppressionCode,
} from "../utils/suppressions";
import { getFullyQualifiedName, getTemplateResponses, NamesOfResponseTemplate } from "../utils/type-mapping";
import { getTypespecType, isTypespecType, transformObjectProperty } from "./transform-object";
import { transformParameter } from "./transform-operations";

const logger = () => getLogger("transform-arm-resources");

const armResourceCache: Map<ArmResourceSchema, TspArmResource> = new Map<ArmResourceSchema, TspArmResource>();
export function transformTspArmResource(schema: ArmResourceSchema): TspArmResource {
  if (armResourceCache.has(schema)) return armResourceCache.get(schema)!;

  const { isFullCompatible } = getOptions();
  const fixMe: string[] = [];

  if (!getSession().configuration["namespace"]) {
    const segments = schema.resourceMetadata[0].GetOperation!.Path.split("/");
    for (let i = segments.length - 1; i >= 0; i--) {
      if (segments[i] === "providers") {
        getSession().configuration["namespace"] = segments[i + 1];
        updateOptions();
        break;
      }
    }
  }

  // TODO: deal with a resource with multiple parents
  if (schema.resourceMetadata[0].Parents.length > 1) {
    fixMe.push(
      `// FIXME: ${schema.resourceMetadata[0].SwaggerModelName} has more than one parent, currently converter will only use the first one`,
    );
  }

  const propertiesModel = schema.properties?.find((p) => p.serializedName === "properties");
  const propertiesModelSchema = propertiesModel?.schema;
  let propertiesModelName = propertiesModelSchema?.language.default.name;
  let propertiesPropertyRequired = false;
  let propertiesPropertyDescription = "";

  if (propertiesModelSchema?.type === SchemaType.Dictionary) {
    propertiesModelName = "Record<unknown>";
  } else if (propertiesModelSchema?.type === SchemaType.Object) {
    propertiesPropertyRequired = propertiesModel?.required ?? false;
    propertiesPropertyDescription = propertiesModel?.language.default.description ?? "";
  }

  // TODO: deal with resources that has no properties property
  if (!propertiesModelName) {
    fixMe.push(`// FIXME: ${schema.resourceMetadata[0].SwaggerModelName} has no properties property`);
    propertiesModelName = "{}";
  }

  const armResourceOperationGroups = getTspOperationGroups(schema);

  const decorators = buildResourceDecorators(schema);
  if (schema.resourceMetadata[0].ScopeType === "Scope") {
    decorators.push({ name: "extensionResource" });
  }

  const clientDecorators = buildResourceClientDecorators(schema);
  const keyProperty = buildKeyProperty(schema);
  const resourceParent = getParentResource(schema);
  const resourceKind = getResourceKind(schema, resourceParent);
  const augmentDecorators = buildKeyAugmentDecorators(schema, keyProperty, resourceKind) ?? [];
  const properties = [keyProperty, ...getOtherProperties(schema, resourceKind)];

  if (propertiesModel) {
    augmentDecorators.push(...buildPropertiesAugmentDecorators(schema, propertiesModel));
  }

  const propertiesPropertyClientDecorator = [];
  if (isFullCompatible && propertiesModel?.extensions?.["x-ms-client-flatten"]) {
    propertiesPropertyClientDecorator.push({
      name: "Legacy.flattenProperty",
      module: "@azure-tools/typespec-client-generator-core",
      namespace: "Azure.ClientGenerator.Core",
      suppressionCode: "@azure-tools/typespec-azure-core/no-legacy-usage",
      suppressionMessage: "Property flatten for SDK backward compatibility.",
    });
  }

  const tspResource: TspArmResource = {
    kind: "ArmResource",
    name: schema.resourceMetadata[0].SwaggerModelName,
    fixMe,
    resourceKind,
    properties,
    resourceParent,
    propertiesModelName,
    propertiesPropertyRequired,
    propertiesPropertyDescription,
    propertiesPropertyClientDecorator,
    doc: schema.language.default.description,
    decorators,
    clientDecorators,
    augmentDecorators,
    resourceOperationGroups: armResourceOperationGroups,
    locationParent: getLocationParent(schema),
  };
  armResourceCache.set(schema, tspResource);
  return tspResource;
}

function getTspOperationGroups(armSchema: ArmResourceSchema): TspArmResourceOperationGroup[] {
  const operationGroups: TspArmResourceOperationGroup[] = [];
  for (const resourceMetadata of armSchema.resourceMetadata) {
    const operations = getResourceOperations(resourceMetadata);
    const interfaceName = getTSPOperationGroupName(resourceMetadata);
    const tspOperations: TspArmResourceOperation[] = [];

    // TODO: handle operations under resource group / management group / tenant

    // read operation
    tspOperations.push(...convertResourceReadOperation(resourceMetadata, operations));

    // exist operation
    tspOperations.push(...convertResourceExistsOperation(resourceMetadata, operations));

    // create operation
    tspOperations.push(...convertResourceCreateOrReplaceOperation(resourceMetadata, operations));

    // patch update operation could either be patch for resource/tag or custom patch
    tspOperations.push(...convertResourceUpdateOperation(resourceMetadata, operations));

    // delete operation
    tspOperations.push(...convertResourceDeleteOperation(resourceMetadata, operations));

    // list operation
    tspOperations.push(...convertResourceListOperations(resourceMetadata, operations));

    // action operation
    tspOperations.push(...convertResourceActionOperations(resourceMetadata, operations));

    const externalResource =
      resourceMetadata.ScopeType === "Extension" ? convertExternalResourceForExtension(resourceMetadata) : undefined;

    if (armSchema.resourceMetadata.length === 1) {
      return [
        {
          isLegacy: false,
          interfaceName,
          resourceOperations: tspOperations,
          externalResource,
        },
      ];
    }

    operationGroups.push({
      isLegacy: true,
      interfaceName,
      resourceOperations: tspOperations,
      legacyOperationGroup: convertLegacyOperationGroup(resourceMetadata),
    });
  }

  return operationGroups;
}

// TO-DO: add NamePattern, NameType, and Description
function convertExternalResourceForExtension(armResource: ArmResource): TspExternalResource {
  const pathSegments = armResource.GetOperation!.Path.split("/").filter((s) => s !== "");
  const providerIndex = pathSegments.indexOf("providers");
  if (providerIndex === -1 || providerIndex + 3 >= pathSegments.length) {
    logger().error(`Invalid path for external resource: ${armResource.GetOperation!.Path}`);
  }
  const resourceType = pathSegments[providerIndex + 2];
  const aliasName = `${singular(resourceType)}ExternalResource`;
  return {
    aliasName,
    targetNamespace: pathSegments[providerIndex + 1],
    resourceType,
    resourceParameterName: pathSegments[providerIndex + 3],
  };
}

function convertLegacyOperationGroup(armResource: ArmResource): TspArmResourceLegacyOperationGroup {
  const pathParameters = getPathParameters(armResource);

  const isExtensionResource = isExtensionScopeType(armResource.ScopeType);
  let externalProviderFound: boolean = false;
  let instanceProviderFound: boolean = false;
  const targetParentParameters: string[] = ["...ApiVersionParameter"];
  const instanceParameters: string[] = [];
  const extensionParentParameters: string[] = [];
  for (let i = 0; i < pathParameters.length; i++) {
    const parameter = pathParameters[i];
    if (parameter.keyName === "subscriptionId") {
      targetParentParameters.push("...SubscriptionIdParameter");
    } else if (parameter.keyName === "resourceGroupName") {
      targetParentParameters.push("...ResourceGroupParameter");
    } else if (parameter.keyName === "location") {
      targetParentParameters.push("...LocationParameter");
    } else if (parameter.segmentName === "providers") {
      if (isExtensionResource) {
        if (externalProviderFound === false) {
          targetParentParameters.push(
            `/** the provider namespace */ @path @segment("providers") @key providerNamespace: "${parameter.keyName}"`,
          );
          externalProviderFound = true;
        } else {
          instanceParameters.push(`...Extension.ExtensionProviderNamespace<${armResource.Name}>`);
          extensionParentParameters.push(`...Extension.ExtensionProviderNamespace<${armResource.Name}>`);
          instanceProviderFound = true;
        }
      } else {
        targetParentParameters.push("...Azure.ResourceManager.Legacy.Provider");
        instanceProviderFound = true;
      }
    } else {
      const resourceNameParameter = `/** ${parameter.description} */\n@path @segment("${parameter.segmentName}") @key ${parameter.pattern ? `@pattern("${parameter.pattern}")` : ""} ${parameter.keyName}: string`;
      if (instanceProviderFound && isExtensionResource) {
        instanceParameters.push(resourceNameParameter);
        if (i !== pathParameters.length - 1) {
          extensionParentParameters.push(resourceNameParameter);
        }
      } else {
        if (i !== pathParameters.length - 1) {
          targetParentParameters.push(resourceNameParameter);
        } else {
          instanceParameters.push(resourceNameParameter);
        }
      }
    }
  }

  const interfaceName = `${singular(getTSPOperationGroupName(armResource))}Ops`;
  return isExtensionResource
    ? {
        type: "Extension",
        interfaceName,
        targetParentParameters,
        instanceParameters,
        extensionParentParameters,
      }
    : {
        type: "Normal",
        interfaceName,
        targetParentParameters,
        instanceParameters,
      };
}

function buildResourceNameParameterForSegment(
  segmentName: string,
  keyName: string,
  pattern: string,
): string | undefined {
  for (const objectSchema of getSession().model.schemas.objects ?? []) {
    if (!isResourceSchema(objectSchema)) {
      continue;
    }

    const resource = objectSchema.resourceMetadata.find(
      (r) => r.ResourceKeySegment === segmentName && r.ResourceKey === keyName,
    );
    if (resource === undefined) continue;

    return `...KeysOf<ResourceNameParameter<
    Resource = ${resource.SwaggerModelName},
    KeyName = "${keyName}",
    SegmentName = "${segmentName}",
    NamePattern = "${pattern}"
  >>`;
  }
  return undefined;
}

function convertResourceReadOperation(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  // every resource should have a get operation
  const operation = resourceMetadata.GetOperation!;
  const swaggerOperation = operations[operation.OperationID];
  const armOperation = buildNewArmOperation(resourceMetadata, operation, swaggerOperation, "ArmResourceRead");
  const syncNames: NamesOfResponseTemplate = {
    _200Name: "ArmResponse",
    _200NameNoBody: "OkResponse",
    _201Name: "ArmResourceCreatedSyncResponse",
    _201NameNoBody: "CreatedResponse",
    _202Name: "AcceptedResponse",
    _202NameNoBody: "AcceptedResponse",
    _204Name: "ArmNoContentResponse",
  };
  let responses: TypespecTemplateModel[] = getTemplateResponses(swaggerOperation, syncNames);
  const templateSyncResponses: TypespecTemplateModel[] = [
    {
      kind: "template",
      name: syncNames._200Name,
      arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
    },
  ];
  if (isSameResponses(responses, templateSyncResponses)) responses = [];
  if (responses.length > 0) armOperation.response = responses;
  return [armOperation as TspArmResourceLifeCycleOperation];
}

function convertResourceExistsOperation(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  const operation = resourceMetadata.ExistOperation;
  if (operation) {
    const swaggerOperation = operations[operation.OperationID];
    const armOperation = buildNewArmOperation(
      resourceMetadata,
      operation,
      swaggerOperation,
      "ArmResourceCheckExistence",
    );
    if (!swaggerOperation.operationId) armOperation.name = "exists";
    return [armOperation as TspArmResourceLifeCycleOperation];
  }
  return [];
}

function convertResourceCreateOrReplaceOperation(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  if (resourceMetadata.CreateOperation) {
    const operation = resourceMetadata.CreateOperation;
    const swaggerOperation = operations[operation.OperationID];
    const isLongRunning = swaggerOperation.extensions?.["x-ms-long-running-operation"] ?? false;
    const armOperation = buildNewArmOperation(
      resourceMetadata,
      operation,
      swaggerOperation,
      isLongRunning ? "ArmResourceCreateOrReplaceAsync" : "ArmResourceCreateOrReplaceSync",
    );

    const bodyParam = swaggerOperation.requests?.[0].parameters?.find((p) => p.protocol.http?.in === "body");
    if (!bodyParam) armOperation.request = { kind: "void", name: "_" };
    else {
      const bodyType = getTypespecType(bodyParam.schema, getSession().model);
      if (bodyType !== armOperation.resource) {
        armOperation.request = { kind: "body", name: bodyType };
      }
    }

    const finalStateVia =
      swaggerOperation.extensions?.["x-ms-long-running-operation-options"]?.["final-state-via"] ?? "location";
    const finalResult = get200ResponseName(swaggerOperation);
    if (isLongRunning && finalStateVia === "location") {
      armOperation.lroHeaders = {
        type: "Location",
        finalResult: finalResult,
      };
    }

    buildBodyDecorator(bodyParam, armOperation, resourceMetadata, "resource", "Resource create parameters.");

    const asyncNames: NamesOfResponseTemplate = {
      _200Name: "ArmResourceUpdatedResponse",
      _200NameNoBody: "OkResponse",
      _201Name: "ArmResourceCreatedResponse",
      _201NameNoBody: "CreatedResponse",
      _202Name: "ArmAcceptedLroResponse",
      _202NameNoBody: "ArmAcceptedLroResponse",
      _204Name: "ArmNoContentResponse",
    };
    const syncNames: NamesOfResponseTemplate = {
      _200Name: "ArmResourceUpdatedResponse",
      _200NameNoBody: "OkResponse",
      _201Name: "ArmResourceCreatedSyncResponse",
      _201NameNoBody: "CreatedResponse",
      _202Name: "AcceptedResponse",
      _202NameNoBody: "AcceptedResponse",
      _204Name: "ArmNoContentResponse",
    };
    let responses: TypespecTemplateModel[] = isLongRunning
      ? getTemplateResponses(swaggerOperation, asyncNames)
      : getTemplateResponses(swaggerOperation, syncNames);
    const templateAsyncResponses: TypespecTemplateModel[] = [
      {
        kind: "template",
        name: asyncNames._200Name,
        arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
      },
      {
        kind: "template",
        name: asyncNames._201Name,
        arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
      },
    ];
    const templateSyncResponses: TypespecTemplateModel[] = [
      {
        kind: "template",
        name: syncNames._200Name,
        arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
      },
      {
        kind: "template",
        name: syncNames._201Name,
        arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
      },
    ];
    if (isLongRunning && isSameResponses(responses, templateAsyncResponses)) responses = [];
    if (!isLongRunning && isSameResponses(responses, templateSyncResponses)) responses = [];
    if (responses.length > 0) armOperation.response = responses;
    if (armOperation.lroHeaders && responses) {
      let _201Response = responses.find((r) => r.name === asyncNames._201Name);
      if (_201Response) {
        _201Response.arguments!.push({
          kind: "object",
          name: `ArmLroLocationHeader${finalResult ? `<FinalResult = ${finalResult}>` : ""} & Azure.Core.Foundations.RetryAfterHeader`,
        }); //TO-DO: do it in a better way
        armOperation.lroHeaders = undefined;
      }

      _201Response = responses.find((r) => r.name === syncNames._201NameNoBody);
      if (_201Response) {
        _201Response.additionalTemplateModel = "ArmLroLocationHeader & Azure.Core.Foundations.RetryAfterHeader";
      }
    }

    buildSuppressionsForArmOperation(armOperation, asyncNames, syncNames);
    return [armOperation as TspArmResourceLifeCycleOperation];
  }
  return [];
}

function convertResourceUpdateOperation(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  if (resourceMetadata.UpdateOperation) {
    const operation = resourceMetadata.UpdateOperation;
    if (!resourceMetadata.CreateOperation || resourceMetadata.CreateOperation.OperationID !== operation.OperationID) {
      const swaggerOperation = operations[operation.OperationID];
      const isLongRunning = swaggerOperation.extensions?.["x-ms-long-running-operation"] ?? false;
      const armOperation = buildNewArmOperation(
        resourceMetadata,
        operation,
        swaggerOperation,
        isLongRunning ? "ArmCustomPatchAsync" : "ArmCustomPatchSync",
      );

      const finalStateVia =
        swaggerOperation.extensions?.["x-ms-long-running-operation-options"]?.["final-state-via"] ?? "location";
      const finalResult = get200ResponseName(swaggerOperation);
      if (isLongRunning && finalStateVia === "azure-async-operation") {
        armOperation.lroHeaders = {
          type: "Azure-AsyncOperation",
          finalResult: finalResult,
        };
      }

      const bodyParam = swaggerOperation.requests?.[0].parameters?.find((p) => p.protocol.http?.in === "body");
      if (!bodyParam) {
        armOperation.patchModel = { kind: "void", name: "_" };
      } else {
        armOperation.patchModel = { kind: "body", name: bodyParam.schema.language.default.name };
      }
      if (bodyParam?.required === false) armOperation.optionalRequestBody = true;

      buildBodyDecorator(
        bodyParam,
        armOperation,
        resourceMetadata,
        "properties",
        "The resource properties to be updated.",
      );

      const asyncNames: NamesOfResponseTemplate = {
        _200Name: "ArmResponse",
        _200NameNoBody: "OkResponse",
        _201Name: "ArmResourceCreatedResponse",
        _201NameNoBody: "CreatedResponse",
        _202Name: "ArmAcceptedLroResponse",
        _202NameNoBody: "ArmAcceptedLroResponse",
        _204Name: "ArmNoContentResponse",
      };
      const syncNames: NamesOfResponseTemplate = {
        _200Name: "ArmResponse",
        _200NameNoBody: "OkResponse",
        _201Name: "ArmResourceCreatedSyncResponse",
        _201NameNoBody: "CreatedResponse",
        _202Name: "AcceptedResponse",
        _202NameNoBody: "AcceptedResponse",
        _204Name: "ArmNoContentResponse",
      };
      let responses = isLongRunning
        ? getTemplateResponses(swaggerOperation, asyncNames)
        : getTemplateResponses(swaggerOperation, syncNames);
      const templateAsyncResponses: TypespecTemplateModel[] = [
        {
          kind: "template",
          name: asyncNames._200Name,
          arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
        },
        {
          kind: "template",
          name: asyncNames._202NameNoBody,
        },
      ];
      const templateSyncResponses: TypespecTemplateModel[] = [
        {
          kind: "template",
          name: syncNames._200Name,
          arguments: [{ kind: "object", name: resourceMetadata.SwaggerModelName }],
        },
      ];
      if (isLongRunning && isSameResponses(responses, templateAsyncResponses)) responses = [];
      if (!isLongRunning && isSameResponses(responses, templateSyncResponses)) responses = [];
      if (responses.length > 0) armOperation.response = responses;
      if (armOperation.lroHeaders && responses) {
        const _202response = responses.find(
          (r) => r.name === asyncNames._202NameNoBody || r.name === asyncNames._202Name,
        );
        if (_202response) {
          _202response.arguments = [
            {
              kind: "object",
              name: `ArmAsyncOperationHeader${finalResult ? `<FinalResult = ${finalResult}>` : ""} & Azure.Core.Foundations.RetryAfterHeader`,
            },
          ]; //TO-DO: do it in a better way
          armOperation.lroHeaders = undefined;
        }
      }

      buildSuppressionsForArmOperation(armOperation, asyncNames, syncNames);
      armOperation.decorators = armOperation.decorators ?? [];
      armOperation.decorators.push({
        name: "patch",
        arguments: [{ value: "#{ implicitOptionality: false }", options: { unwrap: true } }],
      });
      return [armOperation as TspArmResourceLifeCycleOperation];
    }
  }
  return [];
}

function convertResourceDeleteOperation(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  const { isFullCompatible } = getOptions();

  if (resourceMetadata.DeleteOperation) {
    const operation = resourceMetadata.DeleteOperation;
    const swaggerOperation = operations[operation.OperationID];
    const isLongRunning = swaggerOperation.extensions?.["x-ms-long-running-operation"] ?? false;
    const armOperation = buildNewArmOperation(
      resourceMetadata,
      operation,
      swaggerOperation,
      isLongRunning ? "ArmResourceDeleteWithoutOkAsync" : "ArmResourceDeleteSync",
    );

    const finalStateVia =
      swaggerOperation.extensions?.["x-ms-long-running-operation-options"]?.["final-state-via"] ?? "location";
    const finalResult = get200ResponseName(swaggerOperation);
    if (isLongRunning && finalStateVia === "azure-async-operation") {
      armOperation.lroHeaders = {
        type: "Azure-AsyncOperation",
        finalResult: finalResult,
      };
    }

    if (armOperation.lroHeaders && isFullCompatible) {
      armOperation.suppressions = armOperation.suppressions ?? [];
      armOperation.suppressions.push(getSuppressionWithCode(SuppressionCode.LroLocationHeader));
    }

    const asyncNames: NamesOfResponseTemplate = {
      _200Name: "ArmResponse",
      _200NameNoBody: "ArmDeletedResponse",
      _201Name: "ArmResourceCreatedResponse",
      _201NameNoBody: "CreatedResponse",
      _202Name: "ArmDeleteAcceptedLroResponse",
      _202NameNoBody: "ArmDeleteAcceptedLroResponse",
      _204Name: "ArmDeletedNoContentResponse",
    };
    const syncNames: NamesOfResponseTemplate = {
      _200Name: "ArmResponse",
      _200NameNoBody: "ArmDeletedResponse",
      _201Name: "ArmResourceCreatedSyncResponse",
      _201NameNoBody: "CreatedResponse",
      _202Name: "AcceptedResponse",
      _202NameNoBody: "AcceptedResponse",
      _204Name: "ArmDeletedNoContentResponse",
    };
    let responses = isLongRunning
      ? getTemplateResponses(swaggerOperation, asyncNames)
      : getTemplateResponses(swaggerOperation, syncNames);

    const templateAsyncResponses: TypespecTemplateModel[] = [
      {
        kind: "template",
        name: asyncNames._202NameNoBody,
      },
      {
        kind: "template",
        name: asyncNames._204Name,
      },
    ];
    const templateSyncResponses: TypespecTemplateModel[] = [
      {
        kind: "template",
        name: syncNames._200NameNoBody,
      },
      {
        kind: "template",
        name: syncNames._204Name,
      },
    ];
    if (isLongRunning && isSameResponses(responses, templateAsyncResponses)) responses = [];
    if (!isLongRunning && isSameResponses(responses, templateSyncResponses)) responses = [];
    if (armOperation.lroHeaders && responses) {
      const _202response = responses.find(
        (r) => r.name === asyncNames._202NameNoBody || r.name === asyncNames._202Name,
      );
      if (_202response) {
        _202response.arguments = [
          {
            kind: "object",
            name: `ArmAsyncOperationHeader${finalResult ? `<FinalResult = ${finalResult}>` : ""} & Azure.Core.Foundations.RetryAfterHeader`,
          },
        ]; //TO-DO: do it in a better way
        armOperation.lroHeaders = undefined;
      }
    }
    if (responses.length > 0) armOperation.response = responses;

    buildSuppressionsForArmOperation(armOperation, asyncNames, syncNames);
    return [armOperation as TspArmResourceLifeCycleOperation];
  }
  return [];
}

function convertResourceListOperations(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceOperation[] {
  const converted: TspArmResourceOperation[] = [];

  // list by parent operation
  if (resourceMetadata.ListOperations.length) {
    // TODO: TParentName, TParentFriendlyName
    const operation = resourceMetadata.ListOperations[0];
    const swaggerOperation = operations[operation.OperationID];
    const armOperation = buildNewArmOperation(resourceMetadata, operation, swaggerOperation, "ArmResourceListByParent");

    const syncNames: NamesOfResponseTemplate = {
      _200Name: "ArmResponse",
      _200NameNoBody: "OkResponse",
      _201Name: "ArmResourceCreatedSyncResponse",
      _201NameNoBody: "CreatedResponse",
      _202Name: "AcceptedResponse",
      _202NameNoBody: "AcceptedResponse",
      _204Name: "NoContentResponse",
    };
    let responses = getTemplateResponses(swaggerOperation, syncNames);
    if (
      responses.length === 1 &&
      responses[0].name === syncNames._200Name &&
      responses[0].arguments?.[0].name === "ResourceListResult"
    )
      responses = [];
    if (responses.length > 0) armOperation.response = responses;

    converted.push(armOperation as TspArmResourceListOperation);
  }

  // list operation under subscription
  if (resourceMetadata.OperationsFromSubscriptionExtension.length) {
    for (const operation of resourceMetadata.OperationsFromSubscriptionExtension) {
      if (operation.PagingMetadata) {
        const swaggerOperation = operations[operation.OperationID];
        const armOperation = buildNewArmOperation(
          resourceMetadata,
          operation,
          swaggerOperation,
          "ArmResourceListAtScope",
        );

        const syncNames: NamesOfResponseTemplate = {
          _200Name: "ArmResponse",
          _200NameNoBody: "OkResponse",
          _201Name: "ArmResourceCreatedSyncResponse",
          _201NameNoBody: "CreatedResponse",
          _202Name: "AcceptedResponse",
          _202NameNoBody: "AcceptedResponse",
          _204Name: "NoContentResponse",
        };
        let responses = getTemplateResponses(swaggerOperation, syncNames);
        if (
          responses.length === 1 &&
          responses[0].name === syncNames._200Name &&
          responses[0].arguments?.[0].name === "ResourceListResult"
        )
          responses = [];
        if (responses.length > 0) armOperation.response = responses;

        // either list in location or list in subscription
        if (operation.Path.includes("/locations/")) {
          armOperation.baseParameters = [getFullyQualifiedName("LocationBaseParameters")];
        } else {
          armOperation.kind = "ArmListBySubscription";
        }
        converted.push(armOperation as TspArmResourceListOperation);
      }
    }
  }

  return converted;
}

function convertResourceActionOperations(
  resourceMetadata: ArmResource,
  operations: Record<string, Operation>,
): TspArmResourceActionOperation[] {
  const converted: TspArmResourceActionOperation[] = [];

  if (resourceMetadata.OtherOperations.length) {
    for (const operation of resourceMetadata.OtherOperations) {
      const swaggerOperation = operations[operation.OperationID];
      const isLongRunning = swaggerOperation.extensions?.["x-ms-long-running-operation"] ?? false;
      const armOperation = buildNewArmOperation(
        resourceMetadata,
        operation,
        swaggerOperation,
        isLongRunning ? "ArmResourceActionAsync" : "ArmResourceActionSync",
      );

      const finalStateVia =
        swaggerOperation.extensions?.["x-ms-long-running-operation-options"]?.["final-state-via"] ?? "location";
      const finalResult = get200ResponseName(swaggerOperation);
      if (isLongRunning && finalStateVia === "azure-async-operation") {
        armOperation.lroHeaders = {
          type: "Azure-AsyncOperation",
          finalResult: finalResult,
        };
      }

      buildRequestForAction(
        armOperation,
        swaggerOperation,
        resourceMetadata,
        true,
        "body",
        "The content of the action request",
      );

      armOperation.decorators = armOperation.decorators ?? [];
      if (operation.Method !== "POST") {
        armOperation.decorators.push({ name: operation.Method.toLocaleLowerCase() });
      }
      const segments = operation.Path.split("/");
      if (segments[segments.length - 1] !== armOperation.name) {
        armOperation.decorators.push({ name: "action", arguments: [segments[segments.length - 1]] });
      }

      const asyncNames: NamesOfResponseTemplate = {
        _200Name: "ArmResponse",
        _200NameNoBody: "OkResponse",
        _201Name: "ArmResourceCreatedResponse",
        _201NameNoBody: "CreatedResponse",
        _202Name: "ArmAcceptedLroResponse",
        _202NameNoBody: "ArmAcceptedLroResponse",
        _204Name: "NoContentResponse",
      };
      const syncNames: NamesOfResponseTemplate = {
        _200Name: "ArmResponse",
        _200NameNoBody: "OkResponse",
        _201Name: "ArmResourceCreatedSyncResponse",
        _201NameNoBody: "CreatedResponse",
        _202Name: "AcceptedResponse",
        _202NameNoBody: "AcceptedResponse",
        _204Name: "NoContentResponse",
      };
      let responses: TypespecTemplateModel[] | TypespecVoidType = isLongRunning
        ? getTemplateResponses(swaggerOperation, asyncNames)
        : getTemplateResponses(swaggerOperation, syncNames);

      if (isLongRunning) {
        const _202NoBodyResponseIndex = responses.findIndex(
          (r) => r.name === asyncNames._202NameNoBody && !r.arguments,
        );
        if (_202NoBodyResponseIndex >= 0 && responses.length > 1) {
          responses.splice(_202NoBodyResponseIndex, 1);
        } else {
          armOperation.kind = "ArmResourceActionAsyncBase";
          armOperation.baseParameters = armOperation.baseParameters ?? [
            `${getFullyQualifiedName("DefaultBaseParameters")}<${armOperation.resource}>`,
          ];
          const _202Response = responses.find((r) => r.name === asyncNames._202Name);
          if (_202Response && armOperation.lroHeaders?.type === "Azure-AsyncOperation") {
            _202Response.arguments = _202Response.arguments ?? [];
            _202Response.arguments.push({
              kind: "object",
              name: `ArmAsyncOperationHeader${finalResult ? `<FinalResult = ${finalResult}>` : ""} & Azure.Core.Foundations.RetryAfterHeader`,
            });
          }
        }
      }
      if (responses.length === 0) responses = { kind: "void", name: "_" };
      armOperation.response = responses;

      converted.push(armOperation as TspArmResourceActionOperation);
    }
  }

  return converted;
}

function buildRequestForAction(
  armOperation: TspArmResourceOperationBase,
  operation: Operation,
  resourceMetadata: ArmResource,
  templateRequired: boolean,
  templateName: string,
  templateDoc: string,
): void {
  if (!isArmResourceActionOperation(armOperation)) {
    throw new Error(`Operation ${operation.operationId} is not an action operation.`);
  }

  const bodyParam = operation.requests?.[0].parameters?.find((p) => p.protocol.http?.in === "body");
  if (bodyParam === undefined) {
    armOperation.request = { kind: "void", name: "_" };
    return;
  }

  const bodyType = getTypespecType(bodyParam.schema, getSession().model);
  armOperation.request = { kind: "object", name: bodyType };
  if (bodyParam.required !== templateRequired) {
    armOperation.optionalRequestBody = true;
  }
  buildBodyDecorator(bodyParam, armOperation, resourceMetadata, templateName, templateDoc);
}

function buildBodyDecorator(
  bodyParam: Parameter | undefined,
  armOperation: TspArmResourceOperationBase,
  resourceMetadata: ArmResource,
  templateName: string,
  templateDoc: string,
): void {
  const tspOperationGroupName = getTSPOperationGroupName(resourceMetadata);
  const [augmentedDecorators, clientDecorators] = getBodyDecorators(
    bodyParam,
    tspOperationGroupName,
    armOperation.name,
    templateName,
    templateDoc,
  );
  armOperation.augmentedDecorators = armOperation.augmentedDecorators
    ? armOperation.augmentedDecorators.concat(augmentedDecorators)
    : augmentedDecorators;
  armOperation.clientDecorators = armOperation.clientDecorators
    ? armOperation.clientDecorators.concat(clientDecorators)
    : clientDecorators;
}

function isSameResponses(actual: TypespecTemplateModel[], expected: TypespecTemplateModel[]): boolean {
  if (actual.length !== expected.length) return false;
  for (const actualModel of actual) {
    const expectedModel = expected.find((m) => isSameResponse(actualModel, m));
    if (!expectedModel) return false;
  }
  return true;
}

function isSameResponse(actual: TypespecTemplateModel, expected: TypespecTemplateModel): boolean {
  if (actual.name !== expected.name) return false;
  if (actual.arguments?.length !== expected.arguments?.length) return false;
  for (const actualArgument of actual.arguments ?? []) {
    const expectedArgument = expected.arguments?.find(
      (a) => a.name === actualArgument.name && a.kind === actualArgument.kind,
    );
    if (!expectedArgument) return false;

    if (actualArgument.kind === "template" && isSameResponse(actualArgument, expectedArgument as TypespecTemplateModel))
      return false;

    if (actualArgument.additionalProperties !== undefined) return false; // Attention: expected.additionalProperties is always undefined
  }
  if (actual.additionalProperties !== undefined) return false; // Attention: expected.additionalProperties is always undefined

  return true;
}

function getOtherProperties(
  schema: ArmResourceSchema,
  resourceKind: ArmResourceKind,
): (TypespecObjectProperty | TypespecSpreadStatement)[] {
  const knownProperties = ["properties", "name", "id", "type", "systemData"];
  if (resourceKind === "TrackedResource" || resourceKind === "Legacy.TrackedResourceWithOptionalLocation") {
    knownProperties.push(...["location", "tags"]);
  }
  const otherProperties: (TypespecObjectProperty | TypespecSpreadStatement)[] = [];
  for (const property of getAllProperties(schema)) {
    if (!knownProperties.includes(property.serializedName)) {
      const envolopeProperty = getEnvelopeProperty(property);
      otherProperties.push(
        envolopeProperty ?? {
          ...transformObjectProperty(property, getSession().model),
          suppressions: getOptions().isFullCompatible
            ? [getSuppressionWithCode(SuppressionCode.ArmResourceInvalidEnvelopeProperty)]
            : undefined,
        },
      );
    }
  }
  return otherProperties;
}

function getBodyDecorators(
  bodyParam: Parameter | undefined,
  tspOperationGroupName: string,
  operationName: string,
  templateName: string,
  templateDoc: string,
): [string[], TypespecDecorator[]] {
  const { isFullCompatible } = getOptions();

  const augmentedDecorators = [];
  const clientDecorators = [];
  if (bodyParam) {
    if (bodyParam.language.default.name !== templateName && isFullCompatible) {
      clientDecorators.push(
        createClientNameDecorator(
          `${tspOperationGroupName}.${operationName}::parameters.${templateName}`,
          `${bodyParam.language.default.name}`,
        ),
      );
    }
    if (bodyParam.language.default.description !== templateDoc) {
      augmentedDecorators.push(
        `@@doc(${tspOperationGroupName}.\`${operationName}\`::parameters.${templateName}, "${bodyParam.language.default.description}");`,
      );
    }
  }
  return [augmentedDecorators, clientDecorators];
}

function buildNewArmOperation(
  resourceMetadata: ArmResource,
  operation: _ArmResourceOperation,
  swaggerOperation: Operation,
  kind: TspArmOperationType,
): TspArmResourceOperationBase {
  const { removeOperationId, isFullCompatible } = getOptions();
  const { baseParameters, parameters } = buildOperationParameters(swaggerOperation, resourceMetadata);
  const interfaceName = getTSPOperationGroupName(resourceMetadata);
  const armOperation: TspArmResourceOperationBase = {
    doc: operation.Description,
    kind,
    name: getOperationName(interfaceName, operation.OperationID),
    resource: resourceMetadata.SwaggerModelName,
    baseParameters: baseParameters.length > 0 ? baseParameters : undefined,
    parameters: parameters.length > 0 ? parameters : undefined,
    operationId: operation.OperationID,
    examples: swaggerOperation.extensions?.["x-ms-examples"],
    clientDecorators: getOperationClientDecorators(swaggerOperation),
  };

  const swaggerOperationGroupName = getSwaggerOperationGroupName(operation.OperationID);
  if (swaggerOperationGroupName !== capitalize(interfaceName)) {
    armOperation.clientDecorators!.push({
      name: "clientLocation",
      module: "@azure-tools/typespec-client-generator-core",
      namespace: "Azure.ClientGenerator.Core",
      arguments: [swaggerOperationGroupName],
    });
  }

  const swaggerOperationName = getSwaggerOperationName(operation.OperationID);
  if (swaggerOperationName !== capitalize(armOperation.name)) {
    armOperation.clientDecorators!.push({
      name: "clientName",
      module: "@azure-tools/typespec-client-generator-core",
      namespace: "Azure.ClientGenerator.Core",
      arguments: [swaggerOperationName],
    });
  }

  const operationIdFromClient = `${capitalize(swaggerOperationGroupName) ? `${capitalize(swaggerOperationGroupName)}_` : ""}${capitalize(swaggerOperationName)}`;
  const operationIdFromMain = `${capitalize(interfaceName) ? `${capitalize(interfaceName)}_` : ""}${capitalize(armOperation.name)}`;

  if (
    (operationIdFromClient !== operation.OperationID && isFullCompatible) ||
    (removeOperationId === false && operationIdFromMain !== operation.OperationID)
  ) {
    armOperation.decorators = armOperation.decorators ?? [];
    armOperation.decorators.push({
      name: "operationId",
      arguments: [operation.OperationID],
      module: "@typespec/openapi",
      namespace: "TypeSpec.OpenAPI",
      suppressionCode: "@azure-tools/typespec-azure-core/no-openapi",
      suppressionMessage: "non-standard operations",
    });
  }

  if (resourceMetadata.ScopeType === "Scope") {
    armOperation.baseParameters = undefined;
    armOperation.targetResource = "Extension.ScopeParameter";
    armOperation.extensionResource = armOperation.resource;
  } else if (resourceMetadata.ScopeType === "ManagementGroup") {
    armOperation.baseParameters = undefined;
    armOperation.targetResource = "Extension.ManagementGroup";
    armOperation.extensionResource = armOperation.resource;
  } else if (resourceMetadata.ScopeType === "Extension") {
    armOperation.baseParameters = undefined;
  }

  if (operation.PagingMetadata && !armOperation.kind.includes("List")) {
    armOperation.decorators = armOperation.decorators ?? [];
    armOperation.decorators.push({
      name: "list",
    });
  }
  return armOperation;
}

function buildSuppressionsForArmOperation(
  operation: TspArmResourceOperationBase,
  asyncNames: NamesOfResponseTemplate,
  syncNames: NamesOfResponseTemplate,
) {
  if (!getOptions().isFullCompatible) return;

  if (
    operation.response &&
    (operation.kind === "ArmResourceCreateOrReplaceAsync" || operation.kind === "ArmResourceCreateOrReplaceSync")
  ) {
    const armPutOperationResponseCodes = checkArmPutOperationResponseCodes(
      operation.response as TypespecTemplateModel[],
      asyncNames,
      syncNames,
    );
    if (armPutOperationResponseCodes) {
      operation.suppressions = operation.suppressions ?? [];
      operation.suppressions.push(armPutOperationResponseCodes);
    }
  }

  if (operation.response) {
    const noResponseBody = checkNoResponseBody(operation.response as TypespecTemplateModel[], asyncNames, syncNames);
    if (noResponseBody) {
      operation.suppressions = operation.suppressions ?? [];
      operation.suppressions.push(noResponseBody);
    }
  }

  if (
    operation.response &&
    (operation.kind === "ArmResourceDeleteWithoutOkAsync" || operation.kind === "ArmResourceDeleteSync")
  ) {
    const armDeleteOperationResponseCodes = checkArmDeleteOperationResponseCodes(
      operation.response as TypespecTemplateModel[],
      asyncNames,
      syncNames,
    );
    if (armDeleteOperationResponseCodes) {
      operation.suppressions = operation.suppressions ?? [];
      operation.suppressions.push(armDeleteOperationResponseCodes);
    }
  }
}

const existingNames: { [interfaceName: string]: Set<string> } = {};
// TO-DO: Figure out a way to create a new name if the name exists
function getOperationName(interfaceName: string, operationId: string): string {
  if (!operationId) return "";

  let operationName = _.lowerFirst(_.last(operationId.split("_")));
  if (interfaceName in existingNames) {
    if (existingNames[interfaceName].has(operationName)) {
      operationName = _.lowerFirst(
        operationId
          .split("_")
          .map((n) => _.upperFirst(n))
          .join(""),
      );
    }
    existingNames[interfaceName].add(operationName);
  } else {
    existingNames[interfaceName] = new Set<string>([operationName]);
  }
  return operationName;
}

function getPathParameters(
  resource: ArmResource,
): { segmentName: string; keyName: string; pattern: string; description: string | undefined }[] {
  const pathParameters = [];
  const pathSegments = resource.GetOperation!.Path.split("/").filter((s) => s !== "");

  if (pathSegments[1] === "providers" && pathSegments[0].startsWith("{") && pathSegments[0].endsWith("}")) {
    pathParameters.push({
      keyName: pathSegments[0].replace("{", "").replace("}", ""),
      segmentName: "",
      pattern: "",
      description: undefined,
    });
    pathSegments.shift();
  }
  for (let i = 0; i + 1 < pathSegments.length; i += 2) {
    const operation = getSession()
      .model.operationGroups.flatMap((og) => og.operations)
      .find((o) => o.operationId === resource.GetOperation!.OperationID);

    const keyName = pathSegments[i + 1].replace("{", "").replace("}", "");
    const parameter = operation?.parameters?.find((p) => p.language.default.serializedName === keyName);
    const pattern =
      parameter && isStringSchema(parameter.schema) && parameter.schema.pattern
        ? escapeRegex(parameter.schema.pattern)
        : "";

    pathParameters.push({
      segmentName: pathSegments[i],
      keyName,
      pattern,
      description: parameter?.language.default.description,
    });
  }
  return pathParameters;
}

function buildOperationParameters(
  operation: Operation,
  resource: ArmResource,
): { baseParameters: string[]; parameters: TypespecParameter[] } {
  const codeModel = getSession().model;
  const otherParameters: TypespecParameter[] = [];
  const pathParameters = getPathParameters(resource).map((p) => p.keyName);
  pathParameters.push("api-version");
  pathParameters.push("$host");
  if (operation.parameters) {
    for (const parameter of operation.parameters) {
      if (resource.IsSingletonResource && parameter.schema.type === SchemaType.Constant) {
        continue;
      }
      if (!pathParameters.includes(parameter.language.default.serializedName)) {
        otherParameters.push(transformParameter(parameter, codeModel));
      }
    }
  }

  // By default we don't need any base parameters.
  const parameterTemplate: string[] = [];
  if (resource.ScopeType === "Tenant") {
    parameterTemplate.push(getFullyQualifiedName("TenantBaseParameters"));
  } else if (resource.ScopeType === "Subscription") {
    parameterTemplate.push(getFullyQualifiedName("SubscriptionBaseParameters"));
  }

  return {
    baseParameters: parameterTemplate,
    parameters: otherParameters,
  };
}

function getKeyParameter(resourceMetadata: ArmResource): Parameter | undefined {
  for (const operationGroup of getSession().model.operationGroups) {
    for (const operation of operationGroup.operations) {
      if (operation.operationId === resourceMetadata.GetOperation!.OperationID) {
        for (const parameter of operation.parameters ?? []) {
          if (parameter.language.default.serializedName === resourceMetadata.ResourceKey) {
            return parameter;
          }
        }
      }
    }
  }
}

function getParentResource(schema: ArmResourceSchema): TspArmResource | undefined {
  const resourceParent = schema.resourceMetadata[0].Parents?.[0];

  if (!resourceParent || isFirstLevelResource(resourceParent)) {
    return undefined;
  }

  for (const objectSchema of getSession().model.schemas.objects ?? []) {
    if (!isResourceSchema(objectSchema)) {
      continue;
    }

    if (objectSchema.resourceMetadata[0].Name === resourceParent) {
      return transformTspArmResource(objectSchema);
    }
  }
}

function getResourceKind(schema: ArmResourceSchema, resourceParent: TspArmResource | undefined): ArmResourceKind {
  if (schema.language.default.name === "PrivateEndpointConnection" && isCommonTypeModel(schema.language.default.name)) {
    if (resourceParent === undefined) {
      logger().warning(`PrivateEndpointConnection resource is missing parent resource. Change to normal resource.`);
    } else return "PrivateEndpointConnectionResource";
  }

  if (schema.resourceMetadata[0].ScopeType === "Scope") {
    return "ExtensionResource";
  }

  if (schema.resourceMetadata[0].IsTrackedResourceWithOptionalLocation) {
    return "Legacy.TrackedResourceWithOptionalLocation";
  }

  if (schema.resourceMetadata[0].IsTrackedResource) {
    return "TrackedResource";
  }

  return "ProxyResource";
}

function buildKeyAugmentDecorators(
  schema: ArmResourceSchema,
  keyProperty: TypespecSpreadStatement,
  resourceKind: ArmResourceKind,
): TypespecDecorator[] {
  return (
    keyProperty.decorators
      ?.filter((d) => !["pattern", "key", "segment", "path"].includes(d.name))
      .filter((d) => !(d.name === "visibility" && d.arguments?.[0] === "read"))
      .map((d) => {
        d.target = `${schema.resourceMetadata[0].SwaggerModelName}.name`;
        return d;
      }) ?? []
  ).concat(
    resourceKind !== "PrivateEndpointConnectionResource"
      ? {
          name: "doc",
          target: `${schema.resourceMetadata[0].SwaggerModelName}.name`,
          arguments: [generateDocsContent(keyProperty)],
        }
      : [],
  );
}

function buildPropertiesAugmentDecorators(schema: ArmResourceSchema, propertiesModel: Property): TypespecDecorator[] {
  return [
    {
      name: "doc",
      target: `${schema.resourceMetadata[0].SwaggerModelName}.properties`,
      arguments: [generateDocsContent({ doc: propertiesModel?.language.default.description })],
    },
  ];
}

function buildKeyProperty(schema: ArmResourceSchema): TypespecSpreadStatement {
  let decorators;
  let namePattern;
  let keyName;
  let type = "string";
  let doc;
  const segmentName = schema.resourceMetadata[0].ResourceKeySegment;
  if (!schema.resourceMetadata[0].IsSingletonResource) {
    const keyProperty = getKeyParameter(schema.resourceMetadata[0]);
    if (keyProperty === undefined) {
      logger().error(
        `Failed to find key property ${schema.resourceMetadata[0].ResourceKey} for ${schema.language.default.name}`,
      );
    }
    decorators = getPropertyDecorators(keyProperty!);
    namePattern = decorators.find((d) => d.name === "pattern")?.arguments?.[0];
    keyName = schema.resourceMetadata[0].ResourceKey;

    const codeModel = getSession().model;
    const dataTypes = getDataTypes(codeModel);
    const visited = dataTypes.get(keyProperty!.schema) ?? transformDataType(keyProperty!.schema, codeModel);
    type = visited.name;

    doc = keyProperty!.language.default.description;
  } else {
    keyName = singular(schema.resourceMetadata[0].ResourceKeySegment);
  }

  const keyProperty: TypespecSpreadStatement = {
    kind: "spread",
    model: {
      kind: "template",
      name: "ResourceNameParameter",
      namedArguments: { Resource: schema.resourceMetadata[0].SwaggerModelName },
    },
    decorators,
    doc,
  };
  if (keyName) keyProperty.model.namedArguments!["KeyName"] = `"${keyName}"`;
  if (segmentName) keyProperty.model.namedArguments!["SegmentName"] = `"${segmentName}"`;
  if (namePattern !== "^[a-zA-Z0-9-]{3,24}$")
    keyProperty.model.namedArguments!["NamePattern"] = (namePattern as string) ? `"${namePattern}"` : `""`;
  if (type !== "string") keyProperty.model.namedArguments!["Type"] = `${type}`;

  return keyProperty;
}

function buildResourceDecorators(schema: ArmResourceSchema): TypespecDecorator[] {
  const resourceModelDecorators: TypespecDecorator[] = [];

  if (schema.resourceMetadata[0].IsSingletonResource) {
    resourceModelDecorators.push({
      name: "singleton",
      arguments: [getSingletonName(schema)],
    });
  }

  if (schema.resourceMetadata[0].ScopeType === "Tenant") {
    resourceModelDecorators.push({
      name: "tenantResource",
    });
  } else if (schema.resourceMetadata[0].ScopeType === "Subscription") {
    resourceModelDecorators.push({
      name: "subscriptionResource",
    });
  }

  return resourceModelDecorators;
}

function buildResourceClientDecorators(schema: ArmResourceSchema): TypespecDecorator[] {
  const clientDecorator: TypespecDecorator[] = [];
  if (schema.language.csharp?.name) {
    clientDecorator.push(createCSharpNameDecorator(schema));
  }

  return clientDecorator;
}

function getSingletonName(schema: ArmResourceSchema): string {
  const key = schema.resourceMetadata[0].ResourceKey;
  const pathLast = schema.resourceMetadata[0].GetOperation!.Path.split("/").pop() ?? "";
  if (key !== pathLast) {
    if (pathLast?.includes("{")) {
      // this is from c# config, which need confirm with service
      return "default";
    } else {
      return pathLast;
    }
  }
  return key;
}

function getLocationParent(schema: ArmResourceSchema): string | undefined {
  if (schema.resourceMetadata[0].GetOperation!.Path.includes("/locations/")) {
    if (schema.resourceMetadata[0].ScopeType === "Tenant") {
      return "TenantLocationResource";
    } else if (schema.resourceMetadata[0].Parents?.[0] === "ResourceGroupResource") {
      return "ResourceGroupLocationResource";
    }
  }
}
