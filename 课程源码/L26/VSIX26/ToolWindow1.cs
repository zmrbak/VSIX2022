using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace VSIX26
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// 此类实现此包公开的工具窗口，并承载一个用户控件
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// 在Visual Studio中，工具窗口由框架（由shell实现）和面板组成，通常由包实现者实现。
    /// 
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// 该类派生自MPF提供的ToolWindowPane类，以便使用其IVsUIElementPane接口的实现。
    /// 
    /// </para>
    /// </remarks>
    [Guid("66f8b521-fa33-408f-9183-2ba539301ec2")]
    public class ToolWindow1 : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1"/> class.
        /// </summary>
        public ToolWindow1() : base(null)
        {
            this.Caption = "ToolWindow1";

            // This is the user control hosted by the tool window;
            // 这是由工具窗口托管的用户控件；

            // Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object.
            // 注意，即使这个类实现了IDisposable，我们也不会对这个对象调用Dispose。

            // This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            // 这是因为ToolWindowPane对Content属性返回的对象调用Dispose.
            this.Content = new ToolWindow1Control();
        }
    }
}
