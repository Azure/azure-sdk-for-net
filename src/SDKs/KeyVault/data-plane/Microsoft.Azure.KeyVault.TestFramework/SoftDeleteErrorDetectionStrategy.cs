using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Net;

namespace KeyVault.TestFramework
{
    /// <summary>
    /// A retry strategy that will wait until keys/secrets have been deleted or purged entirely. 
    /// Since this is a long running operation that is not guaranteed to complete immediately.
    /// </summary>
    public class SoftDeleteErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            if (ex != null)
            {
                // Key vault will use this error type for all exceptions.
                KeyVaultErrorException kvException;
                if((kvException = ex as KeyVaultErrorException) != null)
                {
                    // Retry on not found and conflict while object is in transitioning state.
                    if (kvException.Response.StatusCode == HttpStatusCode.NotFound ||
                        kvException.Response.StatusCode == HttpStatusCode.Conflict)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
