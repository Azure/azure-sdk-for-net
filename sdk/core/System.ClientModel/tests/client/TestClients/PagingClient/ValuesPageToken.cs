// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.Tests.PagingClient;

internal class ValuesPageToken : ContinuationToken
{
    public override BinaryData ToBytes()
    {
        throw new NotImplementedException();
    }

    public ValuesPageToken? GetNextPageToken()
    {
        throw new NotImplementedException();
    }

    public static ValuesPageToken FromToken(ContinuationToken pageToken)
    {
        throw new NotImplementedException();
    }

    public static ValuesPageToken FromOptions()
    {
        throw new NotImplementedException();
    }
}
