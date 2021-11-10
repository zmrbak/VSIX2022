using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VSIX33
{
    [Guid("f376b4c5-139c-4b5f-b543-bea7ed05c7a3")]
    public class ToolWindow1 : ToolWindowPane
    {
        private IVsEnumWindowSearchOptions searchOptionsEnum;
        private WindowSearchBooleanOption matchCaseOption;

        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            this.Content = new ToolWindow1Control();
        }

        public override IVsEnumWindowSearchOptions SearchOptionsEnum
        {
            get
            {
                if(searchOptionsEnum==null)
                {
                    var list = new List<IVsWindowSearchOption>();
                    list.Add(MatchCaseOption);
                    //list.Add(new WindowSearchBooleanOption("匹配大小写", "匹配大小写",false));
                    searchOptionsEnum = new WindowSearchOptionEnumerator(list);
                }
                return searchOptionsEnum;
            }
        }

        public override bool SearchEnabled => true;

        public WindowSearchBooleanOption MatchCaseOption
        {
            get
            {
                if(matchCaseOption==null)
                {
                    matchCaseOption=new WindowSearchBooleanOption("匹配大小写", "匹配大小写", false);
                }
                return matchCaseOption;
            }
        }

        public override IVsSearchTask CreateSearch(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback)
        {
            if (pSearchQuery == null || pSearchCallback == null) return null;

            return new SearchTask(dwCookie, pSearchQuery, pSearchCallback, this);
        }
        public override void ClearSearch()
        {
            if(this.Content is ToolWindow1Control toolWindow1Control)
            {
                toolWindow1Control.SearchResultsTextBox.Text = toolWindow1Control.SearchContent;
            }
        }
    }
}
