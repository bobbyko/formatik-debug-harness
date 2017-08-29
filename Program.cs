using System;
using System.IO;
using System.Linq;
using System.Text;
using CommandLineParser.Exceptions;
using CommandLineParser.Validation;

namespace Octagon.Formatik.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentParser = new CommandLineParser.CommandLineParser();
            var options = new CommandArguments();
            argumentParser.ExtractArgumentAttributes(options);

            try
            {
                argumentParser.ParseCommandLine(args);
            }
            catch (ArgumentConflictException)
            {
                options.Help = true;
            }
            catch (InvalidConversionException)
            {
                options.Help = true;
            }

            if (File.Exists(options.Input) && File.Exists(options.Example))
            {
                var formatik = new Formatik(File.ReadAllText(options.Input), File.ReadAllText(options.Example));
                //Console.WriteLine(string.Join("\r\n", formatik.Tokens.Select(t => t.InputSelector)));
                
                using (var file = File.Open(options.Input, FileMode.Open))
                {
                    using (var output = new FileStream("output.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        formatik.Process(file, output, Encoding.ASCII);
                    }
                }

                Console.WriteLine("Result ready in output.txt");
            }
            else
            {
                Console.WriteLine("Input or example files not found.");
            }
        }
    }
}
