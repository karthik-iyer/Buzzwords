using Buzzwords.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Buzzwords.Services
{
    public class BuzzwordsListService : IBuzzwordsListService
    {
        

        public int GetValue(int startIndex, int endIndex,int index)
        {   
            var value = Enumerable.Range(startIndex, endIndex).ToArray()[index];
            return value;
        }

        
    }
}
