---
description: 'Generate SDKs from TypeSpec'
---
Your goal is to guide the user through the process of generating SDKs from TypeSpec projects. **Before starting**, show all the high level steps to the user and ask: 

> "Would you like to begin the SDK generation process now? (yes/no)"

Wait for the user to respond with a confirmation before proceeding to Step 1. Use the provided tools to perform actions and gather information as needed.

## Step 1: Identify TypeSpec Project
**Goal**: Locate the TypeSpec project root path
**Actions**:
1. Check if `tspconfig.yaml` or `main.tsp` files are open in editor
2. If found, use the parent directory as project root
3. If not found, prompt user: "Please provide the path to your TypeSpec project root directory"
4. Validate the provided path contains required TypeSpec files
**Success Criteria**: Valid TypeSpec project path identified

## Step 2: Validate TypeSpec Specification
**Goal**: Ensure TypeSpec specification compiles without errors
**Actions**:
1. Refer to #file:validate-typespec.instructions.md
2. If validation succeeds, proceed to Step 3
3. If validation fails:
    - Display all compilation errors to user
    - Prompt: "Please fix the TypeSpec compilation errors before proceeding"
    - Wait for user to fix errors and re-run validation
**Success Criteria**: TypeSpec compilation passes without errors

## Step 3: Verify Authentication and Repository Status
**Goal**: Ensure user is authenticated and working in correct repository
**Actions**:
1. Run `azsdk_get_github_user_details` to verify login status
2. If not logged in, prompt: "Please login to GitHub using `gh auth login`"
3. Once logged in, display user details to confirm identity
4. Run `azsdk_typespec_check_project_in_public_repo` to verify repository
5. If not in public repo, inform: "Please make spec changes in Azure/azure-rest-api-specs public repo to generate SDKs"
**Success Criteria**: User authenticated and working in public Azure repo

## Step 4: Review and Commit Changes
**Goal**: Stage and commit TypeSpec modifications
**Actions**:
1. Run `azsdk_get_modified_typespec_projects` to identify changes
2. If no changes found, inform: "No TypeSpec projects were modified in current branch"
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

## Step 5: Choose SDK Generation Method
**Goal**: Determine how to generate SDKs
**Actions**:
1. Present options: "How would you like to generate SDKs?"
    - Option A: "Generate SDK locally".
    - Option B: "Use SDK generation pipeline"
2. Based on selection:
    - If Option A: 
        - Follow #file:./local-sdk-workflow.instructions.md to generate and compile the SDK.
        - After SDK has been generated, to continue the SDK release, users can create the SDK pull request manually then proceed to Step 9.
    - If Option B: Continue to Step 6
**Success Criteria**: SDK generation method selected

## Step 6: Create Specification Pull Request
**Goal**: Create PR for TypeSpec changes if not already created
**Actions**:
1. Check if spec PR already exists using `azsdk_get_pull_request_link_for_current_branch`
2. If PR exists, display PR details and proceed to Step 7
3. If no PR exists:
    - Refer to #file:create-spec-pullrequest.instructions.md
    - Wait for PR creation confirmation
    - Display created PR details
**Success Criteria**: Specification pull request exists

## Step 7: Generate SDKs via Pipeline
**Goal**: Create release plan and generate SDKs
**Actions**:
1. Refer to #file:create-release-plan.instructions.md
2. If SDK PRs exist, link them to the release plan
3. Refer to #file:sdk-details-in-release-plan.instructions.md to add languages and package names to the release plan
4. If TypeSpec project is for management plane, refer to #file:verify-namespace-approval.instructions.md to check package namespace approval.
5. Refer to #file:run-sdk-gen-pipeline.instructions.md with the spec PR
6. Monitor pipeline status and provide updates
7. Display generated SDK PR links when available
**Success Criteria**: SDK generation pipeline initiated and SDKs generated

## Step 8: Show Generated SDK PRs
**Goal**: Display all created SDK pull requests
**Actions**:
1. Run `azsdk_get_sdk_pull_request_link` to fetch generated SDK PR info.

## Step 9: Create release plan
**Goal**: Create a release plan for the generated SDKs
**Actions**:
1. Refer to #file:create-release-plan.instructions.md to create a release plan using the spec pull request.
2. If the release plan already exists, display the existing plan details.

## Step 10: Mark Spec PR as Ready for Review
**Goal**: Update spec PR to ready for review status
**Actions**:
1. Prompt user to change spec PR to ready for review: "Please change the spec pull request to ready for review status"
2. Get approval and merge the spec PR

## Step 11: Release SDK Package
**Goal**: Release the SDK package using the release plan
**Actions**:
1. Run `ReleaseSdkPackage` to release the SDK package.
2. Inform user to approve the package release using release pipeline.

## Process Complete
Display summary of all created PRs and next steps for user.
