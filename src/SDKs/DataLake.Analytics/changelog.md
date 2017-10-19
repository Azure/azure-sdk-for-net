## Microsoft.Azure.Management.DataLake.Analytics release notes
### Changes in 3.1.2-preview

**Notes**

- Add a read-only field, InnerError of type JobInnerError, to the JobInnerError class.

### Changes in 3.1.1-preview

**Notes**

- Reverted the fields "statistics" and "debugData" of the USqlJobProperties object to be read-only.

### Changes in 3.1.0-preview

**Breaking changes**

- Revised the inheritance structure for objects dealing with job creation, building, and retrieving.
    - NOTE: Only U-SQL is supported in this change; therefore, Hive is not supported.
    - When submitting jobs, change JobInformation objects to CreateJobParameters.
        - When setting the properties for the CreateJobParameters object, be sure to change the USqlJobProperties object to a CreateUSqlJobProperties object.
    - When building jobs, change JobInformation objects to BuildJobParameters objects.
        - When setting the properties for the BuildJobParameters object, be sure to change the USqlJobProperties object to a CreateUSqlJobProperties object.
        - NOTE: The following fields are not a part of the BuildJobParameters object:
            - degreeOfParallelism
            - priority
            - related
    - When getting a list of jobs, the object type that is returned is JobInformationBasic and not JobInformation (more information on the difference is below in the Notes section)
- When getting a list of accounts, the object type that is returned is DataLakeAnalyticsAccountBasic and not DataLakeAnalyticsAccount (more information on the difference is below in the Notes section)

**Notes**
	  
- When getting a list of jobs, the job information for each job now includes a strict subset of the job information that is returned when getting a single job
    - The following fields are included in the job information when getting a single job but are not included in the job information when getting a list of jobs:
        - errorMessage
        - stateAuditRecords
        - properties
            - runtimeVersion
            - script
            - type  
- When getting a list of accounts, the account information for each account now includes a strict subset of the account information that is returned when getting a single account 
    - There are two ways to get a list of accounts: List and ListByResource methods
    - The following fields are included in the account information when getting a list of accounts, which is less than the account information retrieved for a single account:
        - provisioningState
        - state
        - creationTime
        - lastModifiedTime
        - endpoint
- When retrieving account information, an account id field called "accountId" is now included.
    - accountId's description: The unique identifier associated with this Data Lake Analytics account.
- Add support for a `basic` parameter on `ListTables` and `ListTablesByDatabase` which enables a user to retrieve a limited set of properties when listing their tables, resulting in a performance improvement when full metadata is not required.

### Changes in 3.0.1

**Notes**

- This is a hotfix release; therefore, the changes addressed here do not carry over to the versions above.
- Add support for a `basic` parameter on `ListTables` and `ListTablesByDatabase` which enables a user to retrieve a limited set of properties when listing their tables, resulting in a performance improvement when full metadata is not required. (this is addressed in version 3.1.0-preview)
- Add a read-only field, InnerError of type JobInnerError, to the JobInnerError class (this is addressed in version 3.1.2-preview)
- Add two more states to `DataLakeAnalyticsAccountStatus` enum: `Undeleting` and `Canceled` (this will be addressed in an upcoming preview release)

### Changes in 3.0.0
- All previous preview changes (below) are now stable and part of the official release
- Add support for Compute Policy management
    - Compute policies allow an admin to define maximum parallelism and priority for jobs for given users and groups
    - The policy support can be accessed through the `ComputePolicy` operations property.
- Add support for Job Relationships
    - This allows for better definitions and searchability of jobs that are part of pipelines or specific runs.
    - There is a new property bag on JobInformation called `Related`
    - There are four new APIs allowing for retrieval of jobs in a pipeline or recurrence.

### Changes in 2.2.0-preview
- Introduces the new package item type for catalog items.
- Switched the FileType enum to a string since this field is read only and will have new types added and changed with some regularity.
- Allows for listing the following catalog items from their parent's parent item (the database)
    - Table
    - View
    - Table valued function
    - Table statistics

### Changes in 2.1.1-preview
- Update underlying AutoRest framework to the latest. This cleans up a lot of the generated code, making it easier to read.
- The property `FirewallAllowAzureIps` in the Account object is currently ignored by the service and will not have a value when calling get. This property will be enabled and honored by the service in a future update.

### Changes in 2.0.1-preview
- Add support for firewall rule management in Data Lake Analytics
- Remove minimum value requirements for Job parallelism. If a value < 1 is specified, it will use 1.
- Address minor documentation issues for methods and objects.

### Changes in 2.0.0
- As the first official stable release of the `Microsoft.Azure.Management.DataLake.Analytics` package, changes between this version and the preview version are enumerated below. 
    - All nested properties have been flattened down into their containing objects. For example: `myAccount.Properties.DefaultDataLakeStoreAccount` is now: `myAccount.DefaultDataLakeStoreAccount`
    -  Reorganized account management operations into three distinct operation groups: `Account`, `StorageAccounts` and `DataLakeStoreAccounts`. This results in changes to how certain operations are reached. For example, to get firewall rules previously this would be called: `myClient.Account.GetStorageAccount()`. Now: `myClient.StorageAccounts.Get()`.
    - All object properties have been updated to reflect whether they are required, optional or read-only (un-settable). This more explicitly helps the caller understand what they need to pass in and what they cannot pass in. As a result, there are some read-only properties that previously were not, and will need to be removed from object initialization.
    - Updates to include default values for some optional properties for objects. Please see class documentation for details on these defaults.
    - Added billing support for account creation and updates
    - Added support for CRUD of catalog credentials and initiated deprecation warnings for catalog secret CRUD, which will be removed in a future release.
    - As part of credential CRUD, added cascading delete support for a given credential, which will delete all other catalog resources dependent on the credential automatically.
    - Removed unsupported OData query options
    - Added new `SeverityType` enum values
    - Added deprecation warnings for `CreateSecret`,`UpdateSecret` and `DeleteSecret`
    - Fixed the return type for `UpdateSecret` to properly reflect that nothing is returned.
