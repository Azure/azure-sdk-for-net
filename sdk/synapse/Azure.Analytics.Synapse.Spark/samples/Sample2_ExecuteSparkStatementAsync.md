# Create, Run and Cancel Synapse Spark statements and sessions

This sample demonstrates basic asynchronous operations with three core classes in this library: `SparkSessionClient`, `SparkSession`, and `SparkStatement`. `SparkSessionClient` is used to submit statements for execution on Azure Synapse - each method call sends a request to the service's REST API. `SparkStatement` is an entity that represents an individual statement executed within a Spark Job within Synapse. These `SparkStatement` instances are grouped within a containing `SparkSession`. The sample walks through the basics of creating, running, and canceling of requests. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.Spark/README.md) for links and instructions.

## Create Spark batch client

To submit statements to Spark running on Azure Synapse, you need to instantiate a `SparkSessionClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateSparkSessionClientAsync
// Replace the strings below with the spark and endpoint information
string sparkPoolName = "<my-spark-pool-name>";

string endpoint = "<my-endpoint-url>";

SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
```

## Create Spark session

All `SparkStatement` are created within the context of a `SparkSession`, so first create a spark session passing in details on the requested host by calling `StartCreateSparkSessionAsync` and then wait for the operation to be complete. 

```C# Snippet:CreateSparkSessionAsync
SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
{
    DriverMemory = "28g",
    DriverCores = 4,
    ExecutorMemory = "28g",
    ExecutorCores = 4,
    ExecutorCount = 2
};

SparkSessionOperation createSessionOperation = await client.StartCreateSparkSessionAsync(request);
SparkSession sessionCreated = await createSessionOperation.WaitForCompletionAsync();
```

## Retrieve a Spark Session

To retrieve an existing session call `StartGetSparkSessionAsync`, passing in the session ID.

```C# Snippet:GetSparkSessionAsync
SparkSession session = await client.GetSparkSessionAsync(sessionCreated.Id);
Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
```

## Creating Spark statements

To create statements within a session call `StartCreateSparkStatementAsync`, passing in both the statements details in a `SparkStatementOptions` along with the ID of the session and then wait for the operation to be complete.

```C# Snippet:CreateSparkStatementAsync
SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
{
    Kind = SparkStatementLanguageType.Spark,
    Code = @"print(""Hello world\n"")"
};

SparkStatementOperation createStatementOperation = await client.StartCreateSparkStatementAsync(sessionCreated.Id, sparkStatementRequest);
SparkStatement statementCreated = await createStatementOperation.WaitForCompletionAsync();
```

## Retrieve a statement

To retrieve an existing statement call `StartGetSparkStatementAsync`, passing in both the session ID and the ID of the statement.

```C# Snippet:GetSparkStatementAsync
SparkStatement statement = await client.GetSparkStatementAsync(sessionCreated.Id, statementCreated.Id);
Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
```

## Cancel a statement

To cancel a submitted statement call `CancelSparkStatement`, passing in both the session ID and the ID of the statement.

```C# Snippet:CancelSparkStatementAsync
SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Message}");
```

## Cancel a session

To cancel the entire Spark session  call `CancelSparkSession`, passing in the session ID.

```C# Snippet:CancelSparkSessionAsync
Response operation = client.CancelSparkSession(sessionCreated.Id);
```