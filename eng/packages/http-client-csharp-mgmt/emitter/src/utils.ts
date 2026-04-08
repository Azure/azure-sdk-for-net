// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// All path-related utilities have been moved to resource-metadata.ts.
// This file re-exports them for backward compatibility with test imports.
export {
  isVariableSegment,
  RequestPath,
  findLongestPrefixMatch
} from "./resource-metadata.js";
