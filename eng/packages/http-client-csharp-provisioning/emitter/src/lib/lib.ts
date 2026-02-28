// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary } from "@typespec/compiler";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp-provisioning",
  diagnostics: {},
  emitter: {
    options: {} as any, // TODO: define provisioning-specific emitter options
  },
});
