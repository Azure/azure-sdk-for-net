# All SDK Contribution checklist:

This checklist is used to make sure that common guidelines for a pull request are followed.
- [ ] **Please open PR in `Draft` mode if it is:**
	- Work in progress or not intended to be merged.
	- Encountering multiple pipeline failures and working on fixes.
- [ ] If an SDK is being regenerated based on a new swagger spec, a link to the pull request containing these swagger spec changes has been included above.
- [ ] **I have read the [contribution guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).**
- [ ] **The pull request does not introduce [breaking changes](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/breaking-change-rules.md).**

### [General Guidelines and Best Practices](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#general-guidelines)
- [ ] Title of the pull request is clear and informative.
- [ ] There are a small number of commits, each of which have an informative message. This means that previously merged commits do not appear in the history of the PR. For more information on cleaning up the commits in your PR, [see this page](https://github.com/Azure/azure-powershell/blob/master/documentation/development-docs/cleaning-up-commits.md).

### [Testing Guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#testing-guidelines)
- [ ] Pull request includes test coverage for the included changes.

### [SDK Generation Guidelines](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#sdk-generation-guidelines)
- [ ] The generate.cmd file for the SDK has been updated with the version of AutoRest, as well as the commitid of your swagger spec or link to the swagger spec, used to generate the code. (Track 2 only)
- [ ] The `*.csproj` and `AssemblyInfo.cs` files have been updated with the new version of the SDK. Please double check nuget.org current release version.

## Additional management plane SDK specific contribution checklist: 
Note: Only applies to `Microsoft.Azure.Management.[RP]` or `Azure.ResourceManager.[RP]`
 
- [ ] Include updated [management metadata](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/mgmt/mgmtmetadata).
- [ ] Update AzureRP.props to add/remove version info to maintain up to date API versions.

### Management plane SDK Troubleshooting
- If this is very first SDK for a services and you are adding new service folders directly under /SDK, please add `new service` label and/or contact assigned reviewer.
- If the check fails at the `Verify Code Generation` step, please ensure:
	- Do not modify any code in generated folders.
	- Do not selectively include/remove generated files in the PR.
	- Do use `generate.ps1/cmd` to generate this PR instead of calling `autorest` directly.
	Please pay attention to the @microsoft.csharp version output after running `generate.ps1`. If it is lower than current released version (2.3.82), please run it again as it should pull down the latest version.
	
	**Note: We have recently updated the PSH module called by `generate.ps1` to emit additional data. This would help reduce/eliminate the Code Verification check error. Please run following command**:

	    `dotnet msbuild eng/mgmt.proj /t:Util /p:UtilityName=InstallPsModules`

### Old outstanding PR cleanup
 Please note:
	If PRs (including draft) has been out for more than 60 days and there are no responses from our query or followups, they will be closed to maintain a concise list for our reviewers.
