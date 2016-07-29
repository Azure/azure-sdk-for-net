using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition
{
    public interface IDefinition :
        IBlank,
        IWithGroup,
        IWithCreate,
        IWithCreateAndAccessTier
    {}

    public interface IBlank : Resource.Core.Resource.Definition.IDefinitionWithRegion<IWithGroup>
    {}

    public interface IWithGroup : Resource.Core.GroupableResource.Definition.IWithGroup<IWithCreate>
    {}

    public interface IWithCreate :
        ICreatable<IStorageAccount>,
        Resource.Core.Resource.Definition.IDefinitionWithTags<IWithCreate>,
        IWithSku,
        IWithBlobStorageAccountKind,
        IWithGeneralPurposeAccountKind,
        IWithEncryption,
        IWithCustomDomain
    {}

    public interface IWithSku
    {
        IWithCreate WithSku(SkuName skuName);
    }

    public interface IWithBlobStorageAccountKind
    {
        IWithCreateAndAccessTier WithBlobStorageAccountKind();
    }

    public interface IWithGeneralPurposeAccountKind
    {
        IWithCreate WithGeneralPurposeAccountKind();
    }

    public interface IWithEncryption
    {
        IWithCreate WithEncryption(Encryption encryption);
    }

    public interface IWithCustomDomain
    {
        IWithCreate WithCustomDomain(CustomDomain customDomain);

        IWithCreate WithCustomDomain(string name);

        IWithCreate WithCustomDomain(string name, bool useSubDomain);
    }

    public interface IWithCreateAndAccessTier : IWithCreate
    {
        IWithCreate WithAccessTier(AccessTier accessTier);
    }
}
