using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentBuilder.XML;
using DocumentBuilder.JSON;

namespace DocumentBuilder {
	enum Mode{
		XML,
		JSON,
		NULL
	}
	public class DocumentDirector : IDirector {
		IBuilder builder;
		Mode mode = Mode.NULL;
		string command;
		IComposite root;
		List<string> commandElements = new List<string>();
		public void ParseCommand(string command) {
			commandElements = command.Split(':').ToList();
			if(commandElements[0].ToLower() == "mode") {
				SetMode(commandElements[1]);
				commandElements.Clear();
			}
			else if(commandElements[0].ToLower() == "branch") {
				if (mode == Mode.NULL) {
					Console.WriteLine("Mode not set.");
				} else if (commandElements.Count != 2) {
					Console.WriteLine("Wrong branch format.");
				} else {
					BuildBranch();
					commandElements.Clear();
				}
			}
			else if(commandElements[0].ToLower() == "leaf") {
				if (mode == Mode.NULL) {
					Console.WriteLine("Mode not set.");
				} 
				else if(commandElements.Count != 3) {
					Console.WriteLine("Wrong leaf format.");
				} else {
					BuildLeaf();
					commandElements.Clear();
				}
			}
			else if(commandElements[0].ToLower() == "close") {
				if (mode == Mode.NULL) {
					Console.WriteLine("Mode not set.");
				} else {
					CloseBranch();
					commandElements.Clear();
				}
			}
			else if(commandElements[0].ToLower() == "print") {
				if (mode == Mode.NULL) {
					Console.WriteLine("Mode not set.");
				} else {
					root = builder.GetDocument();
					Console.WriteLine(root.Print(0));
					commandElements.Clear();
				}
			}
			else if(commandElements[0].ToLower() == "help") {
				Help();
				commandElements.Clear();
			}
			else {
				Console.WriteLine("Bad input!");
				commandElements.Clear();
			}
		}
		public void SetMode(string modeS) {
			if (modeS.ToLower() == "xml") {
				mode = Mode.XML;
				builder = new XMLBuilder();
				Console.WriteLine("Set mode to XML");
			} 
			else if (modeS.ToLower() == "json") {
				mode = Mode.JSON;
				builder = new JSONBuilder();
				Console.WriteLine("Set mode to JSON");
			} 
			else {
				Console.WriteLine("Something wrong!");
			}
		}
		public void Help() {
			Console.WriteLine("Usage:" +
				"	help				Prints usage(this page)\n" +
				"	mode:<JSON|XML>			Sets mode\n" +
				"	branch:<name>			Creates a new branch with the assigned name\n" +
				"	leaf:<name>:<content>		Creates a new leaf with the assigned name and content\n" +
				"	close				Closes the current branch\n" +
				"	print				Prints the current document\n" +
				"	exit				Exits the program");
		}
		public void BuildBranch() {
			builder.BuildBranch(commandElements[1]);
			Console.WriteLine("Building branch " + commandElements[1]);
		}
		public void BuildLeaf() {
			builder.BuildLeaf(commandElements[1], commandElements[2]);
			Console.WriteLine("Building leaf " + commandElements[1] + " : " + commandElements[2]);
		}
		public void CloseBranch() {
			try {
				builder.CloseBranch();
			}
			catch(Exception e) {
				Console.WriteLine("Not in a branch. You shouldn't see this, hopefully! " + e.Message);
			}
		}
	}
}
