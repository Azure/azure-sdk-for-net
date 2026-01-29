---
description: 'Run the package validation checks for the SDK package.'
---
## Goal
Run the validation checks for the SDK package by collecting the required information from the user and executing the `azsdk_package_run_check` tool.

## Instructions
1. **Collect Required Information**:
    - Prompt the user for the absolute package path to the package directory for the SDK package they want to check.
    - Prompt the user to specify values for each of the parameters required by the azsdk_package_run_check tool. Present the user with options to pick from for the allowed values specified by the parameter schema.

2. **Execute Check**:
    - Use the `azsdk_package_run_check` tool with the package path and check type.

3. **Present Results**:
    - If the package has passed all validation checks, highlight and finish
    - If the package is not ready, display the specific check types that need to be fixed for each language.

## Expected User Interaction Flow
1. Ask: "What is the exact path of the package you want to check for validation?"
2. Ask: "Please specify the check type you want to run (e.g., 'all', 'linting', 'format', etc.)"
3. Execute the check using the provided information
4. Display results and next steps