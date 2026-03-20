# Release History

## 2.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0-beta.1 (2026-03-12)

### Features Added
This is the first release of the `Azure.AI.Extensions.OpenAI` library, a new extension package for the official `OpenAI` .NET library that facilitates and simplifies use of Microsoft Foundry extensions to OpenAI APIs. This package replaces the `Azure.AI.Projects.OpenAI` package. All features, related to `Agents` management were moved to `Azure.AI.Projects.Agents`.

### Breaking Changes
* The Agents tools were moved to the `Azure.AI.Projects.Agents` package.
* `GetProjectResponsesClientForAgent` cannot be used with `AgentDefinition` and `AgentRecord` as these classes are the part of the `Azure.AI.Projects.Agents` package.
