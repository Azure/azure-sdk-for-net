// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { UsageFlags } from "@azure-tools/typespec-client-generator-core";

export interface LiteralTypeContext {
  ModelName: string;
  PropertyName: string;
  Usage: UsageFlags;
}
