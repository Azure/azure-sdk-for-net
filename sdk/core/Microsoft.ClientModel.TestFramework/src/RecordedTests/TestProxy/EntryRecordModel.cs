// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Specifies the recording behavior for individual HTTP requests and responses
/// during test recording sessions.
/// </summary>
public enum EntryRecordModel
{
    /// <summary>
    /// Records the complete HTTP request and response, including headers, body,
    /// and all metadata. This is the default recording behavior.
    /// </summary>
    Record,
    /// <summary>
    /// Excludes the HTTP request and response from being recorded entirely.
    /// The interaction will not appear in the test recording session.
    /// </summary>
    DoNotRecord,
    /// <summary>
    /// Records the HTTP request headers and response data, but excludes the
    /// request body from the recording.
    /// </summary>
    RecordWithoutRequestBody
}
