export type JsonPointer = string;
export type JsonPointerTokens = (string | number)[];

/**
 * Escapes a reference token
 *
 * @param str
 * @returns {string}
 */
function escape(str: string | number): string | number {
  return typeof str === "string" ? str.toString().replace(/~/g, "~0").replace(/\//g, "~1") : str;
}

/**
 * Unescapes a reference token
 *
 * @param str
 * @returns {string}
 */
function unescape(str: string): string {
  return str.replace(/~1/g, "/").replace(/~0/g, "~");
}

/**
 * Converts a json pointer into a array of reference tokens
 *
 * @param pointer
 * @returns {Array}
 */
export function parseJsonPointer(pointer: string): JsonPointerTokens {
  if (pointer === "") {
    return new Array<string>();
  }
  if (pointer.charAt(0) !== "/") {
    throw new Error("Invalid JSON pointer: " + pointer);
  }
  return pointer.substring(1).split(/\//).map(unescape);
}

/**
 * Builds a json pointer from a array of reference tokens
 *
 * @param refTokens segment of paths.
 * @returns JsonPointer string.
 */
export function serializeJsonPointer(refTokens: JsonPointerTokens): string {
  if (refTokens.length === 0) {
    return "";
  }
  return `/${refTokens.map(escape).join("/")}`;
}

export class InvalidJsonPointer extends Error {}
/**
 * Lookup a json pointer in an object
 *
 * @param {Object} obj - object to work on
 * @param {JsonPointer|JsonPointerTokens} pointer - pointer or tokens to a location
 * @returns {*} - value at location, or will throw if location is not present.
 */
export function getFromJsonPointer<T>(obj: any, pointer: JsonPointer | JsonPointerTokens): T {
  const refTokens = Array.isArray(pointer) ? pointer : parseJsonPointer(pointer);

  for (let i = 0; i < refTokens.length; ++i) {
    const tok = refTokens[i];
    if (!(typeof obj === "object" && tok in obj)) {
      throw new InvalidJsonPointer("Invalid reference token: " + tok);
    }
    obj = obj[tok];
  }
  return obj;
}

/**
 * Add a new segment to a json pointer
 * @param pointer Pointer
 * @param suffix Suffix
 * @returns new json pointer
 */
export function appendJsonPointer(pointer: string, ...suffixes: string[]): string {
  return serializeJsonPointer(parseJsonPointer(pointer).concat(suffixes));
}
