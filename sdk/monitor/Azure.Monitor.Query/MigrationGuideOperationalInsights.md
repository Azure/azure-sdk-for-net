# Guide for migrating from Microsoft.Azure.OperationalInsights v1.1.0 to Azure.Monitor.Query v1.0.x

This guide assists you in the migration from [Microsoft.Azure.OperationalInsights](https://www.nuget.org/packages/Microsoft.Azure.OperationalInsights/) v1.1.0 to [Azure.Monitor.Query](https://www.nuget.org/packages/Azure.Monitor.Query/) v1.0.x. Side-by-side comparisons are provided for similar operations between the two client libraries.

Familiarity with the `Microsoft.Azure.OperationalInsights` v1.1.0 package is assumed. If you're new to the `Azure.Monitor.Query` client library for .NET, see the [README file](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/monitor/Azure.Monitor.Query#readme) instead of this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
  - [Cross-service SDK improvements](#cross-service-sdk-improvements)
  - [New features](#new-features)
- [Important changes](#important-changes)
  - [The client](#the-client)
  - [Client constructors and authentication](#client-constructors-and-authentication)
  - [Send a single query request](#send-a-single-query-request)
  - [Retrieve results from a table](#retrieve-results-from-a-table)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we've focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

Several areas of consistent feedback were expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services haven't had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was too steep. The APIs didn't offer an approachable and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel with respect to the .NET ecosystem. Further details are available in the guidelines.

### Cross-service SDK improvements

The `Azure.Monitor.Query` client library also takes advantage of the cross-service improvements made to the Azure development experience. Examples include:

- Using the new [`Azure.Identity`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#readme) library to share a single authentication approach between clients.
- A unified logging and diagnostics pipeline offering a common view of the activities across each of the client libraries.

### New features

There are a variety of new features in version 1.0 of the `Azure.Monitor.Query` library. Some highlights include:

- The ability to execute a batch of Kusto queries with the `LogsQueryClient.QueryBatch()` API.
- The ability to configure the retry policy used by the operations on the client.
- The ability to map a Logs query result to a strongly typed model.
- The ability to retrieve by column name instead of by column index.
- Authentication with Microsoft Entra credentials using [`Azure.Identity`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#readme).

For more new features, changes, and bug fixes, see the [CHANGELOG](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Monitor.Query_1.0.1/sdk/monitor/Azure.Monitor.Query/CHANGELOG.md).

## Important changes

### The client

To provide a more intuitive experience, the top-level client to query logs was renamed to `LogsQueryClient` from `OperationalInsightsDataClient`. `LogsQueryClient` can be authenticated using Microsoft Entra ID. This client is the single entry point to execute a single Kusto query or a batch of Kusto queries.

#### Consistency

There are now methods with similar names, signatures, and locations to create senders and receivers. The result is consistency and predictability on the various features of the library.

### Client constructors and authentication

In `Microsoft.Azure.OperationalInsights` v1.1.0:

```csharp
using Microsoft.Azure.OperationalInsights;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;

// code omitted for brevity

var adSettings = new ActiveDirectoryServiceSettings
{
    AuthenticationEndpoint = new Uri("https://login.microsoftonline.com"),
    TokenAudience = new Uri("https://api.loganalytics.io/"),
    ValidateAuthority = true
};

ServiceClientCredentials credentials = ApplicationTokenProvider.LoginSilentAsync(
    "<domainId or tenantId>", "<clientId>", "<clientSecret>", adSettings).GetAwaiter().GetResult();
var client = new OperationalInsightsDataClient(credentials);
```

In `Azure.Monitor.Query` v1.0.x:

```csharp
using Azure.Monitor.Query;
using Azure.Identity;

// code omitted for brevity
var credential = new ClientSecretCredential("<domainId or tenantId>", "<clientId>", "<clientSecret>");
var client = new LogsQueryClient(credential);
```

### Send a single query request

In `Microsoft.Azure.OperationalInsights` v1.1.0:

```csharp
using Microsoft.Azure.OperationalInsights.Models;

// code omitted for brevity

QueryResults response = await client.QueryAsync("AzureActivity | top 10 by TimeGenerated");
```

In `Azure.Monitor.Query` v1.0.x:

- The `QueryBody` is flattened. Users are expected to pass the Kusto query directly to the API.
- The `timespan` parameter is now required, which helps to avoid querying over the entire data set.

```csharp
using Azure;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;

// code omitted for brevity

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
	workspaceId,
	"AzureActivity | top 10 by TimeGenerated",
	new QueryTimeRange(TimeSpan.FromDays(1)));
```

### Retrieve results from a table

In `Microsoft.Azure.OperationalInsights` v1.1.0:

```csharp
using Microsoft.Azure.OperationalInsights;
using Microsoft.Azure.OperationalInsights.Models;

// code omitted for brevity

var client = new OperationalInsightsDataClient(credentials);
QueryResults response = await client.QueryAsync("AzureActivity | top 10 by TimeGenerated");
IList<Table> tables = response.Tables;

foreach (Table table in tables)
{
	IList<IList<string>> rows = table.Rows;

	foreach (IList<string> row in rows)
	{
	    foreach (string element in row)
        {
            Console.WriteLine(element);
        }
    }
}
```

In `Azure.Monitor.Query` v1.0.x:

```csharp
using Azure;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;

// code omitted for brevity

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
	workspaceId,
	"AzureActivity | top 10 by TimeGenerated",
	new QueryTimeRange(TimeSpan.FromDays(1)));
LogsTable table = response.Value.Table;
IReadOnlyList<LogsTableRow> rows = table.Rows;

foreach (LogsTableRow row in rows)
{
    Console.WriteLine(row.GetString(0)); // Access a particular element with index
    Console.WriteLine(row.GetTimeSpan(1));
    Console.WriteLine(row.ToString());
}
```

## Additional samples

For more examples, see [Samples for Azure.Monitor.Query](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/monitor/Azure.Monitor.Query#examples).
