using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace VSIX30
{
    [Guid("4c311c7c-6e33-4d09-ab3f-0d508a481c6f")]
    public class ToolWindow1 : ToolWindowPane
    {
        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            this.Content = new ToolWindow1Control();
            this.ToolBar = new System.ComponentModel.Design.CommandID(
                new Guid("3466cad1-7533-49e7-986d-7e8ad2433298"), 0x1111
                );
        }
    }
}
