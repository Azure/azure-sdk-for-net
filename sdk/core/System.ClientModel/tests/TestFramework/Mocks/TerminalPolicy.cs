// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace ClientModel.Tests.Mocks;

public class TerminalPolicy : ObservablePolicy
{
    public TerminalPolicy(string id) : base(id)
    {
        IsLastPolicy = true;
    }
}
