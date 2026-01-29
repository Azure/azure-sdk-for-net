---
applyTo: '**/*.cs'
---
# Generate Management Plane SDK Samples

This instruction set guides you through generating C# sample code snippets for Azure Management Plane SDKs using Azure Resource Manager (ARM) operations.

## Prerequisites

The following inputs must be provided:
- **Working directory**: An Azure SDK library directory containing the expected structure
- **JSON file(s)**: One or more REST API example files containing sample request/response data

If any prerequisite is missing, notify the user and halt processing.

## Input Processing

### JSON File Retrieval

JSON files will be provided via GitHub links. You must:
1. Fetch the files from the provided URLs
2. Save them locally in your working directory while preserving the original directory structure

**Example**: If the JSON file is located at:
```
https://github.com/Azure/azure-rest-api-specs/tree/main/specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/PutStorageTask.json
```
Save it to:
```
<working_directory>/specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/PutStorageTask.json
```

### Working Directory Structure

The working directory must have the following structure:
```
<working_directory>/
├── api/          # API specifications and metadata
├── src/          # Source code of the SDK library
├── tests/        # Test files and samples
│   └── Samples/  # Generated samples go here (create if missing)
└── specification/ # Downloaded JSON example files (preserving original structure)
    └── <service>/
        └── <namespace>/
            └── examples/
                └── <api-version>/
                    └── *.json  # REST API example files
```

**Important**:
- Generated samples must be placed in the `tests/Samples` directory
- Downloaded JSON files should preserve their original directory structure under `specification/`
- The samples should call APIs from the library code located in the `src` directory

## JSON File Format

The JSON files contain REST API example data and follow this structure:
```json
{
  "operationId": "StorageTasks_Create",
  "parameters": {
    "api-version": "2023-01-01",
    "monitor": "true",
    "parameters": {
      "identity": {
        "type": "SystemAssigned"
      },
      "location": "westus",
      "properties": {
        "description": "My Storage task",
        "action": {
          "else": {
            "operations": [
              {
                "name": "DeleteBlob",
                "onFailure": "break",
                "onSuccess": "continue"
              }
            ]
          },
          "if": {
            "condition": "[[equals(AccessTier, 'Cool')]]",
            "operations": [
              {
                "name": "SetBlobTier",
                "onFailure": "break",
                "onSuccess": "continue",
                "parameters": {
                  "tier": "Hot"
                }
              }
            ]
          }
        },
        "enabled": true
      }
    },
    "resourceGroupName": "res4228",
    "storageTaskName": "mytask1",
    "subscriptionId": "1f31ba14-ce16-4281-b9b4-3e78da6e1616"
  },
  "title": "PutStorageTask",
  "responses": {
    "200": {
        // omitted for brevity
    },
    "201": {
        // omitted for brevity
    },
    "202": {
        // omitted for brevity
    }
  }
}
```
**Key Fields**:
- `operationId`: Identifies which SDK method to call in the sample
- `parameters`: Contains all parameters needed for the method call
- `title`: Used for naming the sample method
- `responses`: Response examples (usually can be ignored for sample generation)

## Source Code Structure (src/ directory)

### Method Organization

1. **Method Identification**: All service methods include XML documentation comments with the `Operation Id` in a specific XML format. Use this to map JSON `operationId` values to SDK methods.

   **Search Strategy**:
   - Search for the exact XML documentation format within `<summary>` tags:
     ```xml
     /// <item>
     /// <term>Operation Id</term>
     /// <description>OperationId_Value</description>
     /// </item>
     ```
   - The operation ID value is found in the `<description>` tag immediately following the `<term>Operation Id</term>` line
   - **Important**: Only search for this specific XML documentation pattern. If no match is found using this exact format, mark the operation ID as "no match" and do not perform additional regex searches or alternative search methods.
   - This targeted approach prevents time-consuming searches and ensures consistent results.

2. **Class Types**: Service methods are organized in these class types:
   - `*Resource.cs`: Individual ARM resource operations
   - `*Collection.cs`: Collection-level operations (create, list, etc.)
   - `<ServiceName>Extensions.cs`: Extension methods for resources not in this library
   - Other classes: Helper methods (lower priority)

3. **Resource Hierarchy**: ARM resources follow a hierarchical structure where `*Resource.cs` and `*Collection.cs` pairs represent ARM resources.

### Factory Methods

Resources use factory methods to access child resources:
- **Parent exists in library**: Factory method is on the parent `*Resource.cs` class, returns child `*Collection.cs` or `*Resource.cs`
- **Parent not in library**: Factory method is in `<ServiceName>Extensions.cs`, returns child `*Collection.cs` or `*Resource.cs`

## Sample Generation Process

Follow these steps for each JSON file:

### Step 1: Analyze JSON File

- Extract the `operationId` and parameters
- Note the `title` field for method naming
- Understand the parameter structure and types

### Step 2: Determine JSON File Path

- Extract the relative path from the first `examples` directory to the JSON file
- **Format**: Everything after and including the API version directory
- **Example**: For a file at `specification/azuredependencymap/DependencyMap.Management/examples/2025-05-01-preview/Maps_ListBySubscription.json`, the relative path should be `2025-05-01-preview/Maps_ListBySubscription.json`
- **Complex Example**: For `specification/service/Management/examples/2023-01-01/subfolder/operation.json`, the relative path should be `2023-01-01/subfolder/operation.json`
- Store as `jsonFileRelativePath` for documentation comments

### Step 3: Map Operation ID to SDK Method

**Search Process**:
1. Extract the `operationId` from the JSON file
2. Search for methods with XML documentation containing the pattern:
   - `<term>Operation Id</term>` followed by
   - `<description>{operationId}</description>` on the next line
3. **Search only once**: Do not perform multiple searches or use regex patterns if the first search yields no results
4. If no match is found with the XML documentation search, immediately mark as "no match" and proceed to the next JSON file

**Priority Order** (highest to lowest):
1. Methods in `*Resource.cs` classes
2. Methods in `*Collection.cs` classes
3. Methods in `<ServiceName>Extensions.cs` classes

**If no matching method is found**:
- **Do not** perform additional searches with different patterns or regex
- **Do not** spend time on alternative search strategies
- Mark the operation ID as "no match" immediately
- Continue to the next JSON file
- Report the missing method in the final summary

### Step 4: Identify Resource Structure

- Determine the resource hierarchy needed to reach the target method
- Identify parent resources and their factory methods
- Plan the resource instantiation chain

### Step 5: Generate Sample Code

Use the template and guidelines below.

## Naming Conventions

### Sample Class Name

- **For methods in `*Resource.cs` or `*Collection.cs` classes**: Use `Sample_<ClassName>` where `<ClassName>` is the exact class name without the `.cs` extension
  - Example: Method in `DependencyMapResource.cs` → `Sample_DependencyMapResource`
  - Example: Method in `DependencyMapCollection.cs` → `Sample_DependencyMapCollection`

- **For methods in the `<ServiceName>Extensions.cs` class**: Use `Sample_<FirstParameterTypeName>Extensions` where `<FirstParameterTypeName>` is the type name of the method's first parameter (not the service name)
  - Example: Extension method `GetDependencyMaps(this SubscriptionResource subscription, ...)` → `Sample_SubscriptionResourceExtensions` (because first parameter is `SubscriptionResource`)
  - Example: Extension method `GetVirtualMachines(this ResourceGroupResource resourceGroup, ...)` → `Sample_ResourceGroupResourceExtensions` (because first parameter is `ResourceGroupResource`)
  - **Important**: Do NOT use the service name (e.g., `DependencyMap`) in the class name for extensions. Always use the first parameter's type name.

### Sample Method Name

**Format**: `<MethodName>_<TitleOfJsonFile>`

**Components**:

1. **`<MethodName>`**: The actual SDK method name being called
   - Use the exact method name as it appears in the source code
   - **Important**: Since we generate only async samples, remove the `Async` suffix from the method name
   - **Example**: If calling `CreateOrUpdateAsync()`, use `CreateOrUpdate` in the sample method name

2. **`<TitleOfJsonFile>`**: The `title` field from the JSON file
   - Extract the exact value from the JSON file's `title` field
   - **Character normalization**: Remove or replace invalid C# identifier characters:
     - Remove spaces, hyphens, dots, and special characters
     - Convert to PascalCase (first letter uppercase, subsequent words capitalized)
   - **Example transformations**:
     - `"Put Storage Task"` → `PutStorageTask`
     - `"list-by-subscription"` → `ListBySubscription`
     - `"Get VM.Status"` → `GetVMStatus`

**Complete Examples**:
- SDK method: `CreateOrUpdateAsync()`, JSON title: `"Put Storage Task"` → Sample method: `CreateOrUpdate_PutStorageTask()`
- SDK method: `ListAsync()`, JSON title: `"list-by-subscription"` → Sample method: `List_ListBySubscription()`
- SDK method: `GetAsync()`, JSON title: `"Get VM.Status"` → Sample method: `Get_GetVMStatus()`

## Sample Code Template

Generate samples using this structure with the following components:

### Template Structure
```C#
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace <PackageNamespace>.Tests.Samples
{
    public partial class <SampleClassName>
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task <SampleMethodName>()
        {
            // Generated from example definition: <jsonFileRelativePath>
            // this example is just showing the usage of "<operationId>" operation, for the dependent resources, they will have to be created separately

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            <InstancePreparation>

            // invoke the operation
            <MethodParametersPreparation>
            <MethodInvocation>
            <HandleResponse>
        }
    }
}
```

## Implementation Details

### Operation ID Matching

When searching for methods that match a given `operationId`:

1. **Use targeted search**: Search specifically for the XML documentation pattern:
   ```xml
   /// <term>Operation Id</term>
   /// <description>{operationId}</description>
   ```
2. **Single search attempt**: Perform only one search using this exact XML documentation format
3. **No fallback searches**: Do not use regex patterns, partial matches, or alternative search methods if the initial search fails
4. **Efficiency priority**: This approach prioritizes speed and consistency over exhaustive matching
5. **Clear outcomes**: Either find an exact match or mark as "no match" - no ambiguous results

### Template Components

#### InstancePreparation

Construct an instance of the type containing the target method:

- **`*Resource.cs` class**:
  1. Find the `CreateResourceIdentifier` method and call it with parameters
  2. Use `client.Get<ResourceName>(resourceId)` to get the resource instance

- **`*Collection.cs` class**:
  1. Get the parent resource instance (using `*Resource.cs` approach above)
  2. Call the factory method on the parent resource to get the collection

- **`<ServiceName>Extensions.cs` class**:
  1. Get the first parameter's type instance (should be a `*Resource.cs` class)
  2. Follow the `*Resource.cs` approach above

#### MethodParametersPreparation

Handle each parameter based on its type:

- **Primitive types** (string, int, bool): Use values directly from JSON
- **Complex types** (SDK classes): Create instances using object initializer syntax
- **Enum types**: Use matching enum values from the SDK library
- **Collection types** (List, Dictionary):
  - Use collection initializer syntax
  - **Important**: Most collection properties lack setters - never create and assign new instances

#### MethodInvocation

Call the identified method with the prepared parameters.

#### HandleResponse

Handle different return types appropriately:

- **`Response`**: No additional handling needed
- **`Response<T>`**: Unwrap using `.Value` to get type `T`
- **`AsyncPageable<T>`**: Use `await foreach` to iterate over results
- **`ArmOperation`**: No additional handling needed
- **`ArmOperation<T>`**: Unwrap using `.Value` to get type `T`

## Code Quality Guidelines

### Required Practices

1. **Use async methods**: Always use asynchronous versions (methods with `Async` suffix)
2. **Include using directives**: Add all necessary `using` statements at the top
3. **Explicit types**: Never use `var` keyword - always specify explicit types
4. **Public members only**: Only use public members, never internal or private
5. **Proper formatting**: Follow C# coding conventions and proper formatting

### Object Construction

6. **Object initializers**: Use object initializer syntax for complex types
7. **Nested initializers**: Handle nested complex types with nested object initializers
8. **Collection initializers**: Use collection initializer syntax (never construct and assign new instances)

### Parameter Handling

9. **Optional parameters**: Omit optional parameters not provided in JSON
10. **Missing required parameters**:
    - Notify the user about missing required parameters
    - Use `(T)default` as placeholder and continue generation

### Validation and Reporting

11. **Build verification**: Run `dotnet build` in working directory to verify successful compilation
12. **Error resolution**: Fix any build errors before finalizing code

## Quality Assurance and Final Verification

### Compilation and Code Quality

- Ensure all generated samples compile successfully
- Verify proper error handling and resource cleanup
- Confirm samples demonstrate realistic usage patterns
- Test that samples work with the actual SDK library

### Comprehensive Processing Report

Before proceeding with cleanup, generate a detailed verification report:

1. **List all downloaded JSON example files** from the `specification/` directory
2. **For each JSON example file, verify one of the following**:
   - **Generated Sample**: A corresponding sample method was successfully created in the appropriate `Sample_*.cs` file
   - **No Matching Method**: The `operationId` from the JSON file does not correspond to any method in the SDK source code (`src/` directory)

Create a summary report in the following format:

```
## Sample Generation Summary

### Successfully Generated Samples:
- `<json_file_name>` → `Sample_<ClassName>.<MethodName>_<Title>()` (Operation: `<operationId>`)

### JSON Files Without Matching SDK Methods:
- `<json_file_name>` → Operation `<operationId>` marked as "no match" (not found in XML documentation using specified format)

### Total Statistics:
- Total JSON files processed: X
- Samples generated: Y
- Files without matching methods: Z
```

### User Confirmation Required

**CRITICAL**: Do not proceed with cleanup until you receive explicit user confirmation. Present the verification report to the user and ask:

```
"I have completed sample generation and created the above summary report.
Please review the results to ensure all expected samples have been generated.
Do you want me to proceed with cleanup (removing the specification/ directory)? (Y/N)"
```

Only proceed to the cleanup step after receiving affirmative confirmation from the user.

## Cleanup

### Remove Example File Cache

After successfully generating and verifying all samples, clean up the local cache of downloaded JSON example files:

1. **Remove the specification directory**: Delete the entire `specification/` directory that was created in the working directory to store the downloaded JSON files
2. **Preserve generated samples**: Ensure the `tests/Samples/` directory and all generated sample files remain intact
3. **Verify cleanup**: Confirm that only the generated sample files exist and no temporary JSON files remain

**Example cleanup command**:
```powershell
Remove-Item -Path "<working_directory>/specification" -Recurse -Force
```

This cleanup step ensures that:
- No temporary files are left in the repository
- The working directory remains clean
- Only the final generated sample files are preserved
- The repository size is not unnecessarily increased by cached JSON files
