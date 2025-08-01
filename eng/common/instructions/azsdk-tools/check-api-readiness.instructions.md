---
mode: 'agent'
tools: ['CheckApiReadyForSDKGeneration', 'codebase', 'GetPullRequest', 'GetGitHubUserDetails', 'GetPullRequestForCurrentBranch']
description: 'Check API Readiness for SDK Generation'
---
Your goal is to check if API spec pull request is ready for SDK generation. Identify the next action required from user  based on the comments on spec pull request if spec is not ready and notify the user.
Before running, get spec pull request link for current branch or from user if not available in current context. If pull request has APIView links, then highlight them to user.