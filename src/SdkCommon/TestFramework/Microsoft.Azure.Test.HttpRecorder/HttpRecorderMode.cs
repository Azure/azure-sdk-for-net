// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Test.HttpRecorder
{
    /// <summary>
    /// Enum that holds possible modes for the http recorder.
    /// </summary>
    public enum HttpRecorderMode
    {
        /// <summary>
        /// The mock server does not do anything.
        /// </summary>
        None, 

        /// <summary>
        /// In this mode the mock server watches the out-going requests and records
        /// their corresponding responses.
        /// </summary>
        Record,

        /// <summary>
        /// The playback mode should always be after a successful record session.
        /// The mock server matches the given requests and return their stored 
        /// corresponding responses.
        /// </summary>
        Playback
    }
}
