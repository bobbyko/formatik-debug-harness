using CommandLineParser.Arguments;

namespace Octagon.Formatik
{
    public class CommandArguments
    {
        [SwitchArgumentAttribute('h', "help", false, Description = "Command Line Arguments")]
        public bool Help = false;

        [ValueArgument(typeof(string), 'i', "input", Description = "Input data & format")]
        public string Input;

        [ValueArgument(typeof(string), 'e', "example", Description = "Example/Sample output")]
        public string Example;
    }
}