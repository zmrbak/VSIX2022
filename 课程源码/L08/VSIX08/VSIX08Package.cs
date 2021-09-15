using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Task = System.Threading.Tasks.Task;

namespace VSIX08
{
    [ProvideAutoLoad(VSIX08Package.UIContextGuidString, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideUIContextRule(VSIX08Package.UIContextGuidString, name: "XAML load", expression: "Dotxaml", termNames: new[] { "Dotxaml" }, termValues: new[] { "HierSingleSelectionName:.xaml$" })]

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIX08Package.PackageGuidString)]
    public sealed class VSIX08Package : AsyncPackage
    {
        public const string PackageGuidString = "163ca4e4-d9b6-4ce1-9378-008e4d42ad23";
        public const string UIContextGuidString = VSConstants.UICONTEXT.CodeWindow_string;
        public const string StandardCommandSet97String = VSConstants.CMDSETID.StandardCommandSet97_string;

        private CommandEvents saveCommandEvent;
        private DTE IDE { get; set; }

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            IDE = await this.GetServiceAsync(typeof(DTE)) as DTE;
            Assumes.Present(IDE);

            this.saveCommandEvent = IDE.Events.CommandEvents[StandardCommandSet97String, 331];
            saveCommandEvent.BeforeExecute += BeforeSaveCommand;
        }

        private void BeforeSaveCommand(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
        {
            MessageBox.Show("BeforeSaveCommand Executed!");
        }

        #endregion
    }
}
