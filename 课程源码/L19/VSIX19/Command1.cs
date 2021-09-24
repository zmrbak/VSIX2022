using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace VSIX19
{
    internal sealed class Command1
    {
        public const int CommandId = 0x0200;

        //动态菜单数量
        private int mruNumber = 10;
        //菜单名称列表
        private List<string> mruList;

        public static readonly Guid CommandSet = new Guid("42157b7b-bce8-43fd-ab56-49dbc3cabdf6");

        private readonly AsyncPackage package;

        private Command1(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            //var menuCommandID = new CommandID(CommandSet, CommandId);
            //var menuItem = new MenuCommand(this.Execute, menuCommandID);
            //commandService.AddCommand(menuItem);

            InitMruMenu(commandService);
        }

        private void InitMruMenu(OleMenuCommandService commandService)
        {
            mruList = new List<string>();
            for (int i = 0; i < mruNumber; i++)
            {
                string message = string.Format(CultureInfo.CurrentCulture, "Item {0}", i + 1);
                mruList.Add(message);

                var menuCommandID = new CommandID(CommandSet, CommandId + i);
                var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
                menuItem.Text = message;
                menuItem.BeforeQueryStatus += MenuItem_BeforeQueryStatus;

                commandService.AddCommand(menuItem);
            }
        }

        private void MenuItem_BeforeQueryStatus(object sender, EventArgs e)
        {
            var menuCommand = sender as OleMenuCommand;
            if (menuCommand != null)
            {
                var index = menuCommand.CommandID.ID - CommandId;
                if (index >= 0)
                {
                    menuCommand.Text = mruList[index];
                }
            }
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

            var menuCommand = sender as OleMenuCommand;
            if (menuCommand != null)
            {
                var index = menuCommand.CommandID.ID - CommandId;
                if (index >= 0)
                {
                    var selectedText = mruList[index];
                    for (int i = index; i > 0; i--)
                    {
                        mruList[i] = mruList[i - 1];
                    }

                    mruList[0]=selectedText;
                    MessageBox.Show(selectedText);
                }
            }
        }
    }
}
