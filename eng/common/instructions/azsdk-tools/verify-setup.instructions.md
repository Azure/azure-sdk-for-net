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
Display results in a user-friendly and concise format, highlighting any missing dependencies that need to be addressed and how to resolve them.

WHENEVER Python related requirements fail, ALWAYS ASK the user if they have set the `AZSDKTOOLS_PYTHON_VENV_PATH` system environment variable to their desired virtual environment. This tool can only check requirements in the venv path specified by that environment variable.
