// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Storage.Files.DataLake
{
    internal static class ErrorExtensions
    {
// clientDiagnostics parameter is a pattern expected by the codegenerator
#pragma warning disable CA1801
        internal static Exception CreateException(this string jsonMessage, ClientDiagnostics clientDiagnostics, Response response)
#pragma warning restore CA1801
        {
            if (string.IsNullOrWhiteSpace(jsonMessage))
            {
                return new RequestFailedException(
                    status: response.Status,
                    errorCode: response.Status.ToString(CultureInfo.InvariantCulture),
                    message: response.ReasonPhrase,
                    innerException: new Exception());
            }
            else
            {
                Dictionary<string, Dictionary<string, string>> errorDictionary
                    = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonMessage);
                return new RequestFailedException(
                    status: response.Status,
                    errorCode: errorDictionary[Constants.DataLake.ErrorKey][Constants.DataLake.ErrorCodeKey],
                    message: errorDictionary[Constants.DataLake.ErrorKey][Constants.DataLake.ErrorMessageKey],
                    innerException: new Exception());
            }
        }

    }
}
