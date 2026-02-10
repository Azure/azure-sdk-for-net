import { TypespecAlias, TypespecObject } from "../interfaces";

export function addCorePageAlias(typespecObject: TypespecObject): TypespecAlias | undefined {
  const value = typespecObject.properties?.filter((p) => p.name === "value");
  if (!typespecObject.properties?.some((p) => p.name === "nextLink") || !value?.length) {
    return;
  }

  typespecObject.properties = typespecObject.properties.filter((p) => p.name !== "nextLink" && p.name !== "value");

  typespecObject.alias = {
    alias: "Azure.Core.Page",
    params: [value[0].type.replace("[]", "")],
    module: "@azure-tools/typespec-azure-core",
  };

  return;
}
