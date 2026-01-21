# Sample of using Red Teams to test models in Azure.AI.Projects.

In this example we will demonstrate how to create and get the Red team model scans.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_RedTeam
// Sample : https://<account_name>.services.ai.azure.com/api/projects/<project_name>
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
// Sample : https://<account_name>.services.ai.azure.com
var modelEndpoint = System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT");
var modelApiKey = System.Environment.GetEnvironmentVariable("MODEL_API_KEY");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. In this example we will test the model, which name is read from `MODEL_DEPLOYMENT_NAME` using Base64-encoded strings, the model will be tested against prompts asking it to generate the violent content.

```C# Snippet:Sample_CreateRedTeam_RedTeam
AzureOpenAIModelConfiguration config = new(modelDeploymentName: modelDeploymentName);
RedTeam redTeam = new(target: config)
{
    AttackStrategies = { AttackStrategy.Base64 },
    RiskCategories = { RiskCategory.Violence },
    DisplayName = "redteamtest1"
};
```

3. Start the Read-Teaming task. We will authenticate to the endpoint from the variable `MODEL_ENDPOINT` with the API key, taken from variable `MODEL_API_KEY`.

Synchronous sample:
```C# Snippet:Sample_RunScan_RedTeam_Sync
RequestOptions options = new();
options.AddHeader("model-endpoint", modelEndpoint);
options.AddHeader("model-api-key", modelApiKey);
redTeam = projectClient.RedTeams.Create(redTeam: redTeam, options: options);
Console.WriteLine($"Red Team scan created with scan name: {redTeam.Name}");
```

Asynchronous sample:
```C# Snippet:Sample_RunScan_RedTeam_Async
RequestOptions options = new();
options.AddHeader("model-endpoint", modelEndpoint);
options.AddHeader("model-api-key", modelApiKey);
redTeam = await projectClient.RedTeams.CreateAsync(redTeam: redTeam, options: options);
Console.WriteLine($"Red Team scan created with scan name: {redTeam.Name}");
```

4. Get Read-Teaming task and output its status.

Synchronous sample:
```C# Snippet:Sample_GetScanDetails_RedTeam_Sync
redTeam = projectClient.RedTeams.Get(name: redTeam.Name);
Console.WriteLine($"Red Team scan status: {redTeam.Status}");
```

Asynchronous sample:
```C# Snippet:Sample_GetScanDetails_RedTeam_Async
redTeam = await projectClient.RedTeams.GetAsync(name: redTeam.Name);
Console.WriteLine($"Red Team scan status: {redTeam.Status}");
```

5. List all Read-Teaming tasks and their status.

Synchronous sample:
```C# Snippet:Sample_ListRedTeams_RedTeam_Sync
foreach (RedTeam scan in projectClient.RedTeams.GetAll())
{
    Console.WriteLine($"Found scan: {scan.Name}, Status: {scan.Status}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListRedTeams_RedTeam_Async
await foreach (RedTeam scan in projectClient.RedTeams.GetAllAsync())
{
    Console.WriteLine($"Found scan: {scan.Name}, Status: {scan.Status}");
}
```

6. To get the results of the red teaming experiment, open Microsoft Foundry used for the experiments, on the left panel select **Evaluation** and choose **AI red teaming** tab.
