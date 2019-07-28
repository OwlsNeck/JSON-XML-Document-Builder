using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder.JSON {
	class JSONLeaf : IComposite {
		string key, content;
		public JSONLeaf(string key, string content) {
			this.key = key;
			this.content = content;
		}
		public void AddChild(IComposite child) {
			//what?
		}
		public string Print(int depth) {
			string print = "";
			for (int i = 0; i < depth; i++) {
				print += "\t";
			}
			if (print.Length > 0) print.Remove(print.Length - 1);
			print += key + ": " + content + ',';
			return print;
		}
	}
}
