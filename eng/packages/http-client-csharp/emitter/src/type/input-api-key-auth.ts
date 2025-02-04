// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface InputApiKeyAuth {
  Name: string;
  In: ApiKeyLocation;
  Prefix?: string;
}

export type ApiKeyLocation = "header"; // | "query" | "cookie"; // we do not support query or cookie yet
