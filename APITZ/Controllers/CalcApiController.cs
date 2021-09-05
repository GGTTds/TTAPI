using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APITZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcApiController : ControllerBase
    {
        public Class.Calc Calc = new Class.Calc();
        SemaphoreSlim MaxThr = new SemaphoreSlim(8000);

        [HttpGet("{a}/{b}/{v}")]
        public async Task<ActionResult<double>> CalcActio(double a, double b, string v)
        {
                double Dat = 1;
                if (MaxThr.CurrentCount > 10)
                {
                    switch (v)
                    {
                        case "+":
                            await MaxThr.WaitAsync();
                            Parallel.Invoke(
                                   () =>
                                { Dat = Calc.GetSum(a, b); });
                            MaxThr.Release();
                        return Dat;
                        case "-":
                            await MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetMinus(a, b); });
                            MaxThr.Release();
                            return Math.Round(Dat, 5);
                        case "*":
                            await MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetMultiply(a, b); });
                            MaxThr.Release();
                            return Math.Round(Dat, 5);
                        case "d":
                            await MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetDiv(a, b); });
                            MaxThr.Release();
                            return Math.Round(Dat, 5);
                        case "%":
                            await MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetOstOtDiv(a, b); });
                            MaxThr.Release();
                            return Dat;
                        default:
                            return StatusCode(404);
                    }
                }
                else
                {
                    return StatusCode(503);
                }
            

        }
    }
}
