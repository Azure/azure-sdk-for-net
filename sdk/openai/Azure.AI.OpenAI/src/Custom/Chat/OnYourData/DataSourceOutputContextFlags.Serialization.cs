// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

internal static partial class DataSourceOutputContextFlagsExtensions
{
    public static IList<string> ToStringList(this DataSourceOutputContextFlags flags)
    {
        List<string> contexts = [];
        if (flags.HasFlag(DataSourceOutputContextFlags.Intent))
        {
            contexts.Add("intent");
        }
        if (flags.HasFlag(DataSourceOutputContextFlags.Citations))
        {
            contexts.Add("citations");
        }
        if (flags.HasFlag(DataSourceOutputContextFlags.AllRetrievedDocuments))
        {
            contexts.Add("all_retrieved_documents");
        }
        return contexts;
    }

    public static DataSourceOutputContextFlags? FromStringList(IList<string> strings)
    {
        if (strings is null)
        {
            return null;
        }
        DataSourceOutputContextFlags flags = 0;
        foreach (string s in strings)
        {
            if (s == "citations")
            {
                flags |= DataSourceOutputContextFlags.Citations;
            }
            else if (s == "intent")
            {
                flags |= DataSourceOutputContextFlags.Intent;
            }
            else if (s == "all_retrieved_documents")
            {
                flags |= DataSourceOutputContextFlags.AllRetrievedDocuments;
            }
        }
        return flags;
    }
}