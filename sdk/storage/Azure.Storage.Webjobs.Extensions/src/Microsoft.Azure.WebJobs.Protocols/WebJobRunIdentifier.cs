// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents an identifier for a WebJob.</summary>
    [DebuggerDisplay("{GetKey(),nq}")]
#if PUBLICPROTOCOL
    public class WebJobRunIdentifier
#else
    internal class WebJobRunIdentifier
#endif
    {
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static WebJobRunIdentifier()
        {
            var webSiteName = Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.WebSiteNameKey);
            var jobName = Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.JobNameKey);
            var jobTypeName = Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.JobTypeKey);
            var jobRunId = Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.JobRunIdKey);

            WebJobTypes webJobType;
            var isValidWebJobType = Enum.TryParse(jobTypeName, true, out webJobType);

            if (webSiteName == null || !isValidWebJobType || jobName == null)
            {
                Current = null;
            }
            else
            {
                Current = new WebJobRunIdentifier(webSiteName, webJobType, jobName, jobRunId);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="WebJobRunIdentifier"/> class.</summary>
        /// <remarks>This constructor is only intended for serialization support.</remarks>
        public WebJobRunIdentifier()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobRunIdentifier"/> class with the values provided.
        /// </summary>
        /// <param name="jobType">The job type.</param>
        /// <param name="jobName">The job name.</param>
        /// <param name="runId">The job run ID.</param>
        public WebJobRunIdentifier(WebJobTypes jobType, string jobName, string runId)
            : this(Environment.GetEnvironmentVariable(WebSitesKnownKeyNames.WebSiteNameKey), jobType, jobName, runId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobRunIdentifier"/> class with the values provided.
        /// </summary>
        /// <param name="websiteName">The website name.</param>
        /// <param name="jobType">The job type.</param>
        /// <param name="jobName">The job name.</param>
        /// <param name="runId">The job run ID.</param>
        public WebJobRunIdentifier(string websiteName, WebJobTypes jobType, string jobName, string runId)
        {
            if (jobType == WebJobTypes.Triggered && runId == null)
            {
                throw new ArgumentNullException("runId", "runId is required for triggered jobs.");
            }

            WebSiteName = websiteName;
            JobType = jobType;
            JobName = jobName;
            RunId = runId;
        }

        /// <summary>Gets or sets the website name.</summary>
        public string WebSiteName { get; set; }

        /// <summary>Gets or sets the WebJob type.</summary>
        public WebJobTypes JobType { get; set; }

        /// <summary>Gets or sets the job name.</summary>
        public string JobName { get; set; }

        /// <summary>Gets or sets the job run ID.</summary>
        public string RunId { get; set; }

        /// <summary>Gets an identifier for the current web job run, if any.</summary>
        public static WebJobRunIdentifier Current
        {
            get;
            private set;
        }

        /// <summary>Gets a key containing the full web job identifier.</summary>
        /// <returns>A key containing the full web job identifier.</returns>
        public string GetKey()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}${1}${2}${3}",
                WebSiteName, JobType, JobName, RunId).ToLowerInvariant();
        }
    }
}
