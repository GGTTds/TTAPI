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

        [HttpGet("{a}/{b}/{v}")]
        public async Task<ActionResult<double>> CalcActio(double a, double b, string v)
        {
                double Dat = 1;
                if (Count.MaxThr.CurrentCount > 10)
                {
                    switch (v)
                    {
                        case "+":
                            await Count.MaxThr.WaitAsync();
                        Parallel.Invoke(
                                   () =>
                                { Dat = Calc.GetSum(a, b); });
                        Count.MaxThr.Release();
                        return Dat;
                        case "-":
                            await Count.MaxThr.WaitAsync();
                        Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetMinus(a, b); });
                        Count.MaxThr.Release();
                            return Math.Round(Dat, 5);
                        case "*":
                            await Count.MaxThr.WaitAsync();
                        Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetMultiply(a, b); });
                        Count.MaxThr.Release();
                        return Math.Round(Dat, 5);
                        case "d":
                            await Count.MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetDiv(a, b); });
                        Count.MaxThr.Release();
                        return Math.Round(Dat, 5);
                        case "%":
                            await Count.MaxThr.WaitAsync();
                            Parallel.Invoke(
                                  () =>
                                { Dat = Calc.GetOstOtDiv(a, b); });
                        Count.MaxThr.Release();
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
