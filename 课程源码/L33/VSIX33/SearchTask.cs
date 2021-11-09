using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Text;

namespace VSIX33
{
    internal class SearchTask : VsSearchTask
    {
        public ToolWindow1 ToolWindow { get; }
        public SearchTask(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback, ToolWindow1 toolWindow)
            : base(dwCookie, pSearchQuery, pSearchCallback)
        {
            ToolWindow = toolWindow;
        }

        protected override void OnStartSearch()
        {
            _ = OnStartSearchAsync();
        }

        protected  async System.Threading.Tasks.Task OnStartSearchAsync()
        {
            //ThreadHelper.ThrowIfNotOnUIThread();
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var separator = new string[] { Environment.NewLine };

            this.ErrorCode = VSConstants.S_OK;
            try
            {
                if (ToolWindow.Content is ToolWindow1Control toolWindow1Control)
                {
                    var contentArray = toolWindow1Control.SearchContent.Split(separator, StringSplitOptions.None);
                    StringBuilder stringBuilder = new StringBuilder();
                    string searchString = this.SearchQuery.SearchString;

                    foreach (var content in contentArray)
                    {
                        if (content.Contains(searchString))
                        {
                            stringBuilder.AppendLine(content);
                        }
                    }
                    toolWindow1Control.SearchResultsTextBox.Text = stringBuilder.ToString();
                }
            }
            catch 
            {
                this.ErrorCode = VSConstants.E_FAIL;
            }


            base.OnStartSearch();
        }

        protected override void OnStopSearch()
        {
            base.OnStopSearch();
        }

    }
}