using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace VSIX19
{
    [ProvideAutoLoad(VSIX19Package.UIContextGuidString, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideUIContextRule(VSIX19Package.UIContextGuidString, name: "XAML load", expression: "Dotxaml", termNames: new[] { "Dotxaml" }, termValues: new[] { "HierSingleSelectionName:.xaml$" })]


    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIX19Package.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class VSIX19Package : AsyncPackage
    {
        public const string PackageGuidString = "c3a3981e-5dd1-48b2-b0c9-66c3ca41f3a9";
        public const string UIContextGuidString = VSConstants.UICONTEXT.CodeWindow_string;

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await Command1.InitializeAsync(this);
        }

        #endregion
    }
}
