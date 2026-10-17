# Contributing to the Azure SDK

Please see our [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) if you are not familiar with contributing to this repository or have questions.

For specific information about pull request etiquette and best practices, see [this section](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#pull-request-etiquette-and-best-practices).

## Problem

Client-side encryption v1 ranged downloads (`ivInStream`) read the preceding 16-byte ciphertext block as the AES-CBC IV. The async path issued a single `ReadAsync` and ignored the returned count. Streams that return short reads (network, wrappers, retries) left a partial IV (remaining bytes zero) and left leftover IV bytes in the ciphertext stream, so decryption produced corrupted plaintext with no error. The sync path already looped, but neither path threw when the stream ended before 16 IV bytes were available.

Fixes #63859

## Change

- Loop `Read` / `ReadAsync` in `ClientSideDecryptor.DecryptReadInternalV1_0` until all 16 IV bytes are read, keeping the sync and async paths aligned.
- Throw `InvalidDataException` via `Errors.ClientSideEncryption.IncompleteContentEncryptionIv` if the stream ends early.
- Add non-Live unit tests that decrypt v1 content through a wrapper stream that returns at most 8 bytes per `Read`/`ReadAsync`, plus truncated-IV cases.

## Testing

Required TDD run of the new tests (`ClientSideEncryptionIvShortRead`) on unmodified code first, then after the fix. Nearby non-Live ClientSideEncryption tests were also run.

**Before (unmodified decryptor, net10.0):**

```
Failed DecryptRead_V1_IvInStream_ShortReads_DecryptsOriginal_Async [18 ms]
  Error Message:
   System.Security.Cryptography.CryptographicException : The input data is not a complete block.

Failed DecryptRead_V1_IvInStream_TruncatedIv_Throws_Async [16 ms]
  Error Message:
     Expected: <System.IO.InvalidDataException>
  But was:  null

Failed DecryptRead_V1_IvInStream_TruncatedIv_Throws_Sync [1 ms]
  Error Message:
     Expected: <System.IO.InvalidDataException>
  But was:  null

Failed!  - Failed:     3, Passed:     1, Skipped:     0, Total:     4, Duration: 42 ms - Azure.Storage.Blobs.Tests.dll (net10.0)
```

(`DecryptRead_V1_IvInStream_ShortReads_DecryptsOriginal_Sync` already passed because the sync path already looped.)

**After (fix applied, net10.0):**

```
Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 23 ms - Azure.Storage.Blobs.Tests.dll (net10.0)
```

**Nearby ClientSideEncryption tests** (`dotnet test sdk/storage/Azure.Storage.Blobs/tests -f net10.0 --filter "TestCategory!=Live&FullyQualifiedName~ClientSideEncryption"`):

```
Passed!  - Failed:     0, Passed:    30, Skipped:     0, Total:    30, Duration: 18 s - Azure.Storage.Blobs.Tests.dll (net10.0)
```

This change was prepared with AI assistance and reviewed by the author.
