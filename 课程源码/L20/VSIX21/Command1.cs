using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace VSIX21
{
    internal sealed class Command1
    {
        public const int CommandId = 0x0100;

        public static readonly Guid CommandSet = new Guid("b8e59dbf-c048-4017-a631-b154a6e4074e");

        private readonly AsyncPackage package;
        private int index = 0;

        private Command1(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
            menuItem.BeforeQueryStatus += MenuItem_BeforeQueryStatus;
            commandService.AddCommand(menuItem);
        }

        private void MenuItem_BeforeQueryStatus(object sender, EventArgs e)
        {

        }

        public static Command1 Instance
        {
            get;
            private set;
        }

        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new Command1(package, commandService);
        }

        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            OleMenuCommand menuCommand = sender as OleMenuCommand;
            if (menuCommand != null)
            {
                index++;
                menuCommand.Text = "item" + index;

                var menuCommandID = new CommandID(CommandSet, PackageIds.cmdidCommand2);

                var commandService = package.GetService<IMenuCommandService, OleMenuCommandService>();
                var menuCommand1 = commandService.FindCommand(menuCommandID) as OleMenuCommand;
                if (menuCommand1 != null)
                {
                    menuCommand1.Text = "item" + index;
                }
            }


            //string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            //string title = "Command1";

            //VsShellUtilities.ShowMessageBox(
            //    this.package,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
