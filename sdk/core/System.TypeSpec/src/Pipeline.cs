// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest;

public abstract class Pipeline<TMessage>
{
    public abstract TMessage CreateMessage(string verb, Uri uri);

    public abstract void Send(TMessage message);
}
