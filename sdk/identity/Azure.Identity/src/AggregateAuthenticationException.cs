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

        internal AggregateAuthenticationException(string message, ReadOnlyMemory<object> credentials, ReadOnlyMemory<Exception> innerExceptions)
            : base(BuildMessage(message, credentials, innerExceptions), new AggregateException(message, innerExceptions.ToArray()))
        {
        }

        private static string BuildMessage(string message, ReadOnlyMemory<object> credentials, ReadOnlyMemory<Exception> innerExceptions)
        {
            StringBuilder exStr = new StringBuilder(message);

            for (int i = 0; i < credentials.Length; i++)
            {
                exStr.Append(credentials.Span[i].GetType().Name).Append(" Failed: ").Append(innerExceptions.Span[i].Message).Append(Environment.NewLine);
            }

            return exStr.ToString();
        }
    }
}
