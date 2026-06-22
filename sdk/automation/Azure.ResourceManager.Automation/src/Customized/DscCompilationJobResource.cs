// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

#pragma warning disable CS0618
#pragma warning disable CS1591

namespace Azure.ResourceManager.Automation
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobResource : ArmResource, IJsonModel<DscCompilationJobData>, IPersistableModel<DscCompilationJobData>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static readonly ResourceType ResourceType = "Microsoft.Automation/automationAccounts/compilationjobs";

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        protected DscCompilationJobResource()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual DscCompilationJobData Data => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual bool HasData => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string compilationJobName)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<DscCompilationJobResource> Get(CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<DscCompilationJobResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobData IJsonModel<DscCompilationJobData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        void IJsonModel<DscCompilationJobData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobData IPersistableModel<DscCompilationJobData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        string IPersistableModel<DscCompilationJobData>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        BinaryData IPersistableModel<DscCompilationJobData>.Write(ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual ArmOperation<DscCompilationJobResource> Update(WaitUntil waitUntil, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<ArmOperation<DscCompilationJobResource>> UpdateAsync(WaitUntil waitUntil, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}

#pragma warning restore CS0618
#pragma warning restore CS1591
