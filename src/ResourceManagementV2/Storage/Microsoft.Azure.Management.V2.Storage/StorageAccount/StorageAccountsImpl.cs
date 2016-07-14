using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Storage
{
    internal class StorageAccountsImpl :
        GroupableResources<
                IStorageAccount,
                StorageAccountImpl,
                Management.Storage.Models.StorageAccount,
                IStorageAccountsOperations,
                StorageManager>,
        IStorageAccounts
    {
        internal StorageAccountsImpl(IStorageAccountsOperations innerCollection, StorageManager manager) : base(innerCollection, manager)
        {}

        public StorageAccount.Definition.IBlank Define(string name)
        {
            Management.Storage.Models.StorageAccount innerObject = new Management.Storage.Models.StorageAccount();
            StorageAccountImpl wrapped = new StorageAccountImpl(name, 
                innerObject, 
                InnerCollection,
                MyManager);
            wrapped.WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
            return wrapped;
        }

        public override Task<IStorageAccount> GetByGroup(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        protected override StorageAccountImpl wrapModel(Management.Storage.Models.StorageAccount inner)
        {
            return new StorageAccountImpl(inner.Name,
                inner,
                InnerCollection,
                MyManager);
        }

        protected override StorageAccountImpl WrapModel(string name)
        {
            Management.Storage.Models.StorageAccount innerObject = new Management.Storage.Models.StorageAccount();
            return new StorageAccountImpl(name,
                innerObject,
                InnerCollection,
                MyManager
            );
        }
    }
}
