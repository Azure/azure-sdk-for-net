---
description: 'Verify Setup'
---

## Goal
This tool verifies the developer's environment for SDK development and release tasks. It returns what requirements are missing for the specified languages and repo.

Your goal is to identify the project repo root, and pass in the `packagePath` to the Verify Setup tool. For a language repo, pass in the language of the repo.

## Examples
- in `azure-sdk-for-js`, run `azsdk_verify_setup` with `(langs=javascript, packagePath=<path>/azure-sdk-for-js)`.
- in `azure-sdk-for-python`, run `azsdk_verify_setup` with `(langs=python, packagePath=<path>/azure-sdk-for-python, venvPath=<path-to-venv>)`.

## Parameter Requirements
When Python is included in `langs`, BEFORE RUNNING `azsdk_verify_setup`, you MUST ASK THE USER TO SPECIFY WHICH virtual environment they want to check. DO NOT ASSUME THE VENV WITHOUT ASKING THE USER. After obtaining the `venvPath`, you can run the tool.

The user can specify multiple languages to check. If the user wants to check all languages, pass in all supported languages. Passing in no languages will only check the core requirements.

## Output
Display results in a user-friendly and concise format, highlighting any missing dependencies that need to be addressed.
