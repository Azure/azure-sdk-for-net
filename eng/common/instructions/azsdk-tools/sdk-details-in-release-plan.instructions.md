---
description: 'Update SDK details in a release plan from a TypeSpec project'
---
# Step 1: Identify the TypeSpec project path
**Goal**: Identify the path to the TypeSpec project that contains the `tspconfig.yaml` file.
1. Identify the TypeSpec project directory that contains a `tspconfig.yaml` file.
2. If a TypeSpec project path is not provided or known, ask the user for the path.
3. If no `tspconfig.yaml` exists at the given path, inform the user: "No tspconfig.yaml found at the given path. Please provide a valid TypeSpec project path."
**Success Criteria**: Valid TypeSpec project path identified.

# Step 2: Check if release plan exists
**Goal**: Determine if a release plan exists for the API spec pull request or work item Id or release plan Id in current context.
1. Get release plan
2. If no release plan exists, inform the user: "No release plan exists for the API spec pull request. Please create a release plan first."
3. If a release plan exists, proceed to Step 3.
**Success Criteria**: Release plan exists or user informed to create one.

# Step 3: Update Release Plan with SDK Information
**Goal**: Update the release plan with the SDK package names resolved from the TypeSpec project.
1. Use `azsdk_update_sdk_details_in_release_plan` with the release plan work item ID and the TypeSpec project path from Step 1.
2. Confirm successful update of the release plan with the SDK information and summary of languages and package names.
**Success Criteria**: Release plan updated with languages and package names resolved from the TypeSpec project.