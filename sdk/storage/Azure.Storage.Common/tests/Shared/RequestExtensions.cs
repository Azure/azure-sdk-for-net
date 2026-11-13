// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Storage;

public static partial class RequestExtensions
{
    public static string AssertHeaderPresent(this Request request, string headerName)
    {
        if (request.Headers.TryGetValue(headerName, out string value))
        {
            return headerName == Constants.StructuredMessage.StructuredMessageHeader ? null : value;
        }
        StringBuilder sb = new StringBuilder()
            .AppendLine($"`{headerName}` expected on request but was not found.")
            .AppendLine($"{request.Method} {request.Uri}")
            .AppendLine(string.Join("\n", request.Headers.Select(h => $"{h.Name}: {h.Value}s")))
            ;
        Assert.Fail(sb.ToString());
        return null;
    }
}
