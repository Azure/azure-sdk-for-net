//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Azure.Management.DataFactories
{
    internal static class Ensure
    {
#if PORTABLE

        public static void IsNotNull<T>(T value, string name, string msg = null)
        {
            if (value == null)
            {
                if (msg == null)
                {
                    msg = string.Format(CultureInfo.InvariantCulture, "'{0}' may not be null", name);
                }

                throw new ArgumentNullException(name, msg);
            }
        }

        public static void IsNotNullOrEmpty(string value, string name, string msg = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (msg == null)
                {
                    msg = string.Format(CultureInfo.InvariantCulture, "'{0}' may not be null or empty", name);
                }

                throw new ArgumentException(name, msg);
            }
        }
#else
        public static void IsNotNull<T>(T value, string name, string msg = null)
        {
            if (value == null)
            {
                string method = GetFirstForeignMethodOnStack();
                if (msg == null)
                {
                    msg = string.Format(CultureInfo.InvariantCulture, "'{0}' may not be null in {1}", name, method);
                }

                throw new ArgumentNullException(name, msg);
            }
        }

        public static void IsNotNullOrEmpty(string value, string name, string msg = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                string method = GetFirstForeignMethodOnStack();
                if (msg == null)
                {
                    msg = string.Format(CultureInfo.InvariantCulture, "'{0}' may not be null or empty in {1}", name, method);
                }

                throw new ArgumentException(name, msg);
            }
        }
#endif

        public static void IsNotNullOperationException<T>(T value, string name)
        {
            if (value == null)
            {
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "'{0}' may not be null. Something went wrong getting the server response.",
                    name);

                throw new InvalidOperationException(msg);
            }
        }

        public static void IsNotNullNoStackTrace(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            } 
        }

#if !PORTABLE

        /// <summary>
        /// Crawls the current call stack and retrieves the name of the first "foreign" method.
        /// A method is considered foreign if it's not part of this class.
        /// </summary>
        /// <param name="stackFramesToSkip">The stack frames to skip.</param>
        /// <returns>The name of the first foreign method on the call stack.</returns>
        private static string GetFirstForeignMethodOnStack(int stackFramesToSkip = 2)
        {
            string ret = string.Empty;

            // 5: Reasonable upper limit so that we won't work too hard
            for (int framesToSkip = stackFramesToSkip + 1; framesToSkip < stackFramesToSkip + 5; framesToSkip++)
            {
                StackFrame callPoint = new StackFrame(framesToSkip, true);
                if (callPoint.GetMethod() == null)
                {
                    // reached the end of the call stack
                    break;
                }

                string callPointMethod = GetFullyQualifiedMemberName(callPoint.GetMethod());
                ret = "method '" + callPointMethod + "' (" + callPoint + ")";

                if (!callPointMethod.Contains("Microsoft.Azure.Management.DataFactories.Ensure"))
                {
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Given a member reference, find its fully qualified name (assembly, class, member)
        /// </summary>
        /// <param name="member">The member whose name is desired</param>
        /// <returns>The fully qualified member name, including assembly, namespace, class, and member</returns>
        private static string GetFullyQualifiedMemberName(MemberInfo member)
        {
            Type type = member.DeclaringType;

            string ret = string.Format(
                CultureInfo.InvariantCulture,
                "{0}!{1}.{2}",
                type.Assembly.ManifestModule.Name,
                type.FullName,
                member.Name);

            return ret;
        }
#endif
    }
}
