// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Threading;
    using Microsoft.Hadoop.Client.WebHCatResources;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Represents the base of all Client objects.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
        Justification = "DisposableObject implements IDisposable correctly, the implementation of IDisposable in the interfaces is necessary for the design.")]
    public abstract class ClientBase : DisposableObject, IJobSubmissionClientBase
    {
        private ILogger logger;
        private CancellationTokenSource source;
        private IAbstractionContext abstractionContext;

        /// <inheritdoc />
        public bool IgnoreSslErrors { get; set; }

        /// <summary>
        /// Gets or sets the HTTP operation timeout.
        /// </summary>
        public TimeSpan HttpOperationTimeout { get; protected set; }

        /// <summary>
        /// Gets or sets the retry policy.
        /// </summary>
        public IRetryPolicy RetryPolicy { get; protected set; }

        /// <summary>
        /// Gets the Abstraction context to be used to control cancellation and log writing.
        /// </summary>
        protected IAbstractionContext Context
        {
            get
            {
                return this.abstractionContext;
            }
        }

        /// <summary>
        /// Gets or sets the CancellationTokenSource to be used to control cancellation.
        /// </summary>
        public CancellationTokenSource CancellationSource
        {
            get { return this.source; }
            set { this.SetCancellationSource(value); }
        }

        /// <summary>
        /// Gets the CancellationToken to be used to control cancellation.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return this.CancellationSource.Token; }
        }

        /// <summary>
        /// Gets the Logger to be used to log messages.
        /// </summary>
        public ILogger Logger
        {
            get
            {
                if (this.logger == null)
                {
                    this.logger = new Logger();
                }

                return this.logger;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ClientBase class.
        /// </summary>
        protected ClientBase() : this(RetryDefaultConstants.DefaultOperationTimeout, RetryPolicyFactory.CreateExponentialRetryPolicy())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ClientBase class.
        /// </summary>
        /// <param name="httpOperationTimeout">The HTTP operation timeout.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        protected ClientBase(TimeSpan? httpOperationTimeout, IRetryPolicy retryPolicy)
        {
            this.IgnoreSslErrors = false;
            this.RetryPolicy = retryPolicy ?? RetryPolicyFactory.CreateExponentialRetryPolicy();
            this.HttpOperationTimeout = httpOperationTimeout ?? RetryDefaultConstants.DefaultOperationTimeout;
            if (this.HttpOperationTimeout < TimeSpan.FromSeconds(1))
            {
                throw new ArgumentOutOfRangeException("httpOperationTimeout", "The specified HTTP Operation Timeout is too small. The minimum allowed timeout is 1 second.");
            }
            this.SetCancellationSource(Help.SafeCreate<CancellationTokenSource>());
        }

        /// <inheritdoc />
        public void Cancel()
        {
            var source = this.CancellationSource;
            if (source.IsNotNull())
            {
                source.Cancel();
            }
        }

        /// <inheritdoc />
        public void SetCancellationSource(CancellationTokenSource tokenSource)
        {
            if (ReferenceEquals(tokenSource, null))
            {
                throw new ArgumentNullException("tokenSource");
            }

            var oldSource = this.CancellationSource;
            if (oldSource.IsNotNull())
            {
                oldSource.Dispose();
            }

            this.abstractionContext = Help.SafeCreate(() => new AbstractionContext(tokenSource, this.Logger, this.HttpOperationTimeout, this.RetryPolicy));
            tokenSource.Token.Register(this.CancellationCallback);
            this.source = tokenSource;
        }

        /// <inheritdoc />
        public void AddLogWriter(ILogWriter logWriter)
        {
            logWriter.ArgumentNotNull("logWriter");
            this.Logger.AddWriter(logWriter);
        }

        /// <inheritdoc />
        public void RemoveLogWriter(ILogWriter logWriter)
        {
            logWriter.ArgumentNotNull("logWriter");
            this.logger.RemoveWriter(logWriter);
        }
        
        private void CancellationCallback()
        {
            this.SetCancellationSource(Help.SafeCreate<CancellationTokenSource>());
        }

        /// <summary>
        /// Prepares a query job for execution.
        /// </summary>
        /// <param name="queryJob">The Query job to execute.</param>
        /// <typeparam name="TJobType">The Job type.</typeparam>
        /// <returns>Query job which is prepared for execution.</returns>
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "RunAsFileJob", Justification = "RunAsFileJob is a property on this instance.")]
        protected virtual TJobType PrepareQueryJob<TJobType>(TJobType queryJob) where TJobType : QueryJobCreateParameters
        {
            queryJob.ArgumentNotNull("queryJob");
            if (queryJob.HasQuery())
            {
                string restrictedCharacter;
                if (queryJob.RunAsFileJob)
                {
                    queryJob = this.UploadQueryFile(queryJob, queryJob.GetQuery());
                }
                else if (this.TryGetRestrictedCharactersInQuery(queryJob.GetQuery(), out restrictedCharacter))
                {
                    //Replace new lines and carriage returns by their string escape sequences
                    string formattedCharacter = restrictedCharacter.Replace('\n'.ToString(), "\\n");
                    formattedCharacter = formattedCharacter.Replace('\r'.ToString(), "\\r");
                    throw new InvalidOperationException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Query contains restricted character :'{0}'.{1}Please submit job as a File job or set RunAsFileJob to true.",
                            formattedCharacter,
                            Environment.NewLine));
                }
            }

            return queryJob;
        }

        /// <summary>
        /// Uploads the query text for query job into a file in storate.
        /// </summary>
        /// <typeparam name="TJobType">The Job type.</typeparam>
        /// <param name="queryJob">The query job.</param>
        /// <param name="queryText">The query text.</param>
        /// <returns>Query job which is prepared for execution.</returns>
        internal virtual TJobType UploadQueryFile<TJobType>(TJobType queryJob, string queryText) where TJobType : QueryJobCreateParameters
        {
            throw new NotImplementedException();
        }

        internal bool TryGetRestrictedCharactersInQuery(string queryText, out string restrictedCharacter)
        {
            restrictedCharacter = string.Empty;
            foreach (var knownRestrictedCharacter in WebHCatConstants.GetRestrictedCharactersInQuery())
            {
                if (queryText.Contains(knownRestrictedCharacter))
                {
                    restrictedCharacter = knownRestrictedCharacter.ToString();
                    return true;
                }
            }

            return false;
        }
    }
}
