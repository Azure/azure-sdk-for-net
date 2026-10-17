// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface SafetyOverrides {
  destructive?: boolean;
  idempotent?: boolean;
  readOnly?: boolean;
  openWorld?: boolean;
}

export interface ToolIdentity {
  id: string;
  path: string;
  title?: string;
}

export interface McpCodeModel {
  namespace: string;
  commands: (ToolIdentity & {
    operationId: string;
    namespace: string;
    interfaceName?: string;
    name: string;
    title: string;
    safety: SafetyOverrides;
    parameterConstraints?: Record<
      string,
      {
        pattern?: string;
        minLength?: number;
        maxLength?: number;
      }
    >;
  })[];
}
