using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DocumentBuilder {
	class Program {
		public static void Main(string[] args) {
			DocumentDirector director = new DocumentDirector();

			Console.WriteLine("JSON/XML Document Builder\n");
			string command;
			director.Help();
			while (true) {
				Console.Write("> ");
				command = Console.ReadLine();
				if(command.ToLower() == "exit") break;
				director.ParseCommand(command);
			}
		}
	}
}
