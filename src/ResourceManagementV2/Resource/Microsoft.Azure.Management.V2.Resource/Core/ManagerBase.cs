namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IManagerBase
    {
        IResourceManager ResourceManager { get; }
    }

    public abstract class ManagerBase : IManagerBase
    {
        public ManagerBase(RestClient restClient, string subscriptionId)
        {
            if (restClient != null)
            {
                ResourceManager = ResourceManager2
                    .Authenticate(restClient)
                    .WithSubscription(subscriptionId);
            }
        }

        public IResourceManager ResourceManager {
            get; protected set;
        }
    }
}
