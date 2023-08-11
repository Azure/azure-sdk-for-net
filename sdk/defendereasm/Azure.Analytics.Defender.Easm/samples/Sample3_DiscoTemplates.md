# Create Discovery Groups using Templates

This sample shows you how to create discovery groups using templates provided by the client.

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample3_DiscoTemplates_Create_Client
string endpoint = "https://<region>.easm.defender.microsoft.com";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                "<Your_Subscription_Id>",
                "<Your_Resource_Group_Name>",
                "<Your_Workspace_Name>",
                new DefaultAzureCredential());
```

## Get Templates

The `DiscoveryTemplatesList` method can be used to find a discovery template using a filter. The endpoint will return templates based on a partial match on the name field.

```C# Snippet:Sample3_DiscoTemplates_Get_Templates
string partialName = "<partial_name>";
Response<DiscoTemplatePageResult> response = client.GetDiscoTemplates(partialName);
foreach (DiscoTemplate template in response.Value.Value)
{
    Console.WriteLine($"{template.Id}: {template.DisplayName}");
}
```

## Get the Seeds associated with a Template

To get more detail about a disco template, we can use the `DiscoveryTemplatesGet` method. From here, we can see the names and seeds which would be used in a discovery run.

```C# Snippet:Sample3_DiscoTemplates_Get_Template_Seeds
string templateId = Console.ReadLine();

Response<DiscoTemplate> discoTemplateResponse = client.GetDiscoTemplate(templateId);
DiscoTemplate discoTemplate = discoTemplateResponse.Value;

Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
Console.WriteLine("The following names will be used:");
foreach (DiscoSource seed in discoTemplate.Seeds)
{
    Console.WriteLine($"{seed.Kind}: {seed.Name}");
}
```

## Create and Run a new Discovery

The discovery template can be used to create a discovery group with using the client's `DiscoveryGroupsPut` method. Don't forget to run your new disco group with `DiscoveryGroupsRun`.

```C# Snippet:Sample3_DiscoTemplates_Run_Disco_Group
string groupName = "Discovery Group from Template";
DiscoGroupData discoGroupRequest = new DiscoGroupData();
discoGroupRequest.TemplateId = templateId;

client.PutDiscoGroup(groupName, discoGroupRequest);

client.RunDiscoGroup(groupName);
```
