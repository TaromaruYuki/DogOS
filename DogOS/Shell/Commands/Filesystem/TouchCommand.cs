using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DogOS.Shell.Commands.Filesystem
{
    public class TouchCommand : Command
    {
        public TouchCommand() : base("touch", "Create a empty file.", CommandCategory.Filesystem) { }

        public override CommandResult Execute()
        {
            return CommandResult.Failure(new Types.Errors.NotEnoughArguments(
                "A file name was not specified."
            ));
        }


        public override CommandResult Execute(List<string> args)
        {
            if(File.Exists($"{Kernel.drive}{Kernel.dir}{args[0]}"))
            {
                return CommandResult.Failure(new Types.Errors.AlreadyExists(
                    $"File {args[0]}"
                ));
            }

            try
            {
                File.Create($"{Kernel.drive}{Kernel.dir}{args[0]}");
                return CommandResult.Success();
            }
            catch (Exception e)
            {
                return CommandResult.Failure(new Types.Errors.UnknownError(
                    e.ToString()
                ));
            }
        }

        public override void Help()
        {
            Console.WriteLine(Description);

            Console.WriteLine($"\ttouch [file_name] || {Description}");
        }
    }
}