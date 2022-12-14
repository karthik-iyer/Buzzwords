using Buzzwords.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buzzwords.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BuzzwordsController : ControllerBase
    {
        private readonly IBuzzwordsListService _buzzwordsListService;

        public BuzzwordsController(IBuzzwordsListService buzzwordsListService)
        {
            _buzzwordsListService = buzzwordsListService;
        }

        [HttpGet]
        [Route("Listify")]
        public ActionResult<int> GetBuzzword(int startIndex, int endIndex, int index)
        {
            try
            {
                if (startIndex < 0 || endIndex < 0)
                    throw new ArgumentException("Values must be greater than or equal to 0");

                if (startIndex == endIndex)
                    throw new ArgumentException("Start and End Index Cannot be the same");

                if (startIndex > endIndex)
                    throw new ArgumentException("Start Index cannot be greater than end Index");

                var maxCount = endIndex - startIndex + 1;

                if (index > maxCount || index < 0)
                    throw new ArgumentException("Index out of bounds . Must be within range");


                var buzzword = _buzzwordsListService.GetValue(startIndex, endIndex, index);

                return Ok(buzzword);
            }
            catch (Exception ex)
            {

                return BadRequest($"An Error Occured in the request {ex}. StartIndex: {startIndex}, EndIndex: {endIndex}, Index: {index}");
            }
           
        }
    }
}
