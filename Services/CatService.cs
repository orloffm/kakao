using kakao.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kakao.Services
{
    public class CatService
    {
        public IEnumerable<Cat> Get()
        {
            yield return new Cat() { Name = "Kot", Weight = 8 };
            yield return new Cat() { Name = "Koszka", Weight = 5 };
        }
    }
}
