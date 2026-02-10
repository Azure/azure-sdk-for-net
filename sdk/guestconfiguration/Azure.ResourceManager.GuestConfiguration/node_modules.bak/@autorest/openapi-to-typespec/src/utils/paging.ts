import { CodeModel, Operation, isObjectSchema, Response, Property } from "@autorest/codemodel";
import { getLanguageMetadata } from "./metadata";
import { isResponseSchema } from "./schemas";

export interface PaginationExtension {
  /**
   * The name of the field in the response that can be paged over.
   */
  itemName?: string;
  /**
   * Name of the field containing the nextLink value.
   * An empty object indicates a null value and that all results
   * are returned in a single page.
   */
  nextLinkName?: string | {};
  // 'nextLinkOperation', 'group', and 'member' are used together.
  /**
   * Reference to the operation to call to get the next page.
   */
  nextLinkOperation?: Operation;
  /**
   * The name of the operationGroup that nextLinkOperation resides in.
   */
  group?: string;
  /**
   * The name of the operation that nextLinkOperation references.
   */
  member?: string;
  /**
   * Indicates whether this operation is used by another operation to get pages.
   */
  isNextLinkMethod?: boolean;
}

export function isPageableOperation(operation: Operation): boolean {
  const languageMetadata = getLanguageMetadata(operation.language);
  const paginationExtension = languageMetadata.paging;
  return Boolean(paginationExtension);
}

export function getPageableResponse(operation: Operation): Response | undefined {
  if (!isPageableOperation(operation)) {
    return undefined;
  }

  for (const response of operation.responses ?? []) {
    if (!isResponseSchema(response)) {
      continue;
    }

    if (!isObjectSchema(response.schema)) {
      continue;
    }

    if (!response.schema.language.default.paging.isPageable) {
      continue;
    }

    return response;
  }

  return undefined;
}

export function isPageValue(property: Property) {
  return Boolean(property.language.default.paging?.isValue);
}

export function markPagination(codeModel: CodeModel) {
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      const languageMetadata = getLanguageMetadata(operation.language);
      const paginationExtension = languageMetadata.paging;
      if (!isPageableOperation(operation)) {
        continue;
      }
      const itemName = paginationExtension.itemName || "value";
      let nextLinkName: string | null = "nextLink";

      if (typeof paginationExtension.nextLinkName === "string") {
        nextLinkName = paginationExtension.nextLinkName;
      } else if (typeof paginationExtension.nextLinkName === "object") {
        nextLinkName = null;
      }

      for (const response of operation.responses ?? []) {
        if (!isResponseSchema(response)) {
          continue;
        }

        if (!isObjectSchema(response.schema)) {
          continue;
        }

        response.schema.language.default.paging = {
          ...response.schema.language.default.paging,
          isPageable: true,
        };

        for (const property of response.schema.properties ?? []) {
          if (property.serializedName === nextLinkName) {
            property.language.default.paging = {
              ...property.language.default.paging,
              isNextLink: true,
            };
          }

          if (property.serializedName === itemName) {
            property.language.default.paging = {
              ...property.language.default.paging,
              isValue: true,
            };
          }
        }
      }
    }
  }
}
