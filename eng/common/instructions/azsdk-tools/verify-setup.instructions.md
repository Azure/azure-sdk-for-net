---
description: 'Verify Setup'
---

## Goal
This tool verifies the developer's environment for SDK development and release tasks. It returns what requirements are missing for the specified languages and repo, or success if all requirements are satisfied. It can help install supported requirements.

Your goal is to identify the project repo root, and pass in the `packagePath` to the Verify Setup tool. For a language repo, pass in the language of the repo.

## Instructions
1. Check what's missing by calling verify setup with just language and package path parameters. The tool responds with missing requirements, and if any are installable by the tool itself.
2. Ask the user if they want help installing any missing requirements that the tool can install. On approval, **use the tool again WITH THE EXACT PARAMETERS (langs=<language(s)>, packagePath=<path>, requirementsToInstall=["req", "req2", ...])**.

## Examples
- in `azure-sdk-for-js`, run `azsdk_verify_setup` with `(langs=javascript, packagePath=<path>/azure-sdk-for-js)`.
- to install, run `azsdk_verify_setup` with `(langs=javascript, packagePath=<path>/azure-sdk-for-js), requirementsToInstall=['pnpm', 'tsp'])`.

## Parameter Requirements
The user can specify multiple languages to check. If the user wants to check all languages, pass in ALL supported languages. Passing in no languages will only check the core requirements.

To help the user auto-install, YOU MUST pass in the exact approved list of requirements to install in `requirementsToInstall`. **The tool will not install any requirements that are not EXPLICITLY LISTED.** DO NOT PASS IN AN AUTOINSTALL BOOLEAN.

## Output
Display clear, step-by-step instructions on how to resolve any missing requirements identified. Explain why the requirement is necessary if it has a `reason` field. Organize requirements into categorical sections. 

Based on the user's shell environment, enhance the tool instructions with shell-specific commands for resolving missing dependencies.

When Python tool requirements fail, inform the user about the `AZSDKTOOLS_PYTHON_VENV_PATH` environment variable if they have setup issues. The verify-setup tool can only check Python requirements within the virtual environment specified by this environment variable.