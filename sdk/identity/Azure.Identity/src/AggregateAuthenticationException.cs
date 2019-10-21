// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// An exception which is raised when multiple <see cref="TokenCredential"/> fail to authenticate, such as when invoked by the <see cref="ChainedTokenCredential"/> or the <see cref="DefaultAzureCredential"/>
    /// </summary>
    internal class AggregateAuthenticationException : AuthenticationFailedException
    {
        private readonly ReadOnlyMemory<object> _credentials;
        private readonly ReadOnlyMemory<Exception> _innerExceptions;

        internal AggregateAuthenticationException(string message, ReadOnlyMemory<object> credentials, ReadOnlyMemory<Exception> innerExceptions)
            : base(message, new AggregateException(message, innerExceptions.ToArray()))
        {
            _credentials = credentials;
            _innerExceptions = innerExceptions;
        }

        /// <inheritdocs/>
        public override string ToString()
        {
            StringBuilder exStr = new StringBuilder(base.ToString());

            exStr.Append(Environment.NewLine).Append("INNER EXEPTIONS:").Append(Environment.NewLine);

            for (int i = 0; i < _credentials.Length; i++)
            {
                exStr.Append(_credentials.Span[i].GetType().Name).Append(" Failed: ").Append(_innerExceptions.Span[i].Message).Append(Environment.NewLine);
            }

            return exStr.ToString();
        }
    }
}
