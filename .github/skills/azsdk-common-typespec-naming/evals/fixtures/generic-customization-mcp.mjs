import readline from "node:readline";
import { pathToFileURL } from "node:url";

const toolName = "azsdk_customized_code_update";

function handleRequest(request) {
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
        serverInfo: {
          name: "generic-customization-eval-fixture",
          version: "1.0.0",
        },
      });
    case "ping":
      return reply({});
    case "tools/list":
      return reply({
        tools: [
          {
            name: toolName,
            description:
              "Apply TypeSpec and SDK code customizations, regenerate the SDK package, and build it.",
            inputSchema: {
              type: "object",
              properties: {
                customizationRequest: { type: "string" },
                packagePath: { type: "string" },
                tspProjectPath: { type: "string" },
                editScope: {
                  type: "string",
                  enum: ["SpecInputs", "CustomCode", "All"],
                  default: "All",
                },
              },
              required: ["customizationRequest", "packagePath"],
              additionalProperties: false,
            },
          },
        ],
      });
    case "tools/call": {
      if (request.params.name !== toolName) {
        return error(-32602, "Unknown fixture tool");
      }

      const args = request.params.arguments ?? {};
      if (
        !args.customizationRequest ||
        !args.packagePath ||
        args.editScope === "SpecInputs"
      ) {
        return reply({
          isError: true,
          content: [
            {
              type: "text",
              text: "Fixture requires a generic SDK customization request, packagePath, and All or CustomCode scope.",
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
              Message:
                "Generic SDK customization applied, regenerated, and built successfully (mock).",
            }),
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
