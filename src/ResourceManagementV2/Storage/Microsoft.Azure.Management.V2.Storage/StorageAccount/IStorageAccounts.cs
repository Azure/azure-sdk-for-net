using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

namespace Microsoft.Azure.Management.V2.Storage
{
    public interface IStorageAccounts :
        ISupportsCreating<StorageAccount.Definition.IBlank>,
        ISupportsListing<IStorageAccount>
    {}
}
