// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

// TODO: Re-enable sync version

//#pragma warning disable CS1591 // public XML comments
//public abstract class ClientResultCollection<T> : ClientResult, IEnumerable<T>
//{
//    protected internal ClientResultCollection(PipelineResponse response) : base(response)
//    {
//    }

//    public abstract IEnumerator<T> GetEnumerator();

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

//    // TODO: take CancellationToken?
//    //public static ClientResultCollection<T> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<T>
//    public static ClientResultCollection<TValue> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<TValue>
//    {
//        return StreamingClientResult<TValue>.Create<TValue>(response);
//    }
//}
//#pragma warning restore CS1591 // public XML comments
