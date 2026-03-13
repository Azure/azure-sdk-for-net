import "@azure-tools/typespec-azure-core";
import "@typespec/rest";
import "@azure-tools/typespec-azure-resource-manager";
import "./foo.tsp";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/**
 * Test operations that exercise:
 * 1. @route with path parameters (duplicate key scenario in ParameterContextRegistry)
 * 2. Primitive body types (IDictionary<string,string>, string[]) that need special serialization
 */
@armResourceOperations
interface FooConfigurations {
  /**
   * Gets a specific configuration for the Foo resource.
   * Tests @route with path parameter to verify ParameterContextRegistry handles it without crashing.
   */
  @get
  @route("configurations/{configurationName}")
  get(
    ...Azure.ResourceManager.Foundations.DefaultBaseParameters<Foo>,
    @path configurationName: string,
  ): ArmResponse<Record<string>> | ErrorResponse;

  /**
   * Updates a configuration with a dictionary body.
   * Tests primitive body type (Record<string> = IDictionary<string,string>) serialization.
   */
  @post
  @route("configurations/{configurationName}")
  update(
    ...Azure.ResourceManager.Foundations.DefaultBaseParameters<Foo>,
    @path configurationName: string,
    @body parameters: Record<string>,
  ): OkResponse | ErrorResponse;

  /**
   * Restarts hosts with a string array body.
   * Tests primitive body type (string[]) serialization.
   */
  @post
  @route("restartHosts")
  restartHosts(
    ...Azure.ResourceManager.Foundations.DefaultBaseParameters<Foo>,
    @body hosts: string[],
  ): OkResponse | ErrorResponse;
}
