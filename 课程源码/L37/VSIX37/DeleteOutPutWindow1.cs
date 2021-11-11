using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace VSIX37
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class DeleteOutPutWindow1
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4129;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d76b171b-f1df-4dbc-9956-e860636d1ae2");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOutPutWindow1"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private DeleteOutPutWindow1(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

       

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static DeleteOutPutWindow1 Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in DeleteOutPutWindow1's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new DeleteOutPutWindow1(package, commandService);
        }

        Guid guid = Guid.NewGuid();
        bool isCreated=false;

        private void Execute(object sender, EventArgs e)
        {
            _ = ExecuteAsync();
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private async Task ExecuteAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            IVsOutputWindow outputWindow=await ServiceProvider.GetServiceAsync(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Assumes.Present(outputWindow);

            IVsOutputWindowPane outputWindowPane;

            string paneTitle = VSIX37Package.PaneTitle;

            if(isCreated==false)
            {
                outputWindow.CreatePane(ref guid, paneTitle, Convert.ToInt32(true), Convert.ToInt32(false));
                isCreated=true;
            }
            else
            {
                outputWindow.GetPane(ref guid, out outputWindowPane);
                if(outputWindowPane!=null)
                {
                    outputWindow.DeletePane(guid);
                }
                isCreated = false;
            }           
        }
    }
}
