Your goal is to help guide the user to create SDK locally for TypeSpec changes. This is currently supported for **Python** only. User can generate SDK for other languages using SDK generation pipeline.
## Steps to create Python SDK locally from TypeSpec
### Step 1: Check for existing azure-sdk-for-python repository
- Prompt the user to provide the path to their cloned azure-sdk-for-python repository.
### Step 2: Validate repository path
- If the user provides a path to the azure-sdk-for-python repository:
    - Check if the repository exists at the specified path.
    - If the repository exists, proceed to Step 5.
### Step 3: Guide user to set up azure-sdk-for-python repository (if not found)
- If the user does not have the repository or the path is invalid:
    - Go to parent directory of current repo root path.
    - Provide instructions to fork https://github.com/Azure/azure-sdk-for-python repository to the user's GitHub account.
    - Provide instructions to clone the forked repository to the local machine:
        ```bash
        git clone https://github.com/<github-username>/azure-sdk-for-python.git
        ```
### Step 4: Set repository path
- Consider the cloned path as the path to the azure-sdk-for-python repository.
### Step 5: Open azure-sdk-for-python repository in VSCode
- Do not ask the user to run tsp compile.
- Prompt user to open the azure-sdk-for-python repository in VSCode.
### Step 6: Provide SDK generation instructions
- Inform user to use the following prompt to start SDK generation using GitHub Copilot agent:
    ```
    "Help me generate SDK for Python from TypeSpec API specification for project <path to TypeSpec project root>."
    ```
### Step 7: Inform user about SDK generation       
- Inform user to provide link to SDK pull request if they generate SDK locally and created a pull request for it. SDK generation
step below will skip it for the language and reuse the pull request link provided by the user.
- In some cases, user will come back and make more changes to TypeSpec so start the process from step 1 again.
- If user provides a link to SDK pull request then link SDK pull request to release plan if a release plan already exists and skip SDK generation for that language.
- If a release plan does not exits then link the SDK pull request when release plan is created.
