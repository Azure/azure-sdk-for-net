// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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