using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITZ
{
    public static class Count
    {
        public static SemaphoreSlim MaxThr = new SemaphoreSlim(8000);
    }
}
