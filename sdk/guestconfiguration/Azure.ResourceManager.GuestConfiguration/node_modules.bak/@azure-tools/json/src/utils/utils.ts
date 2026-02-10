export interface ValidationError {
  message: string;
  position: number;
}

/**
 * Validate content is json.
 * @param json Json string to validate
 * @returns Error or undefined
 */
export function validateJson(json: string): ValidationError | undefined {
  try {
    // quick check on data.
    JSON.parse(json);
  } catch (e) {
    if (e instanceof SyntaxError) {
      const message = "" + e.message;
      try {
        return {
          message: message.substring(0, message.lastIndexOf("at")).trim(),
          position: parseInt(e.message.substring(e.message.lastIndexOf(" ")).trim()),
        };
      } catch {
        // ignore.
      }
    }
  }
  return undefined;
}
