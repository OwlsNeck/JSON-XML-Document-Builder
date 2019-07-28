using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder {
	public interface IComposite {
		void AddChild(IComposite child);
		string Print(int depth);
	}
}
