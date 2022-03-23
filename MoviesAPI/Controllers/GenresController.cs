using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController: ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<GenresController> _logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet] // api/genres
        [HttpGet("list")] // api/genres/list
        [HttpGet("/allgenres")] // allgenres
        //[ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            _logger.LogInformation("GET all the genres...");

            return await _repository.GetAllGenres();
        }

        [HttpGet("{Id:int}", Name = "getGenre")] // api/genres/example
        [ServiceFilter(typeof(MyActionFilter))]
        public ActionResult<Genre> Get(int Id, string? param2)
        {
            _logger.LogDebug("GET by Id method executing...");

            var genre = _repository.GetGenreById(Id);

            if (genre == null)
            {
                _logger.LogWarning($"Genre with Id {Id} not found");
                _logger.LogError("this is an error");
                //throw new ApplicationException();
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            _logger.LogDebug("POST by method executing...");
            _repository.AddGenre(genre);

            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id }, genre);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            _logger.LogDebug("PUT by method executing...");
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            _logger.LogDebug("DELETE by method executing...");
            return NoContent();

        }
    }
}
