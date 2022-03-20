using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReckonExam.Core.Api
{
    public class StringSearchResult
    {
        public string Candidate { get; set; }
        public string Text { get; set; }
        public List<ResultItem> Results { get; set; } = new List<ResultItem>();
    }
}
