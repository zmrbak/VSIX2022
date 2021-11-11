using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;

namespace VSIX36
{
    [Guid("d4ee0e12-0479-4e62-bab7-11964606ee88")]
    public class ToolWindow1 : ToolWindowPane,IVsRunningDocTableEvents
    {
        private uint pdwCookie;

        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            this.Content = new ToolWindow1Control();
        }

        protected override void Initialize()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            IVsRunningDocumentTable rdt=this.GetService(typeof(SVsRunningDocumentTable)) as IVsRunningDocumentTable;
            if (rdt != null)
            {
                rdt.AdviseRunningDocTableEvents(this,out pdwCookie);
            }
            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            IVsRunningDocumentTable rdt = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SVsRunningDocumentTable)) as IVsRunningDocumentTable;
            if (rdt != null)
            {
                rdt.UnadviseRunningDocTableEvents(pdwCookie);
            }
            base.Dispose(disposing);
        }

        public int OnAfterFirstDocumentLock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnAfterFirstDocumentLock" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie+ Environment.NewLine);
            textBox.AppendText("dwRDTLockType:\t" + dwRDTLockType + Environment.NewLine);
            textBox.AppendText("dwReadLocksRemaining:\t" + dwReadLocksRemaining + Environment.NewLine);
            textBox.AppendText("dwEditLocksRemaining:\t" + dwEditLocksRemaining + Environment.NewLine);

            return VSConstants.S_OK;
        }

        public int OnBeforeLastDocumentUnlock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnBeforeLastDocumentUnlock" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie + Environment.NewLine);
            textBox.AppendText("dwRDTLockType:\t" + dwRDTLockType + Environment.NewLine);
            textBox.AppendText("dwReadLocksRemaining:\t" + dwReadLocksRemaining + Environment.NewLine);
            textBox.AppendText("dwEditLocksRemaining:\t" + dwEditLocksRemaining + Environment.NewLine);

            return VSConstants.S_OK;
        }

        public int OnAfterSave(uint docCookie)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnAfterSave" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie + Environment.NewLine);
            
            return VSConstants.S_OK;
        }

        public int OnAfterAttributeChange(uint docCookie, uint grfAttribs)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnAfterAttributeChange" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie + Environment.NewLine);
            textBox.AppendText("grfAttribs:\t" + grfAttribs + Environment.NewLine);

            return VSConstants.S_OK;
        }

        public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnBeforeDocumentWindowShow" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie + Environment.NewLine);
            textBox.AppendText("fFirstShow:\t" + fFirstShow + Environment.NewLine);
            textBox.AppendText("pFrame:\t" + pFrame + Environment.NewLine);

            return VSConstants.S_OK;
        }

        public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame)
        {
            var textBox = ((ToolWindow1Control)this.Content).textBox;
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText("OnAfterDocumentWindowHide" + Environment.NewLine);
            textBox.AppendText("docCookie:\t" + docCookie + Environment.NewLine);
            textBox.AppendText("pFrame:\t" + pFrame + Environment.NewLine);

            return VSConstants.S_OK;
        }
    }
}
