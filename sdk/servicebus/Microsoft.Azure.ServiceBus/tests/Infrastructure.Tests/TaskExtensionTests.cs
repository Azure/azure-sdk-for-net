using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.ServiceBus.UnitTests.Infrastructure.Tests
{
    public class TaskExtensionsTests
    {  
        // It has been observed during the CI build that test runs can cause delays that were noted at 
        // 1-2 seconds and were causing intermitten failures as a result.  The long delay has been set at 5 
        // seconds arbitrarily, which may delay results should tests fail but is otherwise not expected to 
        // be an actual wait time under normal circumstances.
        private readonly TimeSpan _longDelay = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _tinyDelay = TimeSpan.FromMilliseconds(1);

        [Fact]
        public void WithTimeoutThrowsWhenATimeoutOccursAndNoActionIsSpecified()
        {
            Func<Task> actionUnderTest = async () =>  
                await Task.Delay(_longDelay)
                    .WithTimeout(_tinyDelay);
              
            Assert.ThrowsAsync<TimeoutException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutExecutesTheTimeoutActionWhenATimeoutOccurs()
        {
            var timeoutActionInvoked = false;

            Action timeoutAction = () => { timeoutActionInvoked = true; };
            
            await Task.Delay(_longDelay).WithTimeout(_tinyDelay, null, timeoutAction);
            Assert.True(timeoutActionInvoked, "The timeout action should have been invoked.");
        }

        [Fact]
        public async Task WithTimeoutGenericThrowsWhenATimeoutOccursAndNoActionIsSpecified()
        {
            Func<Task> actionUnderTest = async () => 
                await Task.Delay(_longDelay)
                    .ContinueWith( _ => "blue")
                    .WithTimeout(_tinyDelay);

            await Assert.ThrowsAsync<TimeoutException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutGeneticExecutesTheTimeoutCallbackWhenATimeoutOccurs()
        {
            var timeoutActionInvoked = false;
            var expectedResult = "green";

            Func<string> timeoutCallback = () => 
            { 
                timeoutActionInvoked = true; 
                return expectedResult;
            };

            var result = await Task.Delay(_longDelay)
                .ContinueWith( _ => "blue")
                .WithTimeout(_tinyDelay, null, timeoutCallback);

            Assert.True(timeoutActionInvoked, "The timeout action should have been invoked.");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WithTimeoutDoesNotThrowWhenATimeoutDoesNotOccur()
        {
            var exceptionObserved = false;

            try
            {
                await Task.Delay(_tinyDelay).WithTimeout(_longDelay);
            }
            catch (TimeoutException)
            {
                exceptionObserved = true;
            }

            Assert.False(exceptionObserved, "There should not have been a timeout exception thrown.");
        }

        [Fact]
        public async Task WithTimeoutGenericDoesNotThrowsWhenATimeoutDoesNotOccur()
        {
            var exceptionObserved = false;
                        
            try
            {
                await Task.Delay(_tinyDelay).ContinueWith( _ => "blue").WithTimeout(_longDelay);
            }
            catch (TimeoutException)
            {                
                exceptionObserved = true;
            }

            Assert.False(exceptionObserved, $"There should not have been a timeout exception thrown.");
        }

        [Fact]
        public async Task WithTimeoutGenericReturnsTheValueWhenATimeoutDoesNotOccur()
        {
            var expected = "hello";
            var result = await  Task.Delay(_tinyDelay).ContinueWith( _ => expected).WithTimeout(_longDelay);
            Assert.Equal(result, expected);
        }

        [Fact]
        public async Task WithTimeoutPropagatesAnExceptionForACompletedTask()
        {
            var completionSource = new TaskCompletionSource<object>();
            completionSource.SetException(new MissingFieldException("oops"));

            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(_longDelay);
            await Assert.ThrowsAsync<MissingFieldException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutPropagatesAnExceptionThatCompletesBeforeTimeout()
        {
            Func<Task> actionUnderTest = async () => 
                await Task.Delay(_tinyDelay)
                    .ContinueWith( _ => throw new MissingMemberException("oh no"))
                    .WithTimeout(_longDelay);

            await Assert.ThrowsAsync<MissingMemberException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutGenericPropagatesAnExceptionThatCompletesBeforeTimeout()
        {
           Func<Task> actionUnderTest = async () => 
               await Task.Delay(_tinyDelay)
                   .ContinueWith<string>( _ => throw new MissingMemberException("oh no"))
                   .WithTimeout(_longDelay);

            await Assert.ThrowsAsync<MissingMemberException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutPropagatesACancelledTask()
        {
            var completionSource = new TaskCompletionSource<object>();
            completionSource.SetCanceled();

            Func<Task> actionUnderTest = async () => await completionSource.Task.WithTimeout(_longDelay);
            await Assert.ThrowsAsync<TaskCanceledException>(actionUnderTest);
        }

        [Fact]
        public async Task WithTimeoutInvokesTheCancellationTokenWhenATimeoutOccurs()
        {
            var token = new CancellationTokenSource();

            try
            {
                await Task.Delay(_longDelay).WithTimeout(_tinyDelay, token);
            }

            catch (TimeoutException)
            {
                // Expected; do nothing
            }

            Assert.True(token.IsCancellationRequested, "The cancellation should be requested at timeout.");
        }

        [Fact]
        public async Task WithTimeoutGenericInvokesTheCancellationTokenWhenATimeoutOccurs()
        {
            var token  = new CancellationTokenSource();

            try
            {
                await Task.Delay(_longDelay)
                    .ContinueWith( _ => "hello")
                    .WithTimeout(_tinyDelay, token);
            }

            catch (TimeoutException)
            {
                // Expected; do nothing
            }

            Assert.True(token.IsCancellationRequested, "The cancellation should be requested at timeout.");
        }
    }
}
