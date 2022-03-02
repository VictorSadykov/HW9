using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class SortHelper
    {
        public const string SORT_IN_ALPHABETICAL_ORDER = "1";
        public const string SORT_IN_REVERSE_ALPHABETICAL_ORDER = "2";

        public delegate string[] SortDelegate(string[] array);
        public event SortDelegate SortStarted;

        public string[] Sort(string[] array)
        {
            return SortStarted?.Invoke(array);
        }
    }
}
