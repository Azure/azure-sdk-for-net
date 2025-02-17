// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
import { Type } from "@typespec/compiler";

export enum BodyMediaType {
  None = "None",
  Binary = "Binary",
  Form = "Form",
  Json = "Json",
  Multipart = "Multipart",
  Text = "Text",
  Xml = "Xml",
}

export function typeToBodyMediaType(type: Type | undefined) {
  if (type === undefined) {
    return BodyMediaType.None;
  }

  if (type.kind === "Model") {
    return BodyMediaType.Json;
  } else if (type.kind === "String") {
    return BodyMediaType.Text;
  } else if (type.kind === "Scalar" && type.name === "bytes") {
    return BodyMediaType.Binary;
  }
  return BodyMediaType.None;
}
