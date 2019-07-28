using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder.XML {
	class XMLBuilder : IBuilder {
		List<XMLBranch> branches = new List<XMLBranch>();
		int depth = 0;
		string document;
		public XMLBuilder() {
			branches.Add(new XMLBranch("root"));
			depth += 1;
		}
		public void BuildBranch(string name) {
			branches.Add(new XMLBranch(name));
			branches[branches.Count - 2].AddChild(branches[branches.Count - 1]);
			depth += 1;
		}
		public void BuildLeaf(string name, string content) {
			branches[branches.Count - 1].AddChild(new XMLLeaf(name,content));
			//depth += 1;
		}
		public void CloseBranch() {
			if(depth == 1) {
				Console.WriteLine("Cannot close root branch");
			} else {
				document += branches[branches.Count - 1].Print(depth);
				document += "</" + branches[branches.Count - 1].key + ">";
				Console.WriteLine("Closing branch " + branches[branches.Count - 1].key);
				branches.RemoveAt(branches.Count - 1);
				depth -= 1;
			}

		}
		public IComposite GetDocument() {
			return branches[0];
		}
	}
}
