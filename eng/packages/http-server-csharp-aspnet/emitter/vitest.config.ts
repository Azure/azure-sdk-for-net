// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { defineConfig } from "vitest/config";

export default defineConfig({
  test: {
    root: "./emitter",
    include: ["test/**/*.test.ts"]
  }
});
