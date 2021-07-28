<!-- DO NOT DELETE THIS TEMPLATE -->

## Description
<!--
Please add an informative description that covers that changes made by the pull request.

If you are regenerating your SDK based off of a new swagger spec, please add the link to the corresponding swagger spec pull request that has been merged in the azure-rest-api-specs repository
-->

---

This checklist is used to make sure that common guidelines for a pull request are followed.
- [ ] Please add REST spec PR link to the SDK PR
- [ ] **I have read the [contribution guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).**
- [ ] **The pull request does not introduce [breaking changes](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/breaking-change-rules.md).**

### [General Guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#general-guidelines)
- [ ] Title of the pull request is clear and informative.
- [ ] There are a small number of commits, each of which have an informative message. This means that previously merged commits do not appear in the history of the PR. For more information on cleaning up the commits in your PR, [see this page](https://github.com/Azure/azure-powershell/blob/master/documentation/development-docs/cleaning-up-commits.md).

### [Testing Guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#testing-guidelines)
- [ ] Pull request includes test coverage for the included changes.

### [SDK Generation Guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#sdk-generation-guidelines)
- [ ] If an SDK is being regenerated based on a new swagger spec, a link to the pull request containing these swagger spec changes has been included above.
- [ ] The generate.cmd file for the SDK has been updated with the version of AutoRest, as well as the commitid of your swagger spec or link to the swagger spec, used to generate the code.
- [ ] The `*.csproj` and `AssemblyInfo.cs` files have been updated with the new version of the SDK.
