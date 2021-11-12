using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace VSIX40
{
    [Guid("03449068-a1fe-4599-b983-d42179f7e700")]
    public class ToolWindow1 : ToolWindowPane
    {
        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            this.Content = new ToolWindow1Control(this);
            
        }
    }
}
