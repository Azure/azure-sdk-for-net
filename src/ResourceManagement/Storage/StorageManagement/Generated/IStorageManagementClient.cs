using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure;
using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.Storage
{
    /// <summary>
    /// </summary>
    public partial interface IStorageManagementClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        IStorageAccountsOperations StorageAccounts { get; }

        }
}
