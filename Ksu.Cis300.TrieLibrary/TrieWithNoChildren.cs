using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
	public class TrieWithNoChildren : ITrie
	{
		public void _givenString(string str)
		{
			if (str == "" || str[0] < 'a' || str[0] > 'z')
			{
				throw new ArgumentException();
			}
		}
		private bool _hasEmptyString;
		private ITrie[] _children = new ITrie[26];

		public ITrie Add(string s)
		{
			if (s == "")
			{
				_hasEmptyString = true;
			}
			else if (s[0] < 'a' || s[0] > 'z')
			{
				throw new ArgumentException();
			}
			else
			{
				int loc = s[0] - 'a';
				if (_children[loc] == null)
				{
					_children[loc] = new TrieWithOneChild();
				}
				_children[loc] = _children[loc].Add(s.Substring(1));
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
