import { CodeModel, Schema } from "@autorest/codemodel";
import { TypespecDataType } from "./interfaces";

const dataTypes = new WeakMap<CodeModel, WeakMap<Schema, TypespecDataType>>();

export function getDataTypes(codeModel: CodeModel) {
  let dataTypeMap = dataTypes.get(codeModel);
  if (!dataTypeMap) {
    dataTypeMap = new WeakMap();
    dataTypes.set(codeModel, dataTypeMap);
  }
  return dataTypeMap;
}
