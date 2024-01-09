// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockOptionalClientResult<T> : OptionalClientResult<T>
{
    private T? _value;
    private bool _hasValue;

    public MockOptionalClientResult(T? value, PipelineResponse response)
        : base(value, response)
    {
        _value = value;
    }

    public override T? Value => _value;

    public void SetValue(T? value) => _value = value;

    public override bool HasValue => _hasValue;

    public void SetHasValue(bool value) => _hasValue = value;
}
