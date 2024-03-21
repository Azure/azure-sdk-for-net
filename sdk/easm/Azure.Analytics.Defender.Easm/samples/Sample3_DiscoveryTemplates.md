# Create discovery groups using templates

Instead of manually importing discovery seeds for your discovery run, you can use discovery templates. Discovery templates consist of pre-defined discovery seeds. The following example demonstrates how to search for a discovery template and use it to create a discovery group.

## Create an EASM client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample3_DiscoTemplates_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                new DefaultAzureCredential());
```

## Get templates

The `DiscoveryTemplatesList` method can be used to find a discovery template using a filter. The endpoint will return templates based on a partial match on the name field.

```C# Snippet:Sample3_DiscoTemplates_Get_Templates
            string partialName = "<partial_name>";
                        var response = client.GetDiscoveryTemplates(partialName);
foreach (DiscoveryTemplate template in response)
{
    Console.WriteLine($"{template.Id}: {template.DisplayName}");
}
```

## Get the seeds associated with a template

To get more detail about a disco template, we can use the `DiscoveryTemplatesGet` method. From here, we can see the names and seeds which would be used in a discovery run.

```C# Snippet:Sample3_DiscoTemplates_Get_Template_Seeds
            string templateId = Console.ReadLine();
                        var discoTemplateResponse = client.GetDiscoveryTemplate(templateId);
DiscoveryTemplate discoTemplate = discoTemplateResponse.Value;
Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
Console.WriteLine("The following names will be used:");
foreach (DiscoverySource seed in discoTemplate.Seeds)
{
    Console.WriteLine($"{seed.Kind}: {seed.Name}");
}
```

## Run discovery with a template

To start a discovery from a template, we can use `DiscoveryRun` method with a template id.

```C# Snippet:Sample3_DiscoTemplates_Run_Disco_Group
string groupName = "Discovery Group from Template";
DiscoveryGroupPayload discoGroupRequest = new DiscoveryGroupPayload();
discoGroupRequest.TemplateId = templateId;
client.CreateOrReplaceDiscoveryGroup(groupName, discoGroupRequest);
client.RunDiscoveryGroup(groupName);
```