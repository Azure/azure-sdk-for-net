using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CR.Azure.NetCore.Tests.TestClients.Interface
{
    public partial interface IRedisManagementClient : IDisposable
    {
        string ApiVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri
        {
            get;
            set;
        }

        ServiceClientCredentials Credentials
        {
            get;
            set;
        }

        int? LongRunningOperationInitialTimeout
        {
            get;
            set;
        }

        int? LongRunningOperationRetryTimeout
        {
            get;
            set;
        }

        IRedisOperations RedisOperations
        {
            get;
        }
    }
}
