// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Validates candidate IDs used to construct file-system paths and URIs.
/// Defends against path traversal, separator injection, and accidental ID malformation.
/// Shared by <see cref="AgentOptimizationClient.ResolveOptionsAsync(LoadOptions, System.Threading.CancellationToken)"/>
/// for resolver API and local candidate-directory resolution.
/// </summary>
internal static class CandidateIdValidator
{
    /// <summary>
    /// Throws <see cref="ArgumentException"/> when <paramref name="candidateId"/> is not safe
    /// to use as a path segment or URI fragment.
    /// </summary>
    public static void ThrowIfInvalid(string candidateId, string paramName)
    {
        if (string.IsNullOrEmpty(candidateId))
        {
            throw new ArgumentNullException(paramName);
        }

        if (!IsValid(candidateId))
        {
            throw new ArgumentException("Candidate ID must not contain path separators or '..'.", paramName);
        }
    }

    /// <summary>
    /// Returns <c>true</c> when <paramref name="candidateId"/> is safe to use as a path
    /// segment or URI fragment (no parent-traversal sequences, no path separators).
    /// </summary>
    public static bool IsValid(string candidateId)
    {
        if (string.IsNullOrEmpty(candidateId))
        {
            return false;
        }

        ReadOnlySpan<char> span = candidateId.AsSpan();

        if (ContainsParentTraversal(span))
        {
            return false;
        }

        if (span.IndexOf(Path.DirectorySeparatorChar) >= 0 ||
            span.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
        {
            return false;
        }

        return true;
    }

    private static bool ContainsParentTraversal(ReadOnlySpan<char> value)
    {
        for (int i = 1; i < value.Length; i++)
        {
            if (value[i - 1] == '.' && value[i] == '.')
            {
                return true;
            }
        }

        return false;
    }
}
