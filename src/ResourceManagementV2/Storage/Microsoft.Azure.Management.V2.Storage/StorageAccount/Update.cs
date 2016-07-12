using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Storage.StorageAccount.Update
{
    public interface IUpdate :
        IApplicable<IStorageAccount>,
        Resource.Update.IWithTags<IUpdate>,
        IWithSku,
        IWithCustomDomain,
        IWithAccessTier
    {}

    public interface IWithSku
    {
        IUpdate WithSku(SkuName skuName);
    }

    public interface IWithCustomDomain
    {
        IUpdate WithCustomDomain(CustomDomain customDomain);

        IUpdate WithCustomDomain(string name);

        IUpdate WithCustomDomain(string name, bool useSubDomain);
    }

    public interface IWithEncryption
    {
        IUpdate WithEncryption(Encryption encryption);
    }

    public interface IWithAccessTier
    {
        IUpdate WithAccessTier(AccessTier accessTier);
    }
}
