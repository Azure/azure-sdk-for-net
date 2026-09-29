import readline from "node:readline";
import { pathToFileURL } from "node:url";

const toolName = "azsdk_customized_code_update";

export function handleRequest(request, failCustomization = false) {
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
            name: toolName,
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
        ],
      });
    case "tools/call": {
      if (request.params.name !== toolName)
        return error(-32602, "Unknown fixture tool");
      const args = request.params.arguments ?? {};
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
  input.on("line", (line) => {
    try {
      const result = handleRequest(
        JSON.parse(line),
        process.env.NAMING_EVAL_FAIL === "true",
      );
      if (result) process.stdout.write(`${JSON.stringify(result)}\n`);
    } catch (error) {
      process.stderr.write(`Invalid fixture request: ${error.message}\n`);
      process.exitCode = 1;
      input.close();
    }
  });
}
