---
description: 'Verify Setup'
---
This tool verifies the developer's environment for SDK development and release tasks. It returns what requirements are missing for the specified languages and repo.

Your goal is to identify the project repo root, and pass in the packagePath to the Verify Setup tool. For a language repo, pass in the language. For a non-language repo, do not pass in any languages to just check the core requirements. Summarize the output of the tool.

For example, in `azure-sdk-for-js`, run `azsdk_verify_setup` with `(langs=javascript, packagePath=<path>/azure-sdk-for-js)`.

Display results in a user-friendly and concise format, highlighting any missing dependencies or configuration issues that need to be addressed.
