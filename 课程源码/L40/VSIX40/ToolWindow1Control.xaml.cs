using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace VSIX40
{
    /// <summary>
    /// Interaction logic for ToolWindow1Control.
    /// </summary>
    public partial class ToolWindow1Control : UserControl
    {
        private readonly ToolWindow1 toolWindow1;

        //public Object Package { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1Control"/> class.
        /// </summary>
        public ToolWindow1Control(ToolWindow1 toolWindow1)
        {
            this.InitializeComponent();
            this.toolWindow1 = toolWindow1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text.Length>0)
            {
                var text=BuildTextWithOptions( textBox.Text);
                listBox.Items.Add(text);
            }
        }

        private string BuildTextWithOptions(string text)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            object obj;

            IVsPackage package= toolWindow1.Package as IVsPackage;

            package.GetAutomationObject("My Options"+"."+"My Page",out obj);

            if(obj is Class1 class1)
            {
                return text+":\t"+DateTime.Now.AddDays(class1.AddDays);
            }
            return text;
        }
    }
}