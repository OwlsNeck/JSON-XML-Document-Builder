using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder.JSON {
	class JSONBuilder : IBuilder {
		List<JSONBranch> branches = new List<JSONBranch>();
		int depth = 0;
		string document;
		public JSONBuilder() {
			branches.Add(new JSONBranch(""));
			depth += 1;
		}
		public void BuildBranch(string name) {
			branches.Add(new JSONBranch(name));
			branches[branches.Count - 2].AddChild(branches[branches.Count - 1]);
			depth += 1;
		}
		public void BuildLeaf(string name, string content) {
			branches[branches.Count - 1].AddChild(new JSONLeaf(name, content));
			//depth += 1;
		}
		public void CloseBranch() {
			if (depth == 1) {
				Console.WriteLine("Cannot close root branch");
			} else {
				document += branches[branches.Count - 1].Print(depth);
				document += "}";
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
