using System;

namespace LogDataApp
{
    class ParseLogTextInput : ParseLog
    {
        public override string Parse(string logTextInput)
        {
            UserInput = logTextInput;
            if (UserInput.ToUpper() == "Q") return UserInput.ToUpper();
            return UserInput;
        }
        public string Parse(string logTextInput, DataWriterProxy LogWriter)
        {
            LogWriter.Write(Parse(logTextInput));
            return UserInput;
        }
        string UserInput
        {
            get { return _userInput; }
            set { _userInput = value ?? ""; }
        }

        string _userInput;
    }
}