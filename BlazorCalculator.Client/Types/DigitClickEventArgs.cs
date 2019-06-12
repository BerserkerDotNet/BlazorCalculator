namespace BlazorCalculator.Client.Types
{
    public class DigitClickEventArgs
    {
        public DigitClickEventArgs(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
