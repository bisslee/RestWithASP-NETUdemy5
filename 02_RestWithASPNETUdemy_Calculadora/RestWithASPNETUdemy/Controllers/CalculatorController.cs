using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Sum(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber)&& IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstnumber}/{secondnumber}")]
        public IActionResult Subtract(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) - ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiply/{firstnumber}/{secondnumber}")]
        public IActionResult Multiply(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) * ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstnumber}/{secondnumber}")]
        public IActionResult Mean(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = (ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber))/2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("squareroot/{firstnumber}")]
        public IActionResult SquareRoot(string firstnumber)
        {
            if (IsNumeric(firstnumber))
            {
                var squareroot = Math.Sqrt((double)ConvertToDecimal(firstnumber)) ;
                return Ok(squareroot.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("divide/{firstnumber}/{secondnumber}")]
        public IActionResult Divide(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                if (secondnumber=="0")
                {
                    return BadRequest("Divide By 0");
                }
                var sum = ConvertToDecimal(firstnumber) * ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber
                , System.Globalization.NumberStyles.Any
                , System.Globalization.NumberFormatInfo.InvariantInfo
                , out number);
            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalvalue;

            if (decimal.TryParse(strNumber, out decimalvalue))
            {
                return decimalvalue;
            }

            return 0;
        }


    }
}
