// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a set of extension over the Exception class.
    /// </summary>
#if Non_Public_SDK
    public static class ExceptionExtensions
#else
    internal static class ExceptionExtensions
#endif
    {
        /// <summary>
        /// Gets the first usable exception for this exception.
        /// This method undoes Target Invoke, Aggregate Exception and
        /// Task Canceled Exceptions.
        /// </summary>
        /// <param name="ex">
        /// The exception to be converted.
        /// </param>
        /// <returns>
        /// The first "non wrapping" exception that can be found based 
        /// on unwrapping rules.
        /// </returns>
        public static Exception GetFirstException(this Exception ex)
        {
            var asAgg = ex as AggregateException;
            if (asAgg.IsNotNull())
            {
                var exs = asAgg.Flatten();
                if (exs.InnerException.IsNotNull())
                {
                    return exs.InnerException.GetFirstException();
                }
            }
            var asTargetOfInvoke = ex as TargetInvocationException;
            if (asTargetOfInvoke.IsNotNull())
            {
                return asTargetOfInvoke.InnerException.GetFirstException();
            }
            var asTaskCancel = ex as TaskCanceledException;
            if (asTaskCancel.IsNotNull())
            {
                if (asTaskCancel.InnerException.IsNotNull())
                {
                    return asTaskCancel.InnerException.GetFirstException();
                }
            }
            return ex;
        }

        /// <summary>
        /// Rethrows an exception based on unwrapping rules.
        /// </summary>
        /// <param name="ex">
        /// The exception to rethrow.
        /// </param>
        public static void Rethrow(this Exception ex)
        {
            var newEx = ex.GetFirstException();
            typeof(Exception).GetMethod("PrepForRemoting", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(newEx, new object[0]);
            throw newEx;
        }
    }
}
