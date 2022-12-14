using System;
using System.Collections.Generic;
using System.Text;

namespace Buzzwords.Services.Interface
{
    public interface IBuzzwordsListService
    {
        int GetValue(int startIndex, int endIndex, int index);
    }
}
