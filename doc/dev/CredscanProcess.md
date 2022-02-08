# Guide for Validating the Build Compliance check on azure-sdk-for-net PRs

This guide describes how package owners can monitor their package's Credential Scanner (CredScan) status and correct any errors.
General information about CredScan can be found in the overview documentation at [aka.ms/credscan][credscan_doc]. The
Azure SDK's motivation and methodology for running CredScan is documented [here][devops_doc].

## Table of Contents
- [Check CredScan Status](#check-credscan-status)
- [Correct Active Warnings](#correct-active-warnings)
  - [True Positives](#true-positives)
  - [False Positives](#false-positives)
- [Correct Baselined Warnings](#correct-baselined-warnings)

## Check CredScan Status
CredScan is run each week over the entire `azure-sdk-for-net` repository as part of the
[net-aggregate-reports][aggregate_reports] pipeline. The scan produces a list of active warnings in the "Post
Analysis" task of the "ComplianceTools" job ([example output][credscan_output]).

Each warning will begin with the path to the file containing a potential credential, as well as the row and column where
the credential string begins. For example, for a potential credential that starts in row 3 and column 20 of a
particular file:
```
##[error]sdk/{service}/{package}/{file}.json:sdk/{service}/{package}/{file}.json(3,20)
```

The warning will then list an error code and description of why the potential credential was flagged.

## True Positives
If an Azure service access secret was leaked follow the following procedure:

1. Rotate the affected secrets.
2. Send an email to azuresdkengsysteam@microsoft.com with a list of affected resources and describe the way the leak happened.
3. Check if any unexpected changes were done to the resource while the secret was exposed.
4. If secret was leaked via a git commit try to erase it from the git history by squashing commits or rebasing while excluding the commit. Don't try to erase if the change was already merged to a master branch, just open a new PR that removes the secret.

If CredScan discovers an actual credential, please contact the EngSys team at azuresdkengsysteam@microsoft.com so any
remediation can be done.

## False Positives
If CredScan flags something that's not actually a credential or secret, we can suppress the warning to shut off the
false alarm. CredScan allows you to suppress fake credentials by either suppressing a string value or by suppressing
warnings for a whole file. **Files that contain more than just fake credentials shouldn't be suppressed.**

Credential warnings are suppressed in [eng/CredScanSuppression.json][suppression_file]. Suppressed string values are in
the `"placeholder"` list, and suppressed files are in the `"file"` list under `"suppressions"`.

If you have a fake credential flagged by CredScan, try one of the following (listed from most to least preferable):
  - Import and use a suitable credential from a file that's already suppressed in [eng/CredScanSuppression.json][suppression_file].
  - Replace the credential with a string value that's already suppressed in [eng/CredScanSuppression.json][suppression_file].
  - Move the credential into a `fake_credentials.json` file in your package, and add the file path to the list of suppressed files if necessary.
  - Add the credential to the list of suppressed string values.

Ideally, fake credential files -- which contain nothing but fake secrets -- should be suppressed and their fake
credentials shouldn't appear in any other files. Sanitizers should be used to keep fake credentials out of test
recordings when possible. String value suppression should be avoided unless the string appears in many files.

Suppressing string values will disable warnings no matter where the string comes up during a scan, but is inefficient
and inconvenient for lengthy strings. Suppressing warnings in a file is convenient for fake credential files, but
strings in that file will still trigger warnings if present in another unsuppressed file.

## Correct Baselined Warnings
In addition to active warning that appear in the [net-aggregate-reports][aggregate_reports] pipeline ouput, there
are also CredScan warnings that have been suppressed in [eng/dotnet.gdnbaselines][baseline]. This file is a snapshot of
the active warnings at one point in time; CredScan won't re-raise warnings that have been recorded here.

Ultimately, we hope to remove this baseline file from the repository entirely. If you see any warnings for a package
that you own in this file, please remove a few at a time from the file so that CredScan will output these warnings in
the pipeline. Then, resolve them following the steps from the [Correct Active Warnings](#correct-active-warnings)
section of this guide.

[aggregate_reports]: https://dev.azure.com/azure-sdk/internal/_build?definitionId=1399&_a=summary
[baseline]: https://github.com/Azure/azure-sdk-for-net/blob/main/eng/dotnet.gdnbaselines
[credscan_doc]: https://aka.ms/credscan
[credscan_output]: https://dev.azure.com/azure-sdk/internal/_build/results?buildId=1321293&view=logs&j=3b141548-98d7-5be1-7ef8-eeb08ca02972&t=7989ab4d-bdd3-5239-37e1-e3681bbc7025
[devops_doc]: https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/413/Credential-Scan-Step-in-Pipeline
[suppression_file]: https://github.com/Azure/azure-sdk-for-net/blob/main/eng/CredScanSuppression.json
