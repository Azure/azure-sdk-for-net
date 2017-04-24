using Microsoft.Azure.Management.Redis;
namespace Redis.JsonRpc
{
    public class RedisManagementClientMock : RedisManagementClient
    {
        private IRedisOperations _Redis;

        public override IRedisOperations Redis => _Redis;

        public RedisManagementClientMock(
            System.Uri baseUri,
            Microsoft.Rest.ServiceClientCredentials credentials,
            params System.Net.Http.DelegatingHandler[] handlers):
            base(baseUri, credentials, handlers)
        {
            _Redis = new RedisOperationsMock(base.Redis);
        }
    }
}
