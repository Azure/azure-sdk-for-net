---
mode: 'agent'
tools: ['azsdk_check_service_label', 'azsdk_create_service_label']
---

## Goal
Validate service label exists or create new one for SDK release process.

## Step 1: Get Service Label
Ask user for their service label. If none provided, explain that a valid service label is required for SDK release.

## Step 2: Validate Label
Use `azsdk_check_service_label` to check status:

- **Exists**: Success - user can proceed with next steps in SDK release process
- **InReview**: Label pending approval - user can proceed (will be available once merged)
- **DoesNotExist**: Go to Step 3 to create new label
- **NotAServiceLabel**: Label exists but it is not a service label - go to Step 3 for new service label

## Step 3: Create New Service Label
If no valid service label exists, guide the user through creating a new one.

1. **Check existing labels**: Search for related service labels, offer alternatives
2. **Generate recommendation**: Suggest label name following guidelines:
   - No "Microsoft/Azure" in name
   - Title Case (except short prepositions)
   - Avoid Service Groups: Use "Communication Rooms" instead of "Communication - Rooms"
   - Single label per service
3. **Get confirmation**: User confirms or modifies suggested name
4. **Create label**: Use `azsdk_create_service_label` with confirmed name and documentation link given by user

Inform user they can proceed.
