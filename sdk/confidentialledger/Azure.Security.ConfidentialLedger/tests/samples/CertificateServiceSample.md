# The Certificate Service Client 

By default, the `ConfidentialLedgerClient` will automatically configure itself to trust the root TLS certificate advertised by the `ConfidentialLedgerCertificateClient` `GetLedgerIdentity` operation.
However, if specific customizations are needed to the client option's `Transport`, this automatic configuration needs to be done manually.

Because Confidential Ledgers use self-signed certificates securely generated and stored in an SGX enclave, the certificate for each Confidential Ledger must first be retrieved from the Confidential Ledger Identity Service.

```C# Snippet:GetIdentity
Uri identityServiceEndpoint = new("https://identity.confidential-ledger.core.azure.com") // The hostname from the identityServiceUri
var identityClient = new ConfidentialLedgerCertificateClient(identityServiceEndpoint);

// Get the ledger's  TLS certificate for our ledger.
string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
Response response = identityClient.GetLedgerIdentity(ledgerId);
X509Certificate2 ledgerTlsCert = ConfidentialLedgerCertificateClient.ParseCertificate(response);
```

Now we can construct the `ConfidentialLedgerClient` with a transport configuration that trusts the `ledgerTlsCert`.

```C# Snippet:CreateClient
// Create a certificate chain rooted with our TLS cert.
X509Chain certificateChain = new();
certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);

var f = certificateChain.Build(ledgerTlsCert);

// Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
bool CertValidationCheck(HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
{
    bool isChainValid = certificateChain.Build(cert);
    if (!isChainValid)
        return false;

    var isCertSignedByTheTlsCert = certificateChain.ChainElements.Cast<X509ChainElement>()
        .Any(x => x.Certificate.Thumbprint == ledgerTlsCert.Thumbprint);
    return isCertSignedByTheTlsCert || httpRequestMessage.RequestUri.Host == "identity.confidential-ledger.core.azure.com";
}

// Create an HttpClientHandler to use our certValidationCheck function.
var httpHandler = new HttpClientHandler();
httpHandler.ServerCertificateCustomValidationCallback = CertValidationCheck;

// Create the ledger client using a transport that uses our custom ServerCertificateCustomValidationCallback.
var options = new ConfidentialLedgerClientOptions { Transport = new HttpClientTransport(httpHandler) };
var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);
```
