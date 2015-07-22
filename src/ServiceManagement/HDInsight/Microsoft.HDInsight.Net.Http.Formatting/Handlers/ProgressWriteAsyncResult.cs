// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Handlers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    internal class ProgressWriteAsyncResult : AsyncResult
    {
        private static readonly AsyncCallback _writeCompletedCallback = WriteCompletedCallback;

        private readonly Stream _innerStream;
        private readonly ProgressStream _progressStream;
        private readonly int _count;

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is handled as part of IAsyncResult completion.")]
        public ProgressWriteAsyncResult(Stream innerStream, ProgressStream progressStream, byte[] buffer, int offset, int count, AsyncCallback callback, object state)
            : base(callback, state)
        {
            Contract.Assert(innerStream != null);
            Contract.Assert(progressStream != null);
            Contract.Assert(buffer != null);

            this._innerStream = innerStream;
            this._progressStream = progressStream;
            this._count = count;

            try
            {
                IAsyncResult result = innerStream.BeginWrite(buffer, offset, count, _writeCompletedCallback, this);
                if (result.CompletedSynchronously)
                {
                    this.WriteCompleted(result);
                }
            }
            catch (Exception e)
            {
                this.Complete(true, e);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is handled as part of IAsyncResult completion.")]
        private static void WriteCompletedCallback(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
            {
                return;
            }

            ProgressWriteAsyncResult thisPtr = (ProgressWriteAsyncResult)result.AsyncState;
            try
            {
                thisPtr.WriteCompleted(result);
            }
            catch (Exception e)
            {
                thisPtr.Complete(false, e);
            }
        }

        private void WriteCompleted(IAsyncResult result)
        {
            this._innerStream.EndWrite(result);
            this._progressStream.ReportBytesSent(this._count, this.AsyncState);
            this.Complete(result.CompletedSynchronously);
        }

        public static void End(IAsyncResult result)
        {
            AsyncResult.End<ProgressWriteAsyncResult>(result);
        }
    }
}
