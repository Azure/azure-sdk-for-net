---
mode: 'agent'
tools: ['GenerateSDK', 'GetSDKPullRequestDetails', 'GetReleasePlan', 'GetReleasePlanForPullRequest', 'GetPipelineRun', 'GetPipelineRunStatus', 'LinkSdkPullRequestToReleasePlan']
description: 'Generate SDKs from TypeSpec using pipeline'
---
Your goal is to generate SDKs from the TypeSpec spec pull request. Get API spec pull request link for current branch or from user if not available in current context.
Provide links to SDK pull request when generated for each language.

## Steps for SDK Generation

### Step 1: Check for Existing SDK Pull Requests
- Check if SDK pull requests exist from local SDK generation for any languages
- If SDK pull request exists for a language, skip SDK generation for that language
- Link existing SDK pull request to release plan

### Step 2: Retrieve and Validate Release Plan
- Retrieve the release plan for the API spec
- If API Lifecycle Stage is `Private Preview` then inform user that SDK generation is not supported for this stage and complete the workflow.
- Check if SDK generation has already occurred for each language
- Verify if SDK pull requests exist for each language:
    - If an SDK pull request exists, display its details
    - If no pull request exists or regeneration is needed, proceed to next step

### Step 3: Execute SDK Generation Pipeline
- Run SDK generation for each required language: Python, .NET, JavaScript, Java, and Go
- Execute the SDK generation pipeline with the following required parameters:
    - TypeSpec project root path
    - Pull request number (if the API spec is not merged to the main branch)
    - API version
    - SDK release type (beta for preview API versions, stable otherwise)
    - Language options: `Python`, `.NET`, `JavaScript`, `Java`, `Go`
    - Release plan work item ID

### Step 4: Monitor Pipeline Status
- Check the status of SDK generation pipeline every 2 minutes
- Continue monitoring until pipeline succeeds or fails
- Get SDK pull request link from pipeline once available

### Step 5: Display Results
- Show all pipeline details once pipeline is in completed status
- Highlight the language name for each SDK generation task when displaying details
- Once SDK pull request URL is available:
    - Inform the user of successful SDK generation
    - Display the pull request details for each language
    - Provide links to each generated SDK pull request