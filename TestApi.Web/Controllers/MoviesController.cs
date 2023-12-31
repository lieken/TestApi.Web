using Microsoft.AspNetCore.Mvc;
using TestApi.Web.Core;
using TestApi.Web.Service.Interface;
using TestApi.Web.Service.Model;

namespace TestApi.Web.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _movieService.GetMoviesAsync();
            return Ok(new APIRes
            {
                Header = new APIResHeader
                {
                    MessageCode = MessageBox.MessageCodes.CorrectResult,
                    Message = MessageBox.MessageText.CorrectResult
                },
                Payload = new DataSource { Data = result, Count = result.Count }
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var result = await _movieService.GetMovieAsync(id);

            if (result == null)
            {

                return Ok(new APIRes
                {
                    Header = new APIResHeader
                    {
                        MessageCode = MessageBox.MessageCodes.NoData,
                        Message = MessageBox.MessageCodes.NoData
                    },
                    Payload = new DataSource { }
                });
            }

            return Ok(new APIRes
            {
                Header = new APIResHeader
                {
                    MessageCode = MessageBox.MessageCodes.CorrectResult,
                    Message = MessageBox.MessageText.CorrectResult
                },
                Payload = new DataSource { Data = result, Count = 1 }
            });
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                string errMsg = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Ok(new APIRes
                {
                    Header = new APIResHeader
                    {
                        MessageCode = MessageBox.MessageCodes.ErrorResult,
                        Message = errMsg
                    },
                    Payload = new DataSource { }
                });
            }

            var movieId = await _movieService.CreateMovieAsync(movie);
            return Ok(new APIRes
            {
                Header = new APIResHeader
                {
                    MessageCode = MessageBox.MessageCodes.CorrectResult,
                    Message = MessageBox.MessageText.CorrectResult
                },
                Payload = new DataSource { Data = movieId, Count = movieId }
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieReq movie)
        {
            if (!ModelState.IsValid)
            {
                string errMsg = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Ok(new APIRes
                {
                    Header = new APIResHeader
                    {
                        MessageCode = MessageBox.MessageCodes.ErrorResult,
                        Message = errMsg
                    },
                    Payload = new DataSource { }
                });
            }

            var result = await _movieService.UpdateMovieAsync(id,movie);

            if (result == 0)
            {
                return Ok(new APIRes
                {
                    Header = new APIResHeader
                    {
                        MessageCode = MessageBox.MessageCodes.NoData,
                        Message = MessageBox.MessageText.NoData
                    },
                    Payload = new DataSource { }
                });
            }

            return Ok(new APIRes
            {
                Header = new APIResHeader
                {
                    MessageCode = MessageBox.MessageCodes.CorrectResult,
                    Message = MessageBox.MessageText.CorrectResult
                },
                Payload = new DataSource { Data = result, Count = result }
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if (result == 0)
            {
                return Ok(new APIRes
                {
                    Header = new APIResHeader
                    {
                        MessageCode = MessageBox.MessageCodes.NoData,
                        Message = MessageBox.MessageCodes.NoData
                    },
                    Payload = new DataSource { }
                });
            }


            return Ok(new APIRes
            {
                Header = new APIResHeader
                {
                    MessageCode = MessageBox.MessageCodes.CorrectResult,
                    Message = MessageBox.MessageText.CorrectResult
                },
                Payload = new DataSource { Data = result, Count = result }
            });
        }
    }
}
