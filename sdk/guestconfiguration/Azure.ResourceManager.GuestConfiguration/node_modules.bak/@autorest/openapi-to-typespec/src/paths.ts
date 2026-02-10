import { CodeModel } from "@autorest/codemodel";

export interface PathDetails {}

export type Paths = Map<string, PathDetails>;

export function getAllPaths(model: CodeModel) {
  const paths: Paths = new Map();
  for (const _operationGroup of model.operationGroups) {
    for (const operation of model.operationGroups) {
      const path = operation.protocol.http?.path;
      if (!path) {
        continue;
      }
      paths.set(operation.protocol.http?.path, {});
    }
  }

  return paths;
}
