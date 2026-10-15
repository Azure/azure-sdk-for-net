import readline from "node:readline";
import { pathToFileURL } from "node:url";

const customizationToolName = "azsdk_customized_code_update";
const validationToolName = "azsdk_run_typespec_validation";

export function handleRequest(
  request,
  failCustomization = false,
  state = { customizationApplied: false },
) {
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
              "Apply TypeSpec or SDK customizations. SpecInputs requires tspProjectPath but no packagePath and skips SDK generation/build.",
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
        if (!state.customizationApplied) {
          return reply({
            isError: true,
            content: [
              {
                type: "text",
                text: "Customization must succeed before TypeSpec validation.",
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
      if (
        args.editScope !== "SpecInputs" ||
        !args.tspProjectPath ||
        !args.customizationRequest ||
        args.packagePath
      ) {
        return reply({
          isError: true,
          content: [
            {
              type: "text",
              text: "Fixture requires SpecInputs, tspProjectPath, customizationRequest, and no packagePath.",
            },
          ],
        });
      }
      const result = failCustomization
        ? {
            Success: false,
            ErrorCode: "CustomizationFailed",
            ResponseError: "Naming customization could not be applied.",
            Message: "No edits made. Report the blocker; do not edit manually.",
          }
        : {
            Success: true,
            TypeSpecChangesSummary: [
              "Applied csharp-scoped WidgetProperties.enabled -> IsEnabled in client.tsp; wire names and other languages unchanged (mock).",
            ],
            Message:
              "SpecInputs completed (mock). SDK generation/build and TypeSpec validation were not run; the caller must validate.",
          };
      state.customizationApplied = result.Success;
      return reply({
        content: [{ type: "text", text: JSON.stringify(result) }],
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
  const state = { customizationApplied: false };
  input.on("line", (line) => {
    try {
      const result = handleRequest(
        JSON.parse(line),
        process.env.NAMING_EVAL_FAIL === "true",
        state,
      );
      if (result) process.stdout.write(`${JSON.stringify(result)}\n`);
    } catch (error) {
      process.stderr.write(`Invalid fixture request: ${error.message}\n`);
      process.exitCode = 1;
      input.close();
    }
  });
}
