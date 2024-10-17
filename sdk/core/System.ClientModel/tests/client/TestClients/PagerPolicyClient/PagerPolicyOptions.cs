// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.ReferenceClients.PagerPolicyClient;

public class PagerPolicyOptions
{
    // TODO: implement freezing
    private bool _frozen;

    public string? PhoneNumber { get; set; }

    public virtual void Freeze() => _frozen = true;

    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientLoggingOptions instance after ClientPipeline has been created.");
        }
    }
}
