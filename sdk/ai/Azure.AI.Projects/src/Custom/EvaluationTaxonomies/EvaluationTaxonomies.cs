// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Evaluation;

public partial class EvaluationTaxonomies
{
    /// <summary> Creates or replaces the specified evaluation taxonomy with the provided definition. </summary>
    /// <param name="name"> The name of the evaluation taxonomy. </param>
    /// <param name="body"> The evaluation taxonomy. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<EvaluationTaxonomy> Create(string name, EvaluationTaxonomy body, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(body, nameof(body));

        ClientResult result = Create(name, body, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((EvaluationTaxonomy)result, result.GetRawResponse());
    }

    /// <summary> Creates or replaces the specified evaluation taxonomy with the provided definition. </summary>
    /// <param name="name"> The name of the evaluation taxonomy. </param>
    /// <param name="body"> The evaluation taxonomy. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<EvaluationTaxonomy>> CreateAsync(string name, EvaluationTaxonomy body, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(body, nameof(body));

        ClientResult result = await CreateAsync(name, body, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((EvaluationTaxonomy)result, result.GetRawResponse());
    }
}
