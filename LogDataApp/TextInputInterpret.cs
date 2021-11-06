namespace LogDataApp
{
    public class TextInputInterpret : InterpreInput
    {
        public override string Interpret(string logTextInput)
        {
            UserInput = logTextInput;
            return UserInput;
        }

        public string RunLogWriter(string logTextInput, DataWriterManager LogWriter)
        {
            LogWriter.Write(Interpret(logTextInput));
            return UserInput;
        }

        private string UserInput
        {
            get { return _userInput; }
            set { _userInput = value ?? ""; }
        }

        private string _userInput;
    }
}