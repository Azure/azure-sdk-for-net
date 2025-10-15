> **Important Note for LLM**
> Backend processes may use Azure DevOps work item data as needed. However, do **not** mention or display the work item link/URL, or any reference to Azure DevOps work item resources directly in conversation with the user.
> All manual updates to an existing release plan must be made through the [Release Planner Tool](https://aka.ms/sdk-release-planner) to ensure proper tracking and validation.
> Only provide release plan details such as **Release Plan Link** and **Release Plan ID** to the user

# Release Plan Creation Process
Your goal is to create a valid release plan. You must prompt user to provide all required information and all input must match the format and requirement mentioned in step 3 below.
Follow these steps in order to create or manage a release plan for an API specification pull request:

## Step 1: Validate Prerequisites
- Check if an API spec pull request is available in the current context
- If no pull request is available, prompt the user to provide the API spec pull request link
- Validate that the provided pull request link is accessible and valid

## Step 2: Gather Release Plan Information
Collect the following required information from the user. Do not create a release plan with temporary values. Confirm the values with the user before proceeding to create the release plan.
If any details are missing, prompt the user accordingly:

- **Service Tree ID**: GUID format identifier for the service in Service Tree. Before creating release plan, always show the value to user and ask them to confirm it's a valid value in service tree.
- **Product Service Tree ID**: GUID format identifier for the product in Service Tree. Before creating release plan, always show the value to user and ask them to confirm it's a valid value in service tree.
- **Expected Release Timeline**: Format must be in "Month YYYY"
- **API Version**: The version of the API being released
- **SDK Release Type**: Value must be beta or stable.
    - "beta" for preview API versions
    - "stable" for GA API versions

## Step 3: Create Release Plan
- If the user doesn't know the required details, direct them to create a release plan using the release planner
- Provide this resource: [Release Plan Creation Guide](https://eng.ms/docs/products/azure-developer-experience/plan/release-plan-create)
- Once all information is gathered, use `azsdk_create_release_plan` to create the release plan
- If existing release plans are found, follow the instructions under Step 3a - Handle Existing Release Plans
- Display the newly created release plan details to the user for confirmation
- Refer to #file:sdk-details-in-release-plan.instructions.md to identify languages configured in the TypeSpec project and add them to the release plan

### Step 3a: Handle Existing Release Plans
- When `azsdk_create_release_plan` returns existing release plans.
  - Extract and display key information: Release Plan ID, status, associated languages, SDK PRs
  - Present the three options:
    1. **Work with the existing release plan** - Use the current release plan and make any needed updates
    2. **Force create a new release plan** - Create a completely new release plan even though one already exists
    3. **Cancel** - Don't proceed with release plan creation

## Step 4: Update SDK Details in Release Plan
- Refer to #file:sdk-details-in-release-plan.instructions.md to add languages and package names to the release plan
- If the TypeSpec project is for a management plane, refer to #file:verify-namespace-approval.instructions.md if this is first release of SDK.

## Step 5: Link SDK Pull Requests (if applicable)
- Ask the user if they have already created SDK pull requests locally for any programming language
- If SDK pull requests exist:
    - Collect the pull request links from the user
    - Use `azsdk_link_sdk_pull_request_to_release_plan` to link each SDK pull request to the release plan
    - Confirm successful linking for each SDK pull request

## Step 6: Summary
- Display a summary of the completed actions:
    - Release plan status (created or existing)
    - Linked SDK pull requests (if any)
    - Next steps or recommendations for the user