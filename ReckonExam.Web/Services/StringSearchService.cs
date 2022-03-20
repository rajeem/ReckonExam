using ReckonExam.Core.Api;
using ReckonExam.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReckonExam.Web.Services
{
    public class StringSearchService : IStringSearchService
    {
        public StringSearchResult Search(MainText mainText, SubText subText)
        {
            var result = new StringSearchResult();

            if (mainText?.Text?.Length > 0 && subText?.SubTexts?.Count > 0)
            {
                result.Text = mainText.Text;

                foreach (string st in subText.SubTexts)
                {
                    var resultItem = new ResultItem();
                    resultItem.SubText = st;

                    for (int i = 0; i < mainText.Text.Length; i++)
                    {
                        bool add = true;
                        if (st.Length > (mainText.Text.Length - i)) break;
                        for (int j = 0; j < st.Length; j++)
                        {
                            if (Char.ToUpperInvariant(mainText.Text[i + j]) != Char.ToUpperInvariant(st[j]))
                            {
                                add = false;
                                break;
                            }
                        }

                        if (add)
                        {
                            resultItem.ResultsIndex.Add(i + 1);
                        }

                    }

                    result.Results.Add(resultItem);
                }
            }

            return result;
        }
    }

}
