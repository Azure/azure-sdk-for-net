// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks
{
    public class MockResultCollection<TValue> : ResultCollection<TValue>
    {
        private readonly Func<IEnumerable<TValue>> _enumerateFunc;

        public MockResultCollection(Func<IEnumerable<TValue>> enumerateFunc, PipelineResponse? response = null) :
            base(response ?? new MockPipelineResponse())
        {
            _enumerateFunc = enumerateFunc ?? throw new ArgumentNullException(nameof(enumerateFunc));
        }

        public override IEnumerator<TValue> GetEnumerator()
            => _enumerateFunc().GetEnumerator();
    }
}
