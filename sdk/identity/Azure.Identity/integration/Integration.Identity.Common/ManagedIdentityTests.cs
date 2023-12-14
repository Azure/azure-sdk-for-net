using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Core;

namespace Integration.Identity.Common;

public static class ManagedIdentityTests
{
    public static void AuthToStorage()
    {
        string resourceId = Environment.GetEnvironmentVariable("IDENTITY_USER_DEFINED_IDENTITY")!;
        string account1 = Environment.GetEnvironmentVariable("IDENTITY_STORAGE_NAME_1")!;
        string account2 = Environment.GetEnvironmentVariable("IDENTITY_STORAGE_NAME_2")!;

        var credential1 = new ManagedIdentityCredential();
        var credential2 = new ManagedIdentityCredential(new ResourceIdentifier(resourceId));
        var client1 = new BlobServiceClient(new Uri($"https://{account1}.blob.core.windows.net/"), credential1);
        var client2 = new BlobServiceClient(new Uri($"https://{account2}.blob.core.windows.net/"), credential2);
        client1.GetBlobContainers().ToList();
        client2.GetBlobContainers().ToList();
    }
}
