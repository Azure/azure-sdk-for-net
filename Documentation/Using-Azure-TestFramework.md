## How to Record tests

### Set Environment Variables

#### Environment Variables

`TEST_CSM_ORGID_AUTHENTICATION`
* This is the connection string that determines how to connect to Azure. This includes both your authentiation and the Azure environment to connect to.

`AZURE_TEST_MODE`
* This specifies whether the test framework will `Record` test sessions or `Playback` previously recorded test sessions.

#### Playback Test

The default test mode is `Playback` mode, so setting up the connection string is not required. You can optionally set environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=
AZURE_TEST_MODE=Playback
```

#### Record Test with Interactive login using OrgId

This is no longer the preferred option because it only works when running on .NET Framework. When running on .NET Core you may get an error like `Interactive Login is supported only in NET45 projects`.

To use this option, set the following environment variables before starting Visual Studio:

```
TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={SubId};UserId={orgId};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;
AZURE_TEST_MODE=Record
```

## Record or Playback Tests

- Open the .sln file for test project using the same terminal where the environment variables have been set.
- [Run the tests](https://github.com/Azure/azure-powershell/wiki/Azure-Powershell-Developer-Guide#running-tests) and make sure that you got a generated `.json` file that matches the test name in the bin folder under the `SessionRecords` folder
- Copy the `SessionRecords` folder inside the test project and add all `*.json` files in Visual Studio setting "Copy to Output Directory" property to "Copy if newer"
- To assure that the records work fine, delete the connection string (default mode is Playback mode) OR change HttpRecorderMode within the connection string to "Playback" and run the tests
- Once the tests have been recorded, the files can be manually copied over to the `SessionsRecord` directory or by simply running a powershell script 
```
    .\tools\HelperUtilities\psScripts\Copy-SessionRecords.ps1 -Source "<pathToSessionRecordsInBinDir>" -Destination "<pathToSessionRecordsInProject>"
```

For additional details about alternative authentication methods (ServicePrincipal) and recording powershell tests, click [here](https://github.com/Azure/azure-powershell/blob/preview/documentation/testing-docs/using-azure-test-framework.md)