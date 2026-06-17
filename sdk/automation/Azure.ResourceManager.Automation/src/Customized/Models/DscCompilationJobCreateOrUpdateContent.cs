// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using System.ClientModel.Primitives;

#pragma warning disable CS0618
#pragma warning disable CS1591

namespace Azure.ResourceManager.Automation.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobCreateOrUpdateContent : IJsonModel<DscCompilationJobCreateOrUpdateContent>, IPersistableModel<DscCompilationJobCreateOrUpdateContent>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DscCompilationJobCreateOrUpdateContent(DscConfigurationAssociationProperty configuration)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string ConfigurationName => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public bool? IsIncrementNodeConfigurationBuildRequired
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public AzureLocation? Location
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string Name
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Parameters => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Tags => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobCreateOrUpdateContent IJsonModel<DscCompilationJobCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        void IJsonModel<DscCompilationJobCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobCreateOrUpdateContent IPersistableModel<DscCompilationJobCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        string IPersistableModel<DscCompilationJobCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        BinaryData IPersistableModel<DscCompilationJobCreateOrUpdateContent>.Write(ModelReaderWriterOptions options)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}

#pragma warning restore CS0618
#pragma warning restore CS1591
