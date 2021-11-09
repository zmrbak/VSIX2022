using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace VSIX32
{
    [Guid("1db5605f-2986-49ff-a3e3-72f56846f904")]
    public class ToolWindow1 : ToolWindowPane
    {
        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            OleMenuCommandService oleMenuCommandService =  GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            this.Content = new ToolWindow1Control(oleMenuCommandService);
        }
    }
}
