import { getSession } from "../autorest-session";
import { TypespecProgram } from "../interfaces";
import { formatFile } from "../utils/format";

export async function emitPackage(filePath: string, program: TypespecProgram): Promise<void> {
  const session = getSession();
  // Default to false;
  const includePackage = session.configuration["include-package"] === true;

  if (!includePackage) {
    return;
  }

  const name = program.serviceInformation.name.toLowerCase().replace(/ /g, "-");
  const description = program.serviceInformation.doc;
  const content = JSON.stringify(getPackage(name, description as string));
  session.writeFile({ filename: filePath, content: await formatFile(content, filePath) });
}

const getPackage = (name: string, description: string) => ({
  name: `@typespec-api-spec/${name}`,
  author: "Microsoft Corporation",
  description,
  license: "MIT",
  dependencies: {
    "@typespec/compiler": "^0.44.0",
    "@typespec/rest": "^0.44.0",
    "@typespec/http": "^0.44.0",
    "@typespec/versioning": "^0.44.0",
    "@typespec/prettier-plugin-typespec": "^0.44.0",
    "@azure-tools/typespec-azure-core": "^0.30.0",
    "@azure-tools/typespec-autorest": "^0.30.0",
    prettier: "^2.7.1",
  },
  private: true,
});
