# Create and Manage Discovery Groups

This sample demonstrates how to create and manage discovery runs in a workspace.

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample2_DiscoveryGroups_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                "<Your_Subscription_Id>",
                "<Your_Resource_Group_Name>",
                "<Your_Workspace_Name>",
                new DefaultAzureCredential());
```

## Create a Discovery Group


In order to start discovery runs, we must first create a discovery group, which is a collection of known assets that we can pivot off of. These are created using the `DiscoveryGroupsCreateOrReplace` method.

```C# Snippet:Sample2_DiscoveryGroups_Create_Discovery_Group
string discoveryGroupName = "Sample Disco From C#";
string discoveryGroupDescription = "This is a sample discovery group generated from C#";
            List<String> hosts = new List<String>();
hosts.Add("<host1>.com");
hosts.Add("<host2>.com");
List<String> domains = new List<String>();
domains.Add("<domain1>.com");
domains.Add("<domain2>.com");
                        DiscoGroupData request = new DiscoGroupData();
foreach (var host in hosts)
{
    DiscoSource seed = new DiscoSource();
    seed.Kind = DiscoSourceKind.Host;
    seed.Name = host;
    request.Seeds.Add(seed);
}
foreach (var domain in domains)
{
    DiscoSource seed = new DiscoSource();
    seed.Kind = DiscoSourceKind.Domain;
    seed.Name = domain;
    request.Seeds.Add(seed);
}

request.Name = discoveryGroupName;
request.Description = discoveryGroupDescription;
client.CreateOrReplaceDiscoGroup(discoveryGroupName, request);
```

## Run the Discovery Group

Discovery groups created through the API's `createOrReplace` method aren't run automatically, so we need to start the run ourselves.

```C# Snippet:Sample2_DiscoveryGroups_Run
client.RunDiscoGroup(discoveryGroupName);
Pageable<DiscoGroup> response = client.GetDiscoGroups();
foreach (DiscoGroup discoGroup in response)
{
    Console.WriteLine(discoGroup.Name);
    Pageable<DiscoRunResult> discoRunPageResponse = client.GetRuns(discoGroup.Name);
    int index = 0;
    foreach (DiscoRunResult discoRun in discoRunPageResponse)
    {
        Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}, status: {discoRun.State}");
        if (++index == 5){
            break;
        }
    }
}
```