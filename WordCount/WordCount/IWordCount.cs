using System.Threading.Tasks;
using System.Collections.Generic;

namespace WordCount
{
    public interface IWordCount
    {
        IDictionary<string, int> GetTopWords(int limit);
    }
}
