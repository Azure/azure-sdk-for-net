# Create and Manage Discovery Groups

This sample demonstrates how to create and manage discovery runs in a workspace.

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample2_DiscoveryGroups_Create_Client
string endpoint = "https://<region>.easm.defender.microsoft.com";
EASMClient client = new EASMClient(new System.Uri(endpoint),
                "<Your_Subscription_Id>",
                "<Your_Resource_Group_Name>",
                "<Your_Workspace_Name>",
                new DefaultAzureCredential());
```

## Create a Discovery Group

In order to start discovery runs, we must first create a discovery group, which is a collection of known assets that we can pivot off of. These are created using the `DiscoveryGroupsPut` method.

```C# Snippet:Sample2_DiscoveryGroups_Create_Discovery_Group
string discoveryGroupName = "Sample Disco";
string discoveryGroupDescription = "This is a sample discovery group generated from C#";

string[] hosts = ["<host1>.<org>.com", "<host2>.<org>.com"];
string[] domains = ["<domain1>.com", "<domain2>.com"];

DiscoGroupRequest request = new DiscoGroupRequest();
foreach (string host in hosts)
{
    DiscoSource seed = new DiscoSource(DiscoSourceKind.Host, host);
    request.Seeds.Add(seed);
}
foreach (string domain in domains)
{
    DiscoSource seed = new DiscoSource(DiscoSourceKind.Domain, domain);
    request.Seeds.Add(seed);
}

request.Name = discoveryGroupName;
request.Description = discoveryGroupDescription;

client.DiscoveryGroupsPut(discoveryGroupName, request);
```

## Run the Discovery Group

Discovery groups created through the API's `put` method aren't run automatically, so we need to start the run ourselves.

```C# Snippet:Sample2_DiscoveryGroups_Run
client.DiscoveryGroupsRun(discoveryGroupName);

Response<DiscoGroupPageResponse> response = client.DiscoveryGroupsList();
foreach (DiscoGroupResponse discoGroup in response.Value.Value){
    Console.WriteLine(discoGroup.Name);
    Response<DiscoRunPageResponse> discoRunPageResponse = client.DiscoveryGroupsListRuns(discoGroup.Name);
    int index = 0;
    foreach (DiscoRunResponse discoRun in discoRunPageResponse.Value.Value){
        Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}");
        if (++index == 5){
            break;
        }
    }
}
```
