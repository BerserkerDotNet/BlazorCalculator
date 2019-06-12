namespace BlazorCalculator.Client.Types
{
    public class OperationData : Data
    {
        public OperationData(Operation op)
        {
            Operation = op;
        }

        public Operation Operation { get; }
    }
}
