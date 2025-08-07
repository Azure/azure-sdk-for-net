// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("ImportJob")]
    [CodeGenSerialization(nameof(Error), SerializationValueHook = nameof(SerializeErrorValue))]
    public partial class ImportJob
    {
        // This class declaration:
        // - changes the namespace, class name and property visibility;
        // - Makes the generated class of the same name declare inputBlobUri and outputBlobUri as a **Uri** rather than an **string**.
        // Do not remove.

        /// <summary> The path to the input Azure storage blob that contains file(s) describing the operations to perform in the job. </summary>
        [CodeGenMember("InputBlobUri")]
        public Uri InputBlobUri { get; set; }

        /// <summary> The path to the output Azure storage blob that will contain the errors and progress logs of import job. </summary>
        [CodeGenMember("OutputBlobUri")]
        public Uri OutputBlobUri { get; set; }

        /// <summary> Details of the error(s) that occurred executing the import job. </summary>
        [CodeGenMember("Error")]
        public ResponseError Error { get; }

        /// <summary> Status of the job. </summary>
        [CodeGenMember("Status")]
        public ImportJobStatus? Status { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeErrorValue(Utf8JsonWriter writer)
        {
            writer.WriteObjectValue(Error);
        }
    }
}
