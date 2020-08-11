// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.TransientFaultHandling;

    /// <summary>
    /// The HDInsight job client manages jobs against HDInsight clusters.
    /// </summary>
    public partial class HDInsightJobClient : ServiceClient<HDInsightJobClient>, IHDInsightJobClient
    {
        /// <summary>
        /// Gets the recommended Retry Policy for the HDInsight Job Management Client.
        /// </summary>
        public static RetryPolicy HDInsightRetryPolicy
        {
            get
            {
                return new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(
                    RetryCount, MinBackOff,
                    MaxBackOff, DeltaBackOff);
            }
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightJobClient
        /// class.
        /// <param name='credentials'>
        /// Required. Basic authentication credentials for job submission.
        /// </param>
        /// </summary>
        /// <param name='clusterDnsName'>
        /// Required. The cluster dns name against which the job management is
        /// to be performed.
        /// </param>
        /// <param name='userName'>
        /// Required. The user name used for running job.
        /// </param>
        /// <param name='retryPolicy'>
        /// Optional. Retry Policy for Http Transient errors.
        /// </param>
        public HDInsightJobClient(string endpoint, BasicAuthenticationCredentials credentials, RetryPolicy retryPolicy = null)
            : this(credentials)
        {
            if (retryPolicy == null)
            {
                // If No retry policy is provided then use default retry policy
                retryPolicy = HDInsightJobClient.HDInsightRetryPolicy;
            }

            this.Endpoint = endpoint ?? throw new ArgumentNullException("endpoint");
            this.Username = CultureInfo.CurrentCulture.TextInfo.ToLower(credentials.UserName);
            this.SetRetryPolicy(retryPolicy);
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightJobClient
        /// class.
        /// </summary>
        /// <param name='clusterDnsName'>
        /// Required. The cluster dns name against which the job management is
        /// to be performed.
        /// </param>
        /// <param name='credentials'>
        /// Required. Basic authentication credentials for job submission.
        /// </param>
        /// <param name='httpClient'>
        /// The Http client
        /// </param>
        public HDInsightJobClient(string endpoint, BasicAuthenticationCredentials credentials, HttpClient httpClient, bool disposeHttpClient = true) 
            : this(httpClient, disposeHttpClient)
        {
            this.Endpoint = endpoint ?? throw new ArgumentNullException("endpoint");
            this.Credentials = credentials ?? throw new ArgumentNullException("credentials");
            
            this.Credentials.InitializeServiceClient(this);
            this.Username = CultureInfo.CurrentCulture.TextInfo.ToLower(credentials.UserName);
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        /// </summary>
        partial void CustomInitialize()
        {
            // Having Http client time same as MaxBackOff seems to be not sufficient. This is still
            // raising TaskCancellation Exception. Setting value MaxBackOff + 2 mins for HDinsight
            // gateway time and having 1 min extra buffer.
            this.HttpClient.Timeout = MaxBackOff.Add(TimeSpan.FromMinutes(3));
        }
    }
}
