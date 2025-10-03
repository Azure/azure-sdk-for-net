# Azure Code Transparency client library for .NET

<!-- cspell:ignore cose merkle scitt -->

`Azure.Security.CodeTransparency` is based on a managed service that complies with a [draft SCITT RFC][SCITT_ARCHITECTURE_RFC]. It allows countersigning [COSE signature envelopes][COSE_RFC]. Countersignatures are recorded and signed in an immutable Merkle tree for auditing purposes, and a [receipt][SCITT_RECEIPT_RFC] is issued.

- [OSS server application source code][Service_source_code]

## Getting started

### Install the package

Ensure you have access to the correct NuGet feed.

Install the client library via NuGet:

```dotnetcli
dotnet add package Azure.Security.CodeTransparency --prerelease
```

### Prerequisites

- A running, accessible Code Transparency service
- Ability to create `COSE_Sign1` envelopes (see [example script][CTS_claim_generator_script])
- Your signer details (CA certificate) must be configured in the running service (see [configuration options][CTS_configuration_doc])
- Obtain a valid bearer token if service authentication requires one (see [example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md))

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Authenticate the client

Obtain a valid bearer token if the service requires authentication (see [example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md)).

## Examples

There are two main use cases: submitting a COSE signature envelope and verifying the cryptographic submission receipt, which proves that the signature file was accepted.

Before submitting the COSE file, ensure the service is configured with the appropriate policy.

Use the following code to submit the signature:

```C# Snippet:CodeTransparencySubmission
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
```

Then obtain the transparent statement:

```C# Snippet:CodeTransparencyDownloadTransparentStatement
Response<BinaryData> operationResult = await operation.WaitForCompletionAsync();
string entryId = CborUtils.GetStringValueFromCborMapByKey(operationResult.Value.ToArray(), "EntryId");
Response<BinaryData> transparentStatement = client.GetEntryStatement(entryId);
```

After obtaining the transparent statement, you can distribute it so others can verify its inclusion in the service. The verifier checks that the receipt was issued for the given signature and that its signature was endorsed by the service. Because users might not know which service instance the statement came from, they can extract that information from the receipt to create the client for verification.

```C# Snippet:CodeTransparencyVerification
byte[] transparentStatementBytes = transparentStatement.Value.ToArray();
try
{
    new CodeTransparencyClient(transparentStatementBytes).RunTransparentStatementVerification(transparentStatementBytes);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

If verification completes without exception, you can trust the signature and the receipt. You can then safely inspect the files, especially the payload embedded in the COSE signature envelope.

To learn more about other APIs, see the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples).

### Key concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Troubleshooting

Response values returned from client methods are `Response` objects, which contain information about the HTTP response such as the HTTP `Status` property and a `Headers` collection with more details.

## Next steps

For more extensive documentation, see the API [reference documentation](https://azure.github.io/azure-sdk-for-net/). You can also read more about Microsoft Research's open-source [Confidential Consortium Framework][ccf].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[COSE_RFC]: https://www.rfc-editor.org/rfc/rfc8152.txt
[SCITT_ARCHITECTURE_RFC]: https://www.ietf.org/archive/id/draft-ietf-scitt-architecture-11.txt
[SCITT_RECEIPT_RFC]: https://www.ietf.org/archive/id/draft-ietf-cose-merkle-tree-proofs-08.txt
[API_reference]: https://learn.microsoft.com/dotnet/api/azure.security.keyvault.keys
[Service_source_code]: https://github.com/microsoft/scitt-ccf-ledger
[CTS_claim_generator_script]: https://github.com/microsoft/scitt-ccf-ledger/tree/main/demo/cts_poc
[CTS_configuration_doc]: https://github.com/microsoft/scitt-ccf-ledger/blob/main/docs/configuration.md
[ccf]: https://github.com/Microsoft/CCF
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
