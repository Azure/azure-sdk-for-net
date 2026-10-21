import fs from "node:fs";
import path from "node:path";
import readline from "node:readline";
import { pathToFileURL } from "node:url";

const customizationToolName = "azsdk_customized_code_update";
const validationToolName = "azsdk_run_typespec_validation";

/**
 * @param {unknown} value
 * @returns {value is Record<string, unknown>}
 */
function isRecord(value) {
  return value !== null && typeof value === "object" && !Array.isArray(value);
}

/** @param {unknown} request */
export function handleRequest(request) {
  if (!isRecord(request)) {
    throw new TypeError("Fixture request must be an object.");
  }
  if (request.id === undefined) return null;
  /** @template T @param {T} result */
  const reply = (result) => ({ jsonrpc: "2.0", id: request.id, result });
  /** @param {number} code @param {string} message */
  const error = (code, message) => ({
    jsonrpc: "2.0",
    id: request.id,
    error: { code, message },
  });
  const params = isRecord(request.params) ? request.params : {};

  switch (request.method) {
    case "initialize":
      if (typeof params.protocolVersion !== "string") {
        return error(
          -32602,
          "Fixture initialization requires protocolVersion.",
        );
      }
      return reply({
        protocolVersion: params.protocolVersion,
        capabilities: { tools: {} },
        serverInfo: { name: "naming-eval-fixture", version: "1.0.0" },
      });
    case "ping": {
      /** @type {Record<string, never>} */
      const result = {};
      return reply(result);
    }
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
      const args = isRecord(params.arguments) ? params.arguments : {};
      if (params.name === validationToolName) {
        if (
          typeof args.typeSpecProjectRootPath !== "string" ||
          !args.typeSpecProjectRootPath
        ) {
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
      if (params.name !== customizationToolName) {
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
      return error(
        -32601,
        `Unsupported fixture method: ${String(request.method)}`,
      );
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
      process.stderr.write(
        `Invalid fixture request: ${error instanceof Error ? error.message : String(error)}\n`,
      );
      process.exitCode = 1;
      input.close();
    }
  });
}
