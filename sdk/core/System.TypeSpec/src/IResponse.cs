// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ServiceModel.Rest.Core;

// TODO: this does not include some members from Response (e.g. ClientRequestId). Is that OK?
// TODO: can we turn it into a class?
public interface IResponse
{
    int Status { get; }
    BinaryData Content { get; }
    Stream? ContentStream { get; }
    bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);
    string ReasonPhrase { get; }
    //IEnumerable<string> HeaderNames();
}
