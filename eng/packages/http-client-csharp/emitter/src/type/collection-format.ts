// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export enum CollectionFormat {
  CSV = "csv",
  Simple = "simple",
  SSV = "ssv",
  TSV = "tsv",
  Pipes = "pipes",
  Multi = "multi",
  Form = "form",
}

export const collectionFormatToDelimMap: {
  [key: string]: string | undefined;
} = {
  [CollectionFormat.CSV.toString()]: ",",
  [CollectionFormat.Simple.toString()]: ",", // csv and simple are used interchangeably
  [CollectionFormat.SSV.toString()]: " ",
  [CollectionFormat.TSV.toString()]: "\t",
  [CollectionFormat.Pipes.toString()]: "|",
  [CollectionFormat.Multi.toString()]: undefined,
  [CollectionFormat.Form.toString()]: undefined, // multi and form are used interchangeably
};
