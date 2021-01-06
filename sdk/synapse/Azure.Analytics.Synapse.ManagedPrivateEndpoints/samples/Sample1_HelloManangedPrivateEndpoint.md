```C# Snippet:CreateManagedPrivateClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";
ManagedPrivateEndpointsClient client = new ManagedPrivateEndpointsClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential(includeInteractiveCredentials: true));
```

```C# Snippet:CreateManagedPrivateEndpoint
string managedVnetName = "default";
string managedPrivateEndpointName = "myPrivateEndpoint";
string fakedStorageAccountName = "myStorageAccount";
string privateLinkResourceId = $"/subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/myResourceGroup/providers/Microsoft.Storage/accounts/{fakedStorageAccountName}";
string groupId = "blob";
client.Create(managedVnetName, managedPrivateEndpointName, new ManagedPrivateEndpoint
{
    Properties = new ManagedPrivateEndpointProperties
    {
        PrivateLinkResourceId = privateLinkResourceId,
        GroupId = groupId
    }
});
```

```C# Snippet:ListManagedPrivateEndpoints
List<ManagedPrivateEndpoint> privateEndpoints = client.List(managedVnetName).ToList();
foreach (ManagedPrivateEndpoint privateEndpoint in privateEndpoints)
{
    Console.WriteLine(privateEndpoint.Id);
}
```

```C# Snippet:RetrieveManagedPrivateEndpoint
ManagedPrivateEndpoint retrievedPrivateEndpoint = client.Get(managedVnetName, managedPrivateEndpointName);
Console.WriteLine(retrievedPrivateEndpoint.Id);
```

```C# Snippet:DeleteManagedPrivateEndpoint
client.Delete(managedVnetName, managedPrivateEndpointName);
```
