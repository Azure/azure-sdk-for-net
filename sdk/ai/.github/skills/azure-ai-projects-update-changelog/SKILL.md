---
name: update-changelog
description: "Update the CHANGELOG.md files of C# projects. Parameters: cs_root C# SDK repository root."
---

# Basic information.

This skill requires one parameter <cs_root>, denoting the root of a C# repository. The C# projects contain three `CHANGELOG.md` file in <cs_root>/sdk/ai/Azure.AI.Projects/, <cs_root>/sdk/ai/Azure.AI.Projects.Agents/, and <cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI/.

# Instructions
Get the differences by running

```powershell
cd <cs_root>
git diff
```

```bash
cd <cs_root>
git diff
```

Figure out, which classes are public facing and based on that populate the latest section of `Release History`. Append the found changes to the `### Features Added`, `### Breaking Changes`, `### Bugs Fixed` or `### Other Changes` section. It is also possible to add `### Sample Updates` section or append data to it. Do not modify the header, denoting version and release date, for example `## 2.1.0-beta.2 (Unreleased)`.
