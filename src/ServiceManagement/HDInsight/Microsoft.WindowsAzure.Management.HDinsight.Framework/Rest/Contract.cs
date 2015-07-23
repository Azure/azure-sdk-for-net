namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// A contracts class that mimics the functionality of <see cref="System.Diagnostics.Contracts"/>.
    /// </summary>
    internal static class Contract
    {
        /// <summary>
        /// Wrapper for the CodeContract Requries method.
        /// </summary>
        /// <typeparam name="T">Exception type to be thrown.</typeparam>
        /// <param name="condition">Whether the condition was true or false.</param>
        /// <param name="message">The message to be set in the exception.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Personal preference")]
        public static void Requires<T>(bool condition, string message = null) where T : Exception
        {
            if (!condition)
            {
                // Find the constructor that has a String param
                Type type = typeof(T);
                ConstructorInfo cinfo = type.GetConstructor(new Type[] { typeof(string) });
                if (cinfo == null)
                {
                    throw default(T);
                }

                throw (Exception)cinfo.Invoke(new object[] { message ?? "Requires condition failed." });
            }
        }

        /// <summary>
        /// Assumes the specified condition.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> [condition].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.IO.InvalidDataException">Thrown when <paramref name="condition"/> is false.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Personal Preference")]
        public static void Assume(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new InvalidDataException(message ?? "Contract.Assume failure");
            }
        }

        /// <summary>
        /// Asserts the specified condition.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> [condition].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.IO.InvalidDataException">Thrown when the condition is failed.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Preference")]
        public static void Assert(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new InvalidDataException(message ?? "Contract.Assert failure");
            }
        }

        /// <summary>
        /// Asserts the not null.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void AssertNotNull(object arg, string message)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Asserts the arg not null.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <param name="argName">The argName.</param>
        /// <exception cref="System.ArgumentNullException">When arg is null.</exception>
        public static void AssertArgNotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        /// <summary>
        /// Asserts the arg not null or empty.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <param name="argname">The argName.</param>
        /// <exception cref="System.ArgumentNullException">When arg is null or empty.</exception>
        /// <exception cref="System.ArgumentException">Argument cannot be empty</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Personal preference", MessageId = "argName")]
        public static void AssertArgNotNullOrEmpty(string arg, string argname)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argname);
            }

            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentException("Argument cannot be empty", argname);
            }
        }
    }
}
