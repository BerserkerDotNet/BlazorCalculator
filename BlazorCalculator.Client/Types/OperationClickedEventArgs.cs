namespace BlazorCalculator.Client.Types
{
    public class OperationClickedEventArgs
    {
        public OperationClickedEventArgs(Operation op)
        {
            Operation = op;
        }

        public Operation Operation { get; set; }
    }
}
