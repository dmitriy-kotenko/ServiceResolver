namespace ServiceResolver.Utilities
{
    public static class StaticContext
    {
        // This is an anti-pattern and it's limited to singleton scope usage only. 
        public static IGenericServiceProvider GenericServiceProvider { get; set; }
    }
}
