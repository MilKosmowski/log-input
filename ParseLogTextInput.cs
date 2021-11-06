namespace LogDataApp
{
    public class ParseLogTextInput : ParseLog
    {
        public override string Parse(string logTextInput)
        {
            UserInput = logTextInput.ToUpper();
            return UserInput;
        }

        public string Parse(string logTextInput, DataWriterProxy LogWriter)
        {
            LogWriter.Write(Parse(logTextInput));
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