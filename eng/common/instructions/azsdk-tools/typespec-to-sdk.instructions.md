---
description: 'Generate SDKs from TypeSpec'
---
Your goal is to guide the user through the process of generating SDKs from TypeSpec projects. **Before starting**, show all the high level steps to the user and ask: 

> "Would you like to begin the SDK generation process now? (yes/no)"

Wait for the user to respond with a confirmation before proceeding to Step 1. Use the provided tools to perform actions and gather information as needed.

SDK languages to be generated:
- Management Plane: Python, .NET, JavaScript, Java, Go
- Data Plane: Python, .NET, JavaScript, Java

## Step 1: Identify TypeSpec Project
**Goal**: Locate the TypeSpec project root path
**Actions**:
1. Check if `tspconfig.yaml` or `main.tsp` files are open in editor
2. If found, use the parent directory as project root
3. If not found, prompt user: "Please provide the path to your TypeSpec project root directory"
4. Validate the provided path contains required TypeSpec files
5. Run `azsdk_typespec_check_project_in_public_repo` to verify repository
6. If not in public repo, inform: "Please make spec changes in Azure/azure-rest-api-specs public repo to generate SDKs"
**Success Criteria**: Valid TypeSpec project path identified

## Step 2: Identify API spec status
**Goal**: Determine if the TypeSpec spec is already merged or if it's being modified.
**Actions**:
1. Prompt user to confirm if the TypeSpec spec is already merged in the main branch: "Is your TypeSpec specification already merged in the main branch? (yes/no)"
2. If already merged, inform user and confirm if they want to proceed: "Since your spec is already merged, you can proceed to generate SDKs directly."
   - once confirmed, skip to step 6 for SDK generation
3. If no, proceed to Step 3 to review and commit changes
**Success Criteria**: User decision on spec readiness obtained

## Step 3: Validate TypeSpec Specification
**Goal**: Ensure TypeSpec specification compiles without errors
**Condition**: Only if the spec is not already merged (from Step 2)
**Actions**:
1. Before running, inform user that TypeSpec validation takes around 20 - 30 seconds. Provide complete summary after 
running the tool and highlight any errors and help user fix them.
2. Run `azsdk_run_typespec_validation` to validate the TypeSpec project.
3. If validation succeeds, proceed to Step 4
4. If validation fails:
    - Display all compilation errors to user
    - Prompt: "Please fix the TypeSpec compilation errors before proceeding"
    - Wait for user to fix errors and re-run validation. Provide detailed information about all the changes done by copilot and prompt the user before rerunning the validation.
**Success Criteria**: TypeSpec compilation passes without errors

## Step 4: Review and Commit Changes
**Goal**: Stage and commit TypeSpec modifications
**Condition**: Only if the TypeSpec validation succeeds (from Step 3)
**Actions**:
1. Run `azsdk_get_modified_typespec_projects` to identify changes
2. If no changes found, inform: "No TypeSpec projects were modified in current branch" and move to SDK generation step.
3. Display all modified files (excluding `.github` and `.vscode` folders)
4. Prompt user: "Please review the modified files. Do you want to commit these changes? (yes/no)"
5. If yes:
    - If on main branch, prompt user: "You are currently on the main branch. Please create a new branch using `git checkout -b <branch-name>` before proceeding."
    - Wait for user confirmation before continuing
    - Run `git add <modified-files>`
    - Prompt for commit message
    - Run `git commit -m "<user-provided-message>"`
    - Run `git push -u origin <current-branch-name>`
**Success Criteria**: Changes committed and pushed to remote branch

## Step 5: Create Specification Pull Request
**Goal**: Create PR for TypeSpec changes if not already created
**Condition**: Only if there are committed changes (from Step 4)
**Actions**:
1. Prompt the user to confirm if a pull request already exists for API spec changes. If answer is no or unsure then check if spec PR already exists using `azsdk_get_pull_request_link_for_current_branch`
2. If PR exists, display PR details and proceed to Step 6
3. If no PR exists:
    - Inform user: "No pull request found for the current branch. Proceeding to create a new pull request."
    - Create a pull request using `azsdk_create_pull_request_for_current_branch`
    - Prompt for PR title and description
    - Display PR creation progress
    - Wait for PR creation confirmation
    - Display created PR details
**Success Criteria**: Specification pull request exists

## Step 6: Generate SDKs
**Goal**: Generate SDKs
**Actions**:
1. Identify whether TypeSpec is for Management Plane or Data Plane based on project structure and files.
  - Execute the SDK generation pipeline with the following required parameters for all languages:
    - TypeSpec project root path
    - API spec pull request number (if the API spec is not merged to the main branch, otherwise use 0)
    - API version
    - SDK release type (beta for preview API versions, stable otherwise)
    - Language options:
        For management plane: `Python`, `.NET`, `JavaScript`, `Java`, `Go`
        For data plane: `Python`, `.NET`, `JavaScript`, `Java`
2. Monitor pipeline status after 15 minutes and provide updates. If pipeline is in progress, inform user that it may take additional time and check the status later.
3. Display generated SDK PR links when available
4. If SDK pull request is available for all languages, ask user to review generated SDK pull request and mark them as ready for review when they are ready to get them reviewed and merged.
5. IF SDK pull request was created for test purposes, inform user to close the test SDK pull request.
**Success Criteria**: SDK generation pipeline initiated and SDKs generated

## Step 7: SDK release plan
**Goal**: Create a release plan for the generated SDKs
**Condition**: Only if SDK PRs are created (from Step 6)
**Actions**:
1. Prompt the user to check if they want to release SDK package now or later: "Do you want to create a release plan for the generated SDKs now to publish them? (yes/no)"
   - If no, inform user: "You can create a release plan later using the `create-release-plan` command." and end the workflow.
2. Ask user if they have already created a release plan for the generated SDKs: "Have you already created a release plan for the generated SDKs? (yes/no)"
   - If no, proceed to create a new release plan
   - If yes, get release plan details and show them to user
3. Prompt the user to provide the API spec pull request link if not already available in the current context.
4. If unsure, check if a release plan already exists for API spec pull request.
5. Prompt user to find the service id and product id in service tree `aka.ms/st` and provide them. Stress the importance of correct service id and product id for proper release plan creation.
6. If a new release plan is needed, refer to #file:create-release-plan.instructions.md to create a release plan using the spec pull request. API spec pull request is required to create a release plan.
7. Prompt user to change spec PR to ready for review: "Please change the spec pull request to ready for review status"
8. Suggest users to follow the instructions on spec PR to get approval from API reviewers and merge the spec PR.
9. Link SDK pull requests to the release plan.
10. Each release plan must release SDK for all languages based on the TypeSpec project type (Management Plane or Data Plane). If any language is missing, inform user: "The release plan must include SDKs for all required languages: Python, .NET, JavaScript, Java, Go (for Management Plane) or Python, .NET, JavaScript, Java (for Data Plane)". If it is intentional to exclude a language then user must provide a justification for it.
**Success Criteria**: Release plan created and linked to SDK PRs

## Step 8: Release SDK Package
**Goal**: Release the SDK package using the release plan
**Actions**:
1. Prompt the user to confirm if they want to release the SDK package now: "Do you want to release the SDK package now? (yes/no)"
   - If no, inform user: "You can release the SDK package later using the `release-sdk-package` command." and end the workflow.
2. Get SDK pull request status for all languages.
3. Inform user that it needs to check SDK PR status. If any SDK pull request is not merged, inform user: "Please merge all SDK pull requests before releasing the package.". Show a summary of SDK PR status for all languages.
4. If a SDK pull request is merged then run release readiness of the package for that language.
5. Inform user if a language is ready for release and prompt user for a confirmation to proceed with the release.
6. If user confirms, run `ReleaseSdkPackage` to release the SDK package.
7. Inform user to approve the package release using release pipeline. Warn user that package will be published to public registries once approved.

## Process Complete
Display summary of all created PRs and next steps for user.