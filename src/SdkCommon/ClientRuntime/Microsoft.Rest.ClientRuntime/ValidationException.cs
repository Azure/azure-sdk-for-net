// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Runtime.Serialization;
#if !PORTABLE
using System.Security.Permissions;
#endif

namespace Microsoft.Rest
{
    /// <summary>
    /// Validation exception for Microsoft Rest Client. 
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class ValidationException : RestException
    {
        /// <summary>
        /// Gets validation rule. 
        /// </summary>
        public string Rule { get; private set; }

        /// <summary>
        /// Gets validation target. 
        /// </summary>
        public string Target { get; private set; }

        /// <summary>
        /// Gets validation details.
        /// </summary>
        public object Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ValidationException(string message)
            : base(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        /// <param name="rule">Validation rule.</param>
        /// <param name="target">Target of the validation.</param>
        public ValidationException(string rule, string target)
            : base(string.Format(CultureInfo.InvariantCulture, "'{0}' {1}.", target, rule), null)
        {
            Rule = rule;
            Target = target;
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        /// <param name="rule">Validation rule.</param>
        /// <param name="target">Target of the validation.</param>
        /// <param name="details">Validation details.</param>
        public ValidationException(string rule, string target, object details)
            : base(string.Format(CultureInfo.InvariantCulture, "'{0}' {1} '{2}'.", target, rule, details), null)
        {
            Rule = rule;
            Target = target;
            Details = details;
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the ValidationException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Serializes content of the exception.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Rule", Rule);
            info.AddValue("Target", Target);
            info.AddValue("Details", Details);
        }
#endif
    }
}