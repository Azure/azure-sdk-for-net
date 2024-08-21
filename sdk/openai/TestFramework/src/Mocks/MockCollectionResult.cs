// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks
{
    /// <summary>
    /// Represents a mock implementation of the <see cref="ResultCollection{TValue}"/> class.
    /// </summary>
    /// <typeparam name="TValue">The type of the values in the collection.</typeparam>
    public class MockCollectionResult<TValue> : CollectionResult<TValue>
    {
        private readonly Func<IEnumerable<TValue>> _enumerateFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockCollectionResult{TValue}"/> class with the specified enumeration
        /// function and optional pipeline response.
        /// </summary>
        /// <param name="enumerateFunc">The function used to enumerate the collection.</param>
        /// <param name="response">The pipeline response associated with the collection.</param>
        public MockCollectionResult(Func<IEnumerable<TValue>> enumerateFunc, PipelineResponse? response = null) :
            base(response ?? new MockPipelineResponse())
        {
            _enumerateFunc = enumerateFunc ?? throw new ArgumentNullException(nameof(enumerateFunc));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public override IEnumerator<TValue> GetEnumerator()
            => _enumerateFunc().GetEnumerator();
    }
}
