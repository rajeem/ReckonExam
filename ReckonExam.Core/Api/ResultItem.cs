using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReckonExam.Core.Api
{
    public class ResultItem
    {
        public string SubText { get; set; }

        [JsonIgnore]
        public List<int> ResultsIndex { get; set; } = new List<int>();
        
        public string Results
        {
            get
            {
                return ResultsIndex?.Count > 0 ? string.Join(", ", ResultsIndex.Select(x => x.ToString())) : "";
            }
        }
    }
}
