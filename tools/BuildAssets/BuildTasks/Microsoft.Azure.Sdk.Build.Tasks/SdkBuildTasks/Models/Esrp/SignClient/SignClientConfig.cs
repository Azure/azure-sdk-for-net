// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.SignClient
{
    using Newtonsoft.Json;
    using System;

    public partial class SignClientConfig : EsrpServiceModelBase<SignClientConfig>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("EsrpApiBaseUri")]
        public string EsrpApiBaseUri { get; set; }

        [JsonProperty("EsrpSessionTimeoutInSec")]
        public long EsrpSessionTimeoutInSec { get; set; }

        [JsonProperty("MinThreadPoolThreads")]
        public long MinThreadPoolThreads { get; set; }

        [JsonProperty("MaxDegreeOfParallelism")]
        public long MaxDegreeOfParallelism { get; set; }

        [JsonProperty("ExponentialFirstFastRetry")]
        public bool ExponentialFirstFastRetry { get; set; }

        [JsonProperty("ExponentialRetryCount")]
        public long ExponentialRetryCount { get; set; }

        [JsonProperty("ExponentialRetryMinBackOff")]
        public DateTimeOffset ExponentialRetryMinBackOff { get; set; }

        [JsonProperty("ExponentialRetryMaxBackOff")]
        public DateTimeOffset ExponentialRetryMaxBackOff { get; set; }

        [JsonProperty("ExponentialRetryDeltaBackOff")]
        public DateTimeOffset ExponentialRetryDeltaBackOff { get; set; }

        [JsonProperty("AppDataFolder")]
        public string AppDataFolder { get; set; }

        [JsonProperty("ExitOnFlaggedFile")]
        public bool ExitOnFlaggedFile { get; set; }

        [JsonProperty("FlaggedFileClientWaitTimeout")]
        public string FlaggedFileClientWaitTimeout { get; set; }

        [JsonProperty("ServicePointManagerDefaultConnectionLimit")]
        public long ServicePointManagerDefaultConnectionLimit { get; set; }
    }
}
