// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job
{
    using Microsoft.Rest;
    using System;

    public partial class HDInsightJobClient : ServiceClient<HDInsightJobClient>, IHDInsightJobClient
    {
        private static readonly TimeSpan MinBackOff = TimeSpan.FromMinutes(0);
        private static readonly TimeSpan MaxBackOff = TimeSpan.FromMinutes(8);
        private const int RetryCount = 5;
        private static readonly TimeSpan DeltaBackOff = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The default poll interval to get job status for the HDInsight Job Management Client.
        /// </summary>
        public static readonly TimeSpan DefaultPollInterval = TimeSpan.FromSeconds(30);
    }
}
