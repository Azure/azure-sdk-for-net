---
mode: 'agent'
tools: ['azsdk_check_service_label', 'azsdk_engsys_validate_codeowners_entry_for_service', 'azsdk_engsys_codeowner_update']
---

## Goal:
Validate service label and ensure at least 2 valid code owners exist for SDK repositories.

## Step 1: Validate Service Label
Use `azsdk_check_service_label` to verify the service label exists:
- **DoesNotExist/NotAServiceLabel**: Direct user to create valid service label first. Stop validation process until service label is created.
- **Exists/InReview**: Proceed to Step 2

## Step 2: Validate Code Owners
Ask user to specify SDK repository they want to validate codeowners for or detect from context.

Repository name mapping:
- .NET/dotnet: use "azure-sdk-for-net"
- Python: use "azure-sdk-for-python"
- Java: use "azure-sdk-for-java"
- JavaScript: use "azure-sdk-for-js"
- Go: use "azure-sdk-for-go"

Use `azsdk_engsys_validate_codeowners_entry_for_service` with either `serviceLabel` OR `repoPath` or both, but at least one must be used. If one isn't provided, leave the parameter field empty.

**If entry exists**: Go to Step 3
**If no entry exists**: Go to Step 4

## Step 3: Check Existing Code Owners
Valid code owners must be:
- PUBLIC members of Microsoft and Azure GitHub organizations
- Have write access to the SDK repository

**If at least 2 valid owners**: Success - optionally add or delete additional owners
**If less than 2 valid owners**: CRITICAL - must fix before proceeding:

After any changes, re-validate with `azsdk_engsys_validate_codeowners_entry_for_service`.

## Step 4: Create New Code Owner Entry
When no CODEOWNERS entry exists yet:
1. Ensure you have the following information
   - repo - **Required** - Repository name mapping:
      - .NET/dotnet: use "azure-sdk-for-net"
      - Python: use "azure-sdk-for-python"
      - Java: use "azure-sdk-for-java"
      - JavaScript: use "azure-sdk-for-js"
      - Go: use "azure-sdk-for-go"
   - typeSpecProjectRoot - **Optional** This should be acquired only if the information is present in the previous chat history, if not, ignore and input `""`.
   - path - **Optional** only if there is a service label and we're not making a new entry - This should be acquired when creating a new code owner entry, if no information is present ask the user. Typically looks like `/sdk/projectpath`
   - serviceLabel - **Optional** only if there is a path and we're not making a new entry - This should be acquired from the previous step of Check or Create Service Label.
   - serviceOwners - **Optional** if no ServiceLabel is present. Can be either owners to add or delete, depending on isAdding.
   - sourceOwners - **Optional** if no path or PRLabel are present. Can be either owners to add or delete, depending on isAdding.
   - isAdding - **Required** Should be true if adding owners to an existing entry, false if deleting owners from an existing entry. Should also be false when adding a brand new entry.
1. Provide information to the user about what codeowners is for:
   - [Learn about CODEOWNERS](https://eng.ms/docs/products/azure-developer-experience/develop/supporting-sdk-customers/overview)
   - Service owners is for getting mentioned on issues.
   - Source owners is for getting mentioned in PRs.
2. Collect service owners and source owners (GitHub usernames)
3. Use `azsdk_engsys_codeowner_update` with required parameters
4. Must have at least 2 valid owners from the start

### Fix Options:
1. **Fix invalid owners** - If there are invalid owners after modifing the CODEOWNERS file ALWAYS provide guidance.
   Follow instructions [here](https://aka.ms/azsdk/access) for:
   - Joining Microsoft and Azure GitHub orgs
   - Setting public visibility
   - Requesting write access
2. **Add new owners** using `azsdk_engsys_codeowner_update` with `isAdding: true`
3. **Remove invalid + add valid** owners using `azsdk_engsys_codeowner_update`

## Requirements
- **MINIMUM**: At least 2 valid code owners at all times
- **NO EXCEPTIONS**: Cannot proceed with insufficient owners
- **RESPONSE HANDLING**: If any exception occurs during validation or creation, ALWAYS provide documentation link [CODEOWNERS documentation](https://eng.ms/docs/products/azure-developer-experience/develop/supporting-sdk-customers/codeowners)