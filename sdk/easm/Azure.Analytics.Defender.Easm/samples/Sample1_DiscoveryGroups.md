# Create and manage discovery groups

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/easm/Azure.Analytics.Defender.Easm/README.md#getting-started) for details.

This code sample demonstrates how to create and manage discovery groups in an EASM workspace. Discovery groups are used to discover and map the online assets.

## Create an EASM client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample2_DiscoveryGroups_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                new DefaultAzureCredential());
```

## Create a discovery group

In order to start discovery runs, we must first create a discovery group, which is a collection of known assets that we can pivot off of. These are created using the `DiscoveryGroupsCreateOrReplace` method.

```C# Snippet:Sample2_DiscoveryGroups_Create_Discovery_Group
string discoveryGroupName = "Sample Disco From C#";
string discoveryGroupDescription = "This is a sample discovery group generated from C#";
            string[] hosts = new string[2];
hosts[0] = "<host1>.com";
hosts[1] = "<host2>.com";
string[] domains = new string[2];
domains[0] = "<domain1>.com";
domains[1] = "<domain2>.com";
                        DiscoveryGroupPayload request = new DiscoveryGroupPayload();
foreach (var host in hosts)
{
    DiscoverySource seed = new DiscoverySource();
    seed.Kind = DiscoverySourceKind.Host;
    seed.Name = host;
    request.Seeds.Add(seed);
}
foreach (var domain in domains)
{
    DiscoverySource seed = new DiscoverySource();
    seed.Kind = DiscoverySourceKind.Domain;
    seed.Name = domain;
    request.Seeds.Add(seed);
}

request.Description = discoveryGroupDescription;
client.CreateOrReplaceDiscoveryGroup(discoveryGroupName, request);
```

## Run the discovery group

Discovery groups created through the API's `createOrReplace` method aren't run automatically, so we need to start the run ourselves.

```C# Snippet:Sample2_DiscoveryGroups_Run
client.RunDiscoveryGroup(discoveryGroupName);
Pageable<DiscoveryGroup> response = client.GetDiscoveryGroups();
foreach (DiscoveryGroup discoGroup in response)
{
    Console.WriteLine(discoGroup.Name);
    Pageable<DiscoveryRunResult> discoRunPageResponse = client.GetDiscoveryGroupRuns(discoGroup.Name);
    int index = 0;
    foreach (DiscoveryRunResult discoRun in discoRunPageResponse)
    {
        Console.WriteLine($" - started: {discoRun.StartedDate}, finished: {discoRun.CompletedDate}, assets found: {discoRun.TotalAssetsFoundCount}, status: {discoRun.State}");
        if (++index == 5){
            break;
        }
    }
}
```