using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace VSIX11
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIX11Package.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class VSIX11Package : AsyncPackage
    {
        public const string PackageGuidString =PackageGuids.guidVSIX11PackageString ;

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await Command1.InitializeAsync(this);
            //aad9266a-3350-47b9-bfe5-25a0ae6c344c60b8c56f-9675-4c8d-b28d-e8b86eb93dfe61ab3592-ac5e-45d0-b98d-2370f6aa8d71
            //data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAAAQCAMAAADeZIrLAAAA8FBMVEUAAAD29vb29vb29vb19fX29vb29vb39/f39/fv7+/29vb29vb29vb19fX29vbw5+b19fX29vb29vb19fX09PT19fX29vb29vb29vb29vb29vb29vb39/f09PT29vb29vb29vbZsafw5uT29vb29vb29vb29vYEAgRCQkKhJg3w7/FRg+VDfvSmMxyxTTlek/wqW73Pz8/mz8rx6efhwrzOzs49bc67u7vl5OXMjoLRm5DWqJ/v7u93d3jKycqsQCqioqKdnZ3AwMDGgXPBdGSqqqrGxcZLS0vCwsO2trbr3NlRUVG2Wkfg3+FgYGDe3d8FbkcqAAAAJnRSTlMA8c9bnzf+QGAQr47VcODvgO8VvzBQpbUDzMYKIOwbiFnv3/eYgXbcUiUAAAGnSURBVHjatZODolwxGAa/tW3WOX/WtlFv+/5v0+Q41fUso5kl7kftQ5KxzPsmXohmfEqCayMAoJ5ORCCJ+HO5MExmeALlypx2m81PokYWofFqlZSFQmo58UZg0O4/oBCSwMXrBS1aErrG4F9xfo4iEhvte6m87e90BrDQNA3QBDBhAjgwibsSPRxbOrcfST3AJ+nkutsdFWDTgQsj4DISMR17qIxRoZ0R2BBDaNzjvDs+i0oC/w64/WCM5JWsgDoGqvTZCrwDwnqB87Uf/wwI4OaOQHG+NQK7bRVmgV+8kf8GNDVgSK0RKWNfcEpz6V98m4adQM6td75kTeHv70CM7LH0D0Vx+3F6+PSlVAZiX82PKKEUZup3YNv/GiDX2PBP50THW7EG+EdC3hsveXeUh8MMakAtMBNlJLD9Q8+raCkWgOVPFbxrvn8bgU4b6qMmUQv/xvQHYDLh8kcaQsQ/6X6Pmv8yGPTbeDjxk+LHUvhHYQgSo/1SPhn02yb9zgAPJhs/uf2YdE0/EEr13uRloQMD6X9Mwe1HOJNJw6TuZV4ILO/f/L8ARqxVTnerDlQAAAAASUVORK5CYII=
        }

        #endregion
    }
}
