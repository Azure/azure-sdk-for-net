// <copyright file="StatusCanonicalCode.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Instrumentation.GrpcNetClient;

/// <summary>
/// Canonical result code of span execution.
/// </summary>
/// <remarks>
/// This follows the standard GRPC codes.
/// https://github.com/grpc/grpc/blob/master/doc/statuscodes.md.
/// </remarks>
internal enum StatusCanonicalCode
{
    /// <summary>
    /// The operation completed successfully.
    /// </summary>
    Ok = 0,

    /// <summary>
    /// The operation was cancelled (typically by the caller).
    /// </summary>
    Cancelled = 1,

    /// <summary>
    /// Unknown error. An example of where this error may be returned is if a Status value received
    /// from another address space belongs to an error-space that is not known in this address space.
    /// Also errors raised by APIs that do not return enough error information may be converted to
    /// this error.
    /// </summary>
    Unknown = 2,

    /// <summary>
    /// Client specified an invalid argument. Note that this differs from FAILED_PRECONDITION.
    /// INVALID_ARGUMENT indicates arguments that are problematic regardless of the state of the
    /// system (e.g., a malformed file name).
    /// </summary>
    InvalidArgument = 3,

    /// <summary>
    /// Deadline expired before operation could complete. For operations that change the state of the
    /// system, this error may be returned even if the operation has completed successfully. For
    /// example, a successful response from a server could have been delayed long enough for the
    /// deadline to expire.
    /// </summary>
    DeadlineExceeded = 4,

    /// <summary>
    /// Some requested entity (e.g., file or directory) was not found.
    /// </summary>
    NotFound = 5,

    /// <summary>
    /// Some entity that we attempted to create (e.g., file or directory) already exists.
    /// </summary>
    AlreadyExists = 6,

    /// <summary>
    /// The caller does not have permission to execute the specified operation. PERMISSION_DENIED
    /// must not be used for rejections caused by exhausting some resource (use RESOURCE_EXHAUSTED
    /// instead for those errors). PERMISSION_DENIED must not be used if the caller cannot be
    /// identified (use UNAUTHENTICATED instead for those errors).
    /// </summary>
    PermissionDenied = 7,

    /// <summary>
    /// Some resource has been exhausted, perhaps a per-user quota, or perhaps the entire file system
    /// is out of space.
    /// </summary>
    ResourceExhausted = 8,

    /// <summary>
    /// Operation was rejected because the system is not in a state required for the operation's
    /// execution. For example, directory to be deleted may be non-empty, an rmdir operation is
    /// applied to a non-directory, etc.
    /// A litmus test that may help a service implementor in deciding between FAILED_PRECONDITION,
    /// ABORTED, and UNAVAILABLE: (a) Use UNAVAILABLE if the client can retry just the failing call.
    /// (b) Use ABORTED if the client should retry at a higher-level (e.g., restarting a
    /// read-modify-write sequence). (c) Use FAILED_PRECONDITION if the client should not retry until
    /// the system state has been explicitly fixed. E.g., if an "rmdir" fails because the directory
    /// is non-empty, FAILED_PRECONDITION should be returned since the client should not retry unless
    /// they have first fixed up the directory by deleting files from it.
    /// </summary>
    FailedPrecondition = 9,

    /// <summary>
    /// The operation was aborted, typically due to a concurrency issue like sequencer check
    /// failures, transaction aborts, etc.
    /// </summary>
    Aborted = 10,

    /// <summary>
    /// Operation was attempted past the valid range. E.g., seeking or reading past end of file.
    ///
    /// Unlike INVALID_ARGUMENT, this error indicates a problem that may be fixed if the system
    /// state changes. For example, a 32-bit file system will generate INVALID_ARGUMENT if asked to
    /// read at an offset that is not in the range [0,2^32-1], but it will generate OUT_OF_RANGE if
    /// asked to read from an offset past the current file size.
    ///
    /// There is a fair bit of overlap between FAILED_PRECONDITION and OUT_OF_RANGE. We recommend
    /// using OUT_OF_RANGE (the more specific error) when it applies so that callers who are
    /// iterating through a space can easily look for an OUT_OF_RANGE error to detect when they are
    /// done.
    /// </summary>
    OutOfRange = 11,

    /// <summary>
    /// Operation is not implemented or not supported/enabled in this service.
    /// </summary>
    Unimplemented = 12,

    /// <summary>
    /// Internal errors. Means some invariants expected by underlying system has been broken. If you
    /// see one of these errors, something is very broken.
    /// </summary>
    Internal = 13,

    /// <summary>
    /// The service is currently unavailable. This is a most likely a transient condition and may be
    /// corrected by retrying with a backoff.
    ///
    /// See litmus test above for deciding between FAILED_PRECONDITION, ABORTED, and UNAVAILABLE.
    /// </summary>
    Unavailable = 14,

    /// <summary>
    /// Unrecoverable data loss or corruption.
    /// </summary>
    DataLoss = 15,

    /// <summary>
    /// The request does not have valid authentication credentials for the operation.
    /// </summary>
    Unauthenticated = 16,
}
