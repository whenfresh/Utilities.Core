namespace WhenFresh.Utilities.Core.Facts.Dynamic
{
    using WhenFresh.Utilities.Core.Dynamic;

    public sealed class DerivedDynamicData : DynamicData
    {
        public DerivedDynamicData()
        {
            Data["Foo"] = "bar";
        }
    }
}