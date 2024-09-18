// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class MaxLengthStream : MemoryStream
{
    private int _bytesLeft;

    public MaxLengthStream(int maxLength) : base()
    {
        _bytesLeft = maxLength;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        DecrementLength(ref count);
        if (count > 0)
        {
            base.Write(buffer, offset, count);
        }
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return count > 0 ? base.WriteAsync(buffer, offset, count, cancellationToken) : Task.CompletedTask;
    }

    private void DecrementLength(ref int count)
    {
        var left = Math.Min(count, _bytesLeft);
        count = left;

        _bytesLeft -= count;
    }
}
