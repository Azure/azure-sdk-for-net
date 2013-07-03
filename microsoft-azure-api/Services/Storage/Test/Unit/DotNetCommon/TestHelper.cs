// -----------------------------------------------------------------------------------------
// <copyright file="TestHelper.cs" company="Microsoft">
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

#if !WINDOWS_PHONE
using Fiddler;
using Microsoft.WindowsAzure.Test.Network;
#endif

#if WINDOWS_PHONE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage
{
    public partial class TestHelper
    {
        /// <summary>
        /// Runs a given operation that is expected to throw an exception.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDescription"></param>
        /// <param name="expectedStatusCode"></param>
        internal static void ExpectedException(Action operation, string operationDescription, HttpStatusCode expectedStatusCode, string requestErrorCode = null)
        {
            try
            {
                operation();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual((int)expectedStatusCode, ex.RequestInformation.HttpStatusCode, "Http status code is unexpected.");
                if (!string.IsNullOrEmpty(requestErrorCode))
                {
                    Assert.IsNotNull(ex.RequestInformation.ExtendedErrorInformation);
                    Assert.AreEqual(requestErrorCode, ex.RequestInformation.ExtendedErrorInformation.ErrorCode);
                }
                return;
            }

            Assert.Fail("No exception received while while expecting {0}: {1}", expectedStatusCode, operationDescription);
        }

#if TASK
        /// <summary>
        /// Runs a given operation that is expected to throw an exception.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDescription"></param>
        /// <param name="expectedStatusCode"></param>
        internal static void ExpectedExceptionTask(Task operation, string operationDescription, HttpStatusCode expectedStatusCode, string requestErrorCode = null)
        {
            try
            {
                operation.Wait();
            }
            catch (AggregateException e)
            {
                e = e.Flatten();
                if (e.InnerExceptions.Count > 1)
                {
                    Assert.Fail("Multiple exception received while while expecting {0}: {1}", expectedStatusCode, operationDescription);
                }

                StorageException ex = e.InnerException as StorageException;
                if (ex == null)
                {
                    throw e.InnerException;
                }

                Assert.AreEqual((int)expectedStatusCode, ex.RequestInformation.HttpStatusCode, "Http status code is unexpected.");
                if (!string.IsNullOrEmpty(requestErrorCode))
                {
                    Assert.IsNotNull(ex.RequestInformation.ExtendedErrorInformation);
                    Assert.AreEqual(requestErrorCode, ex.RequestInformation.ExtendedErrorInformation.ErrorCode);
                }
                return;
            }

            Assert.Fail("No exception received while while expecting {0}: {1}", expectedStatusCode, operationDescription);
        }
#endif

#if !WINDOWS_PHONE
        internal static void ExecuteAPMMethodWithCancellation(int cancellationDelayInMS,
          ProxyBehavior[] behaviors,
          Func<IRequestOptions,
          OperationContext,
          AsyncCallback,
          object,
          ICancellableAsyncResult> begin,
          Action<IAsyncResult> end)
        {
            ExecuteAPMMethodWithCancellation<bool>(cancellationDelayInMS,
                behaviors,
                begin,
                (res) =>
                {
                    end(res);
                    return true;
                });
        }

        internal static void ExecuteAPMMethodWithCancellation<T>(int cancellationDelayInMS,
            ProxyBehavior[] behaviors,
            Func<IRequestOptions,
            OperationContext,
            AsyncCallback,
            object,
            ICancellableAsyncResult> begin,
            Func<IAsyncResult, T> end)
        {
            string failMessage = null;
            StorageException storageException = null;
            OperationContext opContext = new OperationContext();

            using (HttpMangler proxy = new HttpMangler(false, behaviors))
            {
                Debug.WriteLine("Begin");
                using (ManualResetEvent completedEvent = new ManualResetEvent(false))
                {
                    ICancellableAsyncResult saveResult = begin(null
                        , opContext,
                        (resp) =>
                        {
                            try
                            {
                                end(resp);
                                failMessage = "Request succeeded even after cancellation";
                            }
                            catch (StorageException ex)
                            {
                                storageException = ex;
                            }
                            catch (Exception badEx)
                            {
                                failMessage = badEx.ToString();
                            }
                            finally
                            {
                                completedEvent.Set();
                            }
                        },
                    null);

                    Thread.Sleep(cancellationDelayInMS);
                    Debug.WriteLine("Cancelling Request");
                    saveResult.Cancel();

                    completedEvent.WaitOne();
                    TestHelper.AssertNAttempts(opContext, 1);
                }
            }

            // Do not use IsNull here so that test result contains failMessage
            Assert.AreEqual(null, failMessage);

            Assert.IsNotNull(storageException);
            Assert.AreEqual("Operation was canceled by user.", storageException.Message);
            Assert.AreEqual(306, storageException.RequestInformation.HttpStatusCode);
            Assert.AreEqual("Unused", storageException.RequestInformation.HttpStatusMessage);
        }

        internal static void ExecuteAPMMethodWithRetry<T>(int ExpectedAttempts,
         ProxyBehavior[] behaviors,
         Func<IRequestOptions, OperationContext, AsyncCallback, object, ICancellableAsyncResult> begin,
         Func<IAsyncResult, T> end)
        {
            string failMessage = null;
            OperationContext opContext = new OperationContext();

            using (HttpMangler proxy = new HttpMangler(false, behaviors))
            {
                Debug.WriteLine("Begin");
                using (ManualResetEvent completedEvent = new ManualResetEvent(false))
                {
                    ICancellableAsyncResult saveResult = begin(null
                        , opContext,
                        (resp) =>
                        {
                            try
                            {
                                Debug.WriteLine("End");
                                end(resp);
                            }
                            catch (Exception badEx)
                            {
                                failMessage = badEx.ToString();
                            }
                            finally
                            {
                                completedEvent.Set();
                            }
                        },
                    null);

                    completedEvent.WaitOne();
                    TestHelper.AssertNAttempts(opContext, ExpectedAttempts);
                }
            }

            // Do not use IsNull here so that test result contains failMessage
            Assert.AreEqual(null, failMessage);
        }

#if TASK
        internal static void ExecuteTaskMethodWithRetry<T>(int ExpectedAttempts,
        ProxyBehavior[] behaviors,
        Func<IRequestOptions, OperationContext, Task<T>> method)
        {
            OperationContext opContext = new OperationContext();

            using (HttpMangler proxy = new HttpMangler(false, behaviors))
            {
                method(null, opContext).Wait();
                TestHelper.AssertNAttempts(opContext, ExpectedAttempts);
            }
        }
#endif

        internal static void ExecuteMethodWithRetry<T>(int ExpectedAttempts,
        ProxyBehavior[] behaviors,
        Func<IRequestOptions, OperationContext, T> method)
        {
            OperationContext opContext = new OperationContext();

            using (HttpMangler proxy = new HttpMangler(false, behaviors))
            {
                method(null, opContext);
                TestHelper.AssertNAttempts(opContext, ExpectedAttempts);
            }
        }

        internal static void ExecuteMethodWithRetryInTryFinally<T>(int ExpectedAttempts,
        ProxyBehavior[] behaviors,
        Func<IRequestOptions, OperationContext, T> method)
        {
            OperationContext opContext = new OperationContext();

            using (HttpMangler proxy = new HttpMangler(false, behaviors))
            {
                try
                {
                    method(null, opContext);
                }
                finally
                {
                    TestHelper.AssertNAttempts(opContext, ExpectedAttempts);
                }
            }
        }

        internal static void VerifyHeaderWasSent(string headerName, string headerValue, Func<Session, bool> selector, Action act)
        {
            string retrievedHeaderValue = null;
            using (HttpMangler proxy = new HttpMangler(false, new ProxyBehavior[]{ new ProxyBehavior(session =>
                {
                    retrievedHeaderValue = session.oRequest.headers[headerName];
                }, selector, null, TriggerType.BeforeRequest)}))
            {
                act();
            }

            Assert.AreEqual(headerValue, retrievedHeaderValue);
        }
#endif
    }
}
