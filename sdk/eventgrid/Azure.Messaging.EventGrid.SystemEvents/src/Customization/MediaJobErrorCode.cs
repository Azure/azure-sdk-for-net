// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary>
    /// Error code describing the error. If you get an enum with a value of <see cref="int.MaxValue"/>, that means the service has returned a new category, and you
    /// should upgrade to the latest SDK.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MediaJobErrorCode
    {
        /// <summary> Fatal service error, please contact support. </summary>
        ServiceError,
        /// <summary> Transient error, please retry, if retry is unsuccessful, please contact support. </summary>
        ServiceTransientError,
        /// <summary> While trying to download the input files, the files were not accessible, please check the availability of the source. </summary>
        DownloadNotAccessible,
        /// <summary> While trying to download the input files, there was an issue during transfer (storage service, network errors), see details and check your source. </summary>
        DownloadTransientError,
        /// <summary> While trying to upload the output files, the destination was not reachable, please check the availability of the destination. </summary>
        UploadNotAccessible,
        /// <summary> While trying to upload the output files, there was an issue during transfer (storage service, network errors), see details and check your destination. </summary>
        UploadTransientError,
        /// <summary> There was a problem with the combination of input files and the configuration settings applied, fix the configuration settings and retry with the same input, or change input to match the configuration. </summary>
        ConfigurationUnsupported,
        /// <summary> There was a problem with the input content (for example: zero byte files, or corrupt/non-decodable files), check the input files. </summary>
        ContentMalformed,
        /// <summary> There was a problem with the format of the input (not valid media file, or an unsupported file/codec), check the validity of the input files. </summary>
        ContentUnsupported,
        /// <summary> There is an error verifying to the account identity. Check and fix the identity configurations and retry. If unsuccessful, please contact support. </summary>
        IdentityUnsupported
    }
}
