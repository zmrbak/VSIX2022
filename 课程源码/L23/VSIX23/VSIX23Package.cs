using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace VSIX23
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIX23Package.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    //     An example rule would be: ContextGuid: {e551fe48-4b78-4dc4-9ddc-183cbfea7d5b}
    //     Expression: VB | CS TermNames: { VB, CS }, TermValues: { ActiveEditorContentType:Basic,
    //     ActiveEditorContentType:CSharp } Delay: 500 This would create a new UI context
    //     that is activated 500 ms after when active editor is either a C# or VB file
    //  创建一个基于规则的 UI 上下文条目，该条目在表达式计算结果为 true 时被激活。
    [ProvideUIContextRule(
        contextGuid: VSConstants.UICONTEXT.SolutionExists_string,
        name: "CSharp",
        expression: "VB | CS",
        termNames: new string[] { "VB", "CS" },
        termValues: new string[] { "HierSingleSelectionName:.vb$","HierSingleSelectionName:.cs$" }
        )]


    public sealed class VSIX23Package : AsyncPackage
    {
        public const string PackageGuidString = "dcd4c29a-3012-4a20-9e01-86534fecb5bb";

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await Command1.InitializeAsync(this);
        }

        #endregion
    }
}
