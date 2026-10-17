// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface McpService {
  outputNamespace: string;
  metadataReferences: string[];
  composites: { path: string; reason: string }[];
}

export interface StaticMember {
  type: string;
  member: string;
}

export interface ToolConfiguration {
  id: string;
  group: string[];
  name: string;
  title: string;
  types: {
    catalog: string;
    options: string;
    binding: string;
    result: string;
    jsonContext: string;
  };
  commandType: string;
  descriptionOverride?: StaticMember;
  errorMessage: string;
  wire: {
    method: "GET" | "HEAD" | "OPTIONS" | "PUT" | "DELETE" | "POST" | "PATCH";
    path: string;
    uri: string;
    constants: { name: string; value: string | boolean | number | null }[];
  };
  options: {
    name: string;
    type: "string" | "bool" | "int" | "long" | "float" | "double" | "decimal";
    required: boolean;
    source?: string;
    description?: string;
    descriptionMember?: StaticMember;
  }[];
  binding: {
    method: string;
    description: string;
    returnType: string;
    parameters: { name: string; type: string; description: string }[];
    calls: {
      target: string;
      method: string;
      arguments: {
        variable?: string;
        member?: StaticMember;
        literal?: string | boolean | number | null;
        name?: string;
      }[];
      await: boolean;
      resultName?: string;
      resultType?: string;
    }[];
    returnVariable: string;
  };
  result: { name: string; type: string }[];
  safety: {
    destructive?: boolean;
    idempotent?: boolean;
    readOnly?: boolean;
    openWorld?: boolean;
  };
}

export interface McpCodeModel {
  namespace: string;
  metadataReferences: string[];
  composites: McpService["composites"];
  operations: (ToolConfiguration & { operationId: string })[];
}
