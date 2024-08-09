// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.RecordingProxy;

/// <summary>
/// Enumeration of possible values of how to record a request. This acts as an override.
/// </summary>
public enum RequestRecordMode
{
    /// <summary>
    /// Records the request.
    /// </summary>
    Record,
    /// <summary>
    /// Records the request headers but skips the request body.
    /// </summary>
    RecordWithoutRequestBody,
    /// <summary>
    /// Does not record the request (nor the response).
    /// </summary>
    DoNotRecord,
}
