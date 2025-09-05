---
description: 'This prompt is designed to check the release readiness of a SDK package.'
---
## Goal
Check the release readiness of an SDK package by collecting the required information from the user and executing the readiness check.

## Instructions
1. **Collect Required Information**:
    - Prompt the user for the exact package name
    - Prompt the user to select the programming language from the following options (case sensitive):
      - Python
      - Java
      - JavaScript
      - .NET
      - Go

2. **Execute Readiness Check**:
    - Use the `azsdk_check_package_release_readiness` tool with the provided package name and selected language
    - Do not check for existing pull requests to run this step.
    - Do not ask the user to create a release plan to run this step.

3. **Present Results**:
    - If the package is ready for release, highlight and provide the link to the release pipeline
    - If the package is not ready, display the specific issues that need to be resolved

4. **Follow-up Actions**:
    - Provide clear next steps based on the readiness status
    - If issues are found, offer guidance on how to resolve them

## Expected User Interaction Flow
1. Ask: "What is the exact name of the package you want to check for release readiness?"
2. Ask: "Please select the programming language for this package: Python, Java, JavaScript, .NET, or Go"
3. Execute the readiness check using the provided information
4. Display results and next steps
