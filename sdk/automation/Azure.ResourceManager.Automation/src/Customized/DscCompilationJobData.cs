// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Models;
using System.ClientModel.Primitives;

#pragma warning disable CS0618
#pragma warning disable CS1591

namespace Azure.ResourceManager.Automation
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobData : ResourceData, IJsonModel<DscCompilationJobData>, IPersistableModel<DscCompilationJobData>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DscCompilationJobData()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string ConfigurationName
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? CreatedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? EndOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string Exception => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public Guid? JobId => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? LastModifiedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? LastStatusModifiedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Parameters => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public JobProvisioningState? ProvisioningState
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string RunOn
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string StartedBy => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? StartOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public AutomationJobStatus? Status
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string StatusDetails
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
    }
}

#pragma warning restore CS0618
#pragma warning restore CS1591
