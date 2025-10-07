---
description: 'Generate SDKs from TypeSpec'
---
Your goal is to guide the user through the process of generating SDKs from TypeSpec projects. **Before starting**, show all the high level steps to the user and ask: 

> "Would you like to begin the SDK generation process now? (yes/no)"

Wait for the user to respond with a confirmation before proceeding. Use the provided tools to perform actions and gather information as needed.

SDK languages to be generated:
- Management Plane: .NET, Go, Java, JavaScript, Python
- Data Plane: .NET, Java, JavaScript, Python

Pre-requisites:
- TypeSpec project path is available in the current context or provided by user. If not available, prompt user to provide the TypeSpec project root path (local path or GitHub URL).

# SDK generation steps

## Step: Generate SDKs
**Goal**: Generate SDKs
**Message to user**: "SDK generation will take approximately 15-20 minutes. Currently SDK is generated using Azure DevOps pipeline and it supports SDK generation from merged API spec or API spec pull request in https://github.com/Azure/azure-rest-api-specs repository only."
**Actions**:
1. Identify whether TypeSpec is for Management Plane or Data Plane based on project structure and files. tspconfig.yaml file contains `resource-manager` for management plane and `data-plane` for data plane as resource provider.
  - Execute the SDK generation pipeline with the following required parameters for all languages:
    - TypeSpec project root path
    - API spec pull request number (if the API spec is not merged to the main branch, otherwise use 0)
    - API version
    - SDK release type (`beta` for preview API versions, `stable` otherwise)
    - Language options:
        For management plane: `Python`, `.NET`, `JavaScript`, `Java`, `Go`
        For data plane: `Python`, `.NET`, `JavaScript`, `Java`
    - Each SDK generation tool call should show a label to indicate the language being generated.
2. Monitor pipeline status after 15 minutes and provide updates. If pipeline is in progress, inform user that it may take additional time and check the status later.
3. Display generated SDK PR links when available. If pipeline fails, inform user with error details and suggest to check pipeline logs for more information.
4. If SDK pull request is available for all languages, ask user to review generated SDK pull request and mark them as ready for review when they are ready to get them reviewed and merged.
5. IF SDK pull request was created for test purposes, inform user to close the test SDK pull request.
**Success Criteria**: SDK generation pipeline initiated and SDKs generated

## Step: SDK release plan
**Goal**: Create a release plan for the generated SDKs
**Condition**: Only if SDK PRs are created
**Message to user**: "Creating a release plan is essential to manage the release of the generated SDKs. Each release plan must include SDKs for all required languages based on the TypeSpec project type (Management Plane or Data Plane) or request exclusion approval for any excluded language. SDK pull request needs to get approval and merged to main branch before releasing the SDK package."
**Actions**:
1. Prompt the user to check if they generated the SDK just to test or do they intend to release it: "Do you want to create a release plan for the generated SDKs to publish them? (yes/no)"
   - If no, inform user: "You can create a release plan later when ready to release the SDK" and end the workflow.
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

## Step: Release SDK Package
**Goal**: Release the SDK package using the release plan
**Actions**:
1. Prompt the user to confirm if they want to release the SDK package now: "Do you want to release the SDK package now? (yes/no)"
   - If no, inform user: "You can release the SDK package later using the prompt `release <package name> for  <language>`" and end the workflow.
2. Get SDK pull request status for all languages.
3. Inform user that it needs to check SDK PR status. If any SDK pull request is not merged, inform user: "Please merge all SDK pull requests before releasing the package.". Show a summary of SDK PR status for all languages.
4. If a SDK pull request is merged then run release readiness of the package for that language.
5. Inform user if a language is ready for release and prompt user for a confirmation to proceed with the release.
6. If user confirms, run the tool to release the SDK package.
7. Inform user to approve the package release using release pipeline. Warn user that package will be published to public registries once approved.
8. Identify remaining languages to be released and inform user to release SDK for all languages to complete the release plan. Release plan completion is required for KPI attestation in service tree.

## Process Complete
Display summary of all created PRs and next steps for user.
