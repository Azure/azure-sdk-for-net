// -----------------------------------------------------------------------------------------
// <copyright file="TestHelper.Common.cs" company="Microsoft">
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

using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

#if WINDOWS_DESKTOP
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
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

#if TASK
        internal static void AssertCancellation(OperationContext ctx)
        {
            TestHelper.AssertNAttempts(ctx, 1);
            Assert.IsInstanceOfType(ctx.LastResult.Exception, typeof(StorageException));
            Assert.AreEqual("Operation was canceled by user.", ctx.LastResult.Exception.Message);
            Assert.AreEqual((int)HttpStatusCode.Unused, ((StorageException)ctx.LastResult.Exception).RequestInformation.HttpStatusCode);
            Assert.AreEqual("Unused", ((StorageException)ctx.LastResult.Exception).RequestInformation.HttpStatusMessage);
        }

        /// <summary>
        /// Runs a given operation that is expected to throw an exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operation"></param>
        /// <param name="operationDescription"></param>
        internal static T ExpectedExceptionTask<T>(Task operation, string operationDescription)
            where T : Exception
        {
            try
            {
                operation.Wait();
            }
            catch (AggregateException ex)
            {
                ex = ex.Flatten();
                if (ex.InnerExceptions.Count > 1)
                {
                    Assert.Fail("Multiple exceptions {0} for operation: {1}", ex.GetType(), operationDescription);
                }
                
                T e = ex.InnerException as T; // Test framework changes the value under debugger
                if (e != null)
                {
                    Assert.IsTrue(operation.IsCompleted);
                    if (ex.InnerException is OperationCanceledException)
                    {
                        Assert.IsTrue(operation.IsCanceled);
                        Assert.IsFalse(operation.IsFaulted);
                        Assert.AreEqual(TaskStatus.Canceled, operation.Status);
                    }
                    else
                    {
                        Assert.IsFalse(operation.IsCanceled);
                        Assert.IsTrue(operation.IsFaulted);
                        Assert.AreEqual(TaskStatus.Faulted, operation.Status);
                    }

                    return e;
                }
                Assert.Fail("Invalid exception {0} for operation: {1}", ex.GetType(), operationDescription);
            }
            catch (Exception ex)
            {
                Assert.Fail("Invalid exception {0} for operation: {1}", ex.GetType(), operationDescription);
            }

            Assert.Fail("No exception received while while expecting {0}: {1}", typeof(T).ToString(), operationDescription);
            return null;
        }
#endif

        /// <summary>
        /// Compares two streams.
        /// </summary>
        internal static void AssertStreamsAreEqual(Stream src, Stream dst)
        {
            Assert.AreEqual(src.Length, dst.Length);

            long origDstPosition = dst.Position;
            long origSrcPosition = src.Position;

            dst.Position = 0;
            src.Position = 0;

            for (int i = 0; i < src.Length; i++)
            {
                Assert.AreEqual(src.ReadByte(), dst.ReadByte());
            }

            dst.Position = origDstPosition;
            src.Position = origSrcPosition;
        }

        /// <summary>
        /// Compares two streams from the starting positions and up to length bytes.
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
        /// Compares two byte buffers.
        /// </summary>
        internal static void AssertBuffersAreEqual(byte[] src, byte[] dst)
        {
            Assert.AreEqual(src.Length, dst.Length);

            for (int i = 0; i < src.Length; i++)
            {
                Assert.AreEqual(src[i], dst[i]);
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
