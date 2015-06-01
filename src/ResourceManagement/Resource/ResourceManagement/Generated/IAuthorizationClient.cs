using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// </summary>
    public partial interface IAuthorizationClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        IManagementLocksOperations ManagementLocks { get; }

        }
}
