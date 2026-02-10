export type WalkStatus = "stop" | "visit-children";

/**
 * Recursively visit all the node in a json object.
 * Visitor should return a @see {WalkStatus} to determine if the object should be visited further.
 * @param obj Object to visit
 * @param visitor Vistor function.
 */
export function walk(obj: unknown, visitor: (value: unknown, path: string[]) => WalkStatus) {
  const visisted = new Set();
  return walkInternal(obj, [], visisted, visitor);
}

function walkInternal(
  obj: unknown,
  path: string[],
  visisted: Set<any>,
  visitor: (value: unknown, path: string[]) => WalkStatus,
) {
  if (!obj) {
    return undefined;
  }
  if (visisted.has(obj)) {
    return;
  }
  visisted.add(obj);

  if (visitor(obj, path) !== "visit-children") {
    return;
  }

  if (Array.isArray(obj)) {
    for (const [index, item] of obj.entries()) {
      walkInternal(item, [...path, index.toString()], visisted, visitor);
    }
  } else if (typeof obj === "object") {
    // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
    for (const [key, item] of Object.entries(obj!)) {
      walkInternal(item, [...path, key], visisted, visitor);
    }
  }
  return false;
}
