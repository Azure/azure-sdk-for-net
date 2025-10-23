---
description: 'Verify SDK namespace approval for management plane'
---
This task is required only for management plane API spec and only if a release plan exists for the API spec pull request.

## Step 1: Check if release plan exists and it is for management plane SDK
**Goal**: Determine if a release plan exists for the API spec pull request or work item Id or release plan Id in current context.
**Actions**:
1. Get release plan and check if it is for management plane SDK
2. If not, inform user: "This task is only applicable for management plane SDKs. No action required."
3. Check if release plan already has namespace approval issue. Also prompt user to check if this is the first release of SDK.
4. If namespace approval issue exists, inform user: "Namespace approval issue already exists for this release plan.". Prompt user to
check if they want to link a different namespace approval issue to the release plan. Show namespace approval status.
5. Move to Step 2 if namespace approval issue does not exist or user wants to link a different namespace approval issue.

## Step 2: Gather Namespace Approval Information
**Goal**: Link namespace approval issue to the release plan.
**Actions**:
1. Collect GitHub issue created in Azure/azure-sdk repo for namespace approval. Do not use any other repo name.
2. Run `azsdk_link_namespace_approval_issue` to link the issue to the release plan work item id.
3. Confirm successful linking of the namespace approval issue to the release plan.
**Success Criteria**: Namespace approval issue linked to the release plan or confirmed as already linked.
