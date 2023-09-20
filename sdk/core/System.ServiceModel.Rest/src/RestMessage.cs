// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;

namespace System.ServiceModel.Rest.Core
{
    public abstract class RestMessage : IDisposable
    {
        /// <summary>
        /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="RestMessage"/> processing.
        /// </summary>
        public CancellationToken CancellationToken { get; internal set; }

        public abstract Result Result { get; }

//        /// <summary>
//        /// The <see cref="ResponseClassifier"/> instance to use for response classification during pipeline invocation.
//        /// </summary>
//        public ResponseErrorClassifier ResponseClassifier { get; set; }

//        /// <summary>
//        /// TBD.
//        /// </summary>
//        public Result Result
//        {
//            get
//            {
//                if (_response == null)
//                {
//#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
//                    throw new InvalidOperationException("Response was not set, make sure SendAsync was called");
//#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
//                }
//                return _response;
//            }
//            set => _response = value;
//        }

        public abstract void Dispose();
    }
}
