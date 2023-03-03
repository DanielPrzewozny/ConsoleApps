using TravelerAppConsole;

namespace TravelerAppCore.Controller
{
    public class Option
    {
        private static int id = 0;
        public int _id { get; set; }
        public string _optionText { get; set; }
        public Options _menuOptions { get; set; }
        public Option(string optionText, Options options)
        {
            _optionText = optionText;
            _menuOptions = options;
            _id = id;
            id++;
        }
    }
}
