# Azure Code Transparency client library for .NET

<!-- cspell:ignore cose merkle scitt -->

`Azure.Security.CodeTransparency` is based on a managed service complying with a [draft SCITT RFC][SCITT_ARCHITECTURE_RFC]. It is a managed service that allows countersigning [COSE signature envelopes][COSE_RFC]. Countersignatures are recorded and signed in the immutable merkle tree for any auditing purposes and [the receipt][SCITT_RECEIPT_RFC] gets issued.

- [OSS server application source code][Service_source_code]

## Getting started

### Install the package

Make sure you have access to the correct NuGet Feed.

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Security.CodeTransparency --prerelease
```

### Prerequisites

- A running and accessible Code Transparency Service
- Ability to create `COSE_Sign1` envelopes, [an example script][CTS_claim_generator_script]
- Your signer details (CA cert) have to be configured in the running service, [about available configuration][CTS_configuration_doc]
- You can get a valid Bearer token if the service authentication is configured to require one, [see example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md)

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Authenticate the client

You can get a valid Bearer token if the service authentication is configured to require one, [see example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md).

## Examples

There are two main use cases for this service: submitting a cose signature envelope and verifying the cryptographic submission receipt. The receipt proves that the signature file was successfully accepted.

Before submitting the cose file, the service must be configured with the relevant Certificate Authority certificate to be able to accept it.

To submit the signature, use the following code:

```C# Snippet:CodeTransparencySubmission
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
```

Once you have the receipt and the signature, you can verify whether the signature was actually included in the Code Transparency service by running the receipt verification logic. The verifier checks if the receipt was issued for a given signature and if the receipt signature was endorsed by the service.

```C# Snippet:CodeTransparencyVerifyReceipt
Response<JwksDocument> key = client.GetPublicKeys();

CcfReceiptVerifier.VerifyTransparentStatementReceipt(key.Value.Keys[0], receiptBytes, inputSignedPayloadBytes);
```

Alternatively, you can retrieve the Transparent Statement of the corresponding submission and run the receipt verification logic

```C# Snippet:CodeTransparencyVerification
Response<BinaryData> transparentStatement = client.GetEntryStatement(entryId);
byte[] transparentStatementBytes = transparentStatement.Value.ToArray();

try
{
    client.RunTransparentStatementVerification(transparentStatementBytes);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

If the verification completes without exception, you can trust the signature and the receipt. This allows you to safely inspect the contents of the files, especially the contents of the payload embedded in a cose signature envelope.

To learn more about other APIs, please refer to our [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples).

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

Response values returned from Azure confidential ledger client methods are `Response` objects, which contain information about the http response such as the http `Status` property and a `Headers` object containing more information about the failure.

## Next steps

For more extensive documentation, see the API [reference documentation](https://azure.github.io/azure-sdk-for-net/).
You may also read more about Microsoft Research's open-source [Confidential Consortium Framework][ccf].

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
