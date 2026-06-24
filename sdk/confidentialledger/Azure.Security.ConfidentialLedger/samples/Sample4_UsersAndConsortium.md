# Users and Consortium — Manage users and view consortium info

This sample demonstrates how to manage ledger users and retrieve consortium information.

## Create or update a ledger user

You can add or update a user in the confidential ledger by providing an AAD object ID and assigning roles.

```C# Snippet:ConfidentialLedger_NewUser
string newUserAadObjectId = "<some AAD user or service principal object Id>";
ledgerClient.CreateOrUpdateLedgerUser(
    newUserAadObjectId,
    RequestContent.Create(new { assignedRoles = new[] { "Reader" } }));
```

## Get consortium members, constitution and enclave quotes

Consortium members can manage and alter the confidential ledger. The constitution is a collection of JavaScript code that defines actions available to members.

```C# Snippet:ConfidentialLedger_Consortium
Pageable<BinaryData> consortiumResponse = ledgerClient.GetConsortiumMembers(new RequestContext());
foreach (var page in consortiumResponse)
{
    string membersJson = page.ToString();
    // Consortium members can manage and alter the confidential ledger, such as by replacing unhealthy nodes.
    Console.WriteLine(membersJson);
}

// The constitution is a collection of JavaScript code that defines actions available to members,
// and vets proposals by members to execute those actions.
Response constitutionResponse = ledgerClient.GetConstitution(new RequestContext());
string constitutionJson = new StreamReader(constitutionResponse.ContentStream).ReadToEnd();

Console.WriteLine(constitutionJson);

// Enclave quotes contain material that can be used to cryptographically verify the validity and contents of an enclave.
Response enclavesResponse = ledgerClient.GetEnclaveQuotes(new RequestContext());
string enclavesJson = new StreamReader(enclavesResponse.ContentStream).ReadToEnd();

Console.WriteLine(enclavesJson);
```
