// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A class representing the DscCompilationJob data model.
    /// Definition of the Dsc Compilation job.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobData : ResourceData, IJsonModel<DscCompilationJobData>, IPersistableModel<DscCompilationJobData>
    {
        /// <summary> Initializes a new instance of <see cref="DscCompilationJobData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DscCompilationJobData()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the name of the Dsc configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string ConfigurationName
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets the creation time of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? CreatedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the end time of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? EndOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the exception of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string Exception => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the id of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public Guid? JobId => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the last modified time. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? LastModifiedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the last status modified time. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? LastStatusModifiedOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets or sets the parameters of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Parameters => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> The current provisioning state of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public JobProvisioningState? ProvisioningState
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the runOn which specifies the group name where the job is to be executed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string RunOn
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets the compilation job started by. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string StartedBy => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the start time of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DateTimeOffset? StartOn => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets or sets the status of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public AutomationJobStatus? Status
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the status details of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string StatusDetails
        {
            get => throw DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <inheritdoc />
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
