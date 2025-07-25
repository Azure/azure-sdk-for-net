// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

internal class PlaybackRetryPolicy : ClientRetryPolicy
{
    private TimeSpan _delay;

    public PlaybackRetryPolicy(TimeSpan delay)
        : base(3)
    {
        _delay = delay;
    }

    protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        return _delay;
    }
}
