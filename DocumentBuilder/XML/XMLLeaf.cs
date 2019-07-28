using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder.XML {
	public class XMLLeaf : IComposite {
		string key, content;
		public XMLLeaf(string key, string content) {
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
			print += "<" + key + ">" + content + "</" + key + ">";
			return print;
		}
	}
}
