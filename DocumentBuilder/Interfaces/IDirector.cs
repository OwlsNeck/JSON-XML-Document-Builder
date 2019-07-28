using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentBuilder {
	interface IDirector {
		void BuildBranch();
		void BuildLeaf();
		void CloseBranch();
	}
}
