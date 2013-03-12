// -----------------------------------------------------------------------------------------
// <copyright file="TestHelperBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Storage.Blob;

#if RTMD
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Microsoft.WindowsAzure.Storage
{
    public partial class TestHelper
    {
        /// <summary>
        /// Runs a given operation that is expected to throw an exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operation"></param>
        /// <param name="operationDescription"></param>
        internal static T ExpectedException<T>(Action operation, string operationDescription)
            where T : Exception
        {
            try
            {
                operation();
            }
            catch (T e)
            {
                return e;
            }
            catch (Exception ex)
            {
                T e = ex as T; // Test framework changes the value under debugger
                if (e != null)
                {
                    return e;
                }
                Assert.Fail("Invalid exception {0} for operation: {1}", ex.GetType(), operationDescription);
            }

            Assert.Fail("No exception received while while expecting {0}: {1}", typeof(T).ToString(), operationDescription);
            return null;
        }

        /// <summary>
        /// Runs a given operation that is expected to throw an exception.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDescription"></param>
        /// <param name="expectedStatusCode"></param>
        internal static void ExpectedException(Action<OperationContext> operation, string operationDescription, int expectedStatusCode)
        {
            OperationContext opContext = new OperationContext();
            try
            {
                operation(opContext);
            }
            catch (Exception)
            {
                Assert.AreEqual(expectedStatusCode, opContext.LastResult.HttpStatusCode, "Http status code is unexpected.");
                return;
            }

            Assert.Fail("No exception received while while expecting {0}: {1}", expectedStatusCode, operationDescription);
        }


        internal static void AssertNAttempts(OperationContext ctx, int n)
        {
            Assert.AreEqual(n, ctx.RequestResults.Count(), String.Format("Operation took more than {0} attempt(s) to complete", n));
        }

        /// <summary>
        /// Compares the streams from the start to current position.
        /// </summary>
        internal static void AssertStreamsAreEqual(Stream src, Stream dst)
        {
            Assert.AreEqual(src.Length, dst.Length);

            long origDstPosition = dst.Position;
            long origSrcPosition = src.Position;
            long originPosition = Math.Min(dst.Position, src.Position);
            dst.Position = 0;
            src.Position = 0;

            for (int i = 0; i < originPosition; i++)
            {
                Assert.AreEqual(src.ReadByte(), dst.ReadByte());
            }

            dst.Position = origDstPosition;
            src.Position = origSrcPosition;
        }

        /// <summary>
        /// Compares 2 streams given the starting position and length
        /// </summary>
        internal static void AssertStreamsAreEqualAtIndex(MemoryStream src, MemoryStream dst, int srcIndex, int dstIndex, int length)
        {
            byte[] origBuffer = src.ToArray();
            byte[] retrBuffer = dst.ToArray();

            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(origBuffer[srcIndex + i], retrBuffer[dstIndex + i]);
            }
        }

        /// <summary>
        /// Validates if this test supports the currnet target tenant. 
        /// Skips the current test if the target tenant is not supported. 
        /// </summary>
        public static void ValidateIfTestSupportTargetTenant(TenantType supportedTenantTypes)
        {
            if ((supportedTenantTypes & TestBase.CurrentTenantType) == 0)
            {
                Assert.Inconclusive("This test is skipped because the target test tenant is {0}.", TestBase.CurrentTenantType);
            }
        }

        /// <summary>
        /// Remove the local fiddler proxy from a URI.
        /// </summary>
        /// <param name="uri">The URI to change.</param>
        /// <returns>The URI without the local fiddler proxy.</returns>
        internal static Uri Defiddler(Uri uri)
        {
            string fiddlerString = "ipv4.fiddler";
            string replacementString = "127.0.0.1";

            string uriString = uri.AbsoluteUri;
            if (uriString.Contains(fiddlerString))
            {
                return new Uri(uriString.Replace(fiddlerString, replacementString));
            }
            else
            {
                return uri;
            }
        }

        /// <summary>
        /// Remove the local fiddler proxy from a blob reference.
        /// </summary>
        /// <param name="blob">The blob to change.</param>
        /// <returns>A blob reference without the local fiddler proxy.
        ///     If no fiddler proxy is present, the old blob reference is returned.</returns>
        internal static CloudBlockBlob Defiddler(CloudBlockBlob blob)
        {
            Uri oldUri = blob.Uri;
            Uri newUri = Defiddler(oldUri);

            if (newUri != oldUri)
            {
                return new CloudBlockBlob(newUri, blob.SnapshotTime, blob.ServiceClient.Credentials);
            }
            else
            {
                return blob;
            }
        }

        /// <summary>
        /// Remove the local fiddler proxy from a blob reference.
        /// </summary>
        /// <param name="blob">The blob to change.</param>
        /// <returns>A blob reference without the local fiddler proxy.
        ///     If no fiddler proxy is present, the old blob reference is returned.</returns>
        internal static CloudPageBlob Defiddler(CloudPageBlob blob)
        {
            Uri oldUri = blob.Uri;
            Uri newUri = Defiddler(oldUri);

            if (newUri != oldUri)
            {
                return new CloudPageBlob(newUri, blob.SnapshotTime, blob.ServiceClient.Credentials);
            }
            else
            {
                return blob;
            }
        }

        internal static void ValidateResponse(OperationContext opContext, int expectedAttempts, int expectedStatusCode, string[] allowedErrorCodes, string errorMessageBeginsWith)
        {
            ValidateResponse(opContext, expectedAttempts, expectedStatusCode, allowedErrorCodes, new string[] { errorMessageBeginsWith });
        }

        internal static void ValidateResponse(OperationContext opContext, int expectedAttempts, int expectedStatusCode, string[] allowedErrorCodes, string[] errorMessageBeginsWith)
        {
            ValidateResponse(opContext, expectedAttempts, expectedStatusCode, allowedErrorCodes, errorMessageBeginsWith, true);
        }

        internal static void ValidateResponse(OperationContext opContext, int expectedAttempts, int expectedStatusCode, string[] allowedErrorCodes, string[] errorMessageBeginsWith, bool stripIndex)
        {
            TestHelper.AssertNAttempts(opContext, 1);
            Assert.AreEqual(opContext.LastResult.HttpStatusCode, expectedStatusCode);
            Assert.IsTrue(allowedErrorCodes.Contains(opContext.LastResult.ExtendedErrorInformation.ErrorCode), "Unexpected Error Code, recieved" + opContext.LastResult.ExtendedErrorInformation.ErrorCode);

            if (errorMessageBeginsWith != null)
            {
                Assert.IsNotNull(opContext.LastResult.ExtendedErrorInformation.ErrorMessage);
                string message = opContext.LastResult.ExtendedErrorInformation.ErrorMessage;
                if (stripIndex)
                {
                    int semDex = opContext.LastResult.ExtendedErrorInformation.ErrorMessage.IndexOf(":");
                    semDex = semDex > 2 ? -1 : semDex;
                    message = message.Substring(semDex + 1);
                }

                Assert.IsTrue(errorMessageBeginsWith.Where((s) => message.StartsWith(s)).Count() > 0, opContext.LastResult.ExtendedErrorInformation.ErrorMessage);
            }
        }
    }
}
