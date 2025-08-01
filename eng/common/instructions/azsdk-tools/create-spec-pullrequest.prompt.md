---
mode: 'agent'
tools: ['codebase', 'CreatePullRequest', 'GetModifiedTypeSpecProjects', 'GetGitHubUserDetails', 'CheckIfSpecInPublicRepo', 'GetPullRequest', 'GetPullRequestForCurrentBranch']
---
Your goal is to identify modified TypeSpec project in current branch and create a pull request for it.
Check if a pull request already exists using GetPullRequestForCurrentBranch. If a pull request exists, inform the user and show the pull request details. If no pull request exists, create a new pull request using CreatePullRequest.

