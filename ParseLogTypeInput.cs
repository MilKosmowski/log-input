using System;
using System.Linq;

namespace LogDataApp
{
    class ParseLogTypeInput : ParseLog
    {

        public override string Parse(string logTypeInput)
        {
            LogOption = logTypeInput;
            return LogOption;
        }

        string LogOption
        {
            get { return _logOption; }
            set
            {
                if (value == "") _logOption = "A";
                else if (_logOptions.Contains(value.ToUpper()))
                    _logOption = value.ToUpper();
                else
                    _logOption = "N";
            }
        }
        private readonly string[] _logOptions = { "C", "F", "E", "A" };

        private string _logOption;
    }
}