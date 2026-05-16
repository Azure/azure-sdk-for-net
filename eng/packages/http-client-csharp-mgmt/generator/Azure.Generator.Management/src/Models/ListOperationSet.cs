// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Captures the set of list operations that back a resource collection's GetAll method
/// when a collection can be listed from more than one ARM scope (subscription /
/// resource group / management group / extension parent). Used to drive the runtime
/// dispatch implementation in the generated GetAll body.
/// </summary>
internal sealed class ListOperationSet
{
    public ListOperationSet(
        IReadOnlyList<ListCandidate> candidates,
        ListCandidate? fallbackCandidate,
        CSharpType itemType)
    {
        Candidates = candidates;
        FallbackCandidate = fallbackCandidate;
        ItemType = itemType;
    }

    /// <summary>
    /// Candidate list operations keyed by a concrete ResourceType comparison
    /// (Subscription / ResourceGroup / ManagementGroup / specific extension parent).
    /// </summary>
    public IReadOnlyList<ListCandidate> Candidates { get; }

    /// <summary>
    /// Optional fallback candidate corresponding to the generic-extension scope
    /// (the legacy "ListForResource" shape). Emitted as the else branch.
    /// </summary>
    public ListCandidate? FallbackCandidate { get; }

    /// <summary>
    /// The paged item type shared by all candidates.
    /// </summary>
    public CSharpType ItemType { get; }

    /// <summary>
    /// True when this set should drive aggregation (more than one candidate or
    /// a single candidate plus a generic-extension fallback).
    /// </summary>
    public bool RequiresAggregation =>
        FallbackCandidate is not null
            ? Candidates.Count >= 1
            : Candidates.Count >= 2;
}

/// <summary>
/// One list candidate within a <see cref="ListOperationSet"/>.
/// </summary>
internal sealed record ListCandidate(
    ResourceMethod Method,
    OperationContext OperationContext,
    RestClientInfo RestClientInfo,
    CSharpType? DispatchResourceType);
