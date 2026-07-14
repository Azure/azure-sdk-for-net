// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// The canonical, single decision site for resilient-response dispatch classification — the
/// .NET port of Python <c>hosting/_dispatch.py</c> (<c>classify_row</c> / <c>decide_disposition</c>).
/// <para>
/// The resilience matrix rows are keyed on <c>(store, background, resilient_background)</c>:
/// </para>
/// <list type="bullet">
/// <item><description>Row 1: <c>store=true, background=true, resilient_background=true</c> — crash-recoverable (re-invoke).</description></item>
/// <item><description>Row 2: <c>store=true, background=true, resilient_background=false</c> — mark failed on interruption.</description></item>
/// <item><description>Row 3: <c>store=true, background=false</c> — foreground stored; mark failed on interruption.</description></item>
/// <item><description>Row 4: <c>store=false</c> — no persisted state, no next-lifetime action.</description></item>
/// </list>
/// </summary>
internal static class ResponseResilienceDispatch
{
    /// <summary>Row 1: resilient background (store + background + resilient_background).</summary>
    public const int Row1ResilientBackground = 1;

    /// <summary>Row 2: non-resilient background (store + background).</summary>
    public const int Row2Background = 2;

    /// <summary>Row 3: foreground stored (store, no background).</summary>
    public const int Row3Foreground = 3;

    /// <summary>Row 4: unstored (no store).</summary>
    public const int Row4Unstored = 4;

    /// <summary>
    /// Classifies a response into its resilience matrix row from the three governing flags.
    /// Matches Python <c>classify_row</c> exactly.
    /// </summary>
    /// <param name="store">Whether the response is persisted to the store.</param>
    /// <param name="background">Whether the response runs in the background.</param>
    /// <param name="resilientBackground">Whether resilient background recovery is enabled.</param>
    /// <returns>The matrix row (1–4).</returns>
    public static int ClassifyRow(bool store, bool background, bool resilientBackground)
    {
        if (!store)
        {
            return Row4Unstored;
        }

        if (!background)
        {
            return Row3Foreground;
        }

        return resilientBackground ? Row1ResilientBackground : Row2Background;
    }

    /// <summary>
    /// Decides the crash-recovery disposition for a response. Only a stored, background,
    /// resilient-background response is re-invoked; everything else is marked failed. Matches
    /// Python <c>decide_disposition</c> exactly.
    /// </summary>
    /// <param name="store">Whether the response is persisted to the store.</param>
    /// <param name="background">Whether the response runs in the background.</param>
    /// <param name="resilientBackground">Whether resilient background recovery is enabled.</param>
    /// <returns>
    /// <see cref="ResponseRecoveryPayload.DispositionReinvoke"/> for a recoverable response;
    /// otherwise <see cref="ResponseRecoveryPayload.DispositionMarkFailed"/>.
    /// </returns>
    public static string DecideDisposition(bool store, bool background, bool resilientBackground)
    {
        if (store && background && resilientBackground)
        {
            return ResponseRecoveryPayload.DispositionReinvoke;
        }

        return ResponseRecoveryPayload.DispositionMarkFailed;
    }

    /// <summary>
    /// Gets whether a response is a "resilient background" response — the composite gate that
    /// enables checkpointing, snapshot persistence, and crash recovery. Equivalent to
    /// <c>store &amp;&amp; background &amp;&amp; resilientBackground</c>.
    /// </summary>
    public static bool IsResilientBackground(bool store, bool background, bool resilientBackground)
        => store && background && resilientBackground;
}
