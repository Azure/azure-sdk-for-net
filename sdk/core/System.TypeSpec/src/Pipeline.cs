// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

public abstract class Pipeline<TMessage>
{
    public abstract TMessage CreateMessage(string verb, Uri uri);

    public abstract void Send(TMessage message);
}
