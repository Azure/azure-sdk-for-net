// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export enum RequestMethod {
  GET = "GET",
  POST = "POST",
  PUT = "PUT",
  PATCH = "PATCH",
  DELETE = "DELETE",
  HEAD = "HEAD",
  OPTIONS = "OPTIONS",
  TRACE = "TRACE",
  NONE = "",
}
export function parseHttpRequestMethod(method: string): RequestMethod {
  if (method.length === 3) {
    if (method.toLowerCase() === "get") return RequestMethod.GET;
    if (method.toLowerCase() === "put") return RequestMethod.PUT;
  } else if (method.length === 4) {
    if (method.toLowerCase() === "post") return RequestMethod.POST;
    if (method.toLowerCase() === "head") return RequestMethod.HEAD;
  } else {
    if (method.toLowerCase() === "patch") return RequestMethod.PATCH;
    if (method.toLowerCase() === "delete") return RequestMethod.DELETE;
    if (method.toLowerCase() === "options") return RequestMethod.OPTIONS;
    if (method.toLowerCase() === "trace") return RequestMethod.TRACE;
  }

  return RequestMethod.NONE;
}
