# Contribute Code or Provide Feedback for Azure SDK for .NET

This repository contains a set of Azure SDKs for .NET that can be consumed for Microsoft Azure applications.

## Basics

If you would like to become an active contributor to this project, please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines/).

In the Azure Developer Experience, you are at Step 4:

[Design, Build and Describe REST API](https://github.com/Azure/adx-documentation-pr/blob/master/README.md#step-1---design-build-and-describe-rest-api) -> [Get Your Swagger Approved](https://github.com/Azure/adx-documentation-pr/blob/master/README.md#step-2---get-your-swagger-approved) -> _**[Generate Request-Response Style Libraries](https://github.com/Azure/adx-documentation-pr/blob/master/README.md#step-3---generate-request-response-style-libraries)**_ -> [Build Command Line Experiences](https://github.com/Azure/adx-documentation-pr/blob/master/README.md#step-4---build-command-line-experiences)

## Table of Contents

[Before Starting](#before-starting)
- [Onboarding](#onboarding)
- [GitHub Basics](#github-basics)
    - [GitHub Workflow](#github-workflow)
    - [Forking the Azure/azure-sdk-for-net repository](#forking-the-azureazure-sdk-for-net-repository)
- [Code of Conduct](#code-of-conduct)

[Filing Issues](#filing-issues)

[Making Changes](#making-changes)
- [Pull Requests](#pull-requests)
- [REST API Specs](#rest-api-specs)
- [Pull Request Guidelines](#pull-request-guidelines)
    - [Cleaning up commits](#cleaning-up-commits)
    - [Breaking changes](#breaking-changes)
    - [General guidelines](#general-guidelines)
    - [Testing guidelines](#testing-guidelines)
    - [SDK generation guidelines](#sdk-generation-guidelines)

## Before Starting

### Onboarding

Before cloning this repository, please make sure you have started in our [documentation repository](https://github.com/Azure/adx-documentation-pr) (you will only have access to that page if you are part of the Azure organization).

### GitHub Basics

#### GitHub Workflow

If you don't have experience with Git and GitHub, some of the terminology and process can be confusing. [Here is a guide to understanding the GitHub flow](https://guides.github.com/introduction/flow/) and [here is a guide to understanding the basic Git commands](https://services.github.com/kit/downloads/github-git-cheat-sheet.pdf).

### Forking the Azure/azure-sdk-for-net repository

Unless you are working with multiple contributors on the same file, we ask that you fork the repository and submit your pull request from there. [Here is a guide to forks in GitHub](https://guides.github.com/activities/forking/).

###  Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Filing Issues

You can find all of the issues that have been filed in the [Issues](https://github.com/Azure/azure-sdk-for-net/issues) section of the repository.

If you encounter any bugs with Azure SDK for .NET, or would like to request a feature, please file an issue [here](https://github.com/Azure/azure-sdk-for-net/issues/new).

You can find the dates for the next three sprints for Azure SDK for .NET in the [Milestones](https://github.com/Azure/azure-sdk-for-net/milestones) section of the Issue page. Each milestone will display the issues that are being worked on for each corresponding sprint.

## Making Changes

### Pull Requests

You can find all of the pull requests that have been opened in the [Pull Request](https://github.com/Azure/azure-sdk-for-net/pulls) section of the repository.

To open your own pull request, click [here](https://github.com/Azure/azure-sdk-for-net/compare). When creating a pull request, keep the following in mind:
- Make sure you are pointing to the fork and branch that your changes were made in
- Choose the correct branch you want your pull request to be merged into
    - The **AutoRest** branch is for code generated from AutoRest
    - The **master** branch is for code generated from Hyak; code in this branch is in support mode only
    - The **Fluent** branch is for the next generation of Azure SDK Management libraries that implement Fluent interfaces
- The pull request template that is provided **should be filled out**; this is not something that should just be deleted or ignored when the pull request is created
    - Deleting or ignoring this template will elongate the time it takes for your pull request to be reviewed
- The SLA for reviewing pull requests is **two business days**

### REST API Specs

Before making any changes to the Azure SDK for .NET repository, the corresponding swagger spec must have been checked into the [Azure REST API Spec](https://github.com/Azure/azure-rest-api-specs) repository.

For more information on how to make changes to the REST API Specs repository, click [here](https://github.com/Azure/azure-rest-api-specs/blob/master/.github/CONTRIBUTING.md).

### Pull Request Guidelines

A pull request template will automatically be included as a part of your PR. Please fill out the checklist as specified. Pull requests **will not be reviewed** unless they include a properly completed checklist.

#### Cleaning up Commits

If you are thinking about making a large change to your SDK, **break up the change into small, logical, testable chunks, and organize your pull requests accordingly**.

Often when a pull request is created with a large number of files changed and/or a large number of lines of code added and/or removed, GitHub will have a difficult time opening up the changes on their site. This forces the Azure SDK for .NET team to use separate software to do a code review on the pull request.

If you find yourself creating a pull request and are unable to see all the changes on GitHub, we recommend **splitting the pull request into multiple pull requests that are able to be reviewed on GitHub**.

If splitting up the pull request is not an option, we recommend **creating individual commits for different parts of the pull request, which can be reviewed individually on GitHub**.

For more information on cleaning up the commits in a pull request, such as how to rebase, squash, and cherry-pick, click [here](https://github.com/Azure/azure-powershell/blob/dev/documentation/cleaning-up-commits.md).

#### Breaking Changes

Breaking changes should **not** be introduced into the repository without giving customers at least six months notice. For a description of breaking changes in Azure SDK for .NET, see [here](https://github.com/Azure/azure-sdk-for-net/blob/AutoRest/Documentation/breaking-changes.md).

#### General guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Title of the pull request is clear and informative
- There are a small number of commits that each have an informative message
- A description of the changes the pull request makes is included, and a reference to the swagger spec pull request is included if the SDK is being regenerated
- All files have the Microsoft copyright header
- The pull request does not introduce [breaking changes](https://github.com/Azure/azure-sdk-for-net/blob/AutoRest/Documentation/breaking-changes.md)

#### Testing Guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Pull request includes test coverage for the included changes


#### SDK Generation Guidelines

The following guidelines must be followed in pull requests that generate an SDK from a swagger spec

- A link to the pull request containing these swagger spec changes have been included in the description of the pull request
- The generate.cmd file for the SDK has been updated with the version of AutoRest, as well as a link to the swagger spec, used to generate the code
- The `project.json` and `AssemblyInfo.cs` files have been updated with the new version of the SDK