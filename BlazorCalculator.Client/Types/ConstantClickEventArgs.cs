namespace BlazorCalculator.Client.Types
{
    public class ConstantClickEventArgs
    {
        public ConstantClickEventArgs(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}
