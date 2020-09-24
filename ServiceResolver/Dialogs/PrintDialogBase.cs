namespace ServiceResolver.Dialogs
{
    public abstract class PrintDialogBase
    {
        public string Name { get; }

        public bool Visible { get; }

        protected PrintDialogBase(string name)
        {
            Name = name;
        }

        protected PrintDialogBase(string name, bool visible)
        {
            Name = name;
            Visible = visible;
        }
    }
}
