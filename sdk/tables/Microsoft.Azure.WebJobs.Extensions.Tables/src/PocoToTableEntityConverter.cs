// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ITableEntity = Azure.Data.Tables.ITableEntity;
using TableEntity = Azure.Data.Tables.TableEntity;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoToTableEntityConverter<TInput> : IConverter<TInput, ITableEntity>
    {
        public PocoToTableEntityConverter()
        {
        }

        public ITableEntity Convert(TInput input)
        {
            if (input == null)
            {
                return null;
            }

            if (input is TableEntity te)
            {
                return te;
            }

            // TableEntity result = new TableEntity();
            // if (_partitionKeyGetter != null)
            // {
            //     result.PartitionKey = _partitionKeyGetter.GetValue(input);
            // }
            //
            // if (_rowKeyGetter != null)
            // {
            //     result.RowKey = _rowKeyGetter.GetValue(input);
            // }
            //
            // if (_timestampGetter != null)
            // {
            //     result.Timestamp = _timestampGetter.GetValue(input);
            // }
            //
            // IDictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>();
            // foreach (KeyValuePair<string, IPropertyGetter<TInput, EntityProperty>> pair in _otherPropertyGetters)
            // {
            //     string propertyName = pair.Key;
            //     IPropertyGetter<TInput, EntityProperty> getter = pair.Value;
            //     Debug.Assert(getter != null);
            //     EntityProperty propertyValue = getter.GetValue(input);
            //     properties.Add(propertyName, propertyValue);
            // }

            // result.ReadEntity(properties, operationContext: null);
            // if (_eTagKeyGetter != null)
            // {
            //     result.ETag = _eTagKeyGetter.GetValue(input);
            // }

            TableEntity result = new TableEntity();
            PocoTypeBinder.Shared.Serialize(input, result);
            return result;
        }
    }
}