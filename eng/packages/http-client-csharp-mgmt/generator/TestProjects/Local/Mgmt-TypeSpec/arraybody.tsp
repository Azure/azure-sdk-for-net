import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

@doc("Script output stream type")
union ScriptOutputStreamType {
  string,

  @doc("is information")
  Information: "Information",

  @doc("is warning")
  Warning: "Warning",

  @doc("is output")
  Output: "Output",

  @doc("is error")
  Error: "Error",
}

@doc("Script execution resource")
@resource("scriptExecutions")
model ScriptExecution is ProxyResource<ScriptExecutionProperties> {
  @doc("Name of the script execution resource")
  @key("scriptExecutionName")
  @segment("scriptExecutions")
  @path
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  name: string;
}

@doc("Script execution properties")
model ScriptExecutionProperties {
  @doc("Output of the script execution")
  output?: string;

  @doc("Error of the script execution")
  error?: string;
}

@armResourceOperations
interface ScriptExecutions {
  @doc("Get a script execution")
  get is ArmResourceRead<ScriptExecution>;

  @doc("Return the logs for a script execution resource")
  @autoRoute
  @armResourceAction(ScriptExecution)
  @post
  getExecutionLogs(
    ...ResourceInstanceParameters<ScriptExecution>,

    #suppress "@azure-tools/typespec-azure-core/request-body-problem"
    @bodyRoot
    @doc("Name of the desired output stream to return. If not provided, will return all. An empty array will return nothing.")
    scriptOutputStreamType?: ScriptOutputStreamType[],
  ): ArmResponse<ScriptExecution> | ErrorResponse;
}
