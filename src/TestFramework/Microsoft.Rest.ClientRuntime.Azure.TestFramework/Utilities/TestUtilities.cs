// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Simply function determining retry policy - retry on any internal server error
        /// </summary>
        public static Func<HttpStatusCode, bool> RetryOnHttp500 = (s => HttpStatusCode.InternalServerError == s);

        /// <summary>
        /// Generate a name to be used in azure
        /// </summary>
        /// <returns></returns>
        public static string GenerateName(string prefix = "azsmnet",
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="testframework_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }

        /// <summary>
        /// Generate a name to be used in azure
        /// </summary>
        /// <returns></returns>
        public static Guid GenerateGuid([System.Runtime.CompilerServices.CallerMemberName]
            string methodName="testframework_failed")
        {
            return HttpMockServer.GetAssetGuid(methodName);
        }

    /// <summary>
    /// Used for mthod traces - format method arguments as a string for output or tracing
    /// </summary>
    /// <param name="parameters">A dictionary representing the parameters of a method call</param>
    /// <returns>A string representation of the parameters</returns>
    public static string AsFormattedString(this IDictionary<string, object> parameters)
        {
            StringBuilder builder = new StringBuilder("(");
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Keys.Count; ++i)
                {
                    string key = parameters.Keys.ElementAt(i);
                    object value = parameters[key];
                    builder.AppendFormat("{0}:{1}", key, value);
                    if (i < parameters.Keys.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
            }

            builder.Append(")");
            return builder.ToString();
        }
        
        /// <summary>
        /// Wait for the specified number of milliseconds unless we are in mock playback mode
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait</param>
        public static void Wait(int milliseconds)
        {
            Wait(TimeSpan.FromMilliseconds(milliseconds));
        }

        /// <summary>
        /// Wait for the specified span unless we are in mock playback mode
        /// </summary>
        /// <param name="timeout">The span of time to wait for</param>
        public static void Wait(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        /// <summary>
        /// Get the method name of the calling method
        /// </summary>
        /// <returns>The name of the declaring method</returns>
        public static string GetCurrentMethodName([System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed_to_get_current_method_anem")
        {
            return methodName;
        }
#if NET45
        /// <summary> 
        /// Get the method name of the calling method 
        /// </summary> 
        /// <param name="index">How deep into the strack trace to look - here we want the caller's caller.</param> 
        /// <returns>The name of the declaring method</returns> 
        [MethodImpl(MethodImplOptions.NoInlining)] 
        public static string GetCurrentMethodName(int index = 1)
        { 
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(index); 
 

            return sf.GetMethod().Name; 
        } 
 
        /// <summary> 
        /// Get the typename of the callling class 
        /// </summary> 
        /// <param name="index">How deep into the strack trace to look - here we want the caller's caller.</param> 
        /// <returns>The name of the declaring type</returns> 
        [MethodImpl(MethodImplOptions.NoInlining)] 
        public static string GetCallingClass(int index = 1)
        { 
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(index); 
 

            return sf.GetMethod().ReflectedType.ToString(); 
        } 
#endif  
        /// <summary>
        /// Break up the connection string into key-value pairs
        /// </summary>
        /// <param name="connectionString">The connection string to parse</param>
        /// <returns>A dictionary of keys and values from the connection string</returns>
        public static IDictionary<string, string> ParseConnectionString(string connectionString)
        {
            // Temporary connection string parser.  We should replace with more robust one
            IDictionary<string, string> settings = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(connectionString))
            {
                string[] pairs = connectionString.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    foreach (string pair in pairs)
                    {
                        string[] keyValue = pair.Split(new char[] {'='}, 2);
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();
                        settings[key] = value;
                    }

                }
                catch (NullReferenceException ex)
                {
                    throw new ArgumentException(
                        string.Format("Connection string \"{0}\" is invalid", connectionString),
                        "connectionString", ex);
                }
            }
            return settings;
        }
    }
}
