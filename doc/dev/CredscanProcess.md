# Guide for Validating the Build Compliance check on azure-sdk-for-net PRs

This guide describes how package owners can monitor their package's Credential Scanner (CredScan) status and correct any errors.
General information about CredScan can be found in the overview documentation at [aka.ms/credscan](credscan_doc). The
Azure SDK's motivation and methodology for running CredScan is documented [here](devops_doc).

## Table of Contents
- [Check CredScan Status](#check-credscan-status)
- [Correct Active Warnings](#correct-active-warnings)
  - [True Positives](#true-positives)
  - [False Positives](#false-positives)
- [Support](#support)

## Check CredScan Status
If your PR fails the Build Compliance check, follow these steps: 

1. Click “View more details on Azure Pipelines”. In the “Compliance” check on the Pipeline page, view the “Scanning for credentials” step. This page will show where the leaked secrets are in the current PR.

2. Each warning will begin with the path to the file containing a potential credential, as well as the row and column where
the credential string begins. For example, for a potential credential that starts in row 3 and column 20 of a
particular file:
```
##[error]sdk/{service}/{package}/{file}.json:sdk/{service}/{package}/{file}.json(3,20)
```

The warning will then list an error code and description of why the potential credential was flagged.

## True Positives
Depending on if you are working on a Track 1 service or a Track 2 service there are different steps to adding/modifying the sanitizer:

For a Track 1 Service:
1.	Access your service's TestBase.cs file.
2.	In the static constructor, JsonPathSanitizers can be added. This allows the sanitization of particular fields identified such as “accessSAS”. Add a field to sanitize like so: “RecorderUtilities.JsonPathSanitizers.Add("$..{FIELDNAMEHERE");”
3.	An example can be found in here in the Track 1 Compute [TestBase.cs file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/compute/Microsoft.Azure.Management.Compute/tests/ScenarioTests/VMTestBase.cs#L32).

For a Track 2 Service:
1.	Access your service's [RPName]ClientBase.cs file. It should extend the ManagementRecordedTestBase. An example for the  CosmosDBManagementClientBase class is shown [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.ResourceManager.CosmosDB/tests/CosmosDBManagementClientBase.cs).
2. Check the proctected constructor in your [RPName]ClientBase.cs file. If a [RPName]RecordedTestSanitizer object is initialized here, open that file. Otherwise, create a [RPName]RecordedTestSanitizer.cs file that extends the RecordedTestSanitizer class. An example of the CosmosDBRecordedTestSanitizer.cs can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.ResourceManager.CosmosDB/tests/CosmosDBManagementRecordedTestSanitizer.cs). 
3. Add the fields that need to be sanitized into the [RPName]RecordedTestSanitizer.cs file into the constructor as shown [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.ResourceManager.CosmosDB/tests/CosmosDBManagementRecordedTestSanitizer.cs#L14).
3.	If the protected constructor in your [RPName]ClientBase class does not create a [RPName]RecordedTestSanitizer object, add the initialization [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.ResourceManager.CosmosDB/tests/CosmosDBManagementClientBase.cs#L48).

Once you have added the Sanitizers, re-record all your test files that had leaked secrets. They should be replaced with the keyword “Sanitized”.
## False Positives
If CredScan flags something that's not actually a credential or secret, we can suppress the warning to shut off the
false alarm. CredScan allows you to suppress fake credentials by either suppressing a string value or by suppressing
warnings for a whole file. **Files that contain more than just fake credentials shouldn't be suppressed.**

Credential warnings are suppressed in [eng/CredScanSuppression.json][suppression_file]. Suppressed string values are in
the `"placeholder"` list, and suppressed files are in the `"file"` list under `"suppressions"`.

If you have a fake credential flagged by CredScan, try one of the following (listed from most to least preferable):
  - Import and use a suitable credential from a file that's already suppressed in [eng/CredScanSuppression.json](suppression_file).
  - Replace the credential with a string value that's already suppressed in [eng/CredScanSuppression.json](suppression_file).
  - Move the credential into a `fake_credentials.json` file in your package, and add the file path to the list of suppressed files if necessary.
  - Add the credential to the list of suppressed string values.

Ideally, fake credential files -- which contain nothing but fake secrets -- should be suppressed and their fake
credentials shouldn't appear in any other files. Sanitizers should be used to keep fake credentials out of test
recordings when possible. String value suppression should be avoided unless the string appears in many files.

Suppressing string values will disable warnings no matter where the string comes up during a scan, but is inefficient
and inconvenient for lengthy strings. Suppressing warnings in a file is convenient for fake credential files, but
strings in that file will still trigger warnings if present in another unsuppressed file.

## Support
If you have any questions about CredScan in azure-sdk-for-net, please post your question in this [Teams channel](https://teams.microsoft.com/l/channel/19%3a7b87fb348f224b37b6206fa9d89a105b%40thread.skype/Language%2520-%2520DotNet?groupId=3e17dcb0-4257-4a30-b843-77f47f1d4121&tenantId=72f988bf-86f1-41af-91ab-2d7cd011db47).
