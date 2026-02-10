import { format } from "prettier";

export function formatFile(content: string, filepath: string) {
  return format(content, {
    filepath,
  });
}

export async function formatTypespecFile(content: string, filepath: string): Promise<string> {
  try {
    return await format(content, {
      plugins: ["@typespec/prettier-plugin-typespec"],
      filepath,
    });
  } catch (e) {
    // const logger = getLogger("formatTypespecFile");
    // logger.error(`Failed to format file ${filepath} \n ${e}`);
    return content;
  }
}
