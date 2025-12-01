---
description: 'Verify Setup'
---

## Goal
This tool verifies the developer's environment for SDK development and release tasks. It returns what requirements are missing for the specified languages and repo, or success if all requirements are satisfied.

Your goal is to identify the project repo root, and pass in the `packagePath` to the Verify Setup tool. For a language repo, pass in the language of the repo.

## Examples
- in `azure-sdk-for-js`, run `azsdk_verify_setup` with `(langs=javascript, packagePath=<path>/azure-sdk-for-js)`.

## Parameter Requirements
The user can specify multiple languages to check. If the user wants to check all languages, pass in ALL supported languages. Passing in no languages will only check the core requirements.

## Output
Display results in an informative and concise step-by-step instructional format, highlighting any missing dependencies that need to be addressed and how to resolve them. Organize requirements by language category. 

Based on the user's shell environment, enhance the tool instructions with shell-specific commands for resolving missing dependencies.

When Python tool requirements fail, inform the user about the `AZSDKTOOLS_PYTHON_VENV_PATH` environment variable if they have setup issues. The verify-setup tool can only check Python requirements within the virtual environment specified by this environment variable.
