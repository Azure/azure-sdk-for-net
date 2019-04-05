[1mdiff --git a/src/SDKs/ServiceBus/data-plane/tests/Microsoft.Azure.ServiceBus.Tests/Infrastructure.Tests/TaskExtensionTests.cs b/src/SDKs/ServiceBus/data-plane/tests/Microsoft.Azure.ServiceBus.Tests/Infrastructure.Tests/TaskExtensionTests.cs[m
[1mindex 2a6bd1103..713ac5eef 100755[m
[1m--- a/src/SDKs/ServiceBus/data-plane/tests/Microsoft.Azure.ServiceBus.Tests/Infrastructure.Tests/TaskExtensionTests.cs[m
[1m+++ b/src/SDKs/ServiceBus/data-plane/tests/Microsoft.Azure.ServiceBus.Tests/Infrastructure.Tests/TaskExtensionTests.cs[m
[36m@@ -1,4 +1,5 @@[m
 ﻿using System;[m
[32m+[m[32musing System.Diagnostics;[m
 using System.Threading;[m
 using System.Threading.Tasks;[m
 using Xunit;[m
[36m@@ -7,12 +8,19 @@[m [mnamespace Microsoft.Azure.ServiceBus.UnitTests[m
 {[m
     public class TaskExtensionsTests[m
     {  [m
[32m+[m[32m        // It has been observed during the CI build that test runs can cause delays that were noted at[m[41m [m
[32m+[m[32m        // 1-2 seconds and were causing intermitten failures as a result.  The long delay has been set at 5[m[41m [m
[32m+[m[32m        // seconds arbitrarily, which may delay results should tests fail but is otherwise not expected to[m[41m [m
[32m+[m[32m        // be an actual wait time under normal circumstances.[m
[32m+[m[32m        private readonly TimeSpan LongDelay = TimeSpan.FromSeconds(5);[m
[32m+[m[32m        private readonly TimeSpan TinyDelay = TimeSpan.FromMilliseconds(1);[m
[32m+[m
         [Fact][m
         public void WithTimeoutThrowsWhenATimeoutOccursAndNoActionIsSpecified()[m
         {[m
             Func<Task> actionUnderTest = async () =>  [m
[31m-                await Task.Delay(1000)[m
[31m-                    .WithTimeout(TimeSpan.FromMilliseconds(1));[m
[32m+[m[32m                await Task.Delay(LongDelay)[m
[32m+[m[32m                    .WithTimeout(TinyDelay);[m
               [m
             Assert.ThrowsAsync<TimeoutException>(actionUnderTest);[m
         }[m
[36m@@ -24,7 +32,7 @@[m [mpublic async Task WithTimeoutExecutesTheTimeoutActionWhenATimeoutOccurs()[m
 [m
             Action timeoutAction = () => { timeoutActionInvoked = true; };[m
             [m
[31m-            await Task.Delay(1000).WithTimeout(TimeSpan.FromMilliseconds(1), null, timeoutAction);[m
[32m+[m[32m            await Task.Delay(LongDelay).WithTimeout(TinyDelay, null, timeoutAction);[m
             Assert.True(timeoutActionInvoked, "The timeout action should have been invoked.");[m
         }[m
 [m
[36m@@ -32,9 +40,9 @@[m [mpublic async Task WithTimeoutExecutesTheTimeoutActionWhenATimeoutOccurs()[m
         public async Task WithTimeoutGenericThrowsWhenATimeoutOccursAndNoActionIsSpecified()[m
         {[m
             Func<Task> actionUnderTest = async () => [m
[31m-                await Task.Delay(1000)[m
[32m+[m[32m                await Task.Delay(LongDelay)[m
                     .ContinueWith( _ => "blue")[m
[31m-                    .WithTimeout(TimeSpan.FromMilliseconds(1));[m
[32m+[m[32m                    .WithTimeout(TinyDelay);[m
 [m
             await Assert.ThrowsAsync<TimeoutException>(actionUnderTest);[m
         }[m
[36m@@ -51,9 +59,9 @@[m [mpublic async Task WithTimeoutGeneticExecutesTheTimeoutCallbackWhenATimeoutOccurs[m
                 return expectedResult;[m
             };[m
 [m
[31m-            var result = await Task.Delay(1000)[m
[32m+[m[32m            var result = await Task.Delay(LongDelay)[m
                 .ContinueWith( _ => "blue")[m
[31m-                .WithTimeout(TimeSpan.FromMilliseconds(1), null, timeoutCallback);[m
[32m+[m[32m                .WithTimeout(TinyDelay, null, timeoutCallback);[m
 [m
             Assert.True(timeoutActionInvoked, "The timeout action should have been invoked.");[m
             Assert.Equal(expectedResult, result);[m
[36m@@ -66,7 +74,7 @@[m [mpublic async Task WithTimeoutDoesNotThrowWhenATimeoutDoesNotOccur()[m
 [m
             try[m
             {[m
[31m-                await Task.Delay(1).WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m                await Task.Delay(TinyDelay).WithTimeout(LongDelay);[m
             }[m
             catch (TimeoutException)[m
             {[m
[36m@@ -80,24 +88,26 @@[m [mpublic async Task WithTimeoutDoesNotThrowWhenATimeoutDoesNotOccur()[m
         public async Task WithTimeoutGenericDoesNotThrowsWhenATimeoutDoesNotOccur()[m
         {[m
             var exceptionObserved = false;[m
[32m+[m[32m            var sw = Stopwatch.StartNew();[m
                         [m
             try[m
             {[m
[31m-                await Task.Delay(1).ContinueWith( _ => "blue").WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[31m-            }[m
[32m+[m[32m                await Task.Delay(TinyDelay).ContinueWith( _ => "blue").WithTimeout(LongDelay);            }[m
             catch (TimeoutException)[m
             {[m
[32m+[m[32m                sw.Stop();[m
                 exceptionObserved = true;[m
             }[m
 [m
[31m-            Assert.False(exceptionObserved, "There should not have been a timeout exception thrown.");[m
[32m+[m[32m            try { sw.Stop(); } catch {}[m
[32m+[m[32m            Assert.False(exceptionObserved, $"There should not have been a timeout exception thrown. Elapsed: [{ sw.Elapsed.ToString("") }]");[m
         }[m
 [m
         [Fact][m
         public async Task WithTimeoutGenericReturnsTheValueWhenATimeoutDoesNotOccur()[m
         {[m
             var expected = "hello";[m
[31m-            var result = await  Task.Delay(1).ContinueWith( _ => expected).WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m            var result = await  Task.Delay(TinyDelay).ContinueWith( _ => expected).WithTimeout(LongDelay);[m
             Assert.Equal(result, expected);[m
         }[m
 [m
[36m@@ -107,7 +117,7 @@[m [mpublic async Task WithTimeoutPropagatesAnExceptionForACompletedTask()[m
             var completionSource = new TaskCompletionSource<object>();[m
             completionSource.SetException(new MissingFieldException("oops"));[m
 [m
[31m-            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(LongDelay);[m
             await Assert.ThrowsAsync<MissingFieldException>(actionUnderTest);[m
         }[m
 [m
[36m@@ -115,9 +125,9 @@[m [mpublic async Task WithTimeoutPropagatesAnExceptionForACompletedTask()[m
         public async Task WithTimeoutPropagatesAnExceptionThatCompletesBeforeTimeout()[m
         {[m
             Func<Task> actionUnderTest = async () => [m
[31m-                await Task.Delay(1)[m
[32m+[m[32m                await Task.Delay(TinyDelay)[m
                     .ContinueWith( _ => throw new MissingMemberException("oh no"))[m
[31m-                    .WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m                    .WithTimeout(LongDelay);[m
 [m
             await Assert.ThrowsAsync<MissingMemberException>(actionUnderTest);[m
         }[m
[36m@@ -126,9 +136,9 @@[m [mawait Task.Delay(1)[m
         public async Task WithTimeoutGenericPropagatesAnExceptionThatCompletesBeforeTimeout()[m
         {[m
            Func<Task> actionUnderTest = async () => [m
[31m-               await Task.Delay(1)[m
[32m+[m[32m               await Task.Delay(TinyDelay)[m
                    .ContinueWith<string>( _ => throw new MissingMemberException("oh no"))[m
[31m-                   .WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m                   .WithTimeout(LongDelay);[m
 [m
             await Assert.ThrowsAsync<MissingMemberException>(actionUnderTest);[m
         }[m
[36m@@ -139,7 +149,7 @@[m [mpublic async Task WithTimeoutPropagatesACancelledTask()[m
             var completionSource = new TaskCompletionSource<object>();[m
             completionSource.SetCanceled();[m
 [m
[31m-            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(TimeSpan.FromMilliseconds(1000));[m
[32m+[m[32m            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(LongDelay);[m
             await Assert.ThrowsAsync<TaskCanceledException>(actionUnderTest);[m
         }[m
 [m
[36m@@ -150,7 +160,7 @@[m [mpublic async Task WithTimeoutInvokesTheCancellationTokenWhenATimeoutOccurs()[m
 [m
             try[m
             {[m
[31m-                await Task.Delay(1000).WithTimeout(TimeSpan.FromMilliseconds(1), token);[m
[32m+[m[32m                await Task.Delay(LongDelay).WithTimeout(TinyDelay, token);[m
             }[m
 [m
             catch (TimeoutException)[m
[36m@@ -168,9 +178,9 @@[m [mpublic async Task WithTimeoutGenericInvokesTheCancellationTokenWhenATimeoutOccur[m
 [m
             try[m
             {[m
[31m-                await Task.Delay(1000)[m
[32m+[m[32m                await Task.Delay(LongDelay)[m
                     .ContinueWith( _ => "hello")[m
[31m-                    .WithTimeout(TimeSpan.FromMilliseconds(1), token);[m
[32m+[m[32m                    .WithTimeout(TinyDelay, token);[m
             }[m
 [m
             catch (TimeoutException)[m
