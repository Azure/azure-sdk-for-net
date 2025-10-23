---
description: 'Check if the package validation checks have passed for the SDK package.'
---
## Goal
Check the validation checks for the SDK package by collecting the required information from the user and executing the run_check command.

## Instructions
1. **Collect Required Information**:
    - Prompt the user for the exact package name
    - Prompt the user to select the programming language from the following options (case sensitive):
      - Python
      - Java
      - JavaScript
      - .NET
      - Go
    - Prompt the user to select the check type to run (default to "all" if not specified):
      - all
      - changelog
      - dependency
      - readme
      - cspell
      - snippets
      - linting
      - format
      - checkaotcompat
      - generatedcodechecks
      - samples


2. **Execute Check**:
    - Use the `azsdk_package_run_check` tool with the package path and check type.
    - If the package path is not provided, use the package name and language to determine the package path for each language and prompt the user to confirm the path before proceeding.


3. **Present Results**:
    - If the package has passed all validation checks, highlight and finish
    - If the package is not ready, display the specific check types that need to be fixed for each language.

## Expected User Interaction Flow
1. Ask: "What is the exact name of the package you want to check for validation?"
2. Ask: "Please select the programming language for this package: Python, Java, JavaScript, .NET, Go, or All"
3. Execute the check using the provided information
4. Display results and next steps