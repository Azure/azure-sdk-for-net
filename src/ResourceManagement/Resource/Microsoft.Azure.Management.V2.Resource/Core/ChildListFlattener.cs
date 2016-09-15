using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class ChildListFlattener<ParentT, ChildT>
    {
        private string switchToCousin = "switchToCousin";
        private IEnumerator<ParentT> parentItr;
        private Func<ParentT, PagedList<ChildT>> loadChildList;
        private PagedList<ChildT> currentChildList;
        private PagedList<ChildT> cousinList;

        public ChildListFlattener(PagedList<ParentT> parentList, Func<ParentT, PagedList<ChildT>> loadChildList)
        {
            parentItr = parentList.GetEnumerator();
            this.loadChildList = loadChildList;
        }

        public PagedList<ChildT> Flatten()
        {
            currentChildList = NextChildList();
            if (currentChildList == null)
            {
                return PagedList<ChildT>.EmptyPagedList<ChildT>();
            }
            SetCousin();
            return new PagedList<ChildT>(new ChildListPage(currentChildList.CurrentPage, this), (string nextPageLink) =>
            {
                if (string.Equals(nextPageLink, switchToCousin))
                {
                    currentChildList = cousinList;
                    SetCousin();
                    return new ChildListPage(currentChildList.CurrentPage, this);
                }
                else
                {
                    currentChildList.LoadNextPage();
                    if (currentChildList.CurrentPage.NextPageLink == null)
                    {
                        SetCousin();
                    }
                }
                return new ChildListPage(currentChildList.CurrentPage, this);
            });
        }

        private bool HasCousin
        {
            get
            {
                return cousinList != null;
            }
        }

        private void SetCousin()
        {
            cousinList = NextChildList();
        }

        private PagedList<ChildT> NextChildList()
        {
            while (parentItr.MoveNext())
            {
                PagedList<ChildT> nextChildList = loadChildList(parentItr.Current);
                if (nextChildList.GetEnumerator().MoveNext())
                {
                    return nextChildList;
                }
            }
            return null;
        }

        protected class ChildListPage : IPage<ChildT>
        {
            private IPage<ChildT> page;
            private ChildListFlattener<ParentT, ChildT> parent;

            public ChildListPage(IPage<ChildT> page, ChildListFlattener<ParentT, ChildT> parent)
            {
                this.page = page;
                this.parent = parent;
            }

            public string NextPageLink
            {
                get
                {
                    if (page.NextPageLink != null)
                    {
                        return page.NextPageLink;
                    }

                    if (parent.HasCousin)
                    {
                        return parent.switchToCousin;
                    }
                    return null;
                }
            }

            public IEnumerator<ChildT> GetEnumerator()
            {
                return page.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
