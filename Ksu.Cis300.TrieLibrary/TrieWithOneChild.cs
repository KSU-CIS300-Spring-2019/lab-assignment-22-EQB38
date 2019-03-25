using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
	public class TrieWithOneChild : ITrie
	{
		public TrieWithOneChild(string str, bool b)
		{
			if (str == "" || str[0] < 'a' || str[0] > 'z')
			{
				throw new ArgumentException();
			}
			b = new bool();

		}
		private bool _hasEmptyString; 
		private ITrie _children;
		private char _label;




		public ITrie Add(string s)
		{
			if (s == "")
			{
				_hasEmptyString = true;
			}
			else if (s[0] == _label)
			{
				Add(s.Substring(0));
			}
			else
			{
				int loc = s[0] - 'a';
				if (_label == null)
				{
					_label = new TrieWithManyChildren(s, _hasEmptyString, _label, );
				}
				_label = _label.Add(s.Substring(1));
			}
			return this;
		}

		public bool Contains(string s)
	{
		if (s == "")
		{
			return _hasEmptyString;
		}
		else
		{
			int loc = s[0] - 'a';
			if (loc < 0 || loc >= _children.Length || _children[loc] == null)
			{
				return false;
			}
			else
			{
				return _children[loc].Contains(s.Substring(1));
			}
		}
	}
	}
}
