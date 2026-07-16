// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Automation.Models
{
    /// <summary> The parameters supplied to the create compilation job operation. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobCreateOrUpdateContent : IJsonModel<DscCompilationJobCreateOrUpdateContent>, IPersistableModel<DscCompilationJobCreateOrUpdateContent>
    {
        /// <summary> Initializes a new instance of <see cref="DscCompilationJobCreateOrUpdateContent"/>. </summary>
        /// <param name="configuration"> Gets or sets the configuration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configuration"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public DscCompilationJobCreateOrUpdateContent(DscConfigurationAssociationProperty configuration)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the name of the Dsc configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string ConfigurationName => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> If a new build version of NodeConfiguration is required. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public bool? IsIncrementNodeConfigurationBuildRequired
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the location of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public AzureLocation? Location
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets name of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public string Name
        {
            get => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
            set => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets or sets the parameters of the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Parameters => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets the tags attached to the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public IDictionary<string, string> Tags => throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Writes the model as JSON. </summary>
        /// <param name="writer"> The UTF-8 JSON writer. </param>
        /// <param name="options"> The model reader writer options. </param>
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
