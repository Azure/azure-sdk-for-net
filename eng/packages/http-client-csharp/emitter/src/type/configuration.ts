// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface Configuration {
  "output-folder": string;
  namespace: string;
  "library-name": string | null;
  flavor?: string;
  "single-top-level-client"?: boolean;
  "unreferenced-types-handling"?: "removeOrInternalize" | "internalize" | "keepAll";
  "model-namespace"?: boolean;
  "models-to-treat-empty-string-as-null"?: string[];
  "additional-intrinsic-types-to-treat-empty-string-as-null"?: string[];
  "methods-to-keep-client-default-value"?: string[];
  "keep-non-overloadable-protocol-signature"?: boolean;
  "intrinsic-types-to-treat-empty-string-as-null"?: string[];
  "head-as-boolean"?: boolean;
  "deserialize-null-collection-as-null-value"?: boolean;
  "generate-sample-project"?: boolean;
  "generate-test-project"?: boolean;
  "use-model-reader-writer"?: boolean;
  "disable-xml-docs"?: boolean;
}
