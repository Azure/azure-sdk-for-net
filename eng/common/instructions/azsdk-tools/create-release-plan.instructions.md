# Release Plan Creation Process
You goal is to create a valid release plan. You must prompt user to provide all required information and all input must match the format and requirement mentioned in step 3 below.

> **Important Note**
> Do **not** ask the user to manually edit the DevOps work item.
> To update a release plan manually, the user must use the [Release Planner Tool](https://apps.powerapps.com/play/e/ed2ffefd-774d-40dd-ab23-7fff01aeec9f/a/821ab569-ae60-420d-8264-d7b5d5ef734c?tenantId=72f988bf-86f1-41af-91ab-2d7cd011db47).

Follow these steps in order to create or manage a release plan for an API specification pull request:

## Step 1: Validate Prerequisites
- Check if an API spec pull request is available in the current context
- If no pull request is available, prompt the user to provide the API spec pull request link
- Validate that the provided pull request link is accessible and valid

## Step 2: Check Existing Release Plan
- Use `azsdk_get_release_plan_for_spec_pr` to check if a release plan already exists for the API spec pull request
- If a release plan exists:
    - Display the existing release plan details to the user
    - Skip to Step 5 (Link SDK Pull Requests)
- If no release plan exists, proceed to Step 3

## Step 3: Gather Release Plan Information
Collect the following required information from the user. Do not create a release plan with temporary values. Confirm the values with the user before proceeding to create the release plan.
If any details are missing, prompt the user accordingly:

- **API Lifecycle Stage**: Must be one of:
    - Private Preview
    - Public Preview  
    - GA (Generally Available)
- **Service Tree ID**: GUID format identifier for the service in Service Tree. Before creating release plan, always show the value to user and ask them to confirm it's a valid value in service tree.
- **Product Service Tree ID**: GUID format identifier for the product in Service Tree. Before creating release plan, always show the value to user and ask them to confirm it's a valid value in service tree.
- **Expected Release Timeline**: Format must be in "Month YYYY"
- **API Version**: The version of the API being released
- **SDK Release Type**: Value must be beta or stable.
    - "beta" for preview API versions
    - "stable" for GA API versions

## Step 4: Create Release Plan
- If the user doesn't know the required details, direct them to create a release plan using the release planner
- Provide this resource: [Release Plan Creation Guide](https://eng.ms/docs/products/azure-developer-experience/plan/release-plan-create)
- Once all information is gathered, use `azsdk_create_release_plan` to create the release plan
- Display the newly created release plan details to the user for confirmation
- Refer to #file:sdk-details-in-release-plan.instructions.md to identify languages configured in the TypeSpec project and add them to the release plan

## Step 5: Update SDK Details in Release Plan
- Refer to #file:sdk-details-in-release-plan.instructions.md to add languages and package names to the release plan
- If the TypeSpec project is for a management plane, refer to #file:verify-namespace-approval.instructions.md if this is first release of SDK.

## Step 6: Link SDK Pull Requests (if applicable)
- Ask the user if they have already created SDK pull requests locally for any programming language
- If SDK pull requests exist:
    - Collect the pull request links from the user
    - Use `azsdk_link_sdk_pull_request_to_release_plan` to link each SDK pull request to the release plan
    - Confirm successful linking for each SDK pull request

## Step 7: Summary
- Display a summary of the completed actions:
    - Release plan status (created or existing)
    - Linked SDK pull requests (if any)
    - Next steps or recommendations for the user