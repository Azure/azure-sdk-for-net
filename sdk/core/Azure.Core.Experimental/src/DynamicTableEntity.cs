// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using Azure.Data.Tables;

// TODO: remove
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over Azure.Tables.TableEntity.
    /// </summary>
    public class DynamicTableEntity : DynamicData
    {
        private readonly TableEntity _entity;

        internal DynamicTableEntity(TableEntity entity)
        {
            _entity = entity;
        }

        public override T ConvertTo<T>()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable GetEnumerable() => _entity;

        public override object? GetProperty(string name)
        {
            if (_entity.TryGetValue(name, out object value))
            {
                return value;
            }

            return null;
        }

        public override object? GetViaIndexer(object index)
        {
            throw new NotImplementedException();
        }

        public override object? SetProperty(string name, object value)
        {
            _entity.Add(name, value);

            return null;
        }

        public override object? SetElement(int index, object value)
        {
            throw new NotImplementedException();
        }

        public override void WriteTo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
