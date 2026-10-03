# Create, inspect, and delete a sandbox

Create a sandbox from the public Ubuntu image, retrieve its properties, and delete it when finished. Replace the endpoint and identifiers with those of your sandbox group. The identity must have access to the group. Install `Azure.Identity` and import `System`, `Azure.Containers.Apps.Sandbox`, `Azure.Containers.Apps.Sandbox.Models`, and `Azure.Identity`.

```C# Snippet:Azure_Containers_Apps_Sandbox_CreateAndDelete
var sandboxGroup = new SandboxGroupClient(
    new Uri("<sandbox-group-endpoint>"),
    "<subscription-id>",
    "<resource-group-name>",
    "<sandbox-group-name>",
    new DefaultAzureCredential());
SandboxesClient sandboxes = sandboxGroup.GetSandboxesClient();
CreateSandboxContent content = new CreateSandboxContent
{
    SourcesRef = new SandboxSource
    {
        DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
    },
    Resources = new SandboxResources("1000m", "2048Mi")
};

SandboxProperties created = sandboxes.CreateSandbox(content).Value;
try
{
    SandboxProperties current = sandboxes.GetProperties(created.Id).Value;
    Console.WriteLine($"Sandbox {current.Id}: {current.State}");
}
finally
{
    sandboxes.Delete(created.Id);
}
```
