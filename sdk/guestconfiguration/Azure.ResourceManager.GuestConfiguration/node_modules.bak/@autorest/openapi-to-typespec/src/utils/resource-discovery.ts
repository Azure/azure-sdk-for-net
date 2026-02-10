import { CodeModel, isObjectSchema, ObjectSchema, Operation, SchemaResponse } from "@autorest/codemodel";
import { getSession, isCommonTypeModel } from "../autorest-session";
import { TypespecObject, TypespecEnum } from "../interfaces";
import { getSkipList } from "./type-mapping";
export interface _ArmResourceOperation {
  Name: string;
  Path: string;
  Method: string;
  OperationID: string;
  IsLongRunning: boolean;
  Description?: string;
  PagingMetadata: _ArmPagingMetadata | null;
}

export interface _ArmPagingMetadata {
  Method: string;
  ItemName: string;
  NextLinkName: string;
}

export interface Metadata {
  Resources: Record<string, ArmResource[]>;
  RenameMapping: Record<string, string>;
  OverrideOperationName: Record<string, string>;
}

export interface ArmResource {
  Name: string;
  GetOperation?: _ArmResourceOperation;
  ExistOperation?: _ArmResourceOperation;
  CreateOperation?: _ArmResourceOperation;
  UpdateOperation?: _ArmResourceOperation;
  DeleteOperation?: _ArmResourceOperation;
  ListOperations: _ArmResourceOperation[];
  OperationsFromResourceGroupExtension: _ArmResourceOperation[];
  OperationsFromSubscriptionExtension: _ArmResourceOperation[];
  OperationsFromManagementGroupExtension: _ArmResourceOperation[];
  OperationsFromTenantExtension: _ArmResourceOperation[];
  OtherOperations: _ArmResourceOperation[];
  Parents: string[];
  SwaggerModelName: string;
  ResourceType: string;
  ResourceKey: string;
  ResourceKeySegment: string;
  IsTrackedResource: boolean;
  IsTrackedResourceWithOptionalLocation: boolean;
  IsManagementGroupResource: boolean;
  ScopeType: ScopeType;
  IsSingletonResource: boolean;
}

export type ScopeType = "NA" | "Scope" | "Tenant" | "Subscription" | "ResourceGroup" | "ManagementGroup" | "Extension";

export function isExtensionScopeType(scopeType: ScopeType): boolean {
  return ["Scope", "Tenant", "Subscription", "ManagementGroup", "Extension"].includes(scopeType);
}

export interface OperationWithResourceOperationFlag extends Operation {
  isResourceOperation?: boolean;
}

export function getResourceOperations(resource: ArmResource): Record<string, Operation> {
  const operations: Record<string, Operation> = {};
  const codeModel = getSession().model;

  const allOperations: _ArmResourceOperation[] = (
    [
      resource.GetOperation,
      resource.CreateOperation,
      resource.ExistOperation,
      resource.UpdateOperation,
      resource.DeleteOperation,
    ].filter((o) => o !== undefined) as _ArmResourceOperation[]
  )
    .concat(resource.ListOperations)
    .concat(resource.OperationsFromResourceGroupExtension)
    .concat(resource.OperationsFromSubscriptionExtension)
    .concat(resource.OperationsFromManagementGroupExtension)
    .concat(resource.OperationsFromTenantExtension)
    .concat(resource.OtherOperations);
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      for (const operationMetadata of allOperations) {
        if (operation.operationId === operationMetadata.OperationID) {
          operations[operation.operationId] = operation;
          (operation as OperationWithResourceOperationFlag).isResourceOperation = true;
        }
      }
    }
  }

  return operations;
}

export function getSingletonResouceListOperation(resource: ArmResource): Operation | undefined {
  const codeModel = getSession().model;

  if (resource.IsSingletonResource) {
    let predictSingletonResourcePath: string | undefined;
    if (resource.IsSingletonResource) {
      predictSingletonResourcePath = resource.GetOperation!.Path.split("/").slice(0, -1).join("/");
    }

    for (const operationGroup of codeModel.operationGroups) {
      for (const operation of operationGroup.operations) {
        // for singleton resource, c# will drop the list operation but we need to get it back
        if (
          operation.requests?.length &&
          operation.requests[0].protocol?.http?.path === predictSingletonResourcePath &&
          operation.requests[0].protocol.http?.method === "get"
        ) {
          return operation;
        }
      }
    }
  }
}

export function getResourceExistOperation(resource: ArmResource): Operation | undefined {
  const codeModel = getSession().model;
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      if (
        operation.requests?.length &&
        operation.requests[0].protocol?.http?.path === resource.GetOperation!.Path &&
        operation.requests[0].protocol.http?.method === "head"
      ) {
        return operation;
      }
    }
  }
}

export interface ArmResourceSchema extends ObjectSchema {
  resourceMetadata: ArmResource[];
}

export interface ArmResourcePropertiesModel extends ObjectSchema {
  isPropertiesModel: boolean;
}

export function tagSchemaAsResource(schema: ObjectSchema, metadata: Metadata): void {
  const resourcesMetadata = metadata.Resources;

  for (const resourceName in resourcesMetadata) {
    if (resourcesMetadata[resourceName][0].SwaggerModelName === schema.language.default.name) {
      (schema as ArmResourceSchema).resourceMetadata = resourcesMetadata[resourceName];
      const propertiesModel = schema.properties?.find((p) => p.serializedName === "properties");
      if (propertiesModel && isObjectSchema(propertiesModel.schema)) {
        (propertiesModel.schema as ArmResourcePropertiesModel).isPropertiesModel = true;
      }
      return;
    }
  }
}

export function isResourceSchema(schema: ObjectSchema): schema is ArmResourceSchema {
  return Boolean((schema as ArmResourceSchema).resourceMetadata);
}

export function filterArmModels(codeModel: CodeModel, objects: TypespecObject[]): TypespecObject[] {
  const filtered: string[] = [];
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      if (operation.requests?.[0].protocol?.http?.path.match(/^\/providers\/[^/]+\/operations$/)) {
        const okResponse = operation.responses?.filter((o) => o.protocol.http?.statusCodes.includes("200"))?.[0];
        const objectName = (okResponse as SchemaResponse)?.schema?.language.default.name;
        if (objectName) {
          filtered.push(objectName);
        }
      }
    }
  }
  filtered.push(
    ...(codeModel.schemas.objects?.filter((o) => isResourceSchema(o)).map((o) => o.language.default.name) ?? []),
  );
  filtered.push(...getSkipList());
  return objects.filter((o) => !filtered.includes(o.name) && !isCommonTypeModel(o.name));
}

export function filterArmEnums(enums: TypespecEnum[]): TypespecEnum[] {
  return enums.filter((e) => !isCommonTypeModel(e.name));
}
