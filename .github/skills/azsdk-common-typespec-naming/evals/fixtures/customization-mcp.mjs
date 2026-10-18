import fs from "node:fs";
import path from "node:path";
import readline from "node:readline";
import { pathToFileURL } from "node:url";

const customizationToolName = "azsdk_customized_code_update";
const validationToolName = "azsdk_run_typespec_validation";

export function handleRequest(request) {
  if (request.id === undefined) return null;
  const reply = (result) => ({ jsonrpc: "2.0", id: request.id, result });
  const error = (code, message) => ({
    jsonrpc: "2.0",
    id: request.id,
    error: { code, message },
  });

  switch (request.method) {
    case "initialize":
      return reply({
        protocolVersion: request.params.protocolVersion,
        capabilities: { tools: {} },
        serverInfo: { name: "naming-eval-fixture", version: "1.0.0" },
      });
    case "ping":
      return reply({});
    case "tools/list":
      return reply({
        tools: [
          {
            name: customizationToolName,
            description:
              "Apply TypeSpec or SDK customizations. Naming-only overrides should use direct file edits instead of this tool.",
            inputSchema: {
              type: "object",
              properties: {
                customizationRequest: { type: "string" },
                tspProjectPath: { type: "string" },
                packagePath: { type: "string" },
                editScope: {
                  type: "string",
                  enum: ["SpecInputs", "CustomCode", "All"],
                  default: "All",
                },
              },
              required: ["customizationRequest"],
              additionalProperties: false,
            },
          },
          {
            name: validationToolName,
            description:
              "Run TypeSpec validation after an applied customization. Requires the absolute TypeSpec project root.",
            inputSchema: {
              type: "object",
              properties: {
                typeSpecProjectRootPath: { type: "string" },
              },
              required: ["typeSpecProjectRootPath"],
              additionalProperties: false,
            },
          },
        ],
      });
    case "tools/call": {
      const args = request.params.arguments ?? {};
      if (request.params.name === validationToolName) {
        if (!args.typeSpecProjectRootPath) {
          return reply({
            isError: true,
            content: [
              {
                type: "text",
                text: "Fixture validation requires typeSpecProjectRootPath.",
              },
            ],
          });
        }
        const root = args.typeSpecProjectRootPath;
        const clientPath = path.join(root, "client.tsp");
        const mainPath = path.join(root, "main.tsp");
        if (
          !fs.existsSync(clientPath) ||
          !fs.existsSync(mainPath) ||
          !/@@clientName\(\s*(?:Widget\.)?WidgetProperties\.enabled\s*,\s*"IsEnabled"\s*,\s*"csharp"\s*\)\s*;/.test(
            fs.readFileSync(clientPath, "utf8"),
          ) ||
          !/import\s+"\.\/client\.tsp"\s*;/.test(
            fs.readFileSync(mainPath, "utf8"),
          )
        ) {
          return reply({
            isError: true,
            content: [
              {
                type: "text",
                text: "Apply and load the scoped naming override before TypeSpec validation.",
              },
            ],
          });
        }
        return reply({
          content: [
            {
              type: "text",
              text: JSON.stringify({
                Success: true,
                TypeSpecProject: args.typeSpecProjectRootPath,
                Message:
                  "TypeSpec validation passed (mock). Run the project compile command next.",
              }),
            },
          ],
        });
      }
      if (request.params.name !== customizationToolName) {
        return error(-32602, "Unknown fixture tool");
      }
      return reply({
        isError: true,
        content: [
          {
            type: "text",
            text: "Unexpected customization call: naming-only overrides must be edited directly. No edits made.",
          },
        ],
      });
    }
    default:
      return error(-32601, `Unsupported fixture method: ${request.method}`);
  }
}

if (
  process.argv[1] &&
  import.meta.url === pathToFileURL(process.argv[1]).href
) {
  const input = readline.createInterface({ input: process.stdin });
  input.on("line", (line) => {
    try {
      const result = handleRequest(JSON.parse(line));
      if (result) process.stdout.write(`${JSON.stringify(result)}\n`);
    } catch (error) {
      process.stderr.write(`Invalid fixture request: ${error.message}\n`);
      process.exitCode = 1;
      input.close();
    }
  });
}
