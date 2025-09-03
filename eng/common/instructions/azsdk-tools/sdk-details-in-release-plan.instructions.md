---
description: 'Identify languages configured in the TypeSpec project and add it to release plan'
---
# Step 1: Find the list of languages and package names
**Goal**: Identify languages configured in the TypeSpec project and generate the json object with language and package name.
1. Identify the language emitter configuration in the `tspconfig.yaml` file in the TypeSpec project root.
2. Identify the package name or namespace for each language emitter.
3. Map the language name in emitter to one of the following in Pascal case(except .NET):
   - .NET
   - Java
   - Python
   - JavaScript
   - Go
4. Remove `github.com/Azure/azure-sdk-for-go/` from Go package name.
4. Create a JSON array object with the following structure:
   ```json
   [
           {
               "language": "<LanguageName>",
               "packageName": "<PackageName>"
           },
           ...
    ]
   ```
5. If no languages are configured, inform the user: "No languages configured in TypeSpec project. Please add at least one language emitter in tspconfig.yaml."
**Success Criteria**: JSON object with languages and package names created.

# Step 2: Check if release plan exists
**Goal**: Determine if a release plan exists for the API spec pull request or work item Id or release plan Id in current context.
1. Get release plan
2. If no release plan exists, inform the user: "No release plan exists for the API spec pull request. Please create a release plan first."
3. If a release plan exists, proceed to Step 3.
**Success Criteria**: Release plan exists or user informed to create one.

# Step 3: Update Release Plan with SDK Information
**Goal**: Update the release plan with the languages and package names identified in Step 1.
1. Use `azsdk_update_sdk_details_in_release_plan` to update the release plan work item with the JSON object created in Step 1.
2. Confirm successful update of the release plan with the SDK information and summary of languages and package names.
**Success Criteria**: Release plan updated with languages and package names.