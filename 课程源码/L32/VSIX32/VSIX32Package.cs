using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace VSIX32
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIX32Package.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ToolWindow1))]
    [ProvideToolWindowVisibility(typeof(ToolWindow1),VSConstants.UICONTEXT.SolutionExists_string)]
    public sealed class VSIX32Package : AsyncPackage
    {
        public const string PackageGuidString = "21498bd8-46ec-4fa7-bc8e-426540eff8eb";

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await ToolWindow1Command.InitializeAsync(this);
        }

        #endregion
    }
}
