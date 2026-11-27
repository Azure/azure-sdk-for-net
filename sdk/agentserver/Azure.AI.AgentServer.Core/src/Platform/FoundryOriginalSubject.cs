// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Invocation-local original-subject assertions supplied by the platform.
/// These assertions are not proof of identity and do not change model authentication.
/// </summary>
[Experimental("AAAS005")]
public sealed class FoundryOriginalSubject
{
    /// <summary>Initializes an immutable original-subject snapshot.</summary>
    /// <param name="objectId">The original subject's object ID, if supplied.</param>
    /// <param name="tenantId">The original subject's tenant ID, if supplied.</param>
    /// <param name="identityType">The original subject's classification, if supplied.</param>
    public FoundryOriginalSubject(string? objectId, string? tenantId, string? identityType)
    {
        ObjectId = objectId;
        TenantId = tenantId;
        IdentityType = identityType;
    }

    /// <summary>Gets the original subject's object ID.</summary>
    public string? ObjectId { get; }

    /// <summary>Gets the original subject's tenant ID.</summary>
    public string? TenantId { get; }

    /// <summary>Gets the original subject's unmodified classification.</summary>
    public string? IdentityType { get; }

    internal static FoundryOriginalSubject? FromHeaders(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("x-ms-original-subject", out StringValues fields))
        {
            return null;
        }

        if (fields.Count != 1 || fields[0] is not string value)
        {
            throw InvalidHeader();
        }

        string? oid = null;
        string? tid = null;
        string? idtype = null;
        var seen = new HashSet<string>(StringComparer.Ordinal);
        int index = 0;
        SkipWhitespace(value, ref index);
        while (index < value.Length)
        {
            int start = index;
            while (index < value.Length && value[index] is >= 'a' and <= 'z')
            {
                index++;
            }

            string key = value.Substring(start, index - start);
            if ((key != "oid" && key != "tid" && key != "idtype")
                || !seen.Add(key)
                || index + 1 >= value.Length
                || value[index++] != '='
                || value[index++] != '"')
            {
                throw InvalidHeader();
            }

            var decoded = new StringBuilder();
            bool closed = false;
            while (index < value.Length)
            {
                char character = value[index++];
                if (character == '"')
                {
                    closed = true;
                    break;
                }

                if (character == '\\')
                {
                    if (index >= value.Length || (value[index] != '\\' && value[index] != '"'))
                    {
                        throw InvalidHeader();
                    }

                    character = value[index++];
                }
                else if (character < ' ' || character > '~')
                {
                    throw InvalidHeader();
                }

                decoded.Append(character);
            }

            if (!closed)
            {
                throw InvalidHeader();
            }

            switch (key)
            {
                case "oid":
                    oid = decoded.ToString();
                    break;
                case "tid":
                    tid = decoded.ToString();
                    break;
                case "idtype":
                    idtype = decoded.ToString();
                    break;
            }

            SkipWhitespace(value, ref index);
            if (index == value.Length)
            {
                break;
            }

            if (value[index++] != ',')
            {
                throw InvalidHeader();
            }

            SkipWhitespace(value, ref index);
            if (index == value.Length)
            {
                throw InvalidHeader();
            }
        }

        if (seen.Count == 0)
        {
            throw InvalidHeader();
        }

        return new FoundryOriginalSubject(oid, tid, idtype);
    }

    private static void SkipWhitespace(string value, ref int index)
    {
        while (index < value.Length && (value[index] == ' ' || value[index] == '\t'))
        {
            index++;
        }
    }

    private static FormatException InvalidHeader() =>
        new("Invalid original-subject platform header.");
}
