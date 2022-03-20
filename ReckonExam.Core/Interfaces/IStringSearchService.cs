using ReckonExam.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReckonExam.Core.Interfaces
{
    public interface IStringSearchService
    {
        StringSearchResult Search(MainText mainText, SubText subText);
    }
}
