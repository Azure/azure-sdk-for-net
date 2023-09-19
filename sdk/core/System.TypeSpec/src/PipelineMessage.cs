// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage
{
    /// <summary>
    /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="PipelineMessage"/> processing.
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    public Result? Result { get; set; }

    public virtual void AddHeader(string key, string value)
    {
        throw new NotImplementedException();
    }
    public virtual void AddRequestContent(BinaryData content)
    {
        throw new NotImplementedException();
    }
}
