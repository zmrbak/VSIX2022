using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VSIX32
{
    /// <summary>
    /// Interaction logic for ToolWindow1Control.
    /// </summary>
    public partial class ToolWindow1Control : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1Control"/> class.
        /// </summary>
        public ToolWindow1Control(OleMenuCommandService oleMenuCommandService)
        {
            this.InitializeComponent();
            OleMenuCommandService = oleMenuCommandService;

            if(OleMenuCommandService!=null)
            {
                {
                    var menuCommandID = new CommandID(PackageGuids.guidVSIX32PackageCmdSet, PackageIds.Button1);
                    var menuItem = new MenuCommand(this.Execute, menuCommandID);
                    OleMenuCommandService.AddCommand(menuItem);
                }
                {
                    var menuCommandID = new CommandID(PackageGuids.guidVSIX32PackageCmdSet, PackageIds.Button2);
                    var menuItem = new MenuCommand(this.Execute, menuCommandID);
                    OleMenuCommandService.AddCommand(menuItem);
                }
                {
                    var menuCommandID = new CommandID(PackageGuids.guidVSIX32PackageCmdSet, PackageIds.Button3);
                    var menuItem = new MenuCommand(this.Execute, menuCommandID);
                    OleMenuCommandService.AddCommand(menuItem);
                }
            }
        }

        private void Execute(object sender, EventArgs e)
        {
            var menuItem = sender as MenuCommand;
            if (menuItem == null) return;

            switch (menuItem.CommandID.ID)
            {
                case PackageIds.Button1:
                    this.Background = Brushes.Red;
                    break;
                case PackageIds.Button2:
                    this.Background = Brushes.Yellow;
                    break;
                case PackageIds.Button3:
                    this.Background = Brushes.Blue;
                    break;
                default:
                    break;
            }
        }

        public OleMenuCommandService OleMenuCommandService { get; }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "ToolWindow1");
        }

        private void MyToolWindow_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(OleMenuCommandService!=null)
            {
                var menuCommandID = new CommandID(PackageGuids.guidVSIX32PackageCmdSet, PackageIds.MyMenu);
                Point p=this.PointToScreen(e.GetPosition(this));
                OleMenuCommandService.ShowContextMenu(menuCommandID,(int)p.X,(int)p.Y);
            }
        }
    }
}