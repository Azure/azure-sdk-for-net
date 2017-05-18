// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Base class representing an exception that occurs when
    /// authenticating against Azure Active Directory
    /// </summary>
    [Serializable]
    public abstract class AadAuthenticationException : Exception
    {
        protected AadAuthenticationException()
        {
        }

        protected AadAuthenticationException(string message) : base(message)
        {
        }

        protected AadAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception that gets thrown when the user explicitly
    /// cancels an authentication operation.
    /// </summary>
    [Serializable]
    public class AadAuthenticationCanceledException : AadAuthenticationException
    {
        public AadAuthenticationCanceledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception that gets thrown when the ADAL library
    /// is unable to authenticate without a popup dialog.
    /// </summary>
    [Serializable]
    public class AadAuthenticationFailedWithoutPopupException : AadAuthenticationException
    {
        public AadAuthenticationFailedWithoutPopupException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception that gets thrown if an authentication operation
    /// fails on the server.
    /// </summary>
    [Serializable]
    public class AadAuthenticationFailedException : AadAuthenticationException
    {
        public AadAuthenticationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception thrown if a refresh token has expired.
    /// </summary>
    [Serializable]
    public class AadAuthenticationCantRenewException : AadAuthenticationException
    {
        public AadAuthenticationCantRenewException()
        {
        }

        public AadAuthenticationCantRenewException(string message) : base(message)
        {
        }

        public AadAuthenticationCantRenewException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}