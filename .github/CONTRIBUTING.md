# Contribute or Provide Feedback for Azure Service Bus

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Filing Issues](#filing-issues)
- [Pull Requests](#pull-requests)
    - [General guidelines](#general-guidelines)
    - [Testing guidelines](#testing-guidelines)

## Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Filing Issues

You can find all of the issues that have been filed in the [Issues](https://github.com/Azure/azure-service-bus-dotnet/issues) section of the repository.

If you encounter any bugs, please file an issue [here](https://github.com/Azure/azure-service-bus-dotnet/issues/new) and make sure to fill out the provided template with the requested information.

To suggest a new feature or changes that could be made, file an issue the same way you would for a bug, but remove the provided template and replace it with information about your suggestion.

### Pull Requests

If you are thinking about making a large change to this library, **break up the change into small, logical, testable chunks, and organize your pull requests accordingly**.

You can find all of the pull requests that have been opened in the [Pull Request](https://github.com/Azure/azure-service-bus-dotnet/pulls) section of the repository.

To open your own pull request, click [here](https://github.com/Azure/azure-service-bus-dotnet/compare). When creating a pull request, keep the following in mind:
- Make sure you are pointing to the fork and branch that your changes were made in
- The pull request template that is provided **should be filled out**; this is not something that should just be deleted or ignored when the pull request is created
    - Deleting or ignoring this template will elongate the time it takes for your pull request to be reviewed

#### General guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Title of the pull request is clear and informative
- There are a small number of commits that each have an informative message
- A description of the changes the pull request makes is included, and a reference to the bug/issue the pull request fixes is included, if applicable
- All files have the Microsoft copyright header

#### Testing guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Pull request includes test coverage for the included changes
- Tests must use xunit
- Test code should not contain hard coded values for resource names or similar values
- Test should not use App.config files for settings
