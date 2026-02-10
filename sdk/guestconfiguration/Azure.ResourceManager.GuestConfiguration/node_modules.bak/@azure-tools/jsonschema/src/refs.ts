/**
 * Represent a json reference.
 */
export type JsonRef =
  | {
      file: string;
      path?: string;
    }
  | {
      path: string;
      file?: string;
    };

/**
 * Parse a json reference into its file and path.
 * @param ref Json reference string.
 * @returns Parsed json reference
 */
export function parseJsonRef(ref: string): JsonRef {
  const [file, path] = ref.split("#");
  return {
    file: file === "" ? undefined : file,
    path: path === undefined ? (undefined as any) : decodeURIComponent(path),
  };
}

/**
 * Convert a @see {JsonRef} into its string format.
 * @param ref Json reference
 * @returns jsonref string.
 */
export function stringifyJsonRef(ref: JsonRef) {
  const path = ref.path === undefined ? "" : `#${ref.path}`;
  return `${ref.file ?? ""}${path}`;
}

/**
 * Update the given document $ref in place using the modifier. Calls the modifier for each instance of a $ref.
 * @param document Document with $ref to update.
 * @param modifier Modifier
 */
export function updateJsonRefs<T extends {} | ArrayLike<{}>>(document: T, modifier: (ref: string) => string): T {
  for (const value of Object.values(document)) {
    if (value && typeof value === "object") {
      const ref = (value as any).$ref;
      if (ref && typeof ref === "string") {
        (value as any).$ref = modifier(ref);
      }
      updateJsonRefs(value as any, modifier);
    }
  }
  return document;
}
