// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

#pragma warning disable CS0618
#pragma warning disable CS1591

namespace Azure.ResourceManager.Automation
{
    public partial class AutomationAccountResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        [ForwardsClientCalls]
        public virtual Response<DscCompilationJobResource> GetDscCompilationJob(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        [ForwardsClientCalls]
        public virtual Task<Response<DscCompilationJobResource>> GetDscCompilationJobAsync(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual DscCompilationJobCollection GetDscCompilationJobs()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Pageable<AutomationJobStream> GetDscCompilationJobStreams(Guid jobId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual AsyncPageable<AutomationJobStream> GetDscCompilationJobStreamsAsync(Guid jobId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<AutomationJobStream> GetStreamDscCompilationJob(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<AutomationJobStream>> GetStreamDscCompilationJobAsync(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}

#pragma warning restore CS0618
#pragma warning restore CS1591
