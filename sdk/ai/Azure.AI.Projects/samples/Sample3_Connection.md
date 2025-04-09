# Sample for Azure.AI.Projects with `ConnectionClient`

In this example we will demonstrate getting the `Serverless` connection to the Azure OpenAI or GIT endpoint, and using chat completion model, deployed on this endpoint. Please note, this example requires the connection to be authenticated in Azure AI Foundry using `ApiKey`.

Synchronous sample:
```C# Snippet:ConnectionExampleSync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new(connectionString, new DefaultAzureCredential());
ConnectionsClient connectionsClient = client.GetConnectionsClient();

ConnectionResponse connection = connectionsClient.GetDefaultConnection(ConnectionType.Serverless, true);

if (connection.Properties.AuthType == AuthenticationType.ApiKey)
{
    var apiKeyAuthProperties = connection.Properties as ConnectionPropertiesApiKeyAuth;
    if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
    {
        throw new ArgumentException("The API key authentication target URI is missing or invalid.");
    }

    if (!Uri.TryCreate(apiKeyAuthProperties.Target, UriKind.Absolute, out var endpoint))
    {
        throw new UriFormatException("Invalid URI format in API key authentication target.");
    }

    var credential = new AzureKeyCredential(apiKeyAuthProperties.Credentials.Key);
    ChatCompletionsClient chatClient = new(endpoint, credential);

    var requestOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
        Model = modelDeploymentName
    };

    ChatCompletions response = chatClient.Complete(requestOptions);
    Console.WriteLine(response.Content);
}
```

Asynchronous sample:
```C# Snippet:ConnectionExampleAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new(connectionString, new DefaultAzureCredential());
ConnectionsClient connectionsClient = client.GetConnectionsClient();

ConnectionResponse connection = await connectionsClient.GetDefaultConnectionAsync(ConnectionType.Serverless, true);

if (connection.Properties.AuthType == AuthenticationType.ApiKey)
{
    var apiKeyAuthProperties = connection.Properties as ConnectionPropertiesApiKeyAuth;
    if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
    {
        throw new ArgumentException("The API key authentication target URI is missing or invalid.");
    }

    if (!Uri.TryCreate(apiKeyAuthProperties.Target, UriKind.Absolute, out var endpoint))
    {
        throw new UriFormatException("Invalid URI format in API key authentication target.");
    }

    var credential = new AzureKeyCredential(apiKeyAuthProperties.Credentials.Key);
    ChatCompletionsClient chatClient = new(endpoint, credential);

    var requestOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
        Model = modelDeploymentName
    };

    ChatCompletions response = await chatClient.CompleteAsync(requestOptions);
    Console.WriteLine(response.Content);
}
```
