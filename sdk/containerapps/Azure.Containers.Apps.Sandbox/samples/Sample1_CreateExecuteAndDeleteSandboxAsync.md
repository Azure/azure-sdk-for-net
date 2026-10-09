# Create a sandbox, execute a command, and delete it asynchronously

Create a sandbox from the public Ubuntu image, run `/bin/echo` in it, and delete it when finished. Replace the endpoint and identifiers with those of your sandbox group. The identity must have access to the group. Install `Azure.Identity` and import `System`, `Azure.Containers.Apps.Sandbox`, `Azure.Containers.Apps.Sandbox.Models`, and `Azure.Identity`.

```C# Snippet:Azure_Containers_Apps_Sandbox_CreateExecuteAndDeleteAsync
var sandboxGroup = new SandboxGroupClient(
    new Uri("<sandbox-group-endpoint>"),
    "<subscription-id>",
    "<resource-group-name>",
    "<sandbox-group-name>",
    new DefaultAzureCredential());
CreateSandboxContent content = new CreateSandboxContent
{
    SourcesRef = new SandboxSource
    {
        DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
    },
    Resources = new SandboxResources("1000m", "2048Mi")
};

SandboxClient sandbox = (await sandboxGroup.CreateSandboxAsync(content)).Value;
try
{
    ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
    command.Arguments.Add("sandbox-command");
    SandboxExecuteCommandResult result = (await sandbox.ExecuteCommandAsync(command)).Value;
    if (result.ExitCode != 0)
    {
        throw new InvalidOperationException($"Command failed with exit code {result.ExitCode}: {result.StandardError}");
    }
    Console.WriteLine(result.StandardOutput);
}
finally
{
    await sandbox.DeleteAsync();
}
```
