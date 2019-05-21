using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.Keyvault.Keys
{
    public class KeyClientOptions : HttpClientOptions
    {
        public RetryPolicy RetryPolicy { get; set; }

        public KeyClientOptions()
        {
            RetryPolicy = new ExponentialRetryPolicy()
            {
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }
}
