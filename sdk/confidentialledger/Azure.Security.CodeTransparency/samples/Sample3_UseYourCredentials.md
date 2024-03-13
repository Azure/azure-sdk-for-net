# Use your credentials

Your service might have [additional configuration][CTS_configuration_doc] which requires you to pass the authentication token in addition to the signature envelope.

Use [DefaultAzureCredential][default_cred_ref] to get your token:

```C#
DefaultAzureCredential credential = new();
string[] scopes = { "https://your.service.scope/.default" };
TokenCredential token = credential.GetToken(new TokenRequestContext(scopes));
CodeTransparencyClient client = new(new Uri("https://cts-service.confidential-ledger.azure.com"), new AzureKeyCredential(token.Token));
```

Once you construct the client instance the token will be sent in the `Authorization` header as `Bearer <token>`.

[CTS_configuration_doc]: https://github.com/microsoft/scitt-ccf-ledger/blob/main/docs/configuration.md
[default_cred_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential

