namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class NetworkResourceProviderClientExtensions
    {
            /// <summary>
            /// Checks whether a domain name in the cloudapp.net zone is available for use.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// The location of the domain name
            /// </param>
            /// <param name='domainNameLabel'>
            /// The domain name to be verified. It must conform to the following regular
            /// expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$.
            /// </param>
            public static DnsNameAvailabilityResult CheckDnsNameAvailability(this INetworkResourceProviderClient operations, string location, string domainNameLabel = default(string))
            {
                return Task.Factory.StartNew(s => ((INetworkResourceProviderClient)s).CheckDnsNameAvailabilityAsync(location, domainNameLabel), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks whether a domain name in the cloudapp.net zone is available for use.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// The location of the domain name
            /// </param>
            /// <param name='domainNameLabel'>
            /// The domain name to be verified. It must conform to the following regular
            /// expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<DnsNameAvailabilityResult> CheckDnsNameAvailabilityAsync( this INetworkResourceProviderClient operations, string location, string domainNameLabel = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DnsNameAvailabilityResult> result = await operations.CheckDnsNameAvailabilityWithHttpMessagesAsync(location, domainNameLabel, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
