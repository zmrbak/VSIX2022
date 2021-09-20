using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using System;
//using Task = System.Threading.Tasks.Task;

namespace VSIX11A
{
    [Command("39d0ad36-e659-4017-8e41-696db6fe4fb6", 0x0100)]
    internal sealed class Command1 : BaseCommand<Command1>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("Command1", "Button clicked");
        }
    }
}
