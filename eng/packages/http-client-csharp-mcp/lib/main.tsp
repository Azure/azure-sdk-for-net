import "@typespec/http";
import "../dist/emitter/index.js";

namespace Azure.Mcp;

using TypeSpec.Reflection;

/** Expose an existing service operation with a stable MCP identity and command path. */
extern dec tool(
  target: Operation,
  id: valueof string,
  path: valueof string,
  title?: valueof string
);

/** Override the conservative HTTP-derived destructive annotation. */
extern dec destructive(target: Operation, value?: valueof boolean);

/** Override the conservative HTTP-derived idempotent annotation. */
extern dec idempotent(target: Operation, value?: valueof boolean);

/** Override the conservative HTTP-derived read-only annotation. */
extern dec readOnly(target: Operation, value?: valueof boolean);

/** Override the conservative HTTP-derived open-world annotation. */
extern dec openWorld(target: Operation, value?: valueof boolean);
