import "@typespec/http";
import "../dist/emitter/index.js";

namespace Azure.Mcp;

using TypeSpec.Reflection;

/** Output configuration and explicitly handwritten composite exclusions. */
model McpService {
  outputNamespace: string;
  metadataReferences?: string[];
  composites?: CompositeSelection[];
}

/** A complete MCP command that delegates service policy to an existing typed handler. */
model CommandConfiguration {
  id: string;
  path: string;
  title: string;
  commandType: string;
  handler: StaticMember;
  resultName: string;
  description?: StaticMember;
  errorPolicy?: StaticMember;
  errorMessage?: string;
  options?: CommandOption[];
  safety: SafetyOverrides;
}

/** Only descriptions are authored; types, requiredness, and names come from the handler. */
model CommandOption {
  name: string;
  description?: string;
  descriptionMember?: StaticMember;
}

model CompositeSelection {
  path: string;
  reason: string;
}

/** Reviewed MCP identity and existing SDK binding for one HTTP operation. */
model ToolConfiguration {
  id: string;
  group: string[];
  name: string;
  title: string;
  types: GeneratedTypes;
  commandType: string;
  descriptionOverride?: StaticMember;
  errorMessage: string;
  wire: WireMapping;
  options: OptionMapping[];
  binding: SdkBinding;
  result: ResultProperty[];
  safety: SafetyOverrides;
}

model GeneratedTypes {
  catalog: string;
  options: string;
  binding: string;
  result: string;
  jsonContext: string;
}

model StaticMember {
  type: string;
  member: string;
}

model WireMapping {
  method: "GET" | "HEAD" | "OPTIONS" | "PUT" | "DELETE" | "POST" | "PATCH";
  path: string;
  uri: string;
  constants: WireConstant[];
}

model WireConstant {
  name: string;
  value: string | boolean | numeric | null;
}

model OptionMapping {
  name: string;
  type: "string" | "bool" | "int" | "long" | "float" | "double" | "decimal";
  required: boolean;
  source?: string;
  description?: string;
  descriptionMember?: StaticMember;
}

model ResultProperty {
  name: string;
  type: string;
}

model SdkBinding {
  method: string;
  description: string;
  returnType: string;
  parameters: BindingParameter[];
  calls: SdkCall[];
  returnVariable: string;
}

model BindingParameter {
  name: string;
  type: string;
  description: string;
}

model SdkCall {
  target: string;
  method: string;
  arguments: BindingArgument[];
  await: boolean;
  resultName?: string;
  resultType?: string;
}

model BindingArgument {
  variable?: string;
  member?: StaticMember;
  literal?: string | boolean | numeric | null;
  name?: string;
}

model SafetyOverrides {
  destructive?: boolean;
  idempotent?: boolean;
  readOnly?: boolean;
  openWorld?: boolean;
}

/** Configure one MCP output library, independent of any Azure service. */
extern dec mcpService(target: Namespace, configuration: valueof McpService);

/** Select an operation and attach its reviewed MCP/SDK mapping. */
extern dec tool(target: Operation, configuration: valueof ToolConfiguration);

/** Select an existing service operation without restating its HTTP or SDK implementation. */
extern dec command(target: Operation, configuration: valueof CommandConfiguration);
