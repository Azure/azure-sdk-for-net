using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
#pragma warning disable AZC0007 // needs constructor with ClientOptions
    /// <summary>
    /// Client for sending requests directly to the management plane.
    /// </summary>
    public sealed class ConfigurationManagementClient
#pragma warning restore AZC0007 // needs constructor with ClientOptions
    {
        /// <summary>
        /// Return a connection string that can be used to instantiate a ConfigurationClient.
        /// </summary>
        /// <param name="endpoint">The endpoint of the Configuration Store</param>
        /// <param name="credential">Credential used to access the AppConfiguration management plane.</param>
        /// <param name="readwrite">Indicate whether to retrieve a connection string for readwrite or readonly access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
#pragma warning disable AZC0003 // Client methods should be virtual
        public static string GetConnectionString(Uri endpoint, TokenCredential credential, bool readwrite = false, CancellationToken cancellationToken = default)
#pragma warning restore AZC0003 // Client methods should be virtual
        {
            // TODO: implement!  dummy stuff here to compile.
            return string.Empty;
        }

        /// <summary>
        /// Return a connection string that can be used to instantiate a ConfigurationClient.
        /// </summary>
        /// <param name="endpoint">The endpoint of the Configuration Store</param>
        /// <param name="credential">Credential used to access the AppConfiguration management plane.</param>
        /// <param name="readwrite">Indicate whether to retrieve a connection string for readwrite or readonly access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
#pragma warning disable AZC0003 // Client methods should be virtual
        public static async Task<string> GetConnectionStringAsync(Uri endpoint, TokenCredential credential, bool readwrite = false, CancellationToken cancellationToken = default)
#pragma warning restore AZC0003 // Client methods should be virtual
        {
            // TODO: implement!  dummy stuff here to compile.
            return await Task.Run(() => { return string.Empty; }).ConfigureAwait(false);
        }
    }
}
