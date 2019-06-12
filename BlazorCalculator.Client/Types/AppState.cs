using System.Collections.Generic;

namespace BlazorCalculator.Client.Types
{
    public class AppState
    {
        public string Current { get; set; }

        public Stack<Data> Stack { get; set; }
    }
}
