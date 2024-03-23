# Using Microsoft.Rest.ClientRuntime.Azure.TestFramework

1. Getting Started
2. Acquiring TestFramework
3. Setup prior to Record/Playback tests
	1. Environment Variables
	2. Playback Test
	3. Record Test with Interactive login using OrgId
	4. Record Test with ServicePrincipal
4. Record/Playback tests
5. Change Test Environment settings at run-time
6. Troubleshooting
7. Supported Key=Value pairs in ConnectionString
8. Environment Variable Reference

## 2. Acquiring TestFramework

TestFramework is available on NuGet at https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.TestFramework/ .

Instructions to manually download it are available on NuGet. However TestFramework will be downloaded automatically as part of the build process, so manually downloading it should generally be unnecessary.

## 3. Setup prior to Record/Playback of tests

In order to Record/Playback a test, you need to setup a connection string that consists various key/value pairs that provides information to the test environment.

#### 3.1 Environment Variables

> TEST_CSM_ORGID_AUTHENTICATION

Value of the env. variable is the connection string that determines how to connect to Azure. This includes authentication and the Azure environment to connect to.

> AZURE_TEST_MODE

This specifies whether test framework will `Record` test sessions or `Playback` previously recorded test sessions.

#### 3.2 Playback Test

The default mode is Playback mode, so no setting up of connection string is required.

#### 3.3 Record Test with Interactive login using OrgId

This is no longer the preferred option because it only works when running on .NET Framework (Full Desktop version of .NET - 4.5.1+) When running on .NET Core you may get an error like `Interactive Login is supported only in NET45 projects`.

To use interactive login, set the following environment variables before starting Visual Studio:

	TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={SubId};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;
	AZURE_TEST_MODE=Record

#### 3.4 Record Test with ServicePrincipal

This is the preferred option for record because it works with both .NET Framework and .NET Core.

To create a service principal, follow the [Azure AD guide to create a Application Service Principal](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-active-directory-application). The application type should be `Web app / API` and the sign-on URL value is irrelevant (you can set any value).

After the service principal is created, you will need to give it access to Azure resources. This can be done with the following PowerShell command, with the [Service Principal Application ID](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key) (this is a guid, not the display name of the service principal) substituted in for `{clientId}`.

	New-AzureRmRoleAssignment -ServicePrincipalName {clientId} -RoleDefinitionName Contributor

To use this option, set the following environment variable before starting Visual Studio. The following values are substituted into the below connection string:

`clientId`: The [Service Principal Application ID](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

`clientSecret`: A [Service Principal Authentication Key](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

`tenantId`: The [AAD Tenant ID](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-tenant-id)


	TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={SubId};ServicePrincipal={clientId};ServicePrincipalSecret={clientSecret};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;
	AZURE_TEST_MODE=Record

## 4. Record/Playback Tests

1. Run the test and make sure that you got a generated .json file that matches the test name in the SessionRecords folder (usually be $sdk/artifacts/bin/{YOUR TEST PROJECT NAME}/{Configuration}/{TargetFramework}/SessionRecords)
2. Copy above SessionRecords folder back to the same level as test .csproj of your service, then add all *.json files to your test project in Visual Studio setting "Copy to Output Directory" property to "Copy if newer"
3. To assure that the records work fine, delete the connection string (default mode is Playback mode) OR change HttpRecorderMode within the connection string to "Playback"

## 5. Change Test Environment settings at run-time
#### 1. Once you set your connection string, you can add or update key/value settings

	Add new key/value pair
 	TestEnvironment.ConnectionString.KeyValuePairs.Add("Foo", "FooValue");

	Update Existing key/value pair
	TestEnvironment.ConnectionString.KeyValuePairs["keyName"]="new value"

	Accessing/Updating TestEndpoints
	TestEnvironment.Endpoints.GraphUri = new Uri("https://newGraphUri.windows.net");

###Note:###
Changing the above properties at run-time has the potential to hard code few things in your tests. Best practice would be to use these properties to change values at run-time from immediate window at run-time and avoid hard-coding certain values.

## 6. Troubleshooting

#### Issue: exceptions in Microsoft.Azure.Test.HttpRecorder

Ensure that the `HttpRecorderMode` in the `TEST_CSM_ORGID_AUTHENTICATION` environment variable is consistent with the value in `AZURE_TEST_MODE` environment variable.

## 7. Connection string

#### 7.1 Supported Key=Value pairs in Connectionstring
	* ManagementCertificate
	* SubscriptionId
	* AADTenant
	* UserId
	* Password
	* ServicePrincipal
	* ServicePrincipalSecret
	* Environment={Prod | Dogfood | Next | Current | Custom}
	* RawToken
	* RawGraphToken
	* HttpRecorderMode={Record | Playback}
	* AADAuthEndpoint
	* OptimizeRecordedFile={true | false:default}
	true: will trim recorded files when long running operations are detected.

	* GraphTokenAudienceUri
	* BaseUri
	* AADAuthUri
	* GalleryUri
	* GraphUri
	* IbizaPortalUri
	* RdfePortalUri
	* ResourceManagementUri
	* ServiceManagementUri
	* AADTokenAudienceUri
	* GraphTokenAudienceUri
	* DataLakeStoreServiceUri
	* DataLakeAnalyticsJobAndCatalogServiceUri

## 8. Supported Environment in Test framework (Azure environments)

#### 8.1 Default Environments and associated Uri

##### Environment = Prod

	AADAuthUri = "https://login.microsoftonline.com"
	GalleryUri = "https://gallery.azure.com/"
	GraphUri = "https://graph.windows.net/"
	IbizaPortalUri = "https://portal.azure.com/"
	RdfePortalUri = "http://go.microsoft.com/fwlink/?LinkId=254433"
	ResourceManagementUri = "https://management.azure.com/"
	ServiceManagementUri = "https://management.core.windows.net"
	AADTokenAudienceUri = "https://management.core.windows.net"
	GraphTokenAudienceUri = "https://graph.windows.net/"
	DataLakeStoreServiceUri = "https://azuredatalakestore.net"
	DataLakeAnalyticsJobAndCatalogServiceUri = "https://azuredatalakeanalytics.net"

##### Environment = Dogfood

	AADAuthUri = "https://login.windows-ppe.net";
	GalleryUri = "https://df.gallery.azure-test.net/";
	GraphUri = "https://graph.ppe.windows.net/";
	IbizaPortalUri = "http://df.onecloud.azure-test.net";
	RdfePortalUri = "https://windows.azure-test.net";
	ResourceManagementUri = "https://api-dogfood.resources.windows-int.net/";
	ServiceManagementUri = "https://management-preview.core.windows-int.net";
	AADTokenAudienceUri = "https://management.core.windows.net";
	GraphTokenAudienceUri = "https://graph.ppe.windows.net/";
	DataLakeStoreServiceUri = "https://caboaccountdogfood.net";
	DataLakeAnalyticsJobAndCatalogServiceUri = "https://konaaccountdogfood.net";

##### Environment = Next

	AADAuthUri = "https://login.windows-ppe.net"
	GalleryUri = "https://next.gallery.azure-test.net/"
	GraphUri = "https://graph.ppe.windows.net/"
	IbizaPortalUri = "http://next.onecloud.azure-test.net"
	RdfePortalUri = "https://auxnext.windows.azure-test.net"
	ResourceManagementUri = "https://api-next.resources.windows-int.net/"
	ServiceManagementUri = "https://managementnext.rdfetest.dnsdemo4.com"
	AADTokenAudienceUri = "https://management.core.windows.net"
	GraphTokenAudienceUri = "https://graph.ppe.windows.net/"
	DataLakeStoreServiceUri = "https://caboaccountdogfood.net"
	DataLakeAnalyticsJobAndCatalogServiceUri = "https://konaaccountdogfood.net"

##### Environment = Current

	AADAuthUri = "https://login.windows-ppe.net"
	GalleryUri = "https://df.gallery.azure-test.net/"
	GraphUri = "https://graph.ppe.windows.net/"
	IbizaPortalUri = "http://df.onecloud.azure-test.net"
	RdfePortalUri = "https://windows.azure-test.net"
	ResourceManagementUri = "https://api-dogfood.resources.windows-int.net/"
	ServiceManagementUri = "https://management-preview.core.windows-int.net"
	AADTokenAudienceUri = "https://management.core.windows.net"
	GraphTokenAudienceUri = "https://graph.ppe.windows.net/"
	DataLakeStoreServiceUri = "https://caboaccountdogfood.net"
	DataLakeAnalyticsJoAbndCatalogServiceUri = "https://konaaccountdogfood.net"

##### Environment = Custom
When specified, test framework expect all Uri's to be provided by the user as part of the connection string.

What is also supported is as below (connections string example)
>SubscriptionId=subId;Environment=Prod;AADAuthUri=customAuthUri;ResourceManagementUri=CustomResourceMgmtUri

Which translates to, all Uri from pre-defined Prod environment will be used, but AADAuthUri and ResourceManagementUri will be overridden by the one provided in the connection string
