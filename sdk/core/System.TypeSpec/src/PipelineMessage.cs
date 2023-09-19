// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage
{
    private Dictionary<string, string> _headers = new Dictionary<string, string>();
    private BinaryData? _content;

    /// <summary>
    /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="PipelineMessage"/> processing.
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    public Result? Result { get; set; }

    public virtual void SetHeader(string key, string value)
        => _headers.Add(key, value);

    public virtual void SetRequestContent(BinaryData content)
        => _content = content;

    public bool TryGetHeader(string name, out string value)
        => _headers.TryGetValue(name, out value);

    public bool RemoveHeader(string name)
        => _headers.Remove(name);
}
