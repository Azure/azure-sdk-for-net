// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
    internal static class IncrementalValuesProviderExtensions
    {
        public static IncrementalValuesProvider<TResult> SelectWhen<TInput, TResult>(
            this IncrementalValuesProvider<TInput> input,
            IncrementalValueProvider<bool> condition,
            Func<TInput, TResult?> selector)
            where TResult : class
        {
            return input
                .Combine(condition)
                .Where(static tuple => tuple.Right)
                .Select((tuple, _) => selector(tuple.Left))
                .Where(static result => result is not null)
                .Select(static (result, _) => result!);
        }
    }
}
