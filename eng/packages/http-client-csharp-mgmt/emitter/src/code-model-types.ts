// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import type { emitAzureCodeModel } from "@azure-typespec/http-client-csharp";

export type CodeModelMutator = NonNullable<
  Parameters<typeof emitAzureCodeModel>[1]
>;
export type CodeModel = Parameters<CodeModelMutator>[0];
export type CSharpEmitterContext = Parameters<CodeModelMutator>[1];
export type InputClient = CodeModel["clients"][number];
export type InputModelType = CodeModel["models"][number];
