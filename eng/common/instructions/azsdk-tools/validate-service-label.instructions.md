---
mode: 'agent'
tools: ['azsdk_check_service_label', 'azsdk_create_service_label']
---
 
## Goal
Validate service label exists or create new one for SDK release process.
 
## Step 1: Provide Information
 
Provide the following information about the importance of service labels:
 
"Before your SDK is released, your service must have a valid service label in the Azure SDK repositories. Service labels enable automatic owner assignment and notifications across the Azure SDK ecosystem.
 
When properly configured, service labels automatically:
 
- Notify service owners when issues are filed against their SDK
- Add appropriate reviewers to pull requests
- Connect code changes to the right team members through CODEOWNERS integration
 
Without a valid service label, the process to identify the correct service owners for issues and code reviews becomes manual and inefficient."
 
## Step 2: Get Service Label
 
Ask user for their service label. If they don't know their service label provide guidance:
 
- Check out the [Common Labels CSV](https://github.com/Azure/azure-sdk-tools/blob/main/tools/github/data/common-labels.csv) file and look for a row whose first column contains your service's product name.
 
If they don't have a service label - go to Step 3 for new service label
 
## Step 3: Validate Label
 
Use `azsdk_check_service_label` to check status:
 
- **Exists**: Success - user can proceed with next steps in SDK release process
- **InReview**: Label pending approval - user can proceed (will be available once merged)
- **DoesNotExist**: Go to Step 3 to create new label
- **NotAServiceLabel**: Label exists but it is not a service label - go to Step 3 for new service label
 
## Step 4: Create New Service Label
 
If no valid service label exists, guide the user through creating a new one.
 
1. **Check existing labels**: Search for related service labels, offer alternatives
2. **Generate recommendation**: Suggest label name following guidelines:
   - Should match the service's official product name as described on Service Tree (e.g., "Event Hubs", "Kusto", "Cosmos", etc.)
   - No "Microsoft/Azure" in name
   - Title Case (except short prepositions)
   - Avoid Service Groups: Use "Communication Rooms" instead of "Communication - Rooms"
   - Single label per service
3. **Get confirmation**: User confirms or modifies suggested name
4. **Create label**: Use `azsdk_create_service_label` with confirmed name and documentation link given by user
 
Inform user they can proceed.