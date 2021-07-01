# Azure Batch Management SDK developer guide

1. Update the Azure Batch Management Swagger specification, which resides in the [Azure/azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) GitHub repository (specifically [here](https://github.com/Azure/azure-rest-api-specs/tree/master/specification/batch/resource-manager))
    * Add new entity types into the Swagger specification.
    * Add new APIs as path-verb pairs in the Swagger specification.
    * Add/remove properties on existing entity types in the Swagger specification.
2. Regenerate the SDK based using [AutoRest](https://github.com/Azure/autorest) on the updated Swagger specification:
    * See this document for more information: https://github.com/Azure/adx-documentation-pr/blob/master/engineering/adx_netsdk_process.md#sdk-generation-from-updated-spec
    * Run the command from the root of the repo: `sdk/batch/Microsoft.Azure.Management.Batch/src/generate.ps1` 
3. Add new tests for your new models and APIs. There are two types of tests, "recorded" tests and unit tests:
    * Recorded tests are run live and the request/response payloads are recorded and then replayed for subsequent runs.
    * Unit tests are in-memory tests which never actually make a REST call.
    * **Note:** You should prefer to add unit tests over recording tests where possible -- recording tests should be reserved for ensuring that the Batch Service accepts the Swagger payload, and only cover the basic happy path scenarios.
4. Update the `CHANGELOG.md` file and the `Version` tag in `src/Microsoft.Azure.Management.Batch.csproj`. Ensure that if you are making a breaking change, you update the major version of the version number.
5. Re-record all of the recording tests against the new API version (see [here](https://github.com/Azure/azure-sdk-for-net/blob/master/doc/dev/Using-Azure-TestFramework.md) for details on how to use the recording framework).
6. Switch test mode back to `Playback` and ensure that all of the tests pass.
7. Open a PR to https://github.com/Azure/azure-sdk-for-net.
