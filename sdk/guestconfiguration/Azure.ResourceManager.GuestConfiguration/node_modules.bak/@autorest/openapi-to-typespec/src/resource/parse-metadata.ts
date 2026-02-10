import { CodeModel, HttpMethod, Operation } from "@autorest/codemodel";
import { getOptions } from "../options";
import { getLogger } from "../utils/logger";
import { _ArmPagingMetadata, _ArmResourceOperation, ArmResource, Metadata } from "../utils/resource-discovery";
import { lastWordToSingular } from "../utils/strings";
import {
  getExtensionOperation,
  getOtherOperations,
  getParents,
  getResourceCollectionOperations,
  setParentOfExtensionOperation,
  setParentOfOtherOperation,
  setParentOfResourceCollectionOperation,
} from "./find-parent";
import {
  findOperation,
  getResourceDataSchema,
  OperationSet,
  populateSingletonRequestPath,
  setResourceDataSchema,
} from "./operation-set";
import { getPagingItemType, isTrackedResource } from "./resource-equivalent";
import { getExtensionResourceType, getResourceKey, getResourceKeySegment, getResourceType, isSingleton } from "./utils";

const logger = () => getLogger("parse-metadata");

export function parseMetadata(codeModel: CodeModel, configuration: Record<string, any>): Metadata {
  const { isFullCompatible } = getOptions();

  const operationSets: { [path: string]: OperationSet } = {};
  const operations = codeModel.operationGroups.flatMap((og) => og.operations);
  for (const operation of operations) {
    const path = getNormalizeHttpPath(operation);
    if (path in operationSets) {
      operationSets[path].Operations.push(operation);
    } else {
      operationSets[path] = { RequestPath: path, Operations: [operation], SingletonRequestPath: undefined };
    }
  }

  const operationSetsByResourceDataSchemaName: { [name: string]: OperationSet[] } = {};
  for (const key in operationSets) {
    const operationSet = operationSets[key];
    let resourceSchemaName = getResourceDataSchema(operationSet);
    if (resourceSchemaName === undefined) {
      const resourceDataConfiguration = configuration["request-path-to-resource-data"] as Record<string, string>;
      const configuredName = resourceDataConfiguration
        ? resourceDataConfiguration[operationSet.RequestPath]
        : undefined;
      if (configuredName && codeModel.schemas.objects?.find((o) => o.language.default.name === configuredName)) {
        resourceSchemaName = configuredName;
        setResourceDataSchema(operationSet, resourceSchemaName);
      }
    }
    if (resourceSchemaName !== undefined) {
      populateSingletonRequestPath(operationSet);
      if (resourceSchemaName in operationSetsByResourceDataSchemaName) {
        operationSetsByResourceDataSchemaName[resourceSchemaName].push(operationSet);
      } else {
        operationSetsByResourceDataSchemaName[resourceSchemaName] = [operationSet];
      }
    }
  }

  for (const key in operationSets) {
    const operationSet = operationSets[key];
    if (getResourceDataSchema(operationSet)) continue;

    for (const operation of operationSet.Operations) {
      // Check if this operation is a collection operation
      if (
        setParentOfResourceCollectionOperation(
          operation,
          key,
          Object.values(operationSetsByResourceDataSchemaName).flat(),
        )
      )
        continue;

      // Otherwise we find a request path that is the longest parent of this, and belongs to a resource
      if (setParentOfOtherOperation(operation, key, Object.values(operationSetsByResourceDataSchemaName).flat()))
        continue;

      setParentOfExtensionOperation(operation, key, Object.values(operationSetsByResourceDataSchemaName).flat());
    }
  }

  const resources: { [name: string]: ArmResource[] } = {};
  for (const resourceSchemaName in operationSetsByResourceDataSchemaName) {
    const operationSets = operationSetsByResourceDataSchemaName[resourceSchemaName];

    for (let index = 0; index < operationSets.length; index++) {
      if (index >= 1 && !isFullCompatible) {
        logger().info(
          `Multi-path operations applied on the same resource. Some operations will be lost. \nResource schema name: ${resourceSchemaName}.\nPath:\n${operationSets
            .map((o) => o.RequestPath)
            .join("\n")}\nTurn on isFullCompatible to keep all operations, or adjust your TypeSpec.`,
        );
        resources[resourceSchemaName + "FixMe"] = [
          {
            Name: resourceSchemaName + "FixMe",
            GetOperation: undefined,
            ExistOperation: undefined,
            CreateOperation: undefined,
            UpdateOperation: undefined,
            DeleteOperation: undefined,
            ListOperations: [],
            OperationsFromResourceGroupExtension: [],
            OperationsFromSubscriptionExtension: [],
            OperationsFromManagementGroupExtension: [],
            OperationsFromTenantExtension: [],
            OtherOperations: [],
            Parents: [],
            SwaggerModelName: "",
            ResourceType: "",
            ResourceKey: "",
            ResourceKeySegment: "",
            IsTrackedResource: false,
            IsTrackedResourceWithOptionalLocation: false,
            IsManagementGroupResource: false,
            ScopeType: "NA",
            IsSingletonResource: false,
          },
        ];
        break;
      }
      (resources[resourceSchemaName] ??= []).push(
        buildResource(
          resourceSchemaName,
          operationSets[index],
          Object.values(operationSetsByResourceDataSchemaName).flat(),
          codeModel,
        ),
      );
    }
  }

  return {
    Resources: resources,
    RenameMapping: {},
    OverrideOperationName: {},
  };
}

// TO-DO: handle expanded resource
function buildResource(
  resourceSchemaName: string,
  set: OperationSet,
  operationSets: OperationSet[],
  codeModel: CodeModel,
): ArmResource {
  const getOperation = buildLifeCycleOperation(set, HttpMethod.Get, "Get");
  if (getOperation === undefined) {
    logger().error(`Resource ${resourceSchemaName} must have a GET operation.`);
  }
  const createOperation = buildLifeCycleOperation(set, HttpMethod.Put, "CreateOrUpdate");
  const updateOperation =
    buildLifeCycleOperation(set, HttpMethod.Patch, "Update") ?? buildLifeCycleOperation(set, HttpMethod.Put, "Update");
  const deleteOperation = buildLifeCycleOperation(set, HttpMethod.Delete, "Delete");
  const existOperation = buildLifeCycleOperation(set, HttpMethod.Head, "CheckExistence");
  const listOperation = buildListOperation(set);
  const otherOperation = buildOtherOperation(set);

  const resourceSchema = codeModel.schemas.objects?.find((o) => o.language.default.name === resourceSchemaName);
  if (!resourceSchema) {
    logger().error(`Cannot find resource schema for name ${resourceSchemaName}`);
  }

  const parents = getParents(set.RequestPath, operationSets);
  const isManagementGroupResource = parents.length > 0 && parents[0] === "ManagementGroupResource";

  const operationsFromResourceGroupExtension = [];
  const operationsFromSubscriptionExtension = [];
  const operationsFromManagementGroupExtension = [];
  const operationsFromTenantExtension = [];

  for (const extension of getExtensionOperation(set)) {
    const extensionOperation = buildResourceOperationFromOperation(extension[0], "_");
    switch (extension[1]) {
      case "ResourceGroup":
        operationsFromResourceGroupExtension.push(extensionOperation);
        break;
      case "Subscription":
        operationsFromSubscriptionExtension.push(extensionOperation);
        break;
      case "ManagementGroup":
        operationsFromManagementGroupExtension.push(extensionOperation);
        break;
      case "Tenant":
        operationsFromTenantExtension.push(extensionOperation);
        break;
    }
  }

  const [isStandardTrackedResource, isOptionalLocation] = isTrackedResource(resourceSchema!);
  return {
    Name: lastWordToSingular(resourceSchemaName),
    GetOperation: getOperation,
    ExistOperation: existOperation,
    CreateOperation: createOperation,
    UpdateOperation: updateOperation,
    DeleteOperation: deleteOperation,
    ListOperations: listOperation ?? [],
    OperationsFromResourceGroupExtension: operationsFromResourceGroupExtension,
    OperationsFromSubscriptionExtension: operationsFromSubscriptionExtension,
    OperationsFromManagementGroupExtension: operationsFromManagementGroupExtension,
    OperationsFromTenantExtension: operationsFromTenantExtension,
    OtherOperations: otherOperation,
    Parents: parents,
    SwaggerModelName: resourceSchemaName,
    ResourceType: getResourceType(set.RequestPath),
    ResourceKey: getResourceKey(set.RequestPath),
    ResourceKeySegment: getResourceKeySegment(set.RequestPath),
    IsTrackedResource: isStandardTrackedResource,
    IsTrackedResourceWithOptionalLocation: isStandardTrackedResource && isOptionalLocation,
    IsManagementGroupResource: isManagementGroupResource,
    ScopeType: getExtensionResourceType(set.RequestPath),
    IsSingletonResource: isSingleton(set),
  };
}

function buildResourceOperationFromOperation(operation: Operation, operationName: string): _ArmResourceOperation {
  let pagingMetadata: _ArmPagingMetadata | null = null;
  const pagingItemType = getPagingItemType(operation, true);
  if (operationName === "GetAll" || pagingItemType !== undefined) {
    let itemName = "value";
    let nextLinkName = null;
    if (operation.extensions?.["x-ms-pageable"]?.itemName) {
      itemName = operation.extensions?.["x-ms-pageable"]?.itemName;
    }
    if (operation.extensions?.["x-ms-pageable"]?.nextLinkName) {
      nextLinkName = operation.extensions?.["x-ms-pageable"]?.nextLinkName;
    }

    pagingMetadata = {
      Method: operation.language.default.name,
      ItemName: itemName,
      NextLinkName: nextLinkName,
    };
  }

  const method = operation.requests![0].protocol.http?.method;
  return {
    Name: operationName,
    Path: operation.requests![0].protocol.http?.path,
    Method: method.toUpperCase(),
    OperationID: operation.operationId ?? "",
    IsLongRunning:
      operation.extensions?.["x-ms-long-running-operation"] === true ||
      method === HttpMethod.Put ||
      method === HttpMethod.Delete,
    PagingMetadata: pagingMetadata,
    Description: operation.language.default.description,
  };
}

function buildOtherOperation(set: OperationSet): _ArmResourceOperation[] {
  const operations = getOtherOperations(set);
  return operations.map((o) => buildResourceOperationFromOperation(o, o.language.default.name));
}

function buildListOperation(set: OperationSet): _ArmResourceOperation[] | undefined {
  const operation = getResourceCollectionOperations(set);
  return operation?.length ? operation.map((o) => buildResourceOperationFromOperation(o, "GetAll")) : undefined;
}

function buildLifeCycleOperation(
  set: OperationSet,
  method: HttpMethod,
  operationName: string,
): _ArmResourceOperation | undefined {
  const operation = findOperation(set, method);
  return operation ? buildResourceOperationFromOperation(operation, operationName) : undefined;
}

function getNormalizeHttpPath(operation: Operation): string {
  if (operation.requests?.length !== 1) {
    throw `No request or more than 1 requests in operation ${operation.operationId}`;
  }

  const path = operation.requests![0].protocol.http?.path;
  const normalizedPath = path?.length === 1 ? path : path?.replace(/\/$/, "");
  if (!normalizedPath) throw `Invalid http path ${path} for operation ${operation.operationId}`;
  return normalizedPath;
}
