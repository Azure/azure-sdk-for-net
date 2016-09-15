using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class PagedList<T> : IReadOnlyList<T>
    {
        private Func<string, IPage<T>> getNextPage;
        private List<T> aggregatedList;

        public IPage<T> CurrentPage { get; private set; }

        public int Count
        {
            get
            {
                LoadAll();
                return aggregatedList.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                while(index > aggregatedList.Count && !LoadNextPage());
                if (index > aggregatedList.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return aggregatedList[index];
            }
        }

        public PagedList(IPage<T> firstPage, Func<string, IPage<T>> getNextPage)
        {
            CurrentPage = firstPage;
            this.getNextPage = getNextPage;
            aggregatedList = new List<T>();
            aggregatedList.AddRange(CurrentPage);
        }

        public PagedList(IEnumerable<T> enumerable) : this(new OnePage<T>(enumerable), (string link) => { return null; })
        {}

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPage.NextPageLink != null;
            }
        }

        public IPage<T> GetNextPage()
        {
            if (!HasNextPage)
            {
                return null;
            }
            return getNextPage(CurrentPage.NextPageLink);
        }

        public bool LoadNextPage()
        {
            CurrentPage = GetNextPage();
            if (CurrentPage == null)
            {
                return false;
            }

            aggregatedList.AddRange(CurrentPage);
            return true;
        }

        public void LoadAll()
        {
            while (LoadNextPage())
            {
                LoadAll();
            }
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private PagedList<T> pagedList;
            private IEnumerator<T> aggregatedListEnumerator;

            public T Current
            {
                get
                {
                    return aggregatedListEnumerator.Current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            internal Enumerator(PagedList<T> list)
            {
                pagedList = list;
                aggregatedListEnumerator = pagedList.aggregatedList.GetEnumerator();
            }

            public void Dispose()
            { }

            bool IEnumerator.MoveNext()
            {
                if (aggregatedListEnumerator.MoveNext())
                {
                    return true;
                }

                int oldCount = pagedList.aggregatedList.Count;
                if (!pagedList.LoadNextPage())
                {
                    return false;
                }
                int newCount = pagedList.aggregatedList.Count;

                aggregatedListEnumerator = pagedList.aggregatedList.GetEnumerator();
                int skipCount = newCount - oldCount;
                while (skipCount > 0)
                {
                    aggregatedListEnumerator.MoveNext();
                    skipCount--;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                aggregatedListEnumerator.Reset();
            }
        }

        public static PagedList<U> EmptyPagedList<U>()
        {
            return new PagedList<U>(new OnePage<U>(new List<U>()));
        }

        protected class OnePage<U> : IPage<U>
        {
            private IEnumerable<U> enumerable;

            public OnePage(IEnumerable<U> enumerable)
            {
                this.enumerable = enumerable;
            }

            public string NextPageLink
            {
                get
                {
                    return null;
                }
            }

            public IEnumerator<U> GetEnumerator()
            {
                return enumerable.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
