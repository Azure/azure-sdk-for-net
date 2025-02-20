// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Uncomment if you want to avoid wrapping inner exceptions
// #define DO_NOT_WRAP_EXCEPTIONS

using System;
#if DO_NOT_WRAP_EXCEPTIONS
using System.Diagnostics;
#endif
using System.Text;

namespace Azure.Provisioning.Generator;

/// <summary>
/// Processing large object graphs can often lead to confusing and/or
/// unhelpful exception messages because an ArgumentNullException deep
/// in a recursive call without parameter values can be meaningless.
/// 
/// ContextualException is used by the static WithContext method that
/// allows you to wrap any exception with helpful context to make the
/// error more discoverable.  If multiple WithContext calls are
/// triggered as an exception unwinds, they'll keep appending their
/// context to the same ContextualException to prevent a hierarchy of
/// useless InnerExceptions.
/// </summary>
/// <param name="context">Additional error context.</param>
/// <param name="message">The exception message.</param>
/// <param name="innerException">An inner exception.</param>
internal class ContextualException(string context, string message, Exception innerException) :
    InvalidOperationException(message, innerException)
{
    /// <summary>
    /// The additional error context.
    /// </summary>
    private string _context = $"{context}{Environment.NewLine}";

    /// <summary>
    /// Gets the original exception message, prefixed by our additional
    /// error context.
    /// </summary>
    /// <value>The message.</value>
    public override string Message
    {
        get
        {
            StringBuilder message = new(_context.Length + base.Message.Length);
            message.Append(_context).Append(base.Message);
            if (InnerException != null)
            {
                message.Append(Environment.NewLine).Append(Environment.NewLine).Append(base.InnerException);
            }
            return message.ToString();
        }
    }

    /// <summary>
    /// Add contextual error information to the exception.
    /// </summary>
    /// <param name="context">Additional error context.</param>
    public void AddContext(string context) =>
        _context = $"{context}{Environment.NewLine}{_context}";

    /// <summary>
    /// Wrap any exceptions raised in the action with additional context.
    /// 
    /// Processing large object graphs can often lead to confusing and/or
    /// unhelpful exception messages because an ArgumentNullException deep
    /// in a recursive call without parameter values can be meaningless.
    /// This helper allows you to wrap any exception with helpful context to
    /// make the error more discoverable.  If multiple WithContext calls
    /// are triggered as an exception bubbles outward, they'll keep
    /// appending their context to the same exception wrapper to prevent a
    /// hierarchy of useless InnerExceptions.
    /// </summary>
    /// <param name="context">Additional error context.</param>
    /// <param name="action">The action to invoke.</param>
    public static void WithContext(string context, Action action)
    {
        try
        {
            action();
        }
        catch (ContextualException ex)
        {
            // If an ErrorContext call already wrapped an exception deeper
            // in the callstack, just tack this context onto that exception
            // and rethrow (without altering the callstack).
            ex.AddContext(context);
            throw;
        }
        catch (Exception ex)
        {
            // Don't interfere with how the exception is raised if we're debugging
#if DO_NOT_WRAP_EXCEPTIONS
            if (!Debugger.IsAttached)
#endif
            {
                // Wrap the original exception with the additional context
                throw new ContextualException(
                    context,
                    $"{ex.GetType().FullName}: {ex.Message}",
                    ex);
            }
#if DO_NOT_WRAP_EXCEPTIONS
            else
            {
                if (ex.Data.Contains("ErrorContext"))
                {
                    context = $"{context}{Environment.NewLine}{ex.Data["ErrorContext"]}";
                }
                ex.Data["ErrorContext"] = context;
                throw;
            }
#endif
        }
    }
}
