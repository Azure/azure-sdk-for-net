# Filing Issues

Filing issues is a great way to contribute to the SDK. Here are some guidelines:

* Include as much detail as you can be about the problem
* Point to a test repository (e.g. hosted on GitHub) that can help reproduce the issue. This works better then trying to describe step by step how to create a repro scenario.
* Github supports markdown, so when filing bugs make sure you check the formatting before clicking submit.

# Contributing Code

## Coding Guidelines

We're in the process of formalizing the coding guidelines for the SDK. For the time being, just follow the existing patterns already present in the code.

## Development Workflow

We actively develop in the dev branch which currently corresponds to WebJobs 3.x . This means that all pull requests by contributors need to be developed and submitted to the dev branch.

When we ship a new release of the SDK, we create a tag for it.

## Building and Running Tests

For details on development prereqs and running tests see [here](https://github.com/Azure/azure-webjobs-sdk/wiki/Development).

## Submitting Pull Requests

Before we can accept your pull-request you'll need to sign a [Contribution License Agreement (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement). You can sign ours [here](https://cla2.dotnetfoundation.org). However, you don't have to do this up-front. You can simply clone, fork, and submit your pull-request as usual.

When your pull-request is created, we classify it. If the change is trivial, i.e. you just fixed a typo, then the PR is labelled with `cla-not-required`. Otherwise it's classified as `cla-required`. In that case, the system will also also tell you how you can sign the CLA. Once you signed a CLA, the current and all future pull-requests will be labelled as `cla-signed`. Signing the CLA might sound scary but it's actually super simple and can be done in less than a minute.

Make sure you can build the code. Familiarize yourself with the project workflow and our coding conventions. If you don't know what a pull request is read this https://help.github.com/articles/using-pull-requests.

Before submitting a feature or substantial code contribution please discuss it with the team and ensure it follows the product roadmap. Note that all code submissions will be rigorously reviewed and tested by the WebJobs SDK Team, and only those that meet the bar for both quality and design/roadmap appropriateness will be merged into the source.
