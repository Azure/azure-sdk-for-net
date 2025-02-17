// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export enum RequestLocation {
  None = "",
  Uri = "Uri",
  Path = "Path",
  Query = "Query",
  Header = "Header",
  Body = "Body",
}

export const requestLocationMap: { [key: string]: RequestLocation } = {
  path: RequestLocation.Path,
  query: RequestLocation.Query,
  header: RequestLocation.Header,
  body: RequestLocation.Body,
  uri: RequestLocation.Uri,
};
