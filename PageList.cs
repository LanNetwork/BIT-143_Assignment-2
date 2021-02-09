namespace Helpdesk
{
    // This is my base linkedlist class. History inherits from this.
    public class PageList
    {
        protected class PageNode
        {
            public string PageName;
            public PageNode Next;
            public PageNode()
            {
            }

            public PageNode(string pageName)
            {
                PageName = pageName;
                Next = null;
            }

            public PageNode(string pageName, PageNode next) : this(pageName)
            {
                Next = next;
            }
        }

        protected PageNode first;
    }
}