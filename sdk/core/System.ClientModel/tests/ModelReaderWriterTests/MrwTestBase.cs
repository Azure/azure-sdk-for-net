// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public abstract class MrwTestBase<T>
    {
        private string? _jsonFolder;
        private string? _wirePayload_Collapsed;
        private string? _jsonPayload_Collapsed;
        private Lazy<T> _instance;

        protected string JsonFolder => _jsonFolder ??= GetJsonFolderName();

        protected virtual string WirePayload => File.ReadAllText(TestData.GetLocation($"{JsonFolder}/WireFormat.json")).TrimEnd();
        protected virtual string JsonPayload => File.ReadAllText(TestData.GetLocation($"{JsonFolder}/JsonFormat.json")).TrimEnd();

        protected string WirePayload_Collapsed => _wirePayload_Collapsed ??= string.Concat(WirePayload.Where(c => !char.IsWhiteSpace(c)));
        protected string JsonPayload_Collapsed => _jsonPayload_Collapsed ??= string.Concat(JsonPayload.Where(c => !char.IsWhiteSpace(c)));

        protected T Instance => _instance.Value;
        protected abstract ModelReaderWriterContext Context { get; }
        protected abstract T GetModelInstance();

        protected abstract void RoundTripTest(string format, RoundTripStrategy<T> strategy);

        protected virtual string GetJsonFolderName()
        {
            var className = GetType().Name;
            return className.Substring(0, className.Length - 5); //strip off 'Tests'
        }

        public MrwTestBase()
        {
            _instance = new(GetModelInstance);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriter_WithContext(string format)
            => RoundTripTest(format, new ModelReaderWriterStrategy_WithContext<T>(Context));

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterNonGeneric(string format)
            => RoundTripTest(format, new ModelReaderWriterNonGenericStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterNonGeneric_WithContext(string format)
            => RoundTripTest(format, new ModelReaderWriterNonGenericStrategy_WithContext<T>(Context));
    }
}
