// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using TestHelpers.Internal;

namespace System.ClientModel.Tests;

public class ClientResultTests
{
    [Test]
    public void CanCreateOptionalResultFromBool()
    {
        PipelineResponse response = new MockPipelineRequest();

    }

    #region Helpers
    private class ErrorOutputMessage<T> : OptionalClientResult<T>
    {
        private readonly ClientRequestException _exception;

        public ErrorOutputMessage(PipelineResponse response, ClientRequestException exception)
            : base(default, response)
        {
            _exception = exception;
        }

        public override T? Value { get => throw _exception; }

        public override bool HasValue => false;
    }
    #endregion
}
