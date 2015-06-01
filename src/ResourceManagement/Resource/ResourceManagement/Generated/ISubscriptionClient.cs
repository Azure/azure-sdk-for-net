using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure;
using Microsoft.Azure.Subscriptions.Models;

namespace Microsoft.Azure.Subscriptions
{
    /// <summary>
    /// </summary>
    public partial interface ISubscriptionClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        ISubscriptionsOperations Subscriptions { get; }

        ITenantsOperations Tenants { get; }

        }
}
