// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class LinkCollection<TInterface, TType> : ObservableCollection<TInterface>
    {
        private readonly DataServiceContext _dataContext;
        private readonly string _propertyName;
        private readonly object _parent;
        public LinkCollection(DataServiceContext dataContext, object parent, string propertyName, IEnumerable<TInterface> items) : base(items)
        {
            _dataContext = dataContext;
            _propertyName = propertyName;
            _parent = parent;
        }
        protected override void InsertItem(int index, TInterface item)
        {
            ValidateItem(item);
            _dataContext.AddLink(_parent, _propertyName, item);
            _dataContext.SaveChanges();
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            _dataContext.DeleteLink(_parent, _propertyName, this[index]);
            _dataContext.SaveChanges();
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, TInterface item)
        {
            throw new NotSupportedException();
        }
        static private void ValidateItem(TInterface item)
        {
            if (!(item is TType))
                throw new InvalidCastException(StringTable.ErrorInvalidLinkType);
        }
    }
}
