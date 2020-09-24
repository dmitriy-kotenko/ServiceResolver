using ServiceResolver.Services;

namespace ServiceResolver.Dialogs
{
    public class PrintDialog : PrintDialogBase
    {
        public string Data { get; }

        public PrintDialog(IDialogDataService dataService, string name) : base(name)
        {
            Data = dataService.GetData();
        }

        public PrintDialog(IDialogDataService dataService, string name, bool visible) : base(name, visible)
        {
            Data = dataService.GetData();
        }
    }
}
