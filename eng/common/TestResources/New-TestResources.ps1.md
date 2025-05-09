---
external help file: -help.xml
Module Name:
online version:
schema: 2.0.0
---

# New-TestResources.ps1

## SYNOPSIS
Deploys live test resources defined for a service directory to Azure.

## SYNTAX

### Default (Default)
```
New-TestResources.ps1 [-BaseName <String>] [-ResourceGroupName <String>] [-ServiceDirectory] <String>
 [-TestResourcesDirectory <String>] [-TestApplicationId <String>] [-TestApplicationSecret <String>]
 [-TestApplicationOid <String>] [-SubscriptionId <String>] [-DeleteAfterHours <Int32>] [-Location <String>]
 [-Environment <String>] [-ResourceType <String>] [-ArmTemplateParameters <Hashtable>]
 [-AdditionalParameters <Hashtable>] [-EnvironmentVariables <Hashtable>] [-CI] [-Force] [-OutFile]
 [-SuppressVsoCommands] [-ServicePrincipalAuth] [-NewTestResourcesRemainingArguments <Object>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Provisioner
```
New-TestResources.ps1 [-BaseName <String>] [-ResourceGroupName <String>] [-ServiceDirectory] <String>
 [-TestResourcesDirectory <String>] [-TestApplicationId <String>] [-TestApplicationSecret <String>]
 [-TestApplicationOid <String>] -TenantId <String> [-SubscriptionId <String>]
 -ProvisionerApplicationId <String> [-ProvisionerApplicationOid <String>]
 [-ProvisionerApplicationSecret <String>] [-DeleteAfterHours <Int32>] [-Location <String>]
 [-Environment <String>] [-ResourceType <String>] [-ArmTemplateParameters <Hashtable>]
 [-AdditionalParameters <Hashtable>] [-EnvironmentVariables <Hashtable>] [-CI] [-Force] [-OutFile]
 [-SuppressVsoCommands] [-ServicePrincipalAuth] [-NewTestResourcesRemainingArguments <Object>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deploys live test resouces specified in test-resources.json or test-resources.bicep
files to a new resource group.

This script searches the directory specified in $ServiceDirectory recursively
for files named test-resources.json or test-resources.bicep.
All found test-resources.json
and test-resources.bicep files will be deployed to the test resource group.

If no test-resources.json or test-resources.bicep files are located the script
exits without making changes to the Azure environment.

A service principal may optionally be passed to $TestApplicationId and $TestApplicationSecret.
Test resources will grant this service principal access to the created resources.
If no service principal is specified, a new one will be created and assigned the
'Owner' role for the resource group associated with the test resources.

This script runs in the context of credentials already specified in Connect-AzAccount
or those specified in $ProvisionerApplicationId and $ProvisionerApplicationSecret.

## EXAMPLES

### EXAMPLE 1
```
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 keyvault
```

Run this in a desktop environment to create a new AAD application and Service Principal
for running live tests against the test resources created.
The principal will have ownership
rights to the resource group and the resources that it contains, but no other resources in
the subscription.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

### EXAMPLE 2
```
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus'
```

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to.
This will also create a new AAD
application and Service Principal for running live tests against the rest resources
created.
The principal will have ownership rights to the resource group and the
resources that it contains, but no other resources in the subscription.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

### EXAMPLE 3
```
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus' `
    -TestApplicationId 'REPLACE_WITH_TEST_APPLICATION_ID' `
    -TestApplicationSecret 'REPLACE_WITH_TEST_APPLICATION_SECRET'
```

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to.
This will grant ownership rights
to the 'TestApplicationId' for the resource group and the resources that it contains,
without altering its existing permissions.

### EXAMPLE 4
```
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus' `
    -ProvisionerApplicationId 'REPLACE_WITH_PROVISIONER_APPLICATION_ID' `
    -ProvisionerApplicationSecret 'REPLACE_WITH_PROVISIONER_APPLICATION_ID' `
    -TestApplicationId 'REPLACE_WITH_TEST_APPLICATION_ID' `
    -TestApplicationOid 'REPLACE_WITH_TEST_APPLICATION_OBJECT_ID' `
    -TestApplicationSecret 'REPLACE_WITH_TEST_APPLICATION_SECRET'
```

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to.
The script will be executed in the
context of the 'ProvisionerApplicationId' rather than the caller.

Depending on the permissions of the Provisioner Application principal, the script may
grant ownership rights 'TestApplicationId' for the resource group and the resources
that it contains, or may emit a message indicating that it was unable to perform the grant.

For the Provisioner Application principal to perform the grant, it will need the
permission 'Application.ReadWrite.OwnedBy' for the Microsoft Graph API.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

### EXAMPLE 5
```
New-TestResources.ps1 `
    -ServiceDirectory '$(ServiceDirectory)' `
    -TenantId '$(TenantId)' `
    -ProvisionerApplicationId '$(ProvisionerId)' `
    -ProvisionerApplicationSecret '$(ProvisionerSecret)' `
    -TestApplicationId '$(TestAppId)' `
    -TestApplicationSecret '$(TestAppSecret)' `
    -DeleteAfterHours 24 `
    -CI `
    -Force `
    -Verbose
```

Run this in an Azure DevOps CI (with approrpiate variables configured) before
executing live tests.
The script will output variables as secrets (to enable
log redaction).

## PARAMETERS

### -BaseName
A name to use in the resource group and passed to the ARM template as 'baseName'.
Limit $BaseName to enough characters to be under limit plus prefixes specified in
the ARM template.
See also https://docs.microsoft.com/azure/architecture/best-practices/resource-naming

Note: The value specified for this parameter will be overriden and generated
by New-TestResources.ps1 if $CI is specified.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Set this value to deploy directly to a Resource Group that has already been
created or to create a new resource group with this name.

If not specified, the $BaseName will be used to generate name for the resource
group that will be created.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceDirectory
A directory under 'sdk' in the repository root - optionally with subdirectories
specified - in which to discover ARM templates named 'test-resources.json' and
Bicep templates named 'test-resources.bicep'.
This can be an absolute path
or specify parent directories.
ServiceDirectory is also used for resource and
environment variable naming.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestResourcesDirectory
An override directory in which to discover ARM templates named 'test-resources.json' and
Bicep templates named 'test-resources.bicep'.
This can be an absolute path
or specify parent directories.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestApplicationId
Optional Azure Active Directory Application ID to authenticate the test runner
against deployed resources.
Passed to the ARM template as 'testApplicationId'.

If not specified, a new AAD Application will be created and assigned the 'Owner'
role for the resource group associated with the test resources.
No permissions
will be granted to the subscription or other resources.

For those specifying a Provisioner Application principal as 'ProvisionerApplicationId',
it will need the permission 'Application.ReadWrite.OwnedBy' for the Microsoft Graph API
in order to create the Test Application principal.

This application is used by the test runner to execute tests against the
live test resources.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestApplicationSecret
Optional service principal secret (password) to authenticate the test runner
against deployed resources.
Passed to the ARM template as
'testApplicationSecret'.

This application is used by the test runner to execute tests against the
live test resources.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestApplicationOid
Service Principal Object ID of the AAD Test Application.
This is used to assign
permissions to the AAD application so it can access tested features on the live
test resources (e.g.
Role Assignments on resources).
It is passed as to the ARM
template as 'testApplicationOid'

If not specified, an attempt will be made to query it from the Azure Active Directory
tenant.
For those specifying a service principal as 'ProvisionerApplicationId',
it will need the permission 'Application.Read.All' for the Microsoft Graph API
in order to query AAD.

For more information on the relationship between AAD Applications and Service
Principals see: https://docs.microsoft.com/azure/active-directory/develop/app-objects-and-service-principals

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant ID of a service principal when a provisioner is specified.
The same
Tenant ID is used for Test Application and Provisioner Application.

This value is passed to the ARM template as 'tenantId'.

```yaml
Type: String
Parameter Sets: Provisioner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Optional subscription ID to use for new resources when logging in as a
provisioner.
You can also use Set-AzContext if not provisioning.

If you do not specify a SubscriptionId and are not logged in, one will be
automatically selected for you by the Connect-AzAccount cmdlet.

Once you are logged in (or were previously), the selected SubscriptionId
will be used for subsequent operations that are specific to a subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionerApplicationId
Optional Application ID of the Azure Active Directory service principal to use for
provisioning the test resources.
If not, specified New-TestResources.ps1 uses the
context of the caller to provision.

If specified, the Provisioner Application principal would benefit from the following
permissions to the Microsoft Graph API:

  - 'Application.Read.All' in order to query AAD to obtain the 'TestApplicaitonOid'

  - 'Application.ReadWrite.OwnedBy' in order to create the Test Application principal
     or grant an existing principal ownership of the resource group associated with
     the test resources.

If the provisioner does not have these permissions, it can still be used with
New-TestResources.ps1 by specifying an existing Test Application principal, including
its Object ID, and managing permissions to the resource group manually.

This value is not passed to the ARM template.

```yaml
Type: String
Parameter Sets: Provisioner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionerApplicationOid
{{ Fill ProvisionerApplicationOid Description }}

```yaml
Type: String
Parameter Sets: Provisioner
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionerApplicationSecret
A service principal secret (password) used to provision test resources when a
provisioner is specified.

This value is not passed to the ARM template.

```yaml
Type: String
Parameter Sets: Provisioner
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeleteAfterHours
Positive integer number of hours from the current time to set the
'DeleteAfter' tag on the created resource group.
The computed value is a
timestamp of the form "2020-03-04T09:07:04.3083910Z".

An optional cleanup process can delete resource groups whose "DeleteAfter"
timestamp is less than the current time.

This is used for CI automation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 120
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Optional location where resources should be created.
If left empty, the default
is based on the cloud to which the template is being deployed:

* AzureCloud -\> 'westus'
* AzureUSGovernment -\> 'usgovvirginia'
* AzureChinaCloud -\> 'chinaeast2'
* Dogfood -\> 'westus'

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
Optional name of the cloud environment.
The default is the Azure Public Cloud
('AzureCloud')

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: AzureCloud
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
{{ Fill ResourceType Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Test
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArmTemplateParameters
Optional key-value pairs of parameters to pass to the ARM template(s).

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdditionalParameters
Optional key-value pairs of parameters to pass to the ARM template(s) and pre-post scripts.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentVariables
Optional key-value pairs of parameters to set as environment variables to the shell.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: @{}
Accept pipeline input: False
Accept wildcard characters: False
```

### -CI
Indicates the script is run as part of a Continuous Integration / Continuous
Deployment (CI/CD) build (only Azure Pipelines is currently supported).

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: ($null -ne $env:SYSTEM_TEAMPROJECTID)
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Force creation of resources instead of being prompted.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutFile
Save test environment settings into a .env file next to test resources template.

On Windows in the Azure/azure-sdk-for-net repository,
the contents of the file are protected via the .NET Data Protection API (DPAPI).
The environment file is scoped to the current service directory.
The environment file will be named for the test resources template that it was
generated for. For ARM templates, it will be test-resources.json.env. For
Bicep templates, test-resources.bicep.env.

If `$SupportsTestResourcesDotenv=$true` in language repos' `LanguageSettings.ps1`,
and if `.env` files are gitignore'd, and if a service directory's `test-resources.bicep`
file does not expose secrets based on `bicep lint`, a `.env` file is written next to
`test-resources.bicep` that can be loaded by a test harness to be used for recording tests.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressVsoCommands
By default, the -CI parameter will print out secrets to logs with Azure Pipelines log
commands that cause them to be redacted.
For CI environments that don't support this (like
stress test clusters), this flag can be set to $false to avoid printing out these secrets to the logs.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: ($null -eq $env:SYSTEM_TEAMPROJECTID)
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalAuth
Use the provisioner SP credentials to deploy, and pass the test SP credentials
to tests.
If provisioner and test SP are not set, provision an SP with user
credentials and pass the new SP to tests.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewTestResourcesRemainingArguments
Captures any arguments not declared here (no parameter errors)
This enables backwards compatibility with old script versions in
hotfix branches if and when the dynamic subscription configuration
secrets get updated to add new parameters.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
