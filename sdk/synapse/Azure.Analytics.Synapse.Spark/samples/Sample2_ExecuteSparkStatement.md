# Create, Run and Cancel Synapse Spark statements and sessions

This sample demonstrates basic operations with three core classes in this library: `SparkSessionClient`, `SparkSession`, and `SparkStatement`. `SparkSessionClient` is used to submit statements for execution on Azure Synapse - each method call sends a request to the service's REST API. `SparkStatement` is an entity that represents an individual statement executed within a Spark Job within Synapse. These `SparkStatement` instances are grouped within a containing `SparkSession`. The sample walks through the basics of creating, running, and canceling of requests. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Spark/README.md) for links and instructions.

## Create Spark batch client

To submit statements to Spark running on Azure Synapse, you need to instantiate a `SparkSessionClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateSparkSessionClient
SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
```

## Create Spark session

All `SparkStatement` are created within the context of a `SparkSession`, so first create a spark session passing in details on the requested host.

```C# Snippet:CreateSparkSession
SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
{
    DriverMemory = "28g",
    DriverCores = 4,
    ExecutorMemory = "28g",
    ExecutorCores = 4,
    ExecutorCount = 2
};

SparkSession sessionCreated = client.CreateSparkSession(request);

// Waiting session creation completion
sessionCreated = PollSparkSession(client, sessionCreated);
```

## Retrieve a Spark Session

To retrieve an existing session call `GetSparkSession`, passing in the session ID.

```C# Snippet:GetSparkSession
SparkSession session = client.GetSparkSession(sessionCreated.Id);
Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
```

## Creating Spark statements

To create statements within a session call `CreateSparkStatement`, passing in both the statements details in a `SparkStatementOptions` along with the ID of the session. To wait for the statement's completion a `PollSparkStatement` call is required. This support code will be detailed below, and it hoped to be temporary. 

```C# Snippet:CreateSparkStatement
SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
{
    Kind = SparkStatementLanguageType.Spark,
    Code = @"print(""Hello world\n"")"
};
SparkStatement statementCreated = client.CreateSparkStatement(sessionCreated.Id, sparkStatementRequest);

// Wait operation completion
statementCreated = PollSparkStatement(client, sessionCreated.Id, statementCreated);
```

## Retrieve a statement

To retrieve an existing statement call `GetSparkStatement`, passing in both the session ID and the ID of the statement.

```C# Snippet:GetSparkStatement
SparkStatement statement = client.GetSparkStatement(sessionCreated.Id, statementCreated.Id);
Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
```

## Cancel a statement

To cancel a submitted statement call `CancelSparkStatement`, passing in both the session ID and the ID of the statement.

```C# Snippet:CancelSparkStatement
SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Msg}");
```

## Cancel a session

To cancel the entire Spark session  call `CancelSparkSession`, passing in the session ID.

```C# Snippet:CancelSparkSession
Response operation = client.CancelSparkSession(sessionCreated.Id);
```

## Support Code

Today the following support code is needed to poll the status of submitted Spark statements and sessions. It is hoped to be temporary, and folded into a standard LRO (Long Running Operation).

```C# Snippet:TemporarySparkSupportCode
 private const string Error = "error";
 private const string Dead = "dead";
 private const string Success = "success";
 private const string Killed = "killed";
 private const string Idle = "idle";

public static List<string> SessionSubmissionFinalStates = new List<string>
 {
     Idle,
     Error,
     Dead,
     Success,
     Killed
 };

 public static SparkSession PollSparkSession(
     SparkSessionClient client,
     SparkSession session,
     IList<string> livyReadyStates = null)
 {
     if (livyReadyStates == null)
     {
         livyReadyStates = SessionSubmissionFinalStates;
     }

     return Poll(
         session,
         s => s.Result.ToString(),
         s => s.State,
         s => client.GetSparkSession(s.Id, true),
         livyReadyStates);
 }

 private const string Starting = "starting";
 private const string Waiting = "waiting";
 private const string Running = "running";
 private const string Cancelling = "cancelling";

 private static List<string> ExecutingStates = new List<string>
 {
     Starting,
     Waiting,
     Running,
     Cancelling
 };

 private static SparkStatement PollSparkStatement(
     SparkSessionClient client,
     int sessionId,
     SparkStatement statement)
 {
     return Poll(
         statement,
         s => null,
         s => s.State,
         s => client.GetSparkStatement(sessionId, s.Id),
         ExecutingStates,
         isFinalState: false);
 }

 private static T Poll<T>(
     T job,
     Func<T, string> getJobState,
     Func<T, string> getLivyState,
     Func<T, T> refresh,
     IList<string> livyReadyStates,
     bool isFinalState = true,
     int pollingInMilliseconds = 0,
     int timeoutInMilliseconds = 0,
     Action<T> writeLog = null)
 {
     var timeWaitedInMilliSeconds = 0;
     if (pollingInMilliseconds == 0)
     {
         pollingInMilliseconds = 5000;
     }

     while (IsJobRunning(getJobState(job), getLivyState(job), livyReadyStates, isFinalState))
     {
         if (timeoutInMilliseconds > 0 && timeWaitedInMilliSeconds >= timeoutInMilliseconds)
         {
             throw new TimeoutException();
         }

         writeLog?.Invoke(job);
         //TestMockSupport.Delay(pollingInMilliseconds);
         System.Threading.Thread.Sleep(pollingInMilliseconds);
         timeWaitedInMilliSeconds += pollingInMilliseconds;

         // TODO: handle retryable excetpion
         job = refresh(job);
     }

     return job;
 }

 private static bool IsJobRunning(string jobState, string livyState, IList<string> livyStates, bool isFinalState = true)
 {
     if ("Succeeded".Equals(jobState, StringComparison.OrdinalIgnoreCase)
         || "Failed".Equals(jobState, StringComparison.OrdinalIgnoreCase)
         || "Cancelled".Equals(jobState, StringComparison.OrdinalIgnoreCase))
     {
         return false;
     }

     return isFinalState ? !livyStates.Contains(livyState) : livyStates.Contains(livyState);
 }
```
