// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.ObjectModel;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ObservableCollectionOfObservableCollectionTests : MrwCollectionTests<ObservableCollection<ObservableCollection<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override ObservableCollection<ObservableCollection<AvailabilitySetData>> GetModelInstance()
        {
            return
            [
                new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]),
                new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378])
            ];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ObservableCollectionTests.LocalContext> s_availabilitySetData_ObservableCollectionTests_LocalContext = new(() => new());

            private ObservableCollection_ObservableCollection_AvailabilitySetData_Info? _observableCollection_ObservableCollection_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ObservableCollection<ObservableCollection<AvailabilitySetData>>) => _observableCollection_ObservableCollection_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_ObservableCollectionTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class ObservableCollection_ObservableCollection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ObservableCollection_ObservableCollection_AvailabilitySetData_Builder();

                private class ObservableCollection_ObservableCollection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ObservableCollection<ObservableCollection<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<ObservableCollection<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
