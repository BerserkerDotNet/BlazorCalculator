namespace BlazorCalculator.Client.Types
{
    public class ValueData : Data
    {
        public ValueData(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}
