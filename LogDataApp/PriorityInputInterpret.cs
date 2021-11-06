using System.Collections.Generic;

namespace LogDataApp
{
    public class PriorityInputInterpret : InterpreInput
    {
        public PriorityInputInterpret(Dictionary<string, string> LogPriorityDictionary)
        {
            this.LogPriorityDictionary = LogPriorityDictionary;
        }

        public override string Interpret(string logPriorityInput)
        {
            LogPriority = logPriorityInput;
            return LogPriority;
        }

        private string LogPriority
        {
            get { return _logPriority; }
            set
            {
                _logPriority = LogPriorityDictionary[value];
                _logPriority ??= "";
            }
        }

        public Dictionary<string, string> LogPriorityDictionary { get; }

        private string _logPriority;
    }
}