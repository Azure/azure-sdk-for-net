#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Castle.DynamicProxy;

namespace Azure.AI.OpenAI.Tests.Utils
{
    public class DisableRecordingInterceptor : IInterceptor
    {
        private const string AsyncSuffix = "Async";
        private readonly List<Tuple<Type, string, EntryRecordModel>> _entries = new();
        private readonly Func<TestRecording?> _getRecording;

        public DisableRecordingInterceptor(Func<TestRecording?> getRecording)
        {
            _getRecording = getRecording ?? throw new ArgumentNullException(nameof(getRecording));
        }

        public TestRecording? Recording => _getRecording();

        public void DisableBodyRecordingFor<TClient>(string methodName)
        {
            _entries.Add(new(typeof(TClient), NormalizeMethodName(methodName), EntryRecordModel.RecordWithoutRequestBody));
        }

        public void DisableRecordingFor<TClient>(string methodName)
        {
            _entries.Add(new(typeof(TClient), NormalizeMethodName(methodName), EntryRecordModel.RecordWithoutRequestBody));
        }

        public void Intercept(IInvocation invocation)
        {
            if (_entries.Count == 0)
            {
                invocation.Proceed();
                return;
            }

            IDisposable? scoped = null;
            try
            {
                string normalizedName = NormalizeMethodName(invocation.Method.Name);
                var entry = _entries.FirstOrDefault(e =>
                    e.Item1.IsAssignableFrom(invocation.TargetType)
                    && e.Item2 == normalizedName);
                if (entry != null)
                {
                    scoped = new TestRecording.DisableRecordingScope(Recording, entry.Item3);
                }

                invocation.Proceed();
            }
            finally
            {
                scoped?.Dispose();
            }
        }

        private static string NormalizeMethodName(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentException("Method name cannot be null, empty, or white space.", nameof(methodName));
            }

            if (methodName.EndsWith(AsyncSuffix))
            {
                return methodName.Substring(0, methodName.Length - AsyncSuffix.Length);
            }

            return methodName;
        }
    }
}
