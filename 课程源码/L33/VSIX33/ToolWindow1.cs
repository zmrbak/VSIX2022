using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;

namespace VSIX33
{
    [Guid("f376b4c5-139c-4b5f-b543-bea7ed05c7a3")]
    public class ToolWindow1 : ToolWindowPane
    {
        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            this.Content = new ToolWindow1Control();
        }

        public override bool SearchEnabled => true;

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
