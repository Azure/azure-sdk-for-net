import pluralize from "pluralize";
import { getSession } from "../autorest-session";
import { getOptions } from "../options";
import { ArmResource } from "./resource-discovery";

const operationGroupNameCache: Map<ArmResource, string> = new Map<ArmResource, string>();
export function getTSPOperationGroupName(resourceMetadata: ArmResource): string {
  if (operationGroupNameCache.has(resourceMetadata)) return operationGroupNameCache.get(resourceMetadata)!;

  // Try pluralizing the resource name first
  let operationGroupName = pluralize(resourceMetadata.SwaggerModelName);
  if (operationGroupName !== resourceMetadata.SwaggerModelName && !isExistingOperationGroupName(operationGroupName)) {
    operationGroupNameCache.set(resourceMetadata, operationGroupName);
  } else {
    // Try operationId then
    operationGroupName = resourceMetadata.GetOperation!.OperationID.split("_")[0];
    if (operationGroupName !== resourceMetadata.SwaggerModelName && !isExistingOperationGroupName(operationGroupName)) {
      operationGroupNameCache.set(resourceMetadata, operationGroupName);
    } else {
      operationGroupName = `${resourceMetadata.SwaggerModelName}OperationGroup`;
      operationGroupNameCache.set(resourceMetadata, operationGroupName);
    }
  }
  return operationGroupName;
}

export function getSwaggerOperationGroupName(operationId: string): string {
  const splittedOperationId = operationId.split("_");
  return splittedOperationId.length === 2 ? splittedOperationId[0] : "";
}

function isExistingOperationGroupName(operationGroupName: string): boolean {
  const codeModel = getSession().model;
  return (
    codeModel.schemas.objects?.find((o) => o.language.default.name === operationGroupName) !== undefined ||
    isInterfaceName(operationGroupName)
  );
}

export function getSwaggerOperationName(operationId: string): string {
  const splittedOperationId = operationId.split("_");
  return splittedOperationId.length === 2 ? splittedOperationId[1] : operationId;
}

const nonResourceOperationGroupNameCache: Set<string> = new Set<string>();
export function getTSPNonResourceOperationGroupName(name: string): string {
  const operationGroupName = `${name}OperationGroup`;
  if (!isExistingOperationGroupName(operationGroupName)) {
    nonResourceOperationGroupNameCache.add(operationGroupName);
    return operationGroupName;
  }

  // Arm resource operation group name cannot be ended with "Operations"
  const groupName = getOptions().isArm ? `${name}NonResourceOperationGroup` : `${name}Operations`;
  nonResourceOperationGroupNameCache.add(groupName);
  return groupName;
}

export function isInterfaceName(name: string): boolean {
  return (
    Array.from(operationGroupNameCache.values()).find((v) => v === name) !== undefined ||
    nonResourceOperationGroupNameCache.has(name)
  );
}
