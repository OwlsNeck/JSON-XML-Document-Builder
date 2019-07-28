using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder.JSON {
	class JSONBranch : IComposite {
		public string key;
		List<IComposite> children = new List<IComposite>();
		public JSONBranch(string key) {
			this.key = key;
		}
		public void AddChild(IComposite child) {
			children.Add(child);
		}
		public string Print(int idepth) {
			int depth = idepth;
			string print = "";
			for (int i = 1; i <= depth; i++) {
				print += "\t";
			}
			if(print.Length > 0) print.Remove(print.Length - 1);
			if (key != "") print += key + ": {\n";
			else print += "{\n";
			foreach (IComposite ic in children) {
				print += ic.Print(depth + 1);
				print += "\n";
			}
			for (int i = 1; i <= depth; i++) {
				print += "\t";
			}
			if (print.Length > 0) print.Remove(print.Length - 1);
			if (key != "") print += "},";
			else print += "}";
			return print;
		}
	}
}
