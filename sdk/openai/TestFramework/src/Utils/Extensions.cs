// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Utils;

public static class HeaderExtensions
{
    public static string? GetFirstOrDefault(this PipelineResponseHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }

    public static string? GetFirstOrDefault(this PipelineRequestHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }
}

public static class CollectionExtensions
{
    public static string? JoinOrNull(this IEnumerable<string> values, string separator)
    {
        if (values == null)
        {
            return null;
        }

        return string.Join(separator, values);
    }
}

public static class FileExtensions
{
    public static string GetRelativePath(string relativeTo, string path)
    {
#if NET
        return Path.GetRelativePath(relativeTo, path);
#else
        relativeTo = Path.GetFullPath(relativeTo);
        path = Path.GetFullPath(path);

        Uri relativeToUri = new Uri(relativeTo);
        Uri pathUri = new Uri(path);

        if (relativeToUri.Scheme != pathUri.Scheme)
        {
            return path;
        }

        Uri relative = relativeToUri.MakeRelativeUri(pathUri);
        return Uri.UnescapeDataString(relative.ToString())
            .Replace('/', '\\');
#endif
    }
}
