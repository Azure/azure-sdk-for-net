// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Represents the mode of a recorded test, determining how network requests and responses
/// are handled during test execution.
/// </summary>
public enum RecordedTestMode
{
    /// <summary>
    /// Live mode executes tests against actual live services with real network requests.
    /// In this mode, tests make actual HTTP calls to live endpoints and receive real responses.
    /// This mode is typically used for integration testing and validation against live services.
    /// </summary>
    Live,
    /// <summary>
    /// Record mode captures network interactions during test execution and saves them
    /// for future playback. Tests run against live services while simultaneously
    /// recording all HTTP requests and responses to session files.
    /// </summary>
    Record,
    /// <summary>
    /// Playback mode replays previously recorded network interactions instead of
    /// making live network requests. Tests execute using saved HTTP request/response
    /// pairs from session files, providing fast and deterministic test execution.
    /// </summary>
    Playback
}
